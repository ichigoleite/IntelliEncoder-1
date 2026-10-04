namespace IntelliEncoder1.Schema.IBM.v3;

/** Response containing alert headlines and pagination metadata */
public class AlertsHeadlinesResponse
{
    /** 
    * Pagination metadata for the response 
    * 
    * @example {"next":null} 
*/
    public required Metadata metadata { get; set; }

    /** 
    * Array of active alert headlines 
    * 
    * @example [] 
*/
    public required Alert[] alerts { get; set; }

}

/** Metadata for pagination */
public class Metadata
{
    /** 
    * Pagination token for retrieving the next set of results. If null, all data has been retrieved. If not null, make additional API calls with this value in the `next` parameter until it returns null. 
    * 
    * 
    * @example 1475863030000 
*/
    public required long next { get; set; }

}

/** Weather alert headline information */
public class Alert
{
    /** 
    * Unique key for the detail record. This attribute is required to access detailed alert information from the Alerts Detail API. 
    * 
    * @example "77128ec9-cebe-46b2-8d72-d1f6860454e7" 
*/
    public required string detailKey { get; set; }

    /** 
    * Code representing the nature of the alert message: 
    * - 1: New - Initial information 
    * - 2: Update - Updates existing message 
    * - 3: Cancel - Cancels the earlier message 
    * 
    * 
    * @example 1 
*/
    public required int messageTypeCode { get; set; }

    /** 
    * Nature of the alert message 
    * 
    * @example "New" 
*/
    public required string messageType { get; set; }

    /** 
    * Product line identifier for the alert 
    * 
    * @example "TOR" 
*/
    public required string productIdentifier { get; set; }

    /** 
    * Phenomena code representing the type of event 
    * 
    * @example "TO" 
*/
    public required string phenomena { get; set; }

    /** 
    * Indicates the type of alert (Watch, Warning, Advisory, etc.). 
    * 
    * **Standard Significance Codes:** 
    * - A: Watch 
    * - B: Bulletin 
    * - L: Local Alerts 
    * - M: Message 
    * - O: Outlook 
    * - R: Report 
    * - S: Statement 
    * - W: Warning 
    * - Y: Advisory 
    * 
    * **JMA Significance Codes:** 
    * - Y: Advisory 
    * - W: Warning 
    * - E: Extreme 
    * 
    * **Environment Canada Significance Codes:** 
    * - A: Watch (non-landbased) 
    * - AO: Orange Watch 
    * - AR: Red Watch 
    * - AY: Yellow Watch 
    * - S: Statement 
    * - W: Warning (non-landbased) 
    * - WO: Orange Warning 
    * - WR: Red Warning 
    * - WY: Yellow Warning 
    * - Y: Advisory (non-landbased) 
    * - YO: Orange Advisory 
    * - YR: Red Advisory 
    * - YY: Yellow Advisory 
    * 
    * 
    * @example "W" 
*/
    public required string significance { get; set; }

    /** 
    * Unique tracking number for the event, represented as either a 4-digit number or a checksum 
    * 
    * @example "160" 
*/
    public required string eventTrackingNumber { get; set; }

    /** 
    * Code of the issuing office 
    * 
    * @example "KTFX" 
*/
    public required string officeCode { get; set; }

    /** 
    * Name of the issuing office 
    * 
    * @example "Great Falls" 
*/
    public string? officeName { get; set; }

    /** 
    * Administrative district of the issuing office. Supports translation. 
    * 
    * @example "Montana" 
*/
    public string? officeAdminDistrict { get; set; }

    /** 
    * State/province code for the issuing office's administrative district 
    * 
    * @example "MT" 
*/
    public string? officeAdminDistrictCode { get; set; }

    /** 
    * Country code of the issuing office 
    * 
    * @example "US" 
*/
    public string? officeCountryCode { get; set; }

    /** 
    * Description of the event triggering the alert. Supports translation. 
    * 
    * @example "Tornado Warning" 
*/
    public required string eventDescription { get; set; }

    /** 
    * Code representing the severity level of the event: 
    * - 1: Extreme - Extraordinary threat to life or property 
    * - 2: Severe - Significant threat to life or property 
    * - 3: Moderate - Possible threat to life or property 
    * - 4: Minor - Minimal to no known threat to life or property 
    * - 5: Unknown - Severity unknown 
    * 
    * 
    * @example 1 
*/
    public required int severityCode { get; set; }

    /** 
    * Severity level of the event in the alert message 
    * 
    * @example "Severe" 
*/
    public required string severity { get; set; }

    /** 
    * Color assigned to alert from the issuing agency (e.g., Red, Yellow, Orange). Supports translation. 
    * 
    * @example "Orange" 
*/
    public string? sourceColorName { get; set; }

    /** 
    * Categories of the alert event 
    * 
    * @example [{"category":"Met","categoryCode":"meteorological"}] 
*/
    public required Category[] categories { get; set; }

    /** 
    * Recommended response actions for the target audience 
    * 
    * @example [{"responseType":"Prepare","responseTypeCode":"prepare"}] 
*/
    public required ResponseType[] responseTypes { get; set; }

    /** 
    * Urgency level of the alert: 
    * - Immediate: Responsive action should be taken immediately 
    * - Expected: Responsive action should be taken soon (within next hour) 
    * - Future: Responsive action should be taken in the near future 
    * - Past: Responsive action is no longer required 
    * - Unknown: Urgency not known 
    * 
    * 
    * @example "Expected" 
*/
    public required string urgency { get; set; }

    /** 
    * Code representing the urgency level: 
    * - 1: Immediate 
    * - 2: Expected 
    * - 3: Future 
    * - 4: Past 
    * - 5: Unknown 
    * 
    * 
    * @example 2 
*/
    public required int urgencyCode { get; set; }

    /** 
    * Describes the likelihood of the event occurring: 
    * - Observed: Determined to have occurred or to be ongoing 
    * - Likely: Likely (p > ~50%) 
    * - Possible: Possible but not likely (p <= ~50%) 
    * - Unlikely: Not expected to occur (p ~ 0) 
    * - Unknown: Certainty unknown 
    * 
    * 
    * @example "Observed" 
*/
    public required string certainty { get; set; }

    /** 
    * Code representing certainty: 
    * - 1: Observed 
    * - 2: Likely 
    * - 3: Possible 
    * - 4: Unlikely 
    * - 5: Unknown 
    * 
    * 
    * @example 1 
*/
    public required int certaintyCode { get; set; }

    /** 
    * Local date and time when the alert becomes effective (ISO 8601 format) 
    * 
    * @example "2017-10-07T12:30:00-05:00" 
*/
    public string? effectiveTimeLocal { get; set; }

    /** 
    * Time zone abbreviation for the effective time 
    * 
    * @example "EDT" 
*/
    public string? effectiveTimeLocalTimeZone { get; set; }

    /** 
    * Local date and time when the alert expires (ISO 8601 format) 
    * 
    * @example "2017-10-07T19:30:00-05:00" 
*/
    public required string expireTimeLocal { get; set; }

    /** 
    * Time zone abbreviation for the expiration time 
    * 
    * @example "EDT" 
*/
    public required string expireTimeLocalTimeZone { get; set; }

    /** 
    * Expiration date and time in UNIX epoch seconds (UTC) 
    * 
    * @example 1373914800 
*/
    public required long expireTimeUTC { get; set; }

    /** 
    * Onset date and time of the information in the alert message (ISO 8601 format) 
    * 
    * @example "2017-10-07T17:30:00-05:00" 
*/
    public string? onsetTimeLocal { get; set; }

    /** 
    * Time zone abbreviation for the onset time 
    * 
    * @example "EDT" 
*/
    public string? onsetTimeLocalTimeZone { get; set; }

    /** 
    * Flood-specific information. Only present for flood-related alerts. 
    * 
    * @example null 
*/
    public Flood? flood { get; set; }

    /** 
    * Identifies type of location: 
    * - C: County 
    * - Z: Zone 
    * - CLC: Canada Location 
    * 
    * 
    * @example "C" 
*/
    public required string areaTypeCode { get; set; }

    /** 
    * Centroid latitude of the location where the event occurs 
    * 
    * @example 48.65 
*/
    public double? latitude { get; set; }

    /** 
    * Centroid longitude of the location where the event occurs 
    * 
    * @example -113.13 
*/
    public double? longitude { get; set; }

    /** 
    * Unique location code for the area where the event occurs 
    * 
    * @example "MTC035" 
*/
    public required string areaId { get; set; }

    /** 
    * Mixed case name of the location 
    * 
    * @example "Glacier" 
*/
    public required string areaName { get; set; }

    /** 
    * IANA time zone identifier 
    * 
    * @example "America/Chicago" 
*/
    public string? ianaTimeZone { get; set; }

    /** 
    * Admin district code (state/province abbreviation) 
    * 
    * @example "MT" 
*/
    public string? adminDistrictCode { get; set; }

    /** 
    * Admin district name (state/province) 
    * 
    * @example "Montana" 
*/
    public string? adminDistrict { get; set; }

    /** 
    * Two-character ISO country code 
    * 
    * @example "US" 
*/
    public required string countryCode { get; set; }

    /** 
    * Country name. Supports translation. 
    * 
    * @example "UNITED STATES OF AMERICA" 
*/
    public required string countryName { get; set; }

    /** 
    * Headline summarizing the alert for the location. Supports translation. 
    * 
    * Format patterns: 
    * - {event} is in effect 
    * - {event} until {DOW HH:MM AM/PM TZCODE} 
    * - {event} from {DOW HH:MM AM/PM TZCODE} until {DOW HH:MM AM/PM TZCODE} 
    * 
    * 
    * @example "Flood Warning until SAT 12:30PM CDT" 
*/
    public required string headlineText { get; set; }

    /** 
    * AI-generated summary of the event. When a summaryHeadline is not available, this field is populated with the value from headlineText. Currently only generated for US alerts in English. 
    * 
    * 
    * @example "Flood Warning: Snowmelt/ice causing rise to 803ft. Two Rivers near Hallock, MT. From this afternoon. Stay off banks." 
*/
    public required string summaryHeadline { get; set; }

    /** 
    * Originating source of the alert 
    * 
    * @example "NWS" 
*/
    public required string source { get; set; }

    /** 
    * Disclaimer related to the alert data. Supports translation. 
    * 
    * @example null 
*/
    public string? disclaimer { get; set; }

    /** 
    * Local date and time when the alert was issued (ISO 8601 format) 
    * 
    * @example "2017-10-07T11:30:00-05:00" 
*/
    public required string issueTimeLocal { get; set; }

    /** 
    * Time zone abbreviation for the issue time 
    * 
    * @example "CDT" 
*/
    public required string issueTimeLocalTimeZone { get; set; }

    /** 
    * Checksum value uniquely identifying the bulletin 
    * 
    * @example "a463d8adbd563a981673b1beab2b04994e80078a" 
*/
    public required string identifier { get; set; }

    /** 
    * Alert process time in UNIX epoch seconds (UTC) 
    * 
    * @example 1475863030000 
*/
    public required long processTimeUTC { get; set; }

    /** 
    * Local date and time when the alert is expected to end (ISO 8601 format). May be null for indefinitely long events (in which case the headline will indicate the event is "in effect"). 
    * 
    * 
    * @example "2021-10-04T16:30:00-04:00" 
*/
    public string? endTimeLocal { get; set; }

    /** 
    * Time zone abbreviation for the alert's end time 
    * 
    * @example "EDT" 
*/
    public string? endTimeLocalTimeZone { get; set; }

    /** 
    * End date and time for the event in UNIX epoch seconds (UTC) 
    * 
    * @example 1633379400 
*/
    public long? endTimeUTC { get; set; }

    /** 
    * Suggested display order for alerts when multiple alerts are active for a location. Lower values (e.g., 17) should be displayed before higher values (e.g., 207). 
    * 
    * **Important Notes:** 
    * - This is an internal ranking by The Weather Company based on multiple factors that can change 
    * - Not an official ranking by government agencies 
    * - Primarily intended for latitude/longitude-based queries, though populated for all location query types 
    * - Retrieve all alerts (repeated calls until next is null) before sorting by displayRank 
    * - Do not assume displayRank associations with specific event types; these may change without notice 
    * - Use of this field is solely at your own risk 
    * 
    * 
    * @example 17 
*/
    public required int displayRank { get; set; }

}

/** Category information for the alert event */
public class Category
{
    /** 
    * Category description of the event: 
    * - Geo: Geophysical (inc. landslide) 
    * - Met: Meteorological (inc. flood) 
    * - Safety: General emergency and public safety 
    * - Security: Law enforcement, military, homeland and local/private security 
    * - Rescue: Rescue and recovery 
    * - Fire: Fire suppression and rescue 
    * - Health: Medical and public health 
    * - Env: Pollution and other environmental 
    * - Transport: Public and private transportation 
    * - Infra: Utility, telecommunication, other non-transport infrastructure 
    * - CBRNE: Chemical, Biological, Radiological, Nuclear or High-Yield Explosive threat or attack 
    * - Other: Other events 
    * 
    * 
    * @example "Met" 
*/
    public required string category { get; set; }

    /** 
    * Code representing the category: 
    * - 1: Geo 
    * - 2: Met 
    * - 3: Safety 
    * - 4: Security 
    * - 5: Rescue 
    * - 6: Fire 
    * - 7: Health 
    * - 8: Env 
    * - 9: Transport 
    * - 10: Infra 
    * - 11: CBRNE 
    * - 12: Other 
    * 
    * 
    * @example 2 
*/
    public required int categoryCode { get; set; }

}

/** Recommended response action for the target audience */
public class ResponseType
{
    /** 
    * Description of the recommended action: 
    * - Shelter: Take shelter in place or per instruction 
    * - Evacuate: Relocate as instructed in the instruction 
    * - Prepare: Make preparations per the instruction 
    * - Execute: Execute a pre-planned activity identified in instruction 
    * - Avoid: Avoid the subject event as per the instruction 
    * - Monitor: Attend to information sources as described in instruction 
    * - Assess: Evaluate the information in this message (should not be used in public warning applications) 
    * - AllClear: The subject event no longer poses a threat or concern and any follow on action is described in instruction 
    * - None: No action recommended 
    * 
    * 
    * @example "Evacuate" 
*/
    public required string responseType { get; set; }

    /** 
    * Code representing the recommended response action: 
    * - 1: Shelter 
    * - 2: Evacuate 
    * - 3: Prepare 
    * - 4: Execute 
    * - 5: Avoid 
    * - 6: Monitor 
    * - 7: Assess 
    * - 8: AllClear 
    * - 9: None 
    * 
    * 
    * @example 2 
*/
    public required int responseTypeCode { get; set; }

}

/** Flood-specific information for flood-related alerts */
public class Flood
{
    /** 
    * Local date and time when the flood reached its crest (ISO 8601 format) 
    * 
    * @example "2017-10-07T21:30:00-05:00" 
*/
    public string? floodCrestTimeLocal { get; set; }

    /** 
    * Time zone abbreviation for the flood crest date and time 
    * 
    * @example "EDT" 
*/
    public string? floodCrestTimeLocalTimeZone { get; set; }

    /** 
    * Local date and time when the flood event ended (ISO 8601 format) 
    * 
    * @example "2017-10-07T23:30:00-05:00" 
*/
    public string? floodEndTimeLocal { get; set; }

    /** 
    * Time zone abbreviation for the flood end date and time 
    * 
    * @example "EDT" 
*/
    public string? floodEndTimeLocalTimeZone { get; set; }

    /** 
    * Immediate cause of the flood event: 
    * - Excessive Rainfall 
    * - Snowmelt 
    * - Rain and Snowmelt 
    * - Dam or Levee Failure 
    * - Ice Jam 
    * - Glacier-Dammed Lake Outburst 
    * - Rain and/or Snowmelt and/or Ice Jam 
    * - Upstream Flooding plus Storm Surge 
    * - Upstream Flooding plus Tidal Effects 
    * - Elevated Upstream Flow plus Tidal Effects 
    * - Wind and/or Tidal Effects 
    * - Upstream Dam or Reservoir Release 
    * - Other Multiple Causes 
    * - Other Effects 
    * - Unknown 
    * 
    * 
    * @example "Excessive Rainfall" 
*/
    public string? floodImmediateCause { get; set; }

    /** 
    * Code representing the immediate cause of the flood: 
    * - ER: Excessive Rainfall 
    * - SM: Snowmelt 
    * - RS: Rain and Snowmelt 
    * - DM: Dam or Levee Failure 
    * - IJ: Ice Jam 
    * - GO: Glacier-Dammed Lake Outburst 
    * - IC: Rain and/or Snowmelt and/or Ice Jam 
    * - FS: Upstream Flooding plus Storm Surge 
    * - FT: Upstream Flooding plus Tidal Effects 
    * - ET: Elevated Upstream Flow plus Tidal Effects 
    * - WT: Wind and/or Tidal Effects 
    * - DR: Upstream Dam or Reservoir Release 
    * - MC: Other Multiple Causes 
    * - OT: Other Effects 
    * - UU: Unknown 
    * 
    * 
    * @example false 
*/
    public string? floodImmediateCauseCode { get; set; }

    /** 
    * Identifier code for the flood location, as assigned by NWS 
    * 
    * @example "SMBM8" 
*/
    public string? floodLocationId { get; set; }

    /** 
    * Name of the flood location corresponding to the flood location ID 
    * 
    * @example "Saint Mary River at International boundary" 
*/
    public string? floodLocationName { get; set; }

    /** 
    * Status indicating whether the flood reached record levels: 
    * - A record flood is not expected 
    * - Near record or record flood expected 
    * - Flood without a period of record to compare 
    * - For areal flood warnings, areal flash flood products, and flood advisories (point and areal) 
    * - N/A 
    * 
    * 
    * @example "Near record or record flood expected" 
*/
    public string? floodRecordStatus { get; set; }

    /** 
    * Code representing the flood record status: 
    * - NO: A record flood is not expected 
    * - NR: Near record or record flood expected 
    * - UU: Flood without a period of record to compare 
    * - OO: For areal flood warnings, areal flash flood products, and flood advisories (point and areal) 
    * 
    * 
    * @example "NR" 
*/
    public string? floodRecordStatusCode { get; set; }

    /** 
    * Description of the flood severity level: 
    * - None 
    * - N/A 
    * - Minor 
    * - Moderate 
    * - Major 
    * - Unknown 
    * 
    * 
    * @example "Minor" 
*/
    public string? floodSeverity { get; set; }

    /** 
    * Code representing the flood severity level: 
    * - N: None 
    * - 0: N/A 
    * - 1: Minor 
    * - 2: Moderate 
    * - 3: Major 
    * - U: Unknown 
    * 
    * 
    * @example "0" 
*/
    public string? floodSeverityCode { get; set; }

    /** 
    * Local date and time when the flood event starts (ISO 8601 format) 
    * 
    * @example "2017-10-07T20:30:00-05:00" 
*/
    public string? floodStartTimeLocal { get; set; }

    /** 
    * Time zone abbreviation for the flood start date and time 
    * 
    * @example "EDT" 
*/
    public string? floodStartTimeLocalTimeZone { get; set; }

}

