using System.Data.SQLite;
using System.Text;
using System.Text.RegularExpressions;
using Dapper;
using IntelliEncoder1.Inputs.TWC;
using IntelliEncoder1.Schema.IntelliEncoder;
using Renci.SshNet;

namespace IntelliEncoder1.Core.IS1;

public partial class IS1StarConfig
{
    public string MSOId = "";
    public string HeadendID = "";
    public List<LFRecordLocation> Locations = [];
    public string[] Airports = [];
    public string[] Maps = [];
    public string[] MapsData = [];
    public string[] PollenStns = [];
    public string[] ClimateStns = [];
    public string[] AirQualityStns = [];
    public string[] TideStns = [];
    public string[] MetroIds = [];
    public string[] IndexIds = [];
    public string[] Skis = [];
    public string[] Counties = [];
    public string[] Areas = [];
    public List<LFRecordLocation> ObsStns = [];
    private Config Config;

    // Regex for interest lists
    [GeneratedRegex(
        """
        wxdata\.setInterestList\('(\w+)',\s*'[^']*',\s*\[([^\]]*)\]\)
        """
        )
    ]
    private static partial Regex InterestListPattern();

    // Regex for MSO codes
    [GeneratedRegex(
        """
        dsm\.set\('msoCode','(\w+)', \w+\)
        """
        )
    ]
    private static partial Regex MSOCode();

    // Regex for headend ID
    [GeneratedRegex(
        """
        dsm\.set\('headendId','(\w+)', \w+\)
        """
        )
    ]
    private static partial Regex HeadendCode();

    // Regex for Locations IDs from MistWx-i2ME location IDs stored as coops/teccis.
    [GeneratedRegex(
        """
        ([0-9]{1,2})([a-zA-Z]{2})([a-zA-Z0-9]{8})
        """
        )
    ]
    private static partial Regex I2MELID();

    public IS1StarConfig(SftpClient sftpClient, Config config)
    {
        // Set config.
        Config = config;

        // Download the config.
        MemoryStream stream = new();
        sftpClient.DownloadFile("/home/dgadmin/config/current/config.py", stream);

        // Read the config.
        string configText = Encoding.UTF8.GetString(stream.ToArray());

        // Parse the config.
        string[][] checkLoc = ParseConfig(configText);

        Console.WriteLine($"Parsing config for IntelliStar 1 with headend ID {HeadendID}");
        Task.WaitAll(LFRecordCheck(checkLoc));
    }

    // Checks if there's a valid LFRecord entry for the location.
    // If not, then it generates one.
    private async Task LFRecordCheck(string[][] checkLoc)
    {
        string lfrPath = Path.Combine(AppContext.BaseDirectory, "Custom", "LFRecord.db");
        // Check if all locations have a LFRecord.
        SQLiteConnection sqlite = new($"Data Source={lfrPath}", true);
        sqlite.Open();

        // Flag if there's custom location
        bool custom = false;

        // Check if a location ID was added.
        Dictionary<string, LFRecordLocation> addedLIDs = [];

        // Check each location.
        foreach (string coop in checkLoc[0])
        {
            Console.WriteLine($"Checking COOP {coop}...");
            var cmd = sqlite.CreateCommand();
            cmd.CommandText = $"SELECT count(*) FROM LFRecord WHERE coopId = '{coop.Trim()}' LIMIT 1";
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count == 0)
            {
                custom = true;

                if (Config.config.Inputs.TWC.Enabled)
                {
                    Console.WriteLine($"COOP {coop} doesn't exist in LFRecord, generating entry...");
                    // Attempt to parse this as a location added from a IntelliEncoder 1/MistWX-i2ME LFRecord.
                    Match match = I2MELID().Match(coop);
                    if (!match.Success)
                    {
                        Console.WriteLine($"Coop {coop} cannot be parsed. This will mean that some locations on your IntelliStar 1 will be unavailable.");
                        continue;
                    }

                    // Location ID variables.
                    int type = Int32.Parse(match.Groups[1].Value);
                    string country = match.Groups[2].Value;
                    string code = match.Groups[3].Value;

                    // Location ID as string
                    string lid = $"{type}_{country}_{code}";

                    // Check if ID isn't already added
                    if (addedLIDs.ContainsKey(lid))
                    {
                        Console.WriteLine($"Coop {lid} already exists in LFRecord. Skipping...");
                        continue;
                    }

                    // Add the location to LFRecord.
                    LFRecordLocation location = await AddNewLocation(sqlite, type, country, code);
                    Locations.Add(location);

                    // if not add it to addedLIDs
                    addedLIDs[lid] = location;
                }

            }
            else
            {
                LFRecordLocation location = sqlite.QuerySingle<LFRecordLocation>($"SELECT * FROM LFRecord WHERE coopId = '{coop.Trim()}' LIMIT 1");
                Locations.Add(location);
                // if not add it to addedLIDs
                addedLIDs[$"{location.locType}_{location.siteId}_{location.locId}"] = location;
            }
        }

        // Check each observation station.
        foreach (string obsstnuf in checkLoc[1])
        {
            string obsstn = obsstnuf.Trim();
            Console.WriteLine($"Checking observation station {obsstn}...");
            var cmd = sqlite.CreateCommand();
            cmd.CommandText = $"SELECT count(*) FROM LFRecord WHERE obsStn = '{obsstn.Trim()}' LIMIT 1";
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count == 0)
            {
                custom = true;

                if (Config.config.Inputs.TWC.Enabled)
                {
                    Console.WriteLine($"Observation station {obsstn} doesn't exist in LFRecord, generating entry...");
                    // Attempt to parse this as a location added from a IntelliEncoder 1/MistWX-i2ME LFRecord.
                    Match match = I2MELID().Match(obsstn);
                    if (!match.Success)
                    {
                        Console.WriteLine($"Tecci {obsstn} cannot be parsed. This will mean that some locations on your IntelliStar 1 will be unavailable.");
                        continue;
                    }

                    // Location ID variables.
                    int type = Int32.Parse(match.Groups[1].Value);
                    string country = match.Groups[2].Value;
                    string code = match.Groups[3].Value;

                    // Location ID as string
                    string lid = $"{type}_{country}_{code}";

                    // Check if ID isn't already added
                    if (addedLIDs.ContainsKey(lid))
                    {
                        Console.WriteLine($"ObsStn {lid} already exists in LFRecord. Skipping...");
                        addedLIDs[lid].obsStn = obsstn.Trim();
                        ObsStns.Add(addedLIDs[lid]);
                        continue;
                    }

                    try
                    {
                        // Add the location to LFRecord.
                        LFRecordLocation location = await AddNewLocation(sqlite, type, country, code);
                        ObsStns.Add(location);

                        // if not add it to addedLIDs
                        addedLIDs[lid] = location;
                    }
                    catch
                    {
                        Console.WriteLine($"Could not grab location ID for {lid}.");
                    }

                }
            }
            else
            {
                LFRecordLocation location = sqlite.QuerySingle<LFRecordLocation>($"SELECT * FROM LFRecord WHERE obsStn = '{obsstn.Trim()}' LIMIT 1");
                ObsStns.Add(location);
            }
        }

        // Custom location warning
        if (!Config.config.Inputs.TWC.Enabled)
        {
            if (custom)
            {
                Console.WriteLine("This config has custom locations that aren't supported by the current LFRecord!");
                Console.WriteLine("To support such locations, the TWC data input must be enabled, as we need to grab location data for these locations! (If the location comes from a IntelliEncoder 1/MistWX-i2ME LFRecord.)");
                Console.WriteLine("Since your config has the TWC data input disabled, custom location data will not be automatically grabbed, and thus, skipped.");
                Console.WriteLine("If you cannot use the TWC data input, a workaround is to open the LFRecord with a SQLite database editor and add the location yourself.");
            }
        }
    }

    private async Task<LFRecordLocation> AddNewLocation(SQLiteConnection sqlite, int type, string country, string code)
    {
        Console.WriteLine($"Grabbing location {type}_{country}_{code} from TWC...");
        InputsTWCLFRecord LFRecord = new(Config);
        LFRecordLocation lflr = await LFRecord.GrabLocation(type, country, code);

        Console.WriteLine($"Writing location {lflr.cityNm} ({lflr.locType}_{lflr.siteId}_{lflr.locId}) to the LFRecord...");

        // Inserting to current LFRecord.
        SQLiteCommand insertSQL = sqlite.CreateCommand();
        insertSQL.CommandText = "INSERT INTO LFRecord (locId, locType, cityNm, stCd, prsntNm, cntryCd, coopId, lat, long, obsStn, secObsStn, tertObsStn, gmtDiff, regSat, cntyNm, zoneId, zoneNm, cntyFips, active, dySTInd, dmaCd, zip2locId, elev, cliStn, tmZnNm, tmZnAbbr, dySTAct, clsRad, metRad, ultRad, ssRad, siteId, idxId, primTecci, secTecci, tertTecci, arptId, mrnZoneId, pllnId, skiId, tideId, epaId, tPrsntNm, wrlsPrsntNm, wmoId) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

        insertSQL.Parameters.AddWithValue("locId", lflr.locId);
        insertSQL.Parameters.AddWithValue("locType", lflr.locType);
        insertSQL.Parameters.AddWithValue("cityNm", lflr.cityNm);
        insertSQL.Parameters.AddWithValue("stCd", lflr.stCd);
        insertSQL.Parameters.AddWithValue("prsntNm", lflr.prsntNm);
        insertSQL.Parameters.AddWithValue("cntryCd", lflr.cntryCd);
        insertSQL.Parameters.AddWithValue("coopId", lflr.coopId);
        insertSQL.Parameters.AddWithValue("cntryCd", lflr.cntryCd);
        insertSQL.Parameters.AddWithValue("coopId", lflr.coopId);
        insertSQL.Parameters.AddWithValue("lat", lflr.lat);
        insertSQL.Parameters.AddWithValue("long", lflr.@long);
        insertSQL.Parameters.AddWithValue("obsStn", lflr.obsStn);
        insertSQL.Parameters.AddWithValue("secObsStn", lflr.secObsStn);
        insertSQL.Parameters.AddWithValue("tertObsStn", lflr.tertObsStn);
        insertSQL.Parameters.AddWithValue("gmtDiff", lflr.gmtDiff);
        insertSQL.Parameters.AddWithValue("regSat", lflr.regSat);
        insertSQL.Parameters.AddWithValue("coopId", lflr.coopId);
        insertSQL.Parameters.AddWithValue("cntyNm", lflr.cntyNm);
        insertSQL.Parameters.AddWithValue("zoneId", lflr.zoneId);
        insertSQL.Parameters.AddWithValue("zoneNm", lflr.cntyNm);
        insertSQL.Parameters.AddWithValue("cntyFips", lflr.cntyFips);
        insertSQL.Parameters.AddWithValue("active", lflr.active);
        insertSQL.Parameters.AddWithValue("dySTInd", lflr.dySTInd);
        insertSQL.Parameters.AddWithValue("dmaCd", lflr.dmaCd);
        insertSQL.Parameters.AddWithValue("zip2locId", lflr.zip2locId);
        insertSQL.Parameters.AddWithValue("elev", lflr.elev);
        insertSQL.Parameters.AddWithValue("cliStn", lflr.cliStn);
        insertSQL.Parameters.AddWithValue("tmZnNm", lflr.tmZnNm);
        insertSQL.Parameters.AddWithValue("tmZnAbbr", lflr.tmZnAbbr);
        insertSQL.Parameters.AddWithValue("dySTAct", lflr.dySTAct);
        insertSQL.Parameters.AddWithValue("clsRad", lflr.clsRad);
        insertSQL.Parameters.AddWithValue("metRad", lflr.metRad);
        insertSQL.Parameters.AddWithValue("ultRad", lflr.ultRad);
        insertSQL.Parameters.AddWithValue("ssRad", lflr.ssRad);
        insertSQL.Parameters.AddWithValue("siteId", lflr.siteId);
        insertSQL.Parameters.AddWithValue("idxId", lflr.idxId);
        insertSQL.Parameters.AddWithValue("primTecci", lflr.primTecci);
        insertSQL.Parameters.AddWithValue("secTecci", lflr.secTecci);
        insertSQL.Parameters.AddWithValue("tertTecci", lflr.tertTecci);
        insertSQL.Parameters.AddWithValue("arptId", lflr.arptId);
        insertSQL.Parameters.AddWithValue("mrnZoneId", lflr.mrnZoneId);
        insertSQL.Parameters.AddWithValue("pllnId", lflr.pllnId);
        insertSQL.Parameters.AddWithValue("skiId", lflr.skiId);
        insertSQL.Parameters.AddWithValue("tideId", lflr.tideId);
        insertSQL.Parameters.AddWithValue("epaId", lflr.epaId);
        insertSQL.Parameters.AddWithValue("tPrsntNm", lflr.tPrsntNm);
        insertSQL.Parameters.AddWithValue("wrlsPrsntNm", lflr.wrlsPrsntNm);
        insertSQL.Parameters.AddWithValue("wmoId", lflr.wmoId);

        try
        {
            insertSQL.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        Console.WriteLine($"Wrote location {lflr.cityNm} ({lflr.locType}_{lflr.siteId}_{lflr.locId}) to the LFRecord!");

        // Return with LFRecordLocation.
        return lflr;
    }

    // Parses the config via regex.
    private string[][] ParseConfig(string config)
    {

        string[] locations = [];
        string[] obsstns = [];

        MatchCollection matches = InterestListPattern().Matches(config);

        foreach (Match match in matches)
        {
            if (match.Groups.Count == 3)
            {
                string type = match.Groups[1].Value;
                string[] data = match.Groups[2].Value.Replace("'", "").Split(",");
                if (type == "mapData")
                {
                    Maps = data;
                }
                else if (type == "imageData")
                {
                    MapsData = data;
                }
                else if (type == "airportId")
                {
                    Airports = data;
                }
                else if (type == "coopId")
                {
                    locations = data;
                }
                else if (type == "obsStation")
                {
                    obsstns = data;
                }
                else if (type == "indexId")
                {
                    IndexIds = data;
                }
                else if (type == "pollenId")
                {
                    PollenStns = data;
                }
                else if (type == "climId")
                {
                    ClimateStns = data;
                }
                else if (type == "metroId")
                {
                    MetroIds = data;
                }
                else if (type == "zone")
                {
                    Areas = data;
                }
                else if (type == "aq")
                {
                    AirQualityStns = data;
                }
                else if (type == "tideStation")
                {
                    TideStns = data;
                }
                else if (type == "skiId")
                {
                    Skis = data;
                }
                else if (type == "county")
                {
                    Counties = data;
                }
            }
        }

        Match msoCodeMatch = MSOCode().Match(config);
        if (msoCodeMatch.Success)
        {
            if (msoCodeMatch.Groups.Count >= 1)
            {
                MSOId = msoCodeMatch.Groups[1].Value;
            }
        }

        Match headendIDMatch = HeadendCode().Match(config);
        if (headendIDMatch.Success)
        {
            if (headendIDMatch.Groups.Count >= 1)
            {
                HeadendID = headendIDMatch.Groups[1].Value;
            }
        }

        return [locations, obsstns];
    }
}