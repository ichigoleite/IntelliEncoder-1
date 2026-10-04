using IntelliEncoder1.Core;
using IntelliEncoder1.Core.IS1;
using IntelliEncoder1.Schema.IntelliEncoder;
namespace IntelliEncoder1.Inputs;

public class MainDataRetriever
{
    Logger Logger;
    Config Config;

    public MainDataRetriever(Config config)
    {
        // Set config.
        Config = config;

        // Make logger.
        Logger = new("Inputs - Data Retriever (Main)", config);
    }

    public async Task<IS1DataRecord[]> RetrieveDataIS1(IS1StarConfig starConfig)
    {
        Logger.Info("Retrieving data...");
        // Check what data sources exist
        ConfigClassInputs Inputs = Config.config.Inputs;
        List<IS1DataRecord> dataRecords = [];

        if (Inputs.TWC.Enabled)
        {
            Logger.Info("Using TWC API to retrieve data.");
            InputsTWCMain input = new(Config);
            dataRecords = [.. dataRecords.Concat(await input.RetrieveDataIS1(starConfig))];
        }


        return [.. dataRecords];
    }
}