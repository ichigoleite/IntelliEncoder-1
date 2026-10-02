// Code from Encode2It

using IntelliEncoder1.Schema.IntelliEncoder;
using Tomlyn;
namespace IntelliEncoder1.Core;

public class Config
{
    public ConfigClass config = new();

    public Config()
    {
        // Check if file exists.
        if (File.Exists("./config.toml"))
        {
            // If so, read it and set config.
            ConfigClass? tempconfig = TomlSerializer.Deserialize<ConfigClass>(File.ReadAllText("./config.xml"));

            // Check if config failed to parse.
            if (tempconfig == null)
            {
                Console.WriteLine("Failed to parse config! Config must be corrupt! Exiting...");
                Environment.Exit(1);
            }

            config = tempconfig;
        }
        else
        {
            // Write config and exit.
            File.WriteAllText("./config.xml", TomlSerializer.Serialize<ConfigClass>(new()));
            Console.WriteLine("Config doesn't exist, therefore we created a new config file. Please set all parameters and try again.");
            Environment.Exit(0);
        }
    }
}