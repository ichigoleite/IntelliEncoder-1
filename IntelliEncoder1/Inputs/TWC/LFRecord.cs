using System.Net.Http.Json;
using System.Text.RegularExpressions;
using IntelliEncoder1.Core;
using IntelliEncoder1.Schema.IBM;
using IntelliEncoder1.Schema.IntelliEncoder;
using MistWX_i2Me.Schema.ibm;
namespace IntelliEncoder1.Inputs.TWC;

public class InputsTWCLFRecord
{
    Logger Logger;
    Config Config;

    public InputsTWCLFRecord(Config config)
    {
        // Set config.
        Config = config;

        // Make logger.
        Logger = new("Inputs - Data Retriever (LFRecord) - TWC", config);
    }

    public async Task<LFRecordLocation> GrabLocation(int type, string country, string id)
    {
        // Set current values.
        LFRecordLocation tempLF = new LFRecordLocation()
        {
            locType = type.ToString(),
            cntryCd = country,
            locId = id
        };

        string genTecci = tempLF.locType + tempLF.cntryCd + tempLF.locId;
        tempLF.primTecci = "T" + genTecci;
        tempLF.coopId = genTecci;

        // Fallback values
        tempLF.cityNm = tempLF.locId.ToUpper();
        tempLF.prsntNm = tempLF.locId;
        tempLF.tPrsntNm = tempLF.locId;
        tempLF.lat = "41.45";
        tempLF.@long = "-74.42";
        tempLF.wrlsPrsntNm = tempLF.locId;
        tempLF.regSat = null;
        tempLF.ssRad = null;
        tempLF.lsRad = null;
        tempLF.siteId = "INTL";
        tempLF.stCd = "INTL";
        tempLF.cntyNm = $"{tempLF.locId} County";
        tempLF.gmtDiff = "-5.00";
        tempLF.cliStn = "305310";
        tempLF.tmZnNm = "Eastern Standard Time";
        tempLF.tmZnAbbr = "EST";
        tempLF.wmoId = null;
        tempLF.arptId = null;
        tempLF.idxId = "KMGJ";
        tempLF.skiId = null;
        tempLF.active = "1";
        tempLF.cntyFips = "99999";
        tempLF.dySTInd = "N";
        tempLF.dySTAct = "0.00";
        tempLF.elev = "0";
        tempLF.dmaCd = null;
        tempLF.siteId = country;

        // Grab data.
        ConfigClassInputsTWC twcConfig = Config.config.Inputs.TWC;
        LocServPointResponse? point = await Config.client.GetFromJsonAsync<LocServPointResponse>($"https://api.weather.com/v3/location/point?locid={id}:{type}:{country}&language={twcConfig.Language}&format=json&apiKey={twcConfig.APIKey}");

        if (point != null)
        {
            if (point.location != null)
            {
                // Location... location.
                tempLF.lat = Math.Round(point.location.latitude, 2).ToString();
                tempLF.@long = Math.Round(point.location.longitude, 2).ToString();

                // Location Name
                // Set it to Display Name
                if (point.location.displayName != null)
                {
                    tempLF.cityNm = point.location.displayName.ToUpper();
                    tempLF.prsntNm = point.location.displayName;
                    tempLF.tPrsntNm = point.location.displayName;
                    if (point.location.displayName.Length >= 16)
                    {
                        tempLF.wrlsPrsntNm = point.location.displayName.Substring(0, 15) + ".";
                    }
                    else
                    {
                        tempLF.wrlsPrsntNm = point.location.displayName;
                    }
                    // Set it to City
                }
                else if (point.location.city != null)
                {
                    tempLF.cityNm = point.location.city.ToUpper();
                    tempLF.prsntNm = point.location.city;
                    tempLF.tPrsntNm = point.location.city;
                    if (point.location.city.Length >= 16)
                    {
                        tempLF.wrlsPrsntNm = point.location.city.Substring(0, 15) + ".";
                    }
                    else
                    {
                        tempLF.wrlsPrsntNm = point.location.city;
                    }
                    // Set it to Locale 2
                }
                else if (point.location.locale != null && point.location.locale.locale2 != null)
                {
                    tempLF.cityNm = point.location.locale.locale2.ToUpper();
                    tempLF.prsntNm = point.location.locale.locale2;
                    tempLF.tPrsntNm = point.location.locale.locale2;
                    if (point.location.locale.locale2.Length >= 16)
                    {
                        tempLF.wrlsPrsntNm = point.location.locale.locale2.Substring(0, 15) + ".";
                    }
                    else
                    {
                        tempLF.wrlsPrsntNm = point.location.locale.locale2;
                    }
                    // Set it to Neighbourhood
                }
                else if (point.location.neighborhood != null)
                {
                    tempLF.cityNm = point.location.neighborhood.ToUpper();
                    tempLF.prsntNm = point.location.neighborhood;
                    tempLF.tPrsntNm = point.location.neighborhood;
                    if (point.location.neighborhood.Length >= 16)
                    {
                        tempLF.wrlsPrsntNm = point.location.neighborhood.Substring(0, 15) + ".";
                    }
                    else
                    {
                        tempLF.wrlsPrsntNm = point.location.neighborhood;
                    }
                    // Set to postal code
                }
                else if (point.location.postalCode != null)
                {
                    tempLF.cityNm = point.location.postalCode.ToUpper();
                    tempLF.prsntNm = point.location.postalCode;
                    tempLF.tPrsntNm = point.location.postalCode;
                    if (point.location.postalCode.Length >= 16)
                    {
                        tempLF.wrlsPrsntNm = point.location.postalCode.Substring(0, 15) + ".";
                    }
                    else
                    {
                        tempLF.wrlsPrsntNm = point.location.postalCode;
                    }
                    // Set it to Admin District
                }
                else if (point.location.adminDistrict != null)
                {
                    tempLF.cityNm = point.location.adminDistrict.ToUpper();
                    tempLF.prsntNm = point.location.adminDistrict;
                    tempLF.tPrsntNm = point.location.adminDistrict;
                    if (point.location.adminDistrict.Length >= 16)
                    {
                        tempLF.wrlsPrsntNm = point.location.adminDistrict.Substring(0, 15) + ".";
                    }
                    else
                    {
                        tempLF.wrlsPrsntNm = point.location.adminDistrict;
                    }
                    // Set it to Country
                }
                else if (point.location.country != null)
                {
                    tempLF.cityNm = point.location.country.ToUpper();
                    tempLF.prsntNm = point.location.country;
                    tempLF.tPrsntNm = point.location.country;
                    if (point.location.country.Length >= 16)
                    {
                        tempLF.wrlsPrsntNm = point.location.country.Substring(0, 15) + ".";
                    }
                    else
                    {
                        tempLF.wrlsPrsntNm = point.location.country;
                    }
                }

                // State code 
                // Set it to adminDistrictCode
                if (point.location.adminDistrictCode != null)
                {
                    tempLF.stCd = point.location.adminDistrictCode;
                }

                // County/Zone names
                // Set it to Locale 1
                if (point.location.locale != null && point.location.locale.locale1 != null)
                {
                    tempLF.cntyNm = point.location.locale.locale1;
                    // Set it to admin district
                }
                else if (point.location.adminDistrict != null)
                {
                    tempLF.cntyNm = point.location.adminDistrict;
                    // Set it to neighborhood
                }
                else if (point.location.neighborhood != null)
                {
                    tempLF.cntyNm = point.location.neighborhood;

                    // Set it to display name
                }
                else if (point.location.displayName != null)
                {
                    tempLF.cntyNm = point.location.displayName;
                    // Set it to city
                }
                else if (point.location.city != null)
                {
                    tempLF.cntyNm = point.location.city;
                    // Set it to countyId
                }
                else if (point.location.countyId != null)
                {
                    tempLF.cntyNm = point.location.countyId;
                }

                // Set countyId
                if (point.location.countyId != null)
                {
                    tempLF.cntyId = point.location.countyId;
                }

                // Set zoneId
                if (point.location.zoneId != null)
                {
                    tempLF.zoneId = point.location.zoneId;
                }

                // Set regionalSatellite
                if (point.location.regionalSatellite != null)
                {
                    tempLF.regSat = point.location.regionalSatellite;
                    tempLF.ssRad = point.location.regionalSatellite;
                    tempLF.lsRad = point.location.regionalSatellite;
                }

                // Set zip2locid
                if (point.location.postalCode != null)
                {
                    tempLF.zip2locId = point.location.postalCode;
                }

                // Set timezone
                if (point.location.ianaTimeZone != null)
                {
                    TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(point.location.ianaTimeZone);
                    tempLF.tmZnNm = tz.StandardName;
                    tempLF.tmZnAbbr = Regex.Replace(tz.StandardName, "[^A-Z]", "");
                    tempLF.gmtDiff = $"{tz.BaseUtcOffset.Hours}.{tz.BaseUtcOffset.ToString("mm")}";
                }

                // Set wmoId and pllnId
                if (point.location.pollenId != null)
                {
                    tempLF.pllnId = point.location.pollenId;
                    tempLF.wmoId = point.location.pollenId;
                }

                // Set dmaCd
                if (point.location.dmaCd != null)
                {
                    tempLF.dmaCd = point.location.dmaCd;
                }

                DateTime start45Day = DateTime.Now.Subtract(TimeSpan.FromDays(45));

                LocServNearAirportResponse? airport = await Config.client.GetFromJsonAsync<LocServNearAirportResponse>($"https://api.weather.com/v3/location/near?geocode={tempLF.lat},{tempLF.@long}&product=airport&format=json&apiKey={twcConfig.APIKey}");
                LocServNearSkiResponse? ski = await Config.client.GetFromJsonAsync<LocServNearSkiResponse>($"https://api.weather.com/v3/location/near?geocode={tempLF.lat},{tempLF.@long}&product=ski&format=json&apiKey={twcConfig.APIKey}");
                LocServNearObsResponse? obs = await Config.client.GetFromJsonAsync<LocServNearObsResponse>($"https://api.weather.com/v3/location/near?geocode={tempLF.lat},{tempLF.@long}&product=airport&format=json&apiKey={twcConfig.APIKey}");
                Almanac1DayResponse? al = await Config.client.GetFromJsonAsync<Almanac1DayResponse>($"https://api.weather.com/v3/wx/almanac/daily/45day?geocode={tempLF.lat},{tempLF.@long}&format=json&units={twcConfig.Units}&startDay={start45Day.ToString("dd")}&startMonth={start45Day.ToString("MM")}&apiKey={twcConfig.APIKey}");

                if (airport != null)
                {
                    if (airport.location != null)
                    {
                        if (airport.location.iataCode != null)
                        {
                            foreach (string? apId in airport.location.iataCode)
                            {
                                if (apId != null)
                                {
                                    tempLF.arptId = apId;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (ski != null)
                {
                    if (ski.location != null)
                    {
                        if (ski.location.skiId != null)
                        {
                            foreach (string? skiId in ski.location.skiId)
                            {
                                if (skiId != null)
                                {
                                    tempLF.skiId = skiId;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (obs != null)
                {
                    int obsIdx = 0;
                    if (obs.location != null)
                    {
                        if (obs.location.stationId != null)
                        {
                            foreach (string? obsId in obs.location.stationId)
                            {
                                if (obs.location != null)
                                {
                                    if (obsId != null)
                                    {
                                        if (obsIdx == 0)
                                        {
                                            tempLF.obsStn = obsId;
                                            tempLF.idxId = obsId;
                                        }
                                        else if (obsIdx == 1)
                                        {
                                            tempLF.secObsStn = obsId;
                                        }
                                        else if (obsIdx == 2)
                                        {
                                            tempLF.tertObsStn = obsId;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                        obsIdx += 1;
                                    }
                                }
                            }
                        }
                    }
                }

                if (al != null)
                {
                    if (al.stationId != null)
                    {
                        tempLF.cliStn = al.stationId.First();
                    }
                }

            }
            else
            {
                Logger.Warn($"Location {tempLF.locId} has no location data, generating fallback ones");
            }
        }
        // Return the generated LFRecordLocation.
        return tempLF;
    }
}