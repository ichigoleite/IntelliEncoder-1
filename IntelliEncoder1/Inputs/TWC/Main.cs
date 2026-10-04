using System.Text;
using System.Text.Unicode;
using IntelliEncoder1.Core;
using IntelliEncoder1.Core.IS1;
using IntelliEncoder1.Inputs.TWC.Data.IS1;
using IntelliEncoder1.Records.IS1;
using IntelliEncoder1.Schema.IntelliEncoder;
using Renci.SshNet;
namespace IntelliEncoder1.Inputs;

public class InputsTWCMain
{
    Logger Logger;
    Config Config;

    public InputsTWCMain(Config config)
    {
        // Set config.
        Config = config;

        // Make logger.
        Logger = new("Inputs - Data Retriever (Main) - TWC", config);
    }

    public async Task<IS1DataRecord[]> RetrieveDataIS1(IS1StarConfig starConfig)
    {
        Logger.Info($"Starting data retrieval for IntelliStar 1 {starConfig.HeadendID}...");
        InputsTWCDataIS1 dataClient = new(Config, Logger);
        List<IS1DataRecord> dataRecords = [];

        // Grab all observations
        foreach (LFRecordLocation location in starConfig.ObsStns)
        {
            Logger.Info($"Grabbing Current Conditions for IntelliStar 1 {starConfig.HeadendID}...");
            IS1CurrentConditions? data = await dataClient.CurrentConditions(location);
            if (data != null)
            {
                dataRecords.Add(data);
            }
        }

        // Grab all forecast data
        foreach (LFRecordLocation location in starConfig.ObsStns)
        {
            Logger.Info($"Grabbing Hourly Forecast for IntelliStar 1 {starConfig.HeadendID}...");
            IS1HourlyForecast? hourly = await dataClient.HourlyForecast(location);
            if (hourly != null)
            {
                dataRecords.Add(hourly);
            }

            Logger.Info($"Grabbing Daily Forecast for IntelliStar 1 {starConfig.HeadendID}...");
            IS1DataRecord[]? daily = await dataClient.DailyForecast(location);
            if (daily != null)
            {
                dataRecords = [.. dataRecords.Concat(daily)];
            }
        }

        Logger.Info($"Grabbed data for IntelliStar 1 {starConfig.HeadendID}...");

        return [.. dataRecords];
    }
}