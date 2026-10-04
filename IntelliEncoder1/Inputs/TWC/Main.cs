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

    public async Task RetrieveDataIS1(ConfigClassSTAR star)
    {
        // SSH clients
        SshClient sshClient = new(star.Connection.Host, star.Connection.Port, star.Connection.Username, star.Connection.Password);
        SftpClient sftpClient = new(star.Connection.Host, star.Connection.Port, star.Connection.Username, star.Connection.Password);

        // Connect to IS1
        sftpClient.Connect();

        // Make sure directories are made
        if (!sftpClient.Exists("/home/dgadmin/.intelliencoder/"))
        {
            sftpClient.CreateDirectory("/home/dgadmin/.intelliencoder/");
        }

        Directory.CreateDirectory(".temp/");

        // Retrieve STAR config
        IS1StarConfig starConfig = new(sftpClient, Config);

        Directory.CreateDirectory($".temp/IS1/{starConfig.HeadendID}");

        Logger.Info($"Starting data retrieval for IntelliStar 1 {starConfig.HeadendID}...");
        InputsTWCDataIS1 dataClient = new(Config, Logger);
        List<IS1DataRecord> dataRecords = [];

        // Grab all observations
        foreach (LFRecordLocation location in starConfig.ObsStns)
        {
            Logger.Info($"Grabbing Current Conditions for IntelliStar 1 {starConfig.HeadendID}...");
            IS1CurrentConditions? cc = await dataClient.CurrentConditions(location);
            if (cc != null)
            {
                dataRecords.Add(cc);
            }
        }

        Logger.Info($"Generating data payload for IntelliStar 1 {starConfig.HeadendID}...");
        // Generate payload
        IS1Payload payload = new() { DataRecords = [.. dataRecords] };

        string? payloadContent = await payload.Generate();
        if (payloadContent == null)
        {
            Logger.Error($"Could not generate IS1 payload for headend ID {starConfig.HeadendID}");
            return;
        }
        File.WriteAllText($".temp/IS1/{starConfig.HeadendID}/payload.py", payloadContent);

        // Upload payload
        Logger.Info($"Uploading data payload for IntelliStar 1 {starConfig.HeadendID}...");
        if (sftpClient.Exists("/home/dgadmin/.intelliencoder/payload.py"))
        {
            sftpClient.Delete("/home/dgadmin/.intelliencoder/payload.py");
        }
        sftpClient.UploadFile(File.OpenRead($".temp/IS1/{starConfig.HeadendID}/payload.py"), "/home/dgadmin/.intelliencoder/payload.py");

        Logger.Info($"Running data payload for IntelliStar 1 {starConfig.HeadendID}...");

        sftpClient.Disconnect();
        sshClient.Connect();

        // Run payload
        sshClient.RunCommand("su -l dgadmin -c '/usr/twc/digi/util/runomni /twc/util/loadSCMTconfig.pyc /home/dgadmin/.intelliencoder/payload.py'");

        Logger.Info($"Sucessfully sent data to the IS1 (Headend ID: {starConfig.HeadendID})");
        return;
    }
}