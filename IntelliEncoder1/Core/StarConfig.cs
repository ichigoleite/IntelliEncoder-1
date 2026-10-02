using System.Text;
using System.Text.RegularExpressions;
using Renci.SshNet;

namespace IntelliEncoder1.Core;

public partial class StarConfig
{
    public string MSOId = "";
    public string[] Locations = [];
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
    public string[] ObsStns = [];

    // Regex for interest lists
    [GeneratedRegex(
        """
        wxdata\.setInterestList\('(\w+)',\s*'[^']*',\s*\[([^\]]*)\]\)
        """,
        RegexOptions.IgnoreCase
        )
    ]
    private static partial Regex InterestListPattern();

    // Regex for MSO codes
    [GeneratedRegex(
        """
        dsm\.set\('msoCode','(\w+)', \w+\)
        """,
        RegexOptions.IgnoreCase
        )
    ]
    private static partial Regex MSOCode();

    public StarConfig(SftpClient sftpClient)
    {
        // Download the config.
        MemoryStream stream = new();
        sftpClient.DownloadFile("/home/dgadmin/config/current/config.py", stream);

        // Read the config.
        string config = Encoding.UTF8.GetString(stream.ToArray());

        // Parse the config.
        Match matches = InterestListPattern().Match(config);
        for (var i = 0; i >= matches.Length; i++)
        {
            if (matches.Groups.Count == 2)
            {
                string type = matches.Groups[0].Value;
                string[] data = matches.Groups[1].Value.Replace("'", "").Split(",");
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
                    Locations = data;
                }
                else if (type == "obsStation")
                {
                    ObsStns = data;
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
            matches = matches.NextMatch();
        }

        Match msoCodeMatch = MSOCode().Match(config);
        if (msoCodeMatch.Success)
        {
            if (msoCodeMatch.Groups.Count >= 1)
            {
                MSOId = msoCodeMatch.Groups[0].Value;
            }
        }
    }
}