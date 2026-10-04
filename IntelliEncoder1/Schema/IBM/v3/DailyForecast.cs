

/** 
* Daily forecast response. Top-level arrays represent the 24-hour daily summary for each forecast day. The `daypart` array contains a single object whose inner arrays interleave day (D) and night (N) segments for each day. 
* 
*/
public class DailyForecastResponse
{
    /** 
    * Midnight-to-midnight daily maximum temperature for each forecast day. Covers the 24-hour period from 12:00 AM to 12:00 AM local time. Continues to display throughout the day, unlike `temperatureMax` which becomes null after 3:00 PM LAT. Units: °F when units=e, °C when units=m/s/h. 
    * 
    * 
    * @example [72,80,81,80] 
*/
    public int?[]? calendarDayTemperatureMax { get; set; }

    /** 
    * Midnight-to-midnight daily minimum temperature for each forecast day. Covers the 24-hour period from 12:00 AM to 12:00 AM local time. Units: °F when units=e, °C when units=m/s/h. 
    * 
    * 
    * @example [47,46,53,62] 
*/
    public int?[]? calendarDayTemperatureMin { get; set; }

    /** 
    * Full name of the day of week for each forecast day. Translated field — value depends on the `language` request parameter. 
    * 
    * 
    * @example ["Sunday","Monday","Tuesday","Wednesday"] 
*/
    public required string dayOfWeek { get; set; }

    /** 
    * UNIX epoch time (seconds) at which this forecast expires and should be refreshed from the API. 
    * 
    * 
    * @example [1777861596,1777861596,1777861596,1777861596] 
*/
    public required long[] expirationTimeUtc { get; set; }

    /** 
    * Human-readable description of the current lunar phase for each forecast day. Translated field — value depends on the `language` request parameter. 
    * 
    * 
    * @example ["Waning Gibbous","Waning Gibbous","Waning Gibbous","Waning Gibbous"] 
*/
    public required string[] moonPhase { get; set; }

    /** 
    * 3-character code representing the lunar phase for each forecast day. 
    * - `N` — New - `WXC` — Waxing Crescent - `FQ` — First Quarter - `WXG` — Waxing Gibbous - `F` — Full - `WNG` — Waning Gibbous - `LQ` — Last Quarter - `WNC` — Waning Crescent 
    * 
    * 
    * @example ["WNG","WNG","WNG","WNG"] 
*/
    public required string moonPhaseCode { get; set; }

    /** 
    * Day number within the monthly lunar cycle (0–29) for each forecast day. Day 0 is New Moon; day 15 is approximately Full Moon. 
    * 
    * 
    * @example [16,17,18,19] 
*/
    public required int[] moonPhaseDay { get; set; }

    /** 
    * First moonrise time in local time for each forecast day, in ISO 8601 format with UTC offset (YYYY-MM-DDTHH:MM:SS±HHmm). Reflects daylight saving conventions. Returns an empty string when no moonrise occurs on that day. 
    * 
    * 
    * @example ["2026-05-03T22:39:33-0400","2026-05-04T23:35:18-0400","","2026-05-06T00:25:14-0400"] 
*/
    public string?[]? moonriseTimeLocal { get; set; }

    /** 
    * First moonrise time as a UNIX epoch value (seconds) for each forecast day. Null when no moonrise occurs on that day. 
    * 
    * 
    * @example [1777862373,1777952118,null,1778041514] 
*/
    public long?[]? moonriseTimeUtc { get; set; }

    /** 
    * First moonset time in local time for each forecast day, in ISO 8601 format with UTC offset (YYYY-MM-DDTHH:MM:SS±HHmm). Reflects daylight saving conventions. 
    * 
    * 
    * @example ["2026-05-03T07:34:12-0400","2026-05-04T08:16:51-0400","2026-05-05T09:06:12-0400","2026-05-06T10:00:24-0400"] 
*/
    public string?[]? moonsetTimeLocal { get; set; }

    /** 
    * First moonset time as a UNIX epoch value (seconds) for each forecast day. Null when no moonset occurs on that day. 
    * 
    * 
    * @example [1777808052,1777897011,1777986372,1778076024] 
*/
    public long?[]? moonsetTimeUtc { get; set; }

    /** 
    * Narrative forecast for the full 24-hour period for each forecast day, up to 256 characters. When the maximum or minimum temperature is over 100°F or below 0°F, the wording changes to a specific temperature with unit (°F) instead of a range. Translated field — value depends on the `language` request parameter. 
    * 
    * 
    * @example ["Clear. Lows overnight in the mid 40s.","Mostly sunny. Highs in the low 80s and lows in the low 50s."] 
*/
    public required string[] narrative { get; set; }

    /** 
    * Forecasted measurable liquid precipitation (or liquid equivalent) during the 24-hour period for each forecast day. Units: inches when units=e, millimeters when units=m. 
    * 
    * 
    * @example [0,0,0,0.8] 
*/
    public required double[] qpf { get; set; }

    /** 
    * Forecasted measurable precipitation as ice during the 24-hour period for each forecast day. Units: inches when units=e, millimeters when units=m. 
    * 
    * 
    * @example [0,0,0,0] 
*/
    public double?[]? qpfIce { get; set; }

    /** 
    * Forecasted measurable precipitation as rain during the 24-hour period for each forecast day. Units: inches when units=e, millimeters when units=m. 
    * 
    * 
    * @example [0,0,0,0.8] 
*/
    public required double[] qpfRain { get; set; }

    /** 
    * Forecasted measurable precipitation as snow during the 24-hour period for each forecast day. Units: inches when units=e, centimeters when units=m. 
    * 
    * 
    * @example [0,0,0,0] 
*/
    public required double[] qpfSnow { get; set; }

    /** 
    * Sunrise time in local time for each forecast day, in ISO 8601 format with UTC offset. Reflects daylight saving conventions. For Arctic and Antarctic regions where sunrise does not occur, this value may equal `sunsetTimeLocal` (both set to 12:01 AM). 
    * 
    * 
    * @example ["2026-05-03T06:46:38-0400","2026-05-04T06:45:40-0400","2026-05-05T06:44:43-0400","2026-05-06T06:43:47-0400"] 
*/
    public string?[]? sunriseTimeLocal { get; set; }

    /** 
    * Sunrise time as a UNIX epoch value (seconds) for each forecast day. 
    * 
    * 
    * @example [1777805198,1777891540,1777977883,1778064227] 
*/
    public long?[]? sunriseTimeUtc { get; set; }

    /** 
    * Sunset time in local time for each forecast day, in ISO 8601 format with UTC offset. Reflects daylight saving conventions. For Arctic and Antarctic regions where sunset does not occur, this value may equal `sunriseTimeLocal` (both set to 12:01 AM). 
    * 
    * 
    * @example ["2026-05-03T20:22:22-0400","2026-05-04T20:23:08-0400","2026-05-05T20:23:54-0400","2026-05-06T20:24:40-0400"] 
*/
    public string?[]? sunsetTimeLocal { get; set; }

    /** 
    * Sunset time as a UNIX epoch value (seconds) for each forecast day. 
    * 
    * 
    * @example [1777854142,1777940588,1778027034,1778113480] 
*/
    public long?[]? sunsetTimeUtc { get; set; }

    /** 
    * Daily maximum temperature for the 7:00 AM – 7:00 PM local period for each forecast day. Equivalent to the daytime (`D`) daypart temperature. Recommended for displaying the daytime high in multi-day forecasts as it aligns with daypart narratives and icon codes. Becomes null after 3:00 PM LAT because the daytime high has already occurred. Units: °F when units=e, °C when units=m/s/h. 
    * 
    * 
    * @example [null,80,81,80] 
*/
    public int?[]? temperatureMax { get; set; }

    /** 
    * Daily minimum temperature for the 7:00 PM – 7:00 AM local period for each forecast day. Equivalent to the nighttime (`N`) daypart temperature. Incorporates hourly forecasts through 8:00 AM the following morning to better capture morning lows. Recommended for displaying the overnight low in multi-day forecasts. Units: °F when units=e, °C when units=m/s/h. 
    * 
    * 
    * @example [46,53,62,64] 
*/
    public required int[] temperatureMin { get; set; }

    /** 
    * Date and time when the forecast becomes valid, in local apparent time (LAT), in ISO 8601 format with UTC offset. Typically 7:00 AM LAT for each forecast day. 
    * 
    * 
    * @example ["2026-05-03T07:00:00-0400","2026-05-04T07:00:00-0400","2026-05-05T07:00:00-0400","2026-05-06T07:00:00-0400"] 
*/
    public required string[] validTimeLocal { get; set; }

    /** 
    * Date and time when the forecast becomes valid, as a UNIX epoch value (seconds). 
    * 
    * 
    * @example [1777806000,1777892400,1777978800,1778065200] 
*/
    public required long[] validTimeUtc { get; set; }

    /** 
    * Array containing a single `DaypartForecast` object. The object's inner arrays interleave day (D) and night (N) segments for each forecast day. Array length is (number of forecast days × 2). Index 0 is always the current day's daytime segment and is null after 3:00 PM LAT. 
    * 
    * 
    * @example [{"dayOrNight":[null,"N","D","N"],"daypartName":[null,"Tonight","Tomorrow","Tomorrow night"],"temperature":[null,46,80,53],"iconCode":[null,31,34,33],"narrative":[null,"Clear skies. Low 46F.","Sunny. High near 80F.","Clear skies. Low 53F."]}] 
*/
    public required DaypartForecast[] daypart { get; set; }

}

/** 
* Daypart forecast data containing interleaved day (D, 7 AM–7 PM) and night (N, 7 PM–7 AM) segments for all forecast days. Each property is an array where even indices correspond to daytime segments and odd indices to nighttime segments. Index 0 (the current day's daytime) is null after 3:00 PM Local Apparent Time. 
* 
*/
public class DaypartForecast
{
    /** 
    * Average cloud cover expressed as a percentage (0–100) for each 12-hour daypart period. 
    * 
    * 
    * @example [null,0,21,14,36,60] 
*/
    public int?[]? cloudCover { get; set; }

    /** 
    * Indicator of whether the daypart is daytime or nighttime. - `D` — Day (7:00 AM – 7:00 PM local) - `N` — Night (7:00 PM – 7:00 AM local) 
    * Index 0 is null after 3:00 PM LAT. 
    * 
    * 
    * @example [null,"N","D","N","D","N"] 
*/
    public string[]? dayOrNight { get; set; }

    /** 
    * Name of the 12-hour daypart. In the first 48 hours, uses relative names ("Today", "Tonight", "Tomorrow", "Tomorrow night"). Beyond 48 hours, uses day-of-week names. Translated field — value depends on the `language` request parameter. 
    * 
    * 
    * @example [null,"Tonight","Tomorrow","Tomorrow night","Tuesday","Tuesday night"] 
*/
    public string?[]? daypartName { get; set; }

    /** 
    * Integer code used as a lookup key to retrieve the appropriate weather icon for the forecasted conditions during each daypart. 
    * 
    * 
    * @example [null,31,34,33,34,27] 
*/
    public int?[]? iconCode { get; set; }

    /** 
    * Extended integer code representing the full set of sensible weather conditions for each daypart, providing higher precision than `iconCode`. 
    * 
    * 
    * @example [null,3100,3400,3300,3400,2700] 
*/
    public int?[]? iconCodeExtend { get; set; }

    /** 
    * Narrative forecast for the 12-hour daypart period. Translated field — value depends on the `language` request parameter. 
    * 
    * 
    * @example [null,"Clear skies. Low 46F. Winds light and variable.","Sunny, along with a few afternoon clouds. High near 80F. Winds WSW at 5 to 10 mph."] 
*/
    public string?[]? narrative { get; set; }

    /** 
    * Maximum probability of precipitation as a percentage (0–100) for each 12-hour daypart period. 
    * 
    * 
    * @example [null,2,3,1,2,7] 
*/
    public int?[]? precipChance { get; set; }

    /** 
    * Type of precipitation associated with the probability of precipitation value for display purposes. - `rain` — liquid precipitation - `snow` — frozen precipitation - `precip` — mixed or indeterminate precipitation type 
    * 
    * 
    * @example [null,"rain","rain","rain","rain","rain"] 
*/
    public string? precipType { get; set; }

    /** 
    * Forecasted measurable liquid precipitation (or liquid equivalent) during each 12-hour daypart period. Units: inches when units=e, millimeters when units=m. 
    * 
    * 
    * @example [null,0,0,0,0,0] 
*/
    public double?[]? qpf { get; set; }

    /** 
    * Forecasted measurable precipitation as ice during each 12-hour daypart period. Units: inches when units=e, millimeters when units=m. 
    * 
    * 
    * @example [null,0,0,0,0,0] 
*/
    public double?[]? qpfIce { get; set; }

    /** 
    * Forecasted measurable precipitation as rain during each 12-hour daypart period. Units: inches when units=e, millimeters when units=m. 
    * 
    * 
    * @example [null,0,0,0,0,0] 
*/
    public double?[]? qpfRain { get; set; }

    /** 
    * Forecasted measurable precipitation as snow during each 12-hour daypart period. Units: inches when units=e, centimeters when units=m. 
    * 
    * 
    * @example [null,0,0,0,0,0] 
*/
    public double?[]? qpfSnow { get; set; }

    /** 
    * Internal code associated with special weather qualifier conditions for each daypart. Null when no special qualifier applies. 
    * 
    * 
    * @example [null,null,null,null,null,null] 
*/
    public string?[]? qualifierCode { get; set; }

    /** 
    * Human-readable phrase describing any special weather qualifier conditions (e.g., "Winds could occasionally gust over 70 mph."). Null when no qualifier applies. Translated field — value depends on the `language` request parameter. 
    * 
    * 
    * @example [null,null,null,null,null,null] 
*/
    public string?[]? qualifierPhrase { get; set; }

    /** 
    * Average relative humidity as a percentage (0–100) for each 12-hour daypart. Defined as the ratio of water vapor present to the amount required to saturate the air at the current temperature. 
    * 
    * 
    * @example [null,63,40,52,44,56] 
*/
    public int?[]? relativeHumidity { get; set; }

    /** 
    * Snow accumulation range for the 12-hour daypart period, expressed as a string (e.g., "3-5", "<1", "30+"). Empty string when no snow accumulation is expected. 
    * 
    * 
    * @example [null,"","","","",""] 
*/
    public string?[]? snowRange { get; set; }

    /** 
    * Representative temperature for each 12-hour daypart period. - For daytime (D) segments: maximum temperature between 7:00 AM and 7:00 PM - For nighttime (N) segments: minimum temperature between 7:00 PM and 7:00 AM, 
    * incorporating hourly forecasts through 8:00 AM the next morning to better 
    * capture morning lows. 
    * Units: °F when units=e, °C when units=m/s/h. 
    * 
    * 
    * @example [null,46,80,53,81,62] 
*/
    public int?[]? temperature { get; set; }

    /** 
    * Apparent temperature that accounts for the combined effect of warm temperatures and high humidity on exposed human skin (heat index). Only relevant for warm conditions. Units: °F when units=e, °C when units=m/s/h. 
    * 
    * 
    * @example [null,61,80,76,81,77] 
*/
    public int?[]? temperatureHeatIndex { get; set; }

    /** 
    * Apparent temperature that accounts for the combined effect of cold temperatures and wind speed on exposed human skin (wind chill). Only relevant for cold conditions. Units: °F when units=e, °C when units=m/s/h. 
    * 
    * 
    * @example [null,46,47,53,54,62] 
*/
    public int?[]? temperatureWindChill { get; set; }

    /** 
    * Description of thunderstorm probability for the 12-hour daypart period. Corresponds to `thunderIndex` values 0–5. Translated field — value depends on the `language` request parameter. 
    * - `0` — No thunder - `1` — Thunder possible - `2` — Thunder expected - `3` — Severe thunderstorms possible - `4` — Severe thunderstorms likely - `5` — High risk of severe thunderstorms 
    * 
    * 
    * @example [null,"No thunder","No thunder","No thunder","No thunder","No thunder"] 
*/
    public string? thunderCategory { get; set; }

    /** 
    * Numeric enumeration of thunderstorm probability for each 12-hour daypart period (0–5), where 0 = No thunder and 5 = High risk of severe thunderstorms. See `thunderCategory` for descriptive labels. 
    * 
    * 
    * @example [null,0,0,0,0,0] 
*/
    public int?[]? thunderIndex { get; set; }

    /** 
    * UV Index risk level description for each 12-hour daypart. Complements `uvIndex` with a human-readable risk category. Night dayparts always report "Low" or "Not Available". Translated field — value depends on the `language` request parameter. 
    * - `-2` → Not Available - `-1` → No Report - `0–2` → Low - `3–5` → Moderate - `6–7` → High - `8–10` → Very High - `11–16` → Extreme 
    * 
    * 
    * @example [null,"Low","Very High","Low","Very High","Low"] 
*/
    public string? uvDescription { get; set; }

    /** 
    * Maximum UV index during each 12-hour daypart period. Night dayparts always report 0. 
    * 
    * 
    * @example [null,0,9,0,9,0] 
*/
    public int?[]? uvIndex { get; set; }

    /** 
    * Average wind direction in true heading (magnetic) notation for each 12-hour daypart, expressed in degrees (0–359). Wind direction is always expressed as the direction from which the wind originates — a North wind blows from North to South. 
    * 
    * 
    * @example [null,275,237,203,191,202] 
*/
    public int?[]? windDirection { get; set; }

    /** 
    * Average wind direction in 16-point cardinal notation for each 12-hour daypart. Translated field — value depends on the `language` request parameter. 
    * 
    * 
    * @example [null,"W","WSW","SSW","S","SSW"] 
*/
    public string? windDirectionCardinal { get; set; }

    /** 
    * Human-readable phrase describing wind direction and speed for each 12-hour daypart (e.g., "Winds SSE at 5 to 10 mph."). Wind speed is the 10-minute average sustained wind speed; gusts are reported separately. Translated field — value depends on the `language` request parameter. 
    * 
    * 
    * @example [null,"Winds light and variable.","Winds WSW at 5 to 10 mph.","Winds SSW at 5 to 10 mph."] 
*/
    public string?[]? windPhrase { get; set; }

    /** 
    * Maximum sustained wind speed (10-minute average) forecast for each 12-hour daypart period. Wind is treated as a vector with both direction and magnitude. Sudden brief variations are wind gusts, reported separately. Units: mph when units=e, km/h when units=m, m/s when units=s, mph when units=h. 
    * 
    * 
    * @example [null,4,8,8,11,11] 
*/
    public int?[]? windSpeed { get; set; }

    /** 
    * Sensible weather phrase describing current conditions for each daypart, up to 32 characters for English. May exceed 32 characters for other languages. Translated field — value depends on the `language` request parameter. 
    * 
    * 
    * @example [null,"Clear","Mostly Sunny","Mostly Clear","Mostly Sunny","Mostly Cloudy"] 
*/
    public string?[]? wxPhraseLong { get; set; }

    /** 
    * Abbreviated sensible weather phrase for each daypart, up to 12 characters. 
    * 
    * 
    * @example [null,"Clear","M Sunny","M Clear","M Sunny","M Cloudy"] 
*/
    public string?[]? wxPhraseShort { get; set; }

}

