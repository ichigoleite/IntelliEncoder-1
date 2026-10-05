using IntelliEncoder1;
using IntelliEncoder1.Core;

// Version Info
string[] versioninfo = [
    "v1.0",
    "Currently in your area..."
];

// Awesome banner
Console.WriteLine("-----------------------------------------------------------------------");
Console.WriteLine("""

▐▓▓▓▓▓▌▐▓▌ ▐▓▌▐▓▓▓▓▓▌▐▓▓▓▓▌▐▓▌   ▐▓▌   ▐▓▓▓▓▓▌▐▓▓▓▓▌▐▓▌ ▐▓▌▐▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌ ▐▓▓▓▓▌▐▓▓▓▓▌    ▐▓▓▌ 
  ▐▓▌  ▐▓▓▌▐▓▌  ▐▓▌  ▐▓▌   ▐▓▌   ▐▓▌     ▐▓▌  ▐▓▌   ▐▓▓▌▐▓▌▐▓▌   ▐▓▌▐▓▌▐▓▌ ▐▓▌▐▓▌   ▐▓▌▐▓▌     ▐▓▌ 
  ▐▓▌  ▐▓▐▓▐▓▌  ▐▓▌  ▐▓▓▓▌ ▐▓▌   ▐▓▌     ▐▓▌  ▐▓▓▓▌ ▐▓▐▓▐▓▌▐▓▌   ▐▓▌▐▓▌▐▓▌ ▐▓▌▐▓▓▓▌ ▐▓▓▓▓▌     ▐▓▌ 
  ▐▓▌  ▐▓▌▐▓▓▌  ▐▓▌  ▐▓▌   ▐▓▌   ▐▓▌     ▐▓▌  ▐▓▌   ▐▓▌▐▓▓▌▐▓▌   ▐▓▌▐▓▌▐▓▌ ▐▓▌▐▓▌   ▐▓▐▓▌      ▐▓▌ 
▐▓▓▓▓▓▌▐▓▌ ▐▓▌  ▐▓▌  ▐▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▓▌▐▓▓▓▓▌▐▓▌ ▐▓▌▐▓▓▓▓▌▐▓▓▓▓▌▐▓▓▓▓▌ ▐▓▓▓▓▌▐▓▌▐▓▌    ▐▓▓▓▌

""");
Console.WriteLine($"Version {versioninfo[0]} - {versioninfo[1]}");
Console.WriteLine("Made by ichigoleite");
Console.WriteLine("Special thanks for mariiful and kokoraii for MARIENCODER, the reference encoder used for this project.");
Console.WriteLine("-----------------------------------------------------------------------");
Console.WriteLine("\n");

// Create config class.
Config config = new(versioninfo);

// Check if custom folder exists
if (!Directory.Exists(Path.Combine(AppContext.BaseDirectory, "Custom")))
{
  Console.WriteLine("Custom directory not made, making right now");
  Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, "Custom"));

  File.Copy(
    Path.Combine(AppContext.BaseDirectory, "Data", "LFRecord.db"),
    Path.Combine(AppContext.BaseDirectory, "Custom", "LFRecord.db"));
  File.Copy(
    Path.Combine(AppContext.BaseDirectory, "Data", "Airports.db"),
    Path.Combine(AppContext.BaseDirectory, "Custom", "Airports.db"));
}

// Create TimedTasks class.
TimedTasks timedTasks = new TimedTasks(config);

// Start loops.
Task.WaitAll(
    timedTasks.MainDataLoop(),
    timedTasks.ScheduleDataLoop()
);

Console.WriteLine("Goodbye.");