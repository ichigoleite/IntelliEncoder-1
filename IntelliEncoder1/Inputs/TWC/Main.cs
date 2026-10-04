using IntelliEncoder1.Core;
using IntelliEncoder1.Core.IS1;
using IntelliEncoder1.Inputs.TWC.Data.IS1;
using IntelliEncoder1.Records;
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

    public async Task RetrieveDataIS1(ConfigClassSTAR star)
    {
        // SSH clients
        SshClient sshClient = new(star.Connection.Host, star.Connection.Port, star.Connection.Username, star.Connection.Password);
        SftpClient sftpClient = new(star.Connection.Host, star.Connection.Port, star.Connection.Username, star.Connection.Password);

        // Make sure directories are made
        sftpClient.CreateDirectory("/home/dgadmin/.intelliencoder/");

        // Retrieve STAR config
        IS1StarConfig starConfig = new(sftpClient, Config);

        InputsTWCDataIS1 dataClient = new(Config, Logger);
        List<DataRecord> dataRecords = [];

        // Grab all observations
        foreach (LFRecordLocation location in starConfig.ObsStns)
        {
            CurrentConditions? cc = await dataClient.CurrentConditions(location);
            if (cc != null)
            {
                dataRecords.Add(cc);
            }
        }

        // Generate payload
        IS1Payload payload = new();
    }
}