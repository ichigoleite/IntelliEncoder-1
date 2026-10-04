using IntelliEncoder1.Core;
using IntelliEncoder1.Schema.IntelliEncoder;

namespace IntelliEncoder1.Inputs.TWC.Data.IS1;

public partial class InputsTWCDataIS1
{
    Config Config;
    Logger Logger;
    HttpClient Client;
    ConfigClassInputsTWC TWCConfig;

    public InputsTWCDataIS1(Config config, Logger logger)
    {
        Config = config;
        Logger = logger;
        Client = config.client;
        TWCConfig = config.config.Inputs.TWC;
    }
}