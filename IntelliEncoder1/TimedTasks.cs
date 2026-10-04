using IntelliEncoder1.Core;
using IntelliEncoder1.Inputs;
using Renci.SshNet;


namespace IntelliEncoder1
{
    public class TimedTasks
    {
        Config config;

        public TimedTasks(Config configobj)
        {
            config = configobj;

            // Make sure directories exist.
            Directory.CreateDirectory(".temp/");
        }

        public async Task MainDataLoop()
        {
            MainDataRetriever retriever = new(config);
            await retriever.RetrieveData();
        }
    }
}

