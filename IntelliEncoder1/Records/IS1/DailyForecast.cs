// This generates daily forecast data for the IntelliStar 1.

using IntelliEncoder1.Core.IS1;
namespace IntelliEncoder1.Records.IS1;

public class IS1Day
{
    public int? MaxTemp = 0;
    public int? MinTemp = 0;
    public int? DayIcon = 3200;
    public int? NightIcon = 3200;
}

public class IS1DailyForecast : IS1DataRecord
{

    // Location
    public string Location = "";

    // Time
    public DateTime Time = DateTime.Now;

    // Days
    public List<IS1Day> Days = [];

    protected override async Task<string> GenerateInternal()
    {

        // All dayparts.
        string dataBody = "";

        // Generate daypart data.

        int dayIdx = 0;

        foreach (IS1Day day in Days)
        {

            int dayNumber = dayIdx + 1;
            string dataName = $"daily_data_{dayNumber}";

            dataBody += $"""
            # Day {dayNumber}  
            keyTime = time.mktime((y,m,d+{dayIdx},0,0,0,wday,jday,-1))
            {dataName} = twc.Data()
            {(day.MaxTemp != null ? $"{dataName}.highTemp = {day.MaxTemp}" : "")}
            {dataName}.lowTemp = {(day.MinTemp != null ? day.MinTemp : "None")}
            {(day.DayIcon != null ? $"{dataName}.daySkyCondition = {day.DayIcon}" : "")}
            {dataName}.eveningSkyCondition = {(day.NightIcon != null ? day.NightIcon : "None")}

            wxdata.setData("{Location}." + str(int(keyTime)), 'dailyFcst', {dataName}, int(keyTime + 86400))

            Log.info("IntelliEncoder 1 - Day {dayNumber} for {Location} set!")

            """;

            dayIdx += 1;
        }

        // Define base string.
        string recordBody = $"""

        # Daily Forecast for {Location}

        # Start message
        Log.info("IntelliEncoder 1 - Sending Daily Forecast data for location {Location}...")

        # Imports
        import time

        # Time 
        y,m,d,H,M,S,wday,jday,dst = time.localtime(time.time())
        # If past 4pm, we need to start with tomorrow
        if H >= 16:
            d = d+1

        # Days

        {dataBody}

        # Finish!
        Log.info("IntelliEncoder 1 - Daily Forecast for {Location} processed!")
        """;

        return recordBody;
    }
}