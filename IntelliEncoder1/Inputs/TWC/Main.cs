using IntelliEncoder1.Core;
using IntelliEncoder1.Schema.IntelliEncoder;
namespace IntelliEncoder1.Inputs;

public class InputsTWCMain
{
    Logger Logger;
    Config Config;
    StarConfig StarConfig;

    public InputsTWCMain(Config config, StarConfig starConfig)
    {
        // Set config.
        Config = config;
        StarConfig = starConfig;

        // Make logger.
        Logger = new("Inputs - Data Retriever (Main) - TWC", config);
    }

    public async Task<DataRecord[]?> RetrieveData()
    {
        // Check what data sources exist
        ConfigClassInputs Inputs = Config.config.Inputs;
        if (Inputs.TWC.Enabled)
        {
            return null;
        }
    }
}