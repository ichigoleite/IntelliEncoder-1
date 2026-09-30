using IntelliEncoder1.Schema.TWC;

Console.WriteLine("Test.");
Payload payload = new()
{
    DataRecords =
    {
        new CurrentConditions()
        {
            Location = "T28JAJATY0307"
        },
        new DaypartForecast()
        {
            Location = "28JAJATY0307",
            Dayparts =
            {
                new() {IsNight = false, Phrase = "Test! Kirby kirby!"},
                new() {IsNight = true, Phrase = "Trans rights are human rights!"},
                new() {IsNight = false, Phrase = "Nano is Nano."},
                new() {IsNight = true, Phrase = "America ya!"},
                new() {IsNight = false, Phrase = "Filtered."},
                new() {IsNight = true, Phrase = "Every day's great at your JUNES!"},
                new() {IsNight = false, Phrase = "But can it run DOOM?"},
                new() {IsNight = true, Phrase = "Kyocera DIGNO 3 (902KC)"},
            }
        }
    }
};

// Write generated payload.
File.WriteAllText("test.py", await payload.Generate());