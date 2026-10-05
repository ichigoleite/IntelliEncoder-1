public class AirportDelay
{
    public required string airport { get; set; }
    public required DisplayAirport display_airport { get; set; }
    public required string color { get; set; }
    public required string category { get; set; }
    public required int delay_secs { get; set; }
    public required string[] reasons { get; set; }
}

public class DisplayAirport
{
    public required string city { get; set; }
    public required string airport_name { get; set; }
}

public class AirportDelaysResult
{
    public required int num_delays { get; set; }
    public required AirportDelay[] delays { get; set; }
    public required string miniMap { get; set; }
    public required string ad { get; set; }
}

public class AirportDelaysResponse
{
    public required AirportDelaysResult AirportDelaysResult { get; set; }
}