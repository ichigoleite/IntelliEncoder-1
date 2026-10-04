namespace IntelliEncoder1.Schema.IBM.v3;

public class LocationNearResponse<T> where T : BaseLocationData
{
    public required T location { get; set; }
}

public class AirportNearResponse : BaseLocationData
{
    /** 
    * Names of the airports nearest the requested location. Entries may be null for locations without a formal airport name. 
    * 
    * @example ["State Capital Parking Lot","Grady Memorial Hospital"] 
    */
    public List<string?>? airportName { get; set; }

    /** 
         * International Air Transport Association (IATA) 3-character airport codes for the nearest airports. Null when no IATA code is assigned. 
         * 
         * @example [null,null] 
          */
    public List<string?>? iataCode { get; set; }

    /** 
         * International Civil Aviation Organization (ICAO) 4-character airport codes for the nearest airports. Null when no ICAO code is assigned. 
         * 
         * @example [null,null] 
          */
    public List<string?>? icaoCode { get; set; }
}

public class ObservationNearResponse : BaseLocationData
{
    /** 
    * ISO 3166-2 state, region, district, or province codes for each station location. May be null for locations without a level-1 administrative division. 
    * 
    * @example ["GA","GA"] 
*/
    public List<string?>? adminDistrictCode { get; set; }
    /** 
    * Human-readable names of the METAR observation stations. 
    * 
    * @example ["Fulton Co. Arpt.","Hartsfield-Jackson Atlanta International"] 
*/
    public required string[] stationName { get; set; }

    /** 
    * ISO country codes for the country in which each station is located. 
    * 
    * @example ["US","US"] 
*/
    public required string[] countryCode { get; set; }

    /** 
    * METAR station identifiers (ICAO-format station IDs used for surface weather observations, e.g., `KATL`). 
    * 
    * @example ["KFTY","KATL"] 
*/
    public required string[] stationId { get; set; }

    /** 
    * Standard IANA time zone identifiers for each station location (e.g., `America/New_York`). 
    * 
    * @example ["America/New_York","America/New_York"] 
*/
    public required string[] ianaTimeZone { get; set; }

    /** 
    * Observation type for each station. Typically `METAR` for surface aviation weather reports. 
    * 
    * @example ["METAR","METAR"] 
*/
    public required string[] obsType { get; set; }
}

public class SkiNearResponse : BaseLocationData
{
    /** 
    * ISO 3166-2 state, region, district, or province codes for each ski resort location (e.g., `NC` for North Carolina, USA). 
    * 
    * @example ["NC","TN"] 
*/
    public string[]? adminDistrictCode { get; set; }

    /** 
    * ISO country codes for the country in which each ski resort is located. 
    * 
    * @example ["US","US"] 
*/
    public string[]? countryCode { get; set; }

    /** 
    * Standard IANA time zone identifiers for each ski resort location. 
    * 
    * @example ["America/New_York","America/New_York"] 
*/
    public string[]? ianaTimeZone { get; set; }

    /** 
    * Ski resort identifiers used internally by The Weather Company. 
    * 
    * @example ["347","303"] 
*/
    public string[]? skiId { get; set; }

    /** 
    * Names of the ski resorts nearest the requested location. 
    * 
    * @example ["Sapphire Valley","Ober Mountain Ski Area & Adventure Park"] 
*/
    public string[]? skiName { get; set; }
}

/** Base location fields common to all product type responses. All fields are parallel arrays where the same array index corresponds to the same result location.  */
public class BaseLocationData
{
    /** 
         * Decimal latitude coordinates of the result locations, in WGS84. Array index corresponds to the same location across all parallel arrays. 
         * 
         * @example [33.7484397,33.7522222] 
          */
    public required double[] latitude { get; set; }

    /** 
         * Decimal longitude coordinates of the result locations, in WGS84. Array index corresponds to the same location across all parallel arrays. 
         * 
         * @example [-84.3874267,-84.3822222] 
          */
    public required double[] longitude { get; set; }

    /** 
         * Distance in kilometers from the requested geocode to each result location. Array index corresponds to the same location across all parallel arrays. 
         * 
         * @example [0.97,1.54] 
          */
    public double[]? distanceKm { get; set; }

    /** 
         * Distance in miles from the requested geocode to each result location. Array index corresponds to the same location across all parallel arrays. 
         * 
         * @example [0.6,0.96] 
          */
    public double[]? distanceMi { get; set; }

}