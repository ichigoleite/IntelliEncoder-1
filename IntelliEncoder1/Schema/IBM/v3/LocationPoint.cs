

/** Top-level response object containing a single location point record. */
public class LocationPointResponse
{
      public required LocationPoint location { get; set; }

}

/** Comprehensive metadata for a single geographic point. */
public class LocationPoint
{
      /** 
      * Center latitude coordinate of the requested location in decimal degrees. 
      * 
      * @example 33.737 
*/
      public required double latitude { get; set; }

      /** 
      * Center longitude coordinate of the requested location in decimal degrees. 
      * 
      * @example -84.386 
*/
      public required double longitude { get; set; }

      /** 
      * Locale-level location detail string (translated). Includes city, state, and country. 
      * 
      * @example "Atlanta, Georgia, United States" 
*/
      public string? address { get; set; }

      /** 
      * State, region, district, or province name — level 1 administrative division (translated). 
      * 
      * @example "Georgia" 
*/
      public string? adminDistrict { get; set; }

      /** 
      * State, region, district, or province code — level 1 administrative division. Populated for US states only. 
      * 
      * @example "GA" 
*/
      public string? adminDistrictCode { get; set; }

      /** 
      * Airport name associated with the ICAO or IATA airport code. Only returned when the `iataCode` or `icaoCode` query parameter is used. 
      * 
      * @example "Hartsfield-Jackson Atlanta Intl Airport" 
*/
      public string? airportName { get; set; }

      /** 
      * City-level place identifier that encompasses lower-level place types. Intended for SEO purposes only. 
      * 
      * @example "5e31d30099c21fa9f77280443980bc98" 
*/
      public string? canonicalCityId { get; set; }

      /** 
      * Full name of the location city (translated). 
      * 
      * @example "Atlanta" 
*/
      public string? city { get; set; }

      /** 
      * Governmental county identifier. For internal use only. 
      * 
      * @example "GAC121" 
*/
      public string? countyId { get; set; }

      /** 
      * Full name of the location country (translated). 
      * 
      * @example "United States" 
*/
      public string? country { get; set; }

      /** 
      * ISO 3166-1 alpha-2 country code. 
      * 
      * @example "US" 
*/
      public string? countryCode { get; set; }

      /** 
      * Common display name for the location (translated). Always returned. 
      * 
      * @example "Atlanta" 
*/
      public required string displayName { get; set; }

      /** 
      * Recommended location context to display alongside `displayName` (translated). Typically contains state and country information. 
      * 
      * @example "Georgia, United States" 
*/
      public string? displayContext { get; set; }

      /** 
      * Indicates whether the point falls within a politically sensitive disputed area. 
      * 
      * @example false 
*/
      public required bool disputedArea { get; set; }

      /** 
      * List of country names claiming territory in the disputed area (translated). 
      * 
      * @example null 
*/
      public string[]? disputedCountries { get; set; }

      /** 
      * List of ISO country codes representing countries that claim the disputed area. 
      * 
      * @example null 
*/
      public string[]? disputedCountryCodes { get; set; }

      /** 
      * Customer identifiers for custom display logic in politically sensitive areas. Contains nested arrays of customer IDs. 
      * 
      * @example null 
*/
      public string[][]? disputedCustomers { get; set; }

      /** 
      * Array of boolean flags indicating whether the country name should be displayed for each entry in `disputedCountries`. 
      * 
      * @example [false] 
*/
      public required bool[] disputedShowCountry { get; set; }

      /** 
      * Designated Market Area (DMA) code. For internal use only. 
      * 
      * @example "524" 
*/
      public string? dmaCd { get; set; }

      /** 
      * Date and time when daylight saving time ends for this location. Formatted as an ISO 8601 datetime string with UTC offset. 
      * 
      * @example "2026-11-01T01:00:00-0500" 
*/
      public string? dstEnd { get; set; }

      /** 
      * Date and time when daylight saving time begins for this location. Formatted as an ISO 8601 datetime string with UTC offset. 
      * 
      * @example "2026-03-08T03:00:00-0400" 
*/
      public string? dstStart { get; set; }

      /** 
      * Standard IANA time zone identifier for the location (e.g., `America/New_York`). 
      * 
      * @example "America/New_York" 
*/
      public string? ianaTimeZone { get; set; }

      /** 
      * Three-character IATA airport code. Only returned when the `iataCode` query parameter is used. 
      * 
      * @example "ATL" 
*/
      public string? iataCode { get; set; }

      /** 
      * Four-character ICAO airport code. Only returned when the `icaoCode` query parameter is used. 
      * 
      * @example "KATL" 
*/
      public string? icaoCode { get; set; }

      /** 
      * Legacy TWC location identifier retained for compatibility with legacy queries. 
      * 
      * @example "USGA5031:27:US" 
*/
      public string? locId { get; set; }

      /** 
      * Sub-type of the `type` field providing a more specific grouping. Currently returns a non-null value only when `type = poi`. 
      * 
      * @example "national park" 
*/
      public string? locationCategory { get; set; }

      /** 
      * Recognized neighborhood name for the location (translated). 
      * 
      * @example "Summerhill" 
*/
      public string? neighborhood { get; set; }

      /** 
      * Unique place identifier for the location, expressed as a SHA-256 hash string. 
      * 
      * @example "9317a8b71b3e53632b05f39ab33ed48cff4d6c42a979fd12306145dff2dbca2f" 
*/
      public required string placeId { get; set; }

      /** 
      * Pollen station identifier. Only valid for locations in the United States. 
      * 
      * @example "ATL" 
*/
      public string? pollenId { get; set; }

      /** 
      * Postal code of the requested location. 
      * 
      * @example "30312" 
*/
      public string? postalCode { get; set; }

      /** 
      * Composite postal key identifier in the format `PostalCode:CountryCode`. 
      * 
      * @example "30312:US" 
*/
      public string? postalKey { get; set; }

      /** 
      * Personal Weather Station (PWS) identifier nearest to the requested location. 
      * 
      * @example "KGAATLAN983" 
*/
      public string? pwsId { get; set; }

      /** 
      * TWC-defined region identifier for satellite coverage of the globe. 
      * 
      * @example "se" 
*/
      public string? regionalSatellite { get; set; }

      /** 
      * Tide station identifier. Only available for locations near coastlines. 
      * 
      * @example "9410170" 
*/
      public string? tideId { get; set; }

      /** 
      * Geospatial type classification for the location record. Determines the nature of the geographic feature returned. 
      * 
      * @example "neighborhood" 
*/
      public required string type { get; set; }

      /** 
      * Government-assigned zone identifier for the location. 
      * 
      * @example "GAZ033" 
*/
      public string? zoneId { get; set; }
      public LocaleInfo? locale { get; set; }

}

/** Additional city and sub-city locale information, providing hierarchical geographic context from broadest (locale1) to most granular (locale4). */
public class LocaleInfo
{
      /** 
      * Broadest sub-city locale level — typically the district or county (translated). 
      * 
      * @example "Fulton County" 
*/
      public string? locale1 { get; set; }

      /** 
      * One level more granular than locale1 — typically the city (translated). 
      * 
      * @example "Atlanta" 
*/
      public string? locale2 { get; set; }

      /** 
      * One level more granular than locale2 — typically the locality (translated). 
      * 
      * @example null 
*/
      public string? locale3 { get; set; }

      /** 
      * Most granular locale level — typically the neighborhood (translated). 
      * 
      * @example "Summerhill" 
*/
      public string? locale4 { get; set; }

}

