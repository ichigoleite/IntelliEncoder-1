using System.Data;
using System.Net.Http.Json;
using IntelliEncoder1.Core;
using IntelliEncoder1.Records.IS1;
using IntelliEncoder1.Schema.IBM.v3;
using IntelliEncoder1.Schema.IntelliEncoder;

namespace IntelliEncoder1.Inputs.TWC.Data.IS1;

public partial class InputsTWCDataIS1
{



    public async Task<IS1HourlyForecast?> HourlyForecast(LFRecordLocation location)
    {
        IS1HourlyForecast data = new()
        {
            Location = location.obsStn ?? "",
        };

        // Grab data.
        try
        {
            HourlyForecastResponse? hourly = await Client.GetFromJsonAsync<HourlyForecastResponse>($"https://api.weather.com/v3/wx/forecast/hourly/2day?geocode={location.lat},{location.@long}&language={TWCConfig.Language}&units={TWCConfig.Units}&format=json&apiKey={TWCConfig.APIKey}");

            if (hourly == null)
            {
                throw new NoNullAllowedException("TWC API returned null!");
            }

            if (hourly.validTimeUtc != null)
            {
                for (var i = 0; i >= hourly.validTimeUtc.Length; i++)
                {
                    data.Hours.Add(new()
                    {
                        MaxTemp = hourly.temperature![i],
                        MinTemp = hourly.temperature![i],
                        WindSpeed = hourly.windSpeed![i],
                        WindDir = CardinalToWindIntMap[hourly.windDirectionCardinal![i]],
                        Temperature = hourly.temperature![i],
                        Condition = hourly.iconCodeExtend![i],
                        PrecipitationChance = hourly.precipChance![i]
                    });
                }
            }
            else
            {
                throw new NoNullAllowedException("No hourly forecast data!");
            }

            return data;

        }
        catch (Exception e)
        {
            Logger.Error($"Could not grab Current Conditions data for observation station {location.obsStn}!");
            Logger.Error(e.ToString());
            return null;
        }


    }
}