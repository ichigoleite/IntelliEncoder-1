// This generates daypart forecast data for the IntelliStar 1.

using System.Text.RegularExpressions;

namespace IntelliEncoder1.Schema.TWC;

public class Daypart
{
    public string Name = "None";
    public string? Phrase;
    public int Icon = 3200;
    public int Temp = 0;
    public bool IsNight = false;
}

public class DaypartForecast : DataRecord
{
    // Number of dayparts.
    public const int DaypartNum = 4;

    // Location
    public string Location = "";

    // Dayparts
    public List<Daypart> Dayparts = [];

    protected override async Task<string> GenerateInternal()
    {

        // All dayparts.
        string dataBody = "";

        // Generate daypart data.

        int daypartCount = 1;
        int daypartIdx = 0;
        bool isNight;

        foreach (Daypart daypart in Dayparts)
        {
            if (daypart.Phrase == null)
            {
                continue;
            }

            // Limit to 8 dayparts
            if (daypartIdx > 8)
            {
                break;
            }

            isNight = daypart.IsNight;

            string varName = $"{daypartCount}_{(daypart.IsNight ? 2 : 1)}";
            string dataName = $"daypart_data_{varName}";
            string validTime = $"int(keyTime + {daypartIdx * 12 * 3600})";
            string expiration = $"int({validTime} + 43200)";

            dataBody += $"""
            # Daypart {daypartCount} ({(isNight ? "Night" : "Day")})
            forecastTime_{varName} = {validTime}
            {dataName} = twc.Data()
            {dataName}.phrase = "{daypart.Phrase}"
            {dataName}.skyCondition = {daypart.Icon}
            {dataName}.temp = {daypart.Temp}
            {dataName}.daypartName = {daypart.Name}

            wxdata.setDaypartData(
                loc="{Location}",
                type="textFcst",
                data={dataName},
                validTime=forecastTime_{varName},
                numDayparts={DaypartNum},
                expiration={expiration}
            )

            Log.info("IntelliEncoder 1 - Daypart {daypartCount} ({(isNight ? "Night" : "Day")}) for {Location} set!")

            """;

            if (isNight)
            {
                daypartCount += 1;
            }

            daypartIdx += 1;
        }

        // Define base string.
        string recordBody = $"""

        # Daypart Forecast for {Location}

        # Imports
        import time

        # Start message
        Log.info("IntelliEncoder 1 - Sending Daypart Forecast data for location {Location}...")

        # Time
        Y, M, D, h, m, s, wd, jd, dst = time.localtime(time.time())
        dOffset = 0  # Always use offset of 0

        keyTime = time.mktime((Y, M, D + dOffset, 5, 0, 0, 0, 0, -1))

        times = [
            keyTime,
            keyTime + (12 * 3600),
            keyTime + (24 * 3600),
            keyTime + (36 * 3600)
        ]

        # Number of dayparts
        numDayparts = {DaypartNum}

        # Dayparts

        {dataBody}

        # Finish!
        Log.info("IntelliEncoder 1 - Daypart Forecast for {Location} processed!")
        """;

        return recordBody;
    }
}