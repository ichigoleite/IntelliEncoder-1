// This generates daypart forecast data for the IntelliStar 1.

namespace IntelliEncoder1.Schema.TWC;

public class Day
{
    public int? MaxTemp = 0;
    public int? MinTemp = 0;
    public int? DayIcon = 3200;
    public int? NightIcon = 3200;
}

public class DailyForecast : DataRecord
{

    // Location
    public string Location = "";

    // Time
    public DateTime Time = DateTime.Now;

    // Days
    public List<Day> Days = [];

    protected override async Task<string> GenerateInternal()
    {

        // All dayparts.
        string dataBody = "";

        // Generate daypart data.

        // Get keyTime
        DateTime midnightLocal = Time.Date;

        long keyTime = ((DateTimeOffset)midnightLocal).ToUnixTimeSeconds();

        int dayIdx = 0;

        foreach (Day day in Days)
        {

            int dayNumber = dayIdx + 1;
            string dataName = $"daily_data_{dayNumber}";

            dataBody += $"""
            # Day {dayNumber}   
            {dataName} = twc.Data()
            {(day.MaxTemp != null ? $"{dataName}.highTemp = {day.MaxTemp}" : "")}
            {dataName}.lowTemp = {(day.MinTemp != null ? day.MinTemp : "None")}
            {(day.DayIcon != null ? $"{dataName}.daySkyCondition = {day.DayIcon}" : "")}
            {dataName}.eveningSkyCondition = {(day.NightIcon != null ? day.NightIcon : "None")}

            wxdata.setData("{Location}.{keyTime + (dayIdx * 86400)}", 'dailyFcst', {dataName}, {keyTime + (dayIdx * 86400) + 86400})

            Log.info("IntelliEncoder 1 - Day {dayNumber} for {Location} set!")

            """;

            dayIdx += 1;
        }

        // Define base string.
        string recordBody = $"""

        # Daily Forecast for {Location}

        # Start message
        Log.info("IntelliEncoder 1 - Sending Daily Forecast data for location {Location}...")

        # Days

        {dataBody}

        # Finish!
        Log.info("IntelliEncoder 1 - Daily Forecast for {Location} processed!")
        """;

        return recordBody;
    }
}