namespace IntelliEncoder1.Schema.IntelliEncoder;

public class ConfigClassSTARConnection
{
    public string Host { get; set; } = "127.0.0.1";
    public int Port { get; set; } = 22;
    public string Username { get; set; } = "root";
    public string Password { get; set; } = "REPLACE_WITH_PASSWORD";
}

public class ConfigClassDataRecords
{
    public bool CurrentConditions { get; set; } = true;
    public bool DailyForecast { get; set; } = true;
    public bool DaypartForecast { get; set; } = true;
    public bool Headline { get; set; } = true;
    public bool HourlyForecast { get; set; } = true;
}

public class ConfigClassInputsTWC
{
    public bool Enabled { get; set; } = true;
    public string APIKey { get; set; } = "REPLACE_WITH_API_KEY";
    public string Units { get; set; } = "e";
    public string Language { get; set; } = "en-US";
}

public class ConfigClassInputsAdCrawl
{
    public bool Enabled { get; set; } = true;
    public string URL { get; set; } = "https://example.com";
}

public class ConfigClassInputsFlightAware
{
    public bool Enabled { get; set; } = true;
}

public class ConfigClassInputs
{
    public ConfigClassInputsTWC TWC { get; set; } = new();
    public ConfigClassInputsAdCrawl AdCrawl { get; set; } = new();
    public ConfigClassInputsFlightAware FlightAware { get; set; } = new();
}

public class ConfigClassLog
{
    public int LogLevel { get; set; } = 3;
}

public class ConfigClassTimers
{
    public int DataTimer { get; set; } = 1800000;
}

public enum ConfigClassSTARTypes
{
    IntelliStar1,
}

public enum ConfigClassSTARMethods
{
    SSH,
}

public class ConfigClassSTAR
{
    public ConfigClassSTARTypes Star { get; set; } = ConfigClassSTARTypes.IntelliStar1;
    public ConfigClassSTARMethods Method { get; set; } = ConfigClassSTARMethods.SSH;
    public ConfigClassSTARConnection Connection { get; set; } = new();

}

public class ConfigClass
{
    public ConfigClassSTAR[] Stars { get; set; } = [new()];
    public ConfigClassDataRecords DataRecords { get; set; } = new();
    public ConfigClassTimers Timers { get; set; } = new();
    public ConfigClassInputs Inputs { get; set; } = new();
    public ConfigClassLog Log { get; set; } = new();
}