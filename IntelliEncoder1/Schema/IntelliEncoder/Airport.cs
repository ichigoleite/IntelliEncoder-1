using System.ComponentModel.DataAnnotations;

namespace IntelliEncoder1.Schema.IntelliEncoder;

public class Airport
{
    [Key]
    public string? country_code { get; set; }
    public string? region_name { get; set; }
    public string? iata { get; set; }
    public string? icao { get; set; }
    public string? airport { get; set; }
    public string? latitude { get; set; }
    public string? longitude { get; set; }

}