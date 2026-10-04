// Code from Encode2It

using IntelliEncoder1.Schema.IntelliEncoder;
using Tomlyn;
namespace IntelliEncoder1.Core;

public class Config
{
    public ConfigClass config = new();
    public HttpClient client;

    public Config(string[] verinfo)
    {
        // Check if file exists.
        if (File.Exists("./config.toml"))
        {
            // If so, read it and set config.
            ConfigClass? tempconfig = TomlSerializer.Deserialize<ConfigClass>(File.ReadAllText("./config.toml"));

            // Check if config failed to parse.
            if (tempconfig == null)
            {
                Console.WriteLine("Failed to parse config! Config must be corrupt! Exiting...");
                Environment.Exit(1);
            }

            config = tempconfig;

            // Add HttpClient.
            client = new();
            client.DefaultRequestHeaders.UserAgent.ParseAdd($"IntelliEncoder {verinfo[0]}, https://github.com/ichigoleite/IntelliEncoder-1 (ichigoleite@ichigoleite.com)");
        }
        else
        {
            // Write config and exit.
            File.WriteAllText("./config.toml", TomlSerializer.Serialize<ConfigClass>(new()));
            Console.WriteLine("Config doesn't exist, therefore we created a new config file. Please set all parameters and try again.");
            Environment.Exit(0);
        }
    }
}