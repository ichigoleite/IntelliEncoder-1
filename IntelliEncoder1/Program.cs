using IntelliEncoder1.Schema.TWC;

Console.WriteLine("Test.");
Payload payload = new()
{
    DataRecords =
    {
        new CurrentConditions()
        {
            Location = "T28JAJATY0307"
        }
    }
};

// Write generated payload.
File.WriteAllText("test.py", await payload.Generate());