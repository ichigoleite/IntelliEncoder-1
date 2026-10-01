// This generates hourly forecast data for the IntelliStar 1.

namespace IntelliEncoder1.Schema.TWC;

public class Hour
{
    public DateTime Time = DateTime.UtcNow.Date.AddHours(DateTime.UtcNow.Hour);
    public int MaxTemp = 0;
    public int MinTemp = 0;
    public int Temperature = 0;
    public int Condition = 3200;
    public int WindSpeed = 0;
    public int WindDir = 0;
    public int PrecipitationChance = 0;
}

public class HourlyForecast : DataRecord
{

    // Location
    public string Location = "";

    // Time
    public DateTime Time = DateTime.Now;

    // Hours
    public List<Hour> Hours = [];

    protected override async Task<string> GenerateInternal()
    {

        // All dayparts.
        string dataBody = "";

        // Generate daypart data.

        int hourIdx = 0;

        foreach (Hour hour in Hours)
        {

            int hourNumber = hourIdx + 1;
            string dataName = $"hourly_data_{hourNumber}";

            dataBody += $"""
            # Hour {hourNumber}  
            forecastTime_{hourNumber}_{Location} = {((DateTimeOffset)hour.Time).ToUnixTimeSeconds()}
            {dataName} = twc.Data()
            {dataName}.minTemp = {hour.MinTemp}
            {dataName}.maxTemp = {hour.MaxTemp}
            {dataName}.windSpeed = {hour.WindSpeed}
            {dataName}.windDir = {hour.WindDir}
            {dataName}.skyCondition = {hour.Condition}
            {dataName}.pop = {hour.PrecipitationChance}

            wxdata.setData("{Location}." + str(int(forecastTime_{hourNumber}_{Location})), 'hourlyFcst', {dataName}, int(forecastTime_{hourNumber}_{Location} + 3600))

            Log.info("IntelliEncoder 1 - Hour {hourNumber} for {Location} set!")

            """;

            hourIdx += 1;
        }

        // Define base string.
        string recordBody = $"""

        # Daily Forecast for {Location}

        # Start message
        Log.info("IntelliEncoder 1 - Sending Hourly Forecast data for location {Location}...")

        # Days

        {dataBody}

        # Finish!
        Log.info("IntelliEncoder 1 - Hourly Forecast for {Location} processed!")
        """;

        return recordBody;
    }
}