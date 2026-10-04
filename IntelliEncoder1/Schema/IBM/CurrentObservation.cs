namespace IntelliEncoder1.Schema.IBM;

/** Current weather observation data */
public class CurrentObservation
{
    /**
     * Base of lowest Mostly Cloudy or Cloudy layer. Expressed in feet when units=e or h, and meters when units=m or s. NULL indicates unlimited ceiling (clear skies).
     *
     * @example 800
     */
    public int? cloudCeiling { get; set; }

    /**
     * The average cloud cover expressed as a percentage (0-100).
     *
     * @example 82
     */
    public int cloudCover { get; set; }

    /**
     * Descriptive sky cover based on percentage of cloud cover (Clear, Partly Cloudy, Mostly Cloudy, Cloudy)
     *
     * @example "Partly Cloudy"
     */
    public required string cloudCoverPhrase { get; set; }

    /**
     * Day of week
     *
     * @example "Thursday"
     */
    public required string dayOfWeek { get; set; }

    /**
     * Daytime or nighttime of the local apparent time (D=Day, N=Night, X=Missing for extreme northern/southern hemisphere)
     *
     * @example "D"
     */
    public required string dayOrNight { get; set; }

    /**
     * Expiration time in UNIX epoch value indicating when data will be outdated
     *
     * @example 1369252800
     */
    public long expirationTimeUtc { get; set; }

    /**
     * Weather icon lookup key (0 to 47)
     *
     * @example 30
     */
    public int iconCode { get; set; }

    /**
     * Four digit code representing the full set of sensible weather icons
     *
     * @example 3200
     */
    public int iconCodeExtend { get; set; }

    /**
     * Observation qualifier code (format: 'OQ' + 4-digit integer)
     *
     * @example "OQ0031"
     */
    public string? obsQualifierCode { get; set; }
    /**
     * Severity index of the observation qualifier (1=low through 6=high)
     *
     * @example 3
     */
    public int? obsQualifierSeverity { get; set; }

    /**
     * Rolling hour liquid precipitation amount. Expressed in inches when units=e, millimeters when units=m, s, or h.
     *
     * @example 0
     */
    public double? precip1Hour { get; set; }

    /**
     * Rolling six hour liquid precipitation amount. Expressed in inches when units=e, millimeters when units=m, s, or h.
     *
     * @example 0
     */
    public double? precip6Hour { get; set; }

    /**
     * Rolling twenty-four hour liquid precipitation amount. Expressed in inches when units=e, millimeters when units=m, s, or h.
     *
     * @example 0
     */
    public double? precip24Hour { get; set; }

    /**
     * Barometric pressure. Expressed in inches of mercury when units=e, millibars when units=m, s, or h.
     *
     * @example 30.18
     */
    public required double pressureAltimeter { get; set; }

    /**
     * Change in pressure in the last three hours. Expressed in inches of mercury for units=e, millibars when units=m, s, or h.
     *
     * @example -0.03
     */
    public required double pressureChange { get; set; }

    /**
     * Mean sea level pressure in millibars
     *
     * @example 1022.4
     */
    public required double pressureMeanSeaLevel { get; set; }

    /**
    * Code for pressure tendency (0=steady, 1=rising, 2=falling, 3=rapidly rising, 4=rapidly falling)
    *
    * @example 0
    */
    public int pressureTendencyCode { get; set; }

    /**
    * Descriptive text of pressure tendency over the past three hours
    *
    * @example "Steady"
    */
    public required string pressureTendencyTrend { get; set; }

    /**
    * Relative humidity percentage (0 to 100)
    *
    * @example 55
    */
    public int relativeHumidity { get; set; }

    /**
    * One hour snowfall amount. Expressed in inches when units=e, centimeters when units=m, s, or h.
    *
    * @example 0
    */
    public double? snow1Hour { get; set; }

    /**
    * Six hour snowfall amount. Expressed in inches when units=e, centimeters when units=m, s, or h.
    *
    * @example 0
    */
    public double? snow6Hour { get; set; }

    /**
    * Twenty four hour snowfall amount. Expressed in inches when units=e, centimeters when units=m, s, or h.
    *
    * @example 0
    */
    public double? snow24Hour { get; set; }

    /**
    * Local time of sunrise (ISO 8601 format). NULL for Arctic/Antarctic regions where sunrise doesn't occur.
    *
    * @example "2023-01-01T12:00:00Z"
    */
    public string? sunriseTimeLocal { get; set; }

    /**
    * Sunrise time in UNIX epoch value
    *
    * @example 1369252800
    */
    public long? sunriseTimeUtc { get; set; }

    /**
    * Local time of sunset (ISO 8601 format). NULL for Arctic/Antarctic regions where sunset doesn't occur.
    *
    * @example "2023-01-01T12:00:00Z"
    */
    public string? sunsetTimeLocal { get; set; }

    /**
    * Sunset time in UNIX epoch value
    *
    * @example 1369252800
    */
    public long? sunsetTimeUtc { get; set; }

    /**
    * Temperature. Expressed in Fahrenheit when units=e, Celsius when units=m, s, or h.
    *
    * @example 74
    */
    public int temperature { get; set; }

    /**
    * Change in temperature compared to 24 hours ago. Expressed in Fahrenheit when units=e, Celsius when units=m, s, or h.
    *
    * @example -26
    */
    public int temperatureChange24Hour { get; set; }

    /**
    * Dew point temperature. Expressed in Fahrenheit when units=e, Celsius when units=m, s, or h.
    *
    * @example 60
    */
    public int temperatureDewPoint { get; set; }

    /**
    * Apparent temperature representing what the air temperature 'feels like' due to wind chill or heat index. Expressed in Fahrenheit when units=e, Celsius when units=m, s, or h.
    *
    * @example 101
    */
    public int temperatureFeelsLike { get; set; }

    /**
    * Heat index apparent temperature. Below 65°F, equals temperature. Expressed in Fahrenheit when units=e, Celsius when units=m, s, or h.
    *
    * @example 82
    */
    public int temperatureHeatIndex { get; set; }

    /**
    * Maximum temperature in the last 24 hours. Expressed in Fahrenheit when units=e, Celsius when units=m, s, or h.
    *
    * @example 73
    */
    public int temperatureMax24Hour { get; set; }

    /**
    * Maximum temperature since 7 A.M. local time. Expressed in Fahrenheit when units=e, Celsius when units=m, s, or h.
    *
    * @example 72
    */
    public int temperatureMaxSince7Am { get; set; }

    /**
    * Minimum temperature in the last 24 hours. Expressed in Fahrenheit when units=e, Celsius when units=m, s, or h.
    *
    * @example 65
    */
    public int temperatureMin24Hour { get; set; }

    /**
    * An apparent temperature that measures expected heat stress in sunlight. It factors air temperature, humidity, wind speed, sun angle, and cloud cover. Expressed in Fahrenheit when units=e, Celsius when units=m, s, or h.
    *
    * @example 55
    */
    public int temperatureWetBulbGlobe { get; set; }

    /**
    * Wind chill apparent temperature. Above 65°F, equals temperature. Expressed in Fahrenheit when units=e, Celsius when units=m, s, or h.
    *
    * @example -34
    */
    public int temperatureWindChill { get; set; }

    /**
    * UV Index description providing risk level of skin damage
    *
    * @example "High"
    */
    public required string uvDescription { get; set; }

    /**
    * TWC's proprietary UV index (-2=Not Available, -1=No Report, 0-2=Low, 3-5=Moderate, 6-7=High, 8-10=Very High, 11-16=Extreme)
    *
    * @example 6
    */
    public int uvIndex { get; set; }

    /**
    * Time observation is valid in local time (ISO 8601 format)
    *
    * @example "2023-01-01T12:00:00Z"
    */
    public required string validTimeLocal { get; set; }

    /**
    * Time observation is valid in UNIX epoch value
    *
    * @example 1369252800
    */
    public int validTimeUtc { get; set; }

    /**
    * Horizontal visibility. Expressed in miles when units=e, kilometers when units=m, s, or h. Values >10 reported as 999 (unlimited). Range 0 to 999.
    *
    * @example 10.2
    */
    public double visibility { get; set; }

    /**
    * Magnetic wind direction in degrees (0-359, where 0°=North, 90°=East, 180°=South, 270°=West)
    *
    * @example 60
    */
    public int windDirection { get; set; }

    /**
    * Cardinal wind direction abbreviation
    *
    * @example "ENE"
    */
    public required string windDirectionCardinal { get; set; }

    /**
    * Maximum wind gust speed. Expressed in mph when units=e or h, km/h when units=m, m/s when units=s.
    *
    * @example 10
    */
    public int? windGust { get; set; }

    /**
    * Sustained wind speed (10-minute average). Expressed in mph when units=e or h, km/h when units=m, m/s when units=s.
    *
    * @example 5
    */
    public int windSpeed { get; set; }

    /**
    * Text description of observed weather conditions (32 character phrase for English)
    *
    * @example "Rain/Freezing Rain/Windy"
    */
    public required string wxPhraseLong { get; set; }

    /**
    * Text description of observed weather conditions (22 character phrase, NULL for non-English languages)
    *
    * @example "Rain/Frz Rain/Wind"
    */
    public string? wxPhraseMedium { get; set; }

    /**
    * Text description of observed weather conditions (12 character phrase, NULL for non-English languages)
    *
    * @example "Frz Rain"
    */
    public string? wxPhraseShort { get; set; }
}
