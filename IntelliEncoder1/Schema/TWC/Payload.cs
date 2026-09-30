// This generates the data payload for the IntelliStar 1.

namespace IntelliEncoder1.Schema.TWC;

public class Payload()
{
    // List of DataRecords.
    public List<DataRecord> DataRecords = [];

    // Generates payload scripts.
    public async Task<string> Generate()
    {
        // Define intro header and such.
        string payloadBody =
        """"
        """
        ichigoleite
        ▐▓▓▓▓▓▌▐▓▌ ▐▓▌▐▓▓▓▓▓▌▐▓▓▓▓▌▐▓▌   ▐▓▌   ▐▓▓▓▓▓▌▐▓▓▓▓▌▐▓▌ ▐▓▌▐▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌ ▐▓▓▓▓▌▐▓▓▓▓▌    ▐▓▓▌ 
          ▐▓▌  ▐▓▓▌▐▓▌  ▐▓▌  ▐▓▌   ▐▓▌   ▐▓▌     ▐▓▌  ▐▓▌   ▐▓▓▌▐▓▌▐▓▌   ▐▓▌▐▓▌▐▓▌ ▐▓▌▐▓▌   ▐▓▌▐▓▌     ▐▓▌ 
          ▐▓▌  ▐▓▐▓▐▓▌  ▐▓▌  ▐▓▓▓▌ ▐▓▌   ▐▓▌     ▐▓▌  ▐▓▓▓▌ ▐▓▐▓▐▓▌▐▓▌   ▐▓▌▐▓▌▐▓▌ ▐▓▌▐▓▓▓▌ ▐▓▓▓▓▌     ▐▓▌ 
          ▐▓▌  ▐▓▌▐▓▓▌  ▐▓▌  ▐▓▌   ▐▓▌   ▐▓▌     ▐▓▌  ▐▓▌   ▐▓▌▐▓▓▌▐▓▌   ▐▓▌▐▓▌▐▓▌ ▐▓▌▐▓▌   ▐▓▐▓▌      ▐▓▌ 
        ▐▓▓▓▓▓▌▐▓▌ ▐▓▌  ▐▓▌  ▐▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▓▌▐▓▓▓▓▌▐▓▌ ▐▓▌▐▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌ ▐▓▓▓▓▌▐▓▌▐▓▌    ▐▓▓▓▌

        This is an auto-generated data payload for the IntelliStar 1.
        You should not NEED to edit this - if you do, please make a bug report in the IntelliEncoder 1 GitHub repository.
        """

        # Intro message.
        Log.info("-----")
        Log.info("START")
        Log.info("-----")
        Log.info("\n")
        Log.info(
            """
            IntelliEncoder 1
            made by ichigoleite

            Special thanks for mariiful and kokoraii for MARIENCODER, the reference encoder used for this project.

            Enough talk, let's get encoding.
            """
        )

        """";

        // Generate all DataRecords.
        foreach (DataRecord record in DataRecords)
        {
            payloadBody += await record.Generate();
        }

        // End with a ending message.
        payloadBody += """
        
        # Ending message.
        Log.info("---")
        Log.info("END")
        Log.info("---")
        Log.info("IntelliEncoder 1 - And that's all! Thank you for your patience!")
        """;

        // Send off the payloadBody.
        return payloadBody;
    }
}