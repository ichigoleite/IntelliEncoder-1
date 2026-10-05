using System.Data;
using System.Net.Http.Json;
using IntelliEncoder1.Core;
using IntelliEncoder1.Core.IS1;
using IntelliEncoder1.Records.IS1;
using IntelliEncoder1.Schema.IBM.v3;
using IntelliEncoder1.Schema.IntelliEncoder;

namespace IntelliEncoder1.Inputs.TWC.Data.IS1;

public partial class InputsTWCDataIS1
{

    public async Task<IS1DataRecord[]?> DailyForecast(LFRecordLocation location)
    {
        IS1DaypartForecast data = new()
        {
            Location = location.coopId ?? "",
        };
        IS1DailyForecast data_daily = new()
        {
            Location = location.coopId ?? "",
        };

        // Grab data.
        try
        {
            DailyForecastResponse? daily = await Client.GetFromJsonAsync<DailyForecastResponse>($"https://api.weather.com/v3/wx/forecast/daily/7day?geocode={location.lat},{location.@long}&language={TWCConfig.Language}&units={TWCConfig.Units}&format=json&apiKey={TWCConfig.APIKey}");

            if (daily == null)
            {
                throw new NoNullAllowedException("TWC API returned null!");
            }

            if (daily.validTimeUtc != null)
            {
                for (var i = 0; i < daily.validTimeUtc.Length; i++)
                {
                    if (DRConfig.DaypartForecast)
                    {
                        data.Dayparts.Add(new()
                        {
                            Name = daily.daypart[0].daypartName![i]!,
                            Phrase = daily.daypart[0].narrative?[i],
                            Icon = (int)daily.daypart[0].iconCodeExtend![i]!,
                            Temp = (int)daily.daypart[0].temperature![i]!,
                            IsNight = daily.daypart[0].dayOrNight![i]! == "D" ? false : true
                        });
                    }
                    if (DRConfig.DailyForecast)
                    {
                        data_daily.Days.Add(new()
                        {
                            MaxTemp = daily.temperatureMax?[i],
                            MinTemp = daily.temperatureMin?[i],
                            DayIcon = daily.daypart[0].iconCodeExtend?[i],
                            NightIcon = daily.daypart[0].iconCodeExtend?[i + 1],
                        });
                    }
                }
            }
            else
            {
                throw new NoNullAllowedException("No daily forecast data!");
            }

            return [data, data_daily];

        }
        catch (Exception e)
        {
            Logger.Error($"Could not grab Daily Forecast data for location {location.coopId}!");
            Logger.Error(e.ToString());
            return null;
        }


    }
}