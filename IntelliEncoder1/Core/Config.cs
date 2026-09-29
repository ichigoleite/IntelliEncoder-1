// Placeholder from Encode2It

using System.Xml.Serialization;
namespace IntelliEncoder1.Core;

public class Config
{
    public object config = new();

    public Config()
    {
        // Check if file exists.
        if (File.Exists("./config.xml"))
        {
            // If so, read it and set config.
            object? tempconfig = (object?)new XmlSerializer(typeof(object)).Deserialize(File.OpenRead("./config.xml"));

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
            new XmlSerializer(typeof(object)).Serialize(File.OpenWrite("./config.xml"), config);
            Console.WriteLine("Config doesn't exist, therefore we created a new config file. Please set all parameters and try again.");
            Environment.Exit(0);
        }
    }
}