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

        # Imports.
        import twccommon

        # Intro message.
        twccommon.Log.info("---------------------------------------------------------------")
        twccommon.Log.info("START")
        twccommon.Log.info("---------------------------------------------------------------")
        twccommon.Log.info("\n")
        twccommon.Log.info(
            """
            ichigoleite
            ▐▓▓▓▓▓▌▐▓▌ ▐▓▌▐▓▓▓▓▓▌▐▓▓▓▓▌▐▓▌   ▐▓▌   ▐▓▓▓▓▓▌▐▓▓▓▓▌▐▓▌ ▐▓▌▐▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌ ▐▓▓▓▓▌▐▓▓▓▓▌    ▐▓▓▌ 
              ▐▓▌  ▐▓▓▌▐▓▌  ▐▓▌  ▐▓▌   ▐▓▌   ▐▓▌     ▐▓▌  ▐▓▌   ▐▓▓▌▐▓▌▐▓▌   ▐▓▌▐▓▌▐▓▌ ▐▓▌▐▓▌   ▐▓▌▐▓▌     ▐▓▌ 
              ▐▓▌  ▐▓▐▓▐▓▌  ▐▓▌  ▐▓▓▓▌ ▐▓▌   ▐▓▌     ▐▓▌  ▐▓▓▓▌ ▐▓▐▓▐▓▌▐▓▌   ▐▓▌▐▓▌▐▓▌ ▐▓▌▐▓▓▓▌ ▐▓▓▓▓▌     ▐▓▌ 
              ▐▓▌  ▐▓▌▐▓▓▌  ▐▓▌  ▐▓▌   ▐▓▌   ▐▓▌     ▐▓▌  ▐▓▌   ▐▓▌▐▓▓▌▐▓▌   ▐▓▌▐▓▌▐▓▌ ▐▓▌▐▓▌   ▐▓▐▓▌      ▐▓▌ 
            ▐▓▓▓▓▓▌▐▓▌ ▐▓▌  ▐▓▌  ▐▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▓▌▐▓▓▓▓▌▐▓▌ ▐▓▌▐▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌ ▐▓▓▓▓▌▐▓▌▐▓▌    ▐▓▓▓▌

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
        twccommon.Log.info("---------------------------------------------------------------")
        twccommon.Log.info("END")
        twccommon.Log.info("---------------------------------------------------------------")
        twccommon.Log.info("IntelliEncoder 1 - And that's all! Thank you for your patience!")
        """;

        // Send off the payloadBody.
        return payloadBody;
    }
}