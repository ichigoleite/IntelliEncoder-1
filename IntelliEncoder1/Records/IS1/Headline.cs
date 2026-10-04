// This generates headline data for the IntelliStar 1.

using IntelliEncoder1.Core.IS1;
namespace IntelliEncoder1.Records.IS1;

public class IS1Alert
{
    public string Text = "Nano Shinonome has triggered a massive explosion in Tokisadame.";
    public string Phenomena = "TCD";
    public string Significance = "W";
    public string PIL = "SVS";
    public string PILExt = "001";
    public DateTime Expiration = DateTime.UtcNow.AddHours(4);
}

public class IS1Headline : IS1DataRecord
{

    // Area
    public string? Area;
    // County
    public string? County;

    // Alerts
    public List<IS1Alert> Alerts = [];

    protected override async Task<string> GenerateInternal()
    {

        // All dayparts.
        string dataBody = "";

        // Generate daypart data.

        int alertIdx = 0;

        foreach (IS1Alert alert in Alerts)
        {
            if (Area != null)
            {
                string dataName = $"alert_{Area}_{alertIdx}";

                dataBody += $"""
                # Alert {alertIdx + 1} for area {Area}

                areaList = wxdata.getUGCInterestList('{Area}', 'zone')

                for area in areaList:
                    {dataName} = twc.Data()
                    {dataName}.headline = "{alert.Text.Replace("\"", "\\\"")}"
                    {dataName}.phenSig = "{alert.Phenomena}_{alert.Significance}"
                    {dataName}.expiration = {((DateTimeOffset)alert.Expiration).ToUnixTimeSeconds()}

                    wxdata.setHeadline(area, {dataName}, {((DateTimeOffset)alert.Expiration).ToUnixTimeSeconds()})

                Log.info("IntelliEncoder 1 - Alert {alertIdx + 1} for area {Area} sent.")

                """;
            }

            if (County != null)
            {
                string dataName = $"alert_{County}_{alertIdx}";

                dataBody += $"""
                # Alert {alertIdx + 1} for county {County}

                counties = wxdata.getBulletinInterestList("{County}")

                for county in counties:
                    {dataName} = twc.Data()
                    {dataName}.text = "{alert.Text.Replace("\"", "\\\"")}"
                    {dataName}.pil = "{alert.PIL}"
                    {dataName}.pilExt = "{alert.PILExt}"
                    {dataName}.expiration = {((DateTimeOffset)alert.Expiration).ToUnixTimeSeconds()}
                    {dataName}.dispExpiration = {((DateTimeOffset)alert.Expiration).ToUnixTimeSeconds()}

                    wxdata.setBulletin(county, {dataName}, {((DateTimeOffset)alert.Expiration).ToUnixTimeSeconds()})

                Log.info("IntelliEncoder 1 - Alert {alertIdx + 1} for county {County} sent.")

                """;
            }


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