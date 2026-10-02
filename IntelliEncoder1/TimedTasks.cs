using IntelliEncoder1.Core;
using Renci.SshNet;


namespace IntelliEncoder1
{
    public class TimedTasks
    {
        Config config;
        StarConfig StarConfig;

        SshClient SSHClient;
        SftpClient SFTPClient;

        public TimedTasks(Config configobj)
        {
            config = configobj;

            // Connect to the i1.
            SSHClient = new(config.config.SSH.Host, config.config.SSH.Port, config.config.SSH.Username, config.config.SSH.Password);
            SFTPClient = new(config.config.SSH.Host, config.config.SSH.Port, config.config.SSH.Username, config.config.SSH.Password);

            // Make sure directories exist.
            Directory.CreateDirectory(".temp/");

            SFTPClient.CreateDirectory("/home/dgadmin/.intelliencoder/");

            // Import i1 config
            StarConfig = new(SFTPClient);
        }

        public async Task MainDataLoop()
        {

        }
    }
}

