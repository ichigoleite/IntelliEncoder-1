// This generates headline data for the IntelliStar 1.

using IntelliEncoder1.Core;
namespace IntelliEncoder1.Records;

public class Alert
{
    public string Text = "Nano Shinonome has triggered a massive explosion in Tokisadame.";
    public string Phenomena = "TCD";
    public string Significance = "W";
    public DateTime Expiration = DateTime.UtcNow.AddHours(4);
}

public class Headline : DataRecord
{

    // Area
    public string Area = "";

    // Alerts
    public List<Alert> Alerts = [];

    protected override async Task<string> GenerateInternal()
    {

        // All dayparts.
        string dataBody = "";

        // Generate daypart data.

        int alertIdx = 0;

        foreach (Alert alert in Alerts)
        {
            string dataName = $"alert_{Area}_{alertIdx}";

            dataBody += $"""
            # Alert {alertIdx + 1} for area {Area}

            areaList = wxdata.getUGCInterestList('{Area}', 'zone')

            for area in areaList:
                {dataName} = twc.Data()
                {dataName}.headline = "{alert.Text}"
                {dataName}.phenSig = "{alert.Phenomena}_{alert.Significance}"
                {dataName}.expiration = {((DateTimeOffset)alert.Expiration).ToUnixTimeSeconds()}

                wxdata.setHeadline(area, {dataName}, {((DateTimeOffset)alert.Expiration).ToUnixTimeSeconds()})

            Log.info("IntelliEncoder 1 - Alert {alertIdx + 1} for area {Area} sent.")

            """;

            alertIdx += 1;
        }

        // Define base string.
        string recordBody = $"""

        # Headline for {Area}

        # Start message
        Log.info("IntelliEncoder 1 - Sending Headline data for area {Area}...")

        # Headline

        {dataBody}

        # Finish!
        Log.info("IntelliEncoder 1 - Headline for {Area} processed!")
        """;

        return recordBody;
    }
}