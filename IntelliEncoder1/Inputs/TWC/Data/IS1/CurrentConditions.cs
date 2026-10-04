using System.Data;
using System.Net.Http.Json;
using IntelliEncoder1.Core;
using IntelliEncoder1.Records.IS1;
using IntelliEncoder1.Schema.IBM.v3;
using IntelliEncoder1.Schema.IntelliEncoder;

namespace IntelliEncoder1.Inputs.TWC.Data.IS1;

public partial class InputsTWCDataIS1
{

    public async Task<IS1CurrentConditions?> CurrentConditions(LFRecordLocation location)
    {
        IS1CurrentConditions data = new();

        // Grab data.
        try
        {
            CurrentObservation? cc = await Client.GetFromJsonAsync<CurrentObservation>($"https://api.weather.com/v3/wx/observations/current?geocode={location.lat},{location.@long}&language={TWCConfig.Language}&units={TWCConfig.Units}&format=json&apiKey={TWCConfig.APIKey}");

            if (cc == null)
            {
                throw new NoNullAllowedException("TWC API returned null!");
            }

            return new()
            {
                Location = location.obsStn ?? "",
                Expiration = cc.expirationTimeUtc + 3600,
                SkyCondition = cc.iconCodeExtend,
                Temperature = cc.temperature,
                RelativeHumidity = cc.relativeHumidity,
                FeelsLike = cc.temperatureFeelsLike,
                HeatIndex = cc.temperatureHeatIndex,
                UVIndex = cc.uvIndex,
                DewPoint = cc.temperatureDewPoint,
                Pressure = cc.pressureAltimeter,
                Visibility = cc.visibility,
                WindDirection = CardinalToWindIntMap[cc.windDirectionCardinal],
                WindSpeed = cc.windSpeed,
                WindGusts = cc.windGust,
                MeanSeaLevel = cc.pressureMeanSeaLevel,
                PressureTendency = cc.pressureTendencyCode
            };
        }
        catch (Exception e)
        {
            Logger.Error($"Could not grab Current Conditions data for observation station {location.obsStn}!");
            Logger.Error(e.ToString());
            return null;
        }


    }
}