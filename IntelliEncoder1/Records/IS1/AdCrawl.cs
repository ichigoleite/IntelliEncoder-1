// This generates ad crawl data for the IntelliStar 1.

using IntelliEncoder1.Core.IS1;
namespace IntelliEncoder1.Records.IS1;

public class IS1Crawl
{
    // MSO Code
    public string MSOCode = "00000";
    // Text
    public string Text = "Test ad crawl";
    public int Start = 0;
    public int End = 2000000000;
}

public class IS1AdCrawl : IS1DataRecord
{

    public IS1Crawl[] Crawls = [];

    protected override async Task<string> GenerateInternal()
    {

        // All dayparts.
        string dataBody = "";

        // Generate crawl data.

        foreach (IS1Crawl crawl in Crawls)
        {
            dataBody += $"({crawl.Start},{crawl.End},[(0, 23)],'{crawl.MSOCode}','{crawl.Text}'),";
        }

        // Define base string.
        string recordBody = $"""

        # Ad Crawl

        # Start message
        Log.info("IntelliEncoder 1 - Sending Ad Crawl data...")

        crawl_data = twc.Data()
        crawl_data.crawls = [
            {dataBody}
        ]
        dsm.set('Config.1.Ldl_LASCrawl', d, 0)
        dsm.set('Config.0.LASCrawl', d, 0)
        ds.commit()

        # Finish!
        Log.info("IntelliEncoder 1 - Ad Crawls processed!")
        """;

        return recordBody;
    }
}