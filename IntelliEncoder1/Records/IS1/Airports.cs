// This generates daily forecast data for the IntelliStar 1.

using IntelliEncoder1.Core.IS1;
using System.Globalization;
namespace IntelliEncoder1.Records.IS1;

public class IS1DelayInfo
{
    public int Duration = 0;
    public int Trend = 0;
    public string Reason = "";
}

public class IS1Delay
{
    public string Airport = "";
    public IS1DelayInfo Arrival = new();
    public IS1DelayInfo Departure = new();
}

public class IS1AirportDelays : IS1DataRecord
{
    // Time
    public DateTime Time = DateTime.Now;

    // Days
    public List<IS1Delay> Delays = [];

    protected override async Task<string> GenerateInternal()
    {

        // All dayparts.
        string dataBody = "";

        // Generate delay data.

        foreach (IS1Delay delay in Delays)
        {
            string dataName = $"airport_data_{delay.Airport.Replace(" ", "")}";

            dataBody += $"""
            # Airport {delay.Airport.Replace(" ", "")}
            
            {dataName}.arrivalDelay = {(int)(delay.Arrival.Duration / 60)}
            {dataName}.arrivalDelayReason = "{new CultureInfo("en-US", false).TextInfo.ToTitleCase(delay.Arrival.Reason).Replace(" ", "")}"
            {dataName}.arrivalDelayTrend = {delay.Arrival.Trend}

            {dataName}.departureDelay = {(int)(delay.Departure.Duration / 60)}
            {dataName}.departureDelayReason = "{new CultureInfo("en-US", false).TextInfo.ToTitleCase(delay.Departure.Reason).Replace(" ", "")}"
            {dataName}.departureDelayTrend = {delay.Departure.Trend}

            wxdata.setData("{delay.Airport.Replace(" ", "")}", 'airportDelays', {dataName}, {((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds() + 3600})

            Log.info("IntelliEncoder 1 - Airport {delay.Airport.Replace(" ", "")} set!")

            """;
        }

        // Define base string.
        string recordBody = $"""

        # Airport Delays

        # Start message
        Log.info("IntelliEncoder 1 - Sending Airport Delay data...")

        # Airport Delays

        {dataBody}

        # Finish!
        Log.info("IntelliEncoder 1 - Airport Delays processed!")
        """;

        return recordBody;
    }
}