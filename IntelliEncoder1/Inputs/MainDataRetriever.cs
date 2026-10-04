using IntelliEncoder1.Core;
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

    public async Task RetrieveData()
    {
        Logger.Info("Retrieving data...");
        // Check what data sources exist
        ConfigClassInputs Inputs = Config.config.Inputs;
        List<Task> tasks = [];
        if (Inputs.TWC.Enabled)
        {
            Logger.Info("Using TWC API to retrieve data.");
            InputsTWCMain input = new(Config);
            foreach (ConfigClassSTAR star in Config.config.Stars)
            {
                if (star.Star == ConfigClassSTARTypes.IntelliStar1)
                {
                    tasks.Add(input.RetrieveDataIS1(star));
                }
            }
        }
        else
        {
            Logger.Info("None of the supported inputs are enabled.");
        }

        Task.WaitAll(tasks);
    }
}