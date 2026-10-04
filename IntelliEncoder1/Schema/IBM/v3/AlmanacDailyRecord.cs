

/** Historical daily climate statistics for one weather station. Each property is a parallel array indexed by date within the requested range. */
public class AlmanacDailyRecord
{
    /** 
    * Time interval indicator for the almanac data. Always 'D' for daily records. 
    * 
    * @example ["D"] 
*/
    public string[]? almanacInterval { get; set; }

    /** 
    * Calendar date for each record in MMDD format (e.g., '1231' for December 31). 
    * 
    * @example ["1231"] 
*/
    public string[]? almanacRecordDate { get; set; }

    /** 
    * Number of years of historical data used to compute the statistics for each date. Nullable when insufficient historical data is available. 
    * 
    * @example [30] 
*/
    public int?[]? almanacRecordPeriod { get; set; }

    /** 
    * Year in which the all-time record high temperature occurred for each date. Nullable when no record data is available. 
    * 
    * @example [1984] 
*/
    public int?[]? almanacRecordYearMax { get; set; }

    /** 
    * Year in which the all-time record low temperature occurred for each date. Nullable when no record data is available. 
    * 
    * @example [1983] 
*/
    public int?[]? almanacRecordYearMin { get; set; }

    /** 
    * 30-year average daily precipitation for each date, in the units specified by the `units` request parameter. Nullable when no historical data is available. 
    * 
    * @example [144.78] 
*/
    public double?[]? precipitationAverage { get; set; }

    /** 
    * 30-year average daily snowfall accumulation for each date, in the units specified by the `units` request parameter. Nullable when no historical snow data is available. 
    * 
    * @example [null] 
*/
    public double?[]? snowAccumulationAverage { get; set; }

    /** 
    * ICAO or national weather service station identifier for the reporting station. 
    * 
    * @example ["095874"] 
*/
    public string[]? stationId { get; set; }

    /** 
    * Human-readable name of the weather station. Nullable when station name data is unavailable. 
    * 
    * @example ["MILLEDGEVILLE"] 
*/
    public string?[]? stationName { get; set; }

    /** 
    * 30-year average daily maximum temperature for each date, in the units specified by the `units` request parameter. Nullable when no historical data is available. 
    * 
    * @example [14] 
*/
    public int?[]? temperatureAverageMax { get; set; }

    /** 
    * 30-year average daily minimum temperature for each date, in the units specified by the `units` request parameter. Nullable when no historical data is available. 
    * 
    * @example [1] 
*/
    public int?[]? temperatureAverageMin { get; set; }

    /** 
    * 30-year average daily mean temperature for each date, in the units specified by the `units` request parameter. Nullable when no historical data is available. 
    * 
    * @example [8] 
*/
    public int?[]? temperatureMean { get; set; }

    /** 
    * All-time record high temperature for each date, in the units specified by the `units` request parameter. Nullable when no record data is available. 
    * 
    * @example [27] 
*/
    public int?[]? temperatureRecordMax { get; set; }

    /** 
    * All-time record low temperature for each date, in the units specified by the `units` request parameter. Nullable when no record data is available. 
    * 
    * @example [-14] 
*/
    public int?[]? temperatureRecordMin { get; set; }

}