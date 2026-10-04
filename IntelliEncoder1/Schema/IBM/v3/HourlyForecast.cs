namespace IntelliEncoder1.Schema.IBM.v3;

/** 
* Array-based response where each index position corresponds to a single forecast hour in 
* chronological order. Field names are sorted alphabetically in the response for presentation 
* purposes only and do not represent the API response sort order. 
* 
*/
public class HourlyForecastResponse
{
    /** 
    * Hourly average cloud cover expressed as a percentage. Acceptable values are 0 to 100. 
    * 
    * @example [0] 
*/
    public int[]? cloudCover { get; set; }

    /** 
    * Day of the week for the forecast hour. Available values: Sunday, Monday, Tuesday, 
    * Wednesday, Thursday, Friday, Saturday. 
    * 
    * **Note:** Supports multiple languages. Include a valid language code in the request URL 
    * to receive translated values. 
    * 
    * 
    * @example ["Monday"] 
*/
    public string[]? dayOfWeek { get; set; }

    /** 
    * Indicates whether the forecast hour falls during daytime or nighttime based on the local 
    * apparent time of the location. 
    * 
    * - `D` = Day 
    * - `N` = Night 
    * - `X` = Missing (applicable to extreme northern and southern hemispheres) 
    * 
    * 
    * @example ["N"] 
*/
    public string[]? dayOrNight { get; set; }

    /** 
    * The time when the forecast data expires, expressed as a UNIX epoch timestamp (seconds since January 1, 1970 UTC). 
    * 
    * @example [1777864855] 
*/
    public long[]? expirationTimeUtc { get; set; }

    /** 
    * A numeric code used to look up the corresponding weather icon. Represents the forecasted weather conditions for the hour. 
    * 
    * @example [31] 
*/
    public int[]? iconCode { get; set; }

    /** 
    * Extended numeric code representing the full set of sensible weather conditions for the hour. 
    * 
    * @example [3100] 
*/
    public int[]? iconCodeExtend { get; set; }

    /** 
    * Hourly maximum probability of precipitation expressed as a percentage. Acceptable values are 0 to 100. 
    * 
    * @example [1] 
*/
    public int[]? precipChance { get; set; }

    /** 
    * Short text describing the expected precipitation type associated with the `precipChance` 
    * parameter. Available values: 
    * 
    * - `rain` 
    * - `snow` 
    * - `precip` (any type of precipitation) 
    * 
    * 
    * @example ["rain"] 
*/
    public string[]? precipType { get; set; }

    /** 
    * Hourly mean sea level pressure. 
    * 
    * @example [30.08] 
*/
    public double[]? pressureMeanSeaLevel { get; set; }

    /** 
    * The forecasted measurable precipitation (liquid or liquid equivalent) for the upcoming 
    * hour. For example, if the local time is 8:35 am, the returned value represents the 
    * timeframe of 9:00 am to 10:00 am. 
    * 
    * - If `units=e`, values are in inches. 
    * - If `units=m`, values are in millimeters. 
    * 
    * 
    * @example [0] 
*/
    public double[]? qpf { get; set; }

    /** 
    * The forecasted hourly freezing rain accumulation for the upcoming hour. For example, if 
    * local time is 8:35 am, the returned value represents the timeframe of 9:00 am to 
    * 10:00 am. Actual ice accumulation on a given surface may depend on non-meteorological 
    * factors such as the presence of treatment chemicals. 
    * 
    * - Precision to hundredths when in inches. 
    * - Precision to tenths when in millimeters. 
    * 
    * 
    * @example [0] 
*/
    public double?[]? qpfIce { get; set; }

    /** 
    * The forecasted measurable rain accumulation for the upcoming hour. 
    * 
    * @example [0] 
*/
    public double[]? qpfRain { get; set; }

    /** 
    * The forecasted hourly snow accumulation for the upcoming hour. For example, if the local 
    * time is 8:35 am, the returned value represents the timeframe of 9:00 am to 10:00 am. 
    * 
    * - If `units=e`, values are in inches. 
    * - If `units=m`, values are in centimeters. 
    * 
    * 
    * @example [0] 
*/
    public double[]? qpfSnow { get; set; }

    /** 
    * The ratio of water vapor in the air relative to the amount required for saturation at a constant temperature. Always expressed as a percentage. Acceptable values are 0 to 100. 
    * 
    * @example [52] 
*/
    public int[]? relativeHumidity { get; set; }

    /** 
    * The identifier of a tropical system currently impacting or forecasted to impact the 
    * requested location at the specified hour. The presence of a `stormId` does not indicate 
    * the level or timing of the impact (whether imminent, occurring, or ending). Returns 
    * `null` when no tropical system is affecting the forecast. Format varies by source and 
    * is not globally unique. 
    * 
    * 
    * @example ["EP022002"] 
*/
    public string?[]? stormId { get; set; }

    /** 
    * The temperature of the air measured by a thermometer 1.5 meters (4.5 feet) above the 
    * ground, shaded from other elements. Acceptable values are -140 to 140 (°F). 
    * 
    * - If `units=e`, values are in Fahrenheit. 
    * - If `units=m`, `s`, or `h`, values are in Celsius. 
    * 
    * 
    * @example [58] 
*/
    public int[]? temperature { get; set; }

    /** 
    * The temperature to which air must be cooled at constant pressure to reach saturation. 
    * The dew point is an indirect measure of humidity and will never exceed the air 
    * temperature. When dew point and temperature are equal, clouds or fog typically form. 
    * Acceptable values are -80 to 100 (°F) or -62 to 37 (°C). 
    * 
    * - If `units=e`, values are in Fahrenheit. 
    * - If `units=m`, `s`, or `h`, values are in Celsius. 
    * 
    * 
    * @example [40] 
*/
    public int[]? temperatureDewPoint { get; set; }

    /** 
    * Apparent temperature representing what the air feels like on exposed human skin due to 
    * the combined effect of wind chill or heat index. 
    * 
    * - When temperature is 65°F or higher, this value represents the computed heat index. 
    * - When temperature is below 65°F, this value represents the computed wind chill. 
    * 
    * Acceptable values are -140 to 140. 
    * 
    * - If `units=e`, values are in Fahrenheit. 
    * - If `units=m`, `s`, or `h`, values are in Celsius. 
    * 
    * 
    * @example [58] 
*/
    public int?[]? temperatureFeelsLike { get; set; }

    /** 
    * Apparent temperature representing what the air feels like on exposed human skin due to 
    * the combined effect of warm temperatures and high humidity. When the temperature is 
    * below 65°F, this value is set equal to the actual temperature. 
    * 
    * - If `units=e`, values are in Fahrenheit. 
    * - If `units=m`, `s`, or `h`, values are in Celsius. 
    * 
    * 
    * @example [58] 
*/
    public int[]? temperatureHeatIndex { get; set; }

    /** 
    * Apparent temperature representing what the air feels like on exposed human skin due to 
    * the combined effect of cold temperatures and wind speed. When the temperature is above 
    * 65°F, this value is set equal to the actual temperature. 
    * 
    * - If `units=e`, values are in Fahrenheit. 
    * - If `units=m`, `s`, or `h`, values are in Celsius. 
    * 
    * 
    * @example [58] 
*/
    public int[]? temperatureWindChill { get; set; }

    /** 
    * Text description of the UV index indicating the associated risk level of skin damage 
    * due to sun exposure. Corresponds to the `uvIndex` value as follows: 
    * 
    * - `-2` = Not Available 
    * - `-1` = No Report 
    * - `0` to `2` = Low 
    * - `3` to `5` = Moderate 
    * - `6` to `7` = High 
    * - `8` to `10` = Very High 
    * - `11` to `16` = Extreme 
    * 
    * 
    * @example ["Low"] 
*/
    public string[]? uvDescription { get; set; }

    /** 
    * Hourly maximum UV index. Acceptable values are -2 to 16: 
    * 
    * - `-2` = Not Available 
    * - `-1` = No Report 
    * - `0` to `2` = Low 
    * - `3` to `5` = Moderate 
    * - `6` to `7` = High 
    * - `8` to `10` = Very High 
    * - `11` to `16` = Extreme 
    * 
    * 
    * @example [0] 
*/
    public int[]? uvIndex { get; set; }

    /** 
    * The time for which the forecast is valid, expressed in local apparent time. 
    * Format: `YYYY-MM-DDTHH:MM:SS±NNNN` where `NNNN` is the GMT offset in hours and minutes. 
    * 
    * 
    * @example ["2026-05-04T00:00:00-0400"] 
*/
    public string[]? validTimeLocal { get; set; }

    /** 
    * The time for which the forecast is valid, expressed as a UNIX epoch timestamp (seconds since January 1, 1970 UTC). 
    * 
    * @example [1777867200] 
*/
    public long[]? validTimeUtc { get; set; }

    /** 
    * Horizontal visibility at the forecast location. May be reported as a fractional value 
    * when less than 2 miles. Values of zero can occur with dense fog, heavy snow, smoke, or 
    * intense rainfall. Acceptable values are 0 to 10. For values less than 1, visibility is 
    * reported with two decimal places in both metric and imperial units. 
    * 
    * - If `units=e`, values are in miles. 
    * - If `units=m` or `h`, values are in kilometers. 
    * 
    * 
    * @example [10] 
*/
    public double[]? visibility { get; set; }

    /** 
    * Hourly average wind direction in true heading notation. Acceptable values are 0 to 359. 
    * 
    * @example [279] 
*/
    public int[]? windDirection { get; set; }

    /** 
    * Hourly average wind direction in cardinal notation. Available values: N, NNE, NE, ENE, 
    * E, ESE, SE, SSE, S, SSW, SW, WSW, W, WNW, NW, NNW. 
    * 
    * **Note:** Supports multiple languages. Include a valid language code in the request URL 
    * to receive translated values. 
    * 
    * 
    * @example ["W"] 
*/
    public string[]? windDirectionCardinal { get; set; }

    /** 
    * The maximum expected wind gust speed for the forecast hour. Individual array items are null when no significant wind gusts are expected. 
    * 
    * @example [18] 
*/
    public int?[]? windGust { get; set; }

    /** 
    * The forecasted sustained wind speed at the top of the hour. Wind is treated as a vector 
    * with both direction and magnitude. The sustained wind speed represents a 10-minute 
    * average. Sudden or brief variations are reported separately in `windGust`. Wind direction 
    * is expressed as the direction from which the wind blows (a North wind blows from North 
    * to South). All wind values are calculated at 10 meters above ground level. 
    * 
    * - If `units=e`, values are in miles per hour (mph). 
    * - If `units=m` or `h`, values are in kilometers per hour (km/h). 
    * - If `units=s`, values are in meters per second (m/s). 
    * 
    * 
    * @example [2] 
*/
    public int[]? windSpeed { get; set; }

    /** 
    * A text description of the forecasted hourly sensible weather conditions. Up to 32 
    * characters for English phrases; phrases in other languages may exceed this limit. 
    * 
    * **Note:** Supports multiple languages. Include a valid language code in the request URL 
    * to receive translated values. 
    * 
    * 
    * @example ["Clear"] 
*/
    public string[]? wxPhraseLong { get; set; }

    /** 
    * A short text description of the forecasted hourly sensible weather conditions. Up to 12 characters. Individual array items may be null. 
    * 
    * @example ["Clear"] 
*/
    public string?[]? wxPhraseShort { get; set; }

    /** 
    * A number indicating the impact level of the forecasted weather for the hour. Can be 
    * used to determine graphical treatment of weather displays (for example, applying red 
    * font on weather.com). Acceptable values are 1 to 6: 
    * 
    * - `1` = No threat 
    * - `6` = Dangerous / life threatening 
    * 
    * 
    * @example [1] 
*/
    public int[]? wxSeverity { get; set; }

}

