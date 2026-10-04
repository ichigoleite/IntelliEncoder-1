using System.Net.Http.Json;
using IntelliEncoder1.Core;
using IntelliEncoder1.Core.IS1;
using IntelliEncoder1.Records.IS1;
using IntelliEncoder1.Schema.ichigoleite;
namespace IntelliEncoder1.Inputs;

public class InputsAdCrawlMain
{
    Logger Logger;
    Config Config;

    public InputsAdCrawlMain(Config config)
    {
        // Set config.
        Config = config;

        // Make logger.
        Logger = new("Inputs - Data Retriever (Main) - Ad Crawl", config);
    }

    public async Task<IS1DataRecord[]> RetrieveDataIS1(IS1StarConfig starConfig)
    {


        Logger.Info($"Starting ad crawl retrieval for IntelliStar 1 {starConfig.HeadendID}...");
        List<IS1DataRecord> dataRecords = [];

        // Grab all observations
        try
        {
            ILAdCrawl[]? crawldata = await Config.client.GetFromJsonAsync<ILAdCrawl[]>(Config.config.Inputs.AdCrawl.URL);

            List<IS1Crawl> crawls = [];
            if (crawldata != null)
            {
                foreach (ILAdCrawl crawl in crawldata)
                {
                    crawls.Add(new()
                    {
                        Text = crawl.text,
                        Start = crawl.start,
                        End = crawl.end
                    });
                }

                IS1AdCrawl adCrawl = new()
                {
                    Crawls = [.. crawls]
                };
                dataRecords.Add(adCrawl);
            }
            else
            {

            }
        }
        catch (Exception e)
        {
            Logger.Error("Could not grab ad crawls.");
            Logger.Error(e.ToString());
        }

        Logger.Info($"Grabbed ad crawl for IntelliStar 1 {starConfig.HeadendID}...");

        return [.. dataRecords];
    }
}