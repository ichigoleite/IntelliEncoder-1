using System.Text;
using IntelliEncoder1.Core;
using IntelliEncoder1.Core.IS1;
using IntelliEncoder1.Schema.IntelliEncoder;
using Renci.SshNet;

namespace IntelliEncoder1.Clients.IS1;

public class SSHClient
{
    public SshClient sshClient;
    public SftpClient sftpClient;
    public Config Config;
    public Logger Logger;

    public SSHClient(ConfigClassSTAR star, Config config)
    {
        Config = config;
        Logger = new("Clients - SSH (IntelliStar 1)", config);

        // SSH clients
        sshClient = new(star.Connection.Host, star.Connection.Port, star.Connection.Username, star.Connection.Password);
        sftpClient = new(star.Connection.Host, star.Connection.Port, star.Connection.Username, star.Connection.Password);
    }

    public void Prepare()
    {
        // Connect to IS1
        sftpClient.Connect();

        // Make sure directories are made
        if (!sftpClient.Exists("/home/dgadmin/.intelliencoder/"))
        {
            sftpClient.CreateDirectory("/home/dgadmin/.intelliencoder/");
        }

        Directory.CreateDirectory(".temp/");
        return;
    }

    public IS1StarConfig GrabStarConfig()
    {
        // Download the config.
        MemoryStream stream = new();
        sftpClient.DownloadFile("/home/dgadmin/config/current/config.py", stream);

        // Read the config.
        string configText = Encoding.UTF8.GetString(stream.ToArray());

        // Retrieve STAR config
        return new(configText, Config);
    }

    public void SendPayload(IS1StarConfig starConfig)
    {
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
    }
}