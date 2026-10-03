namespace IntelliEncoder1.Schema.IBM;

public class LocServNearAirportLocation
{
    public List<double>? latitude { get; set; }

    public List<double>? longitude { get; set; }

    public List<double?>? distanceKm { get; set; }

    public List<double?>? distanceMi { get; set; }

    public List<string?>? airportName { get; set; }

    public List<string?>? iataCode { get; set; }

    public List<string?>? icaoCode { get; set; }
}

public class LocServNearAirportResponse
{
    public LocServNearAirportLocation? location { get; set; }
}