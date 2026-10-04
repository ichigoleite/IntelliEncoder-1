using System.Buffers;
using IntelliEncoder1.Clients.IS1;
using IntelliEncoder1.Core;
using IntelliEncoder1.Core.IS1;
using IntelliEncoder1.Inputs;
using IntelliEncoder1.Schema.IntelliEncoder;


namespace IntelliEncoder1
{
    public class TimedTasks
    {
        Config Config;
        Logger Logger;

        public TimedTasks(Config configobj)
        {
            Config = configobj;
            Logger = new("Inputs - Data Retriever (Main) - Ad Crawl", configobj);

            // Make sure directories exist.
            Directory.CreateDirectory(".temp/");
        }

        public async Task MainDataLoop()
        {

            foreach (ConfigClassSTAR star in Config.config.Stars)
            {
                if (star.Star == ConfigClassSTARTypes.IntelliStar1)
                {
                    IS1StarConfig starConfig;
                    SSHClient sshClient;

                    if (star.Method == ConfigClassSTARMethods.SSH)
                    {
                        sshClient = new(star, Config);

                        sshClient.Prepare();
                        starConfig = sshClient.GrabStarConfig();
                    }
                    else
                    {
                        Logger.Warn("IntelliStar 1 config has an unknown method.");
                        continue;
                    }


                    Directory.CreateDirectory($".temp/IS1/{starConfig.HeadendID}");

                    MainDataRetriever retriever = new(Config);
                    IS1DataRecord[] dataRecords = await retriever.RetrieveDataIS1(starConfig);

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


                    if (star.Method == ConfigClassSTARMethods.SSH)
                    {
                        sshClient.SendPayload(starConfig);
                    }
                }
            }
        }
    }
}

