using IntelliEncoder1.Core;
using IntelliEncoder1.Schema.IntelliEncoder;

namespace IntelliEncoder1.Inputs.TWC.Data.IS1;

public partial class InputsTWCDataIS1
{
    Config Config;
    Logger Logger;
    HttpClient Client;
    ConfigClassInputsTWC TWCConfig;
    ConfigClassDataRecords DRConfig;

    // Turns TWC wind cardinal to equivlant int.
    private readonly static Dictionary<string, int> CardinalToWindIntMap = new(){
        {"CALM", 0},
        {"N", 1},
        {"NNE", 2},
        {"NE", 3},
        {"ENE", 4},
        {"E", 5},
        {"ESE", 6},
        {"SE", 7},
        {"SSE", 8},
        {"S", 9},
        {"SSW", 10},
        {"SW", 11},
        {"WSW", 12},
        {"W", 13},
        {"WNW", 14},
        {"NW", 15},
        {"NNW", 16},
        {"VAR", 17}
    };

    public InputsTWCDataIS1(Config config, Logger logger)
    {
        Config = config;
        Logger = logger;
        Client = config.client;
        TWCConfig = config.config.Inputs.TWC;
        DRConfig = config.config.DataRecords;
    }
}