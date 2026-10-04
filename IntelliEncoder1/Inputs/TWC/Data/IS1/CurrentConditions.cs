using System.Data;
using System.Net.Http.Json;
using IntelliEncoder1.Core;
using IntelliEncoder1.Records.IS1;
using IntelliEncoder1.Schema.IBM;
using IntelliEncoder1.Schema.IntelliEncoder;

namespace IntelliEncoder1.Inputs.TWC.Data.IS1;

public partial class InputsTWCDataIS1
{

    // Turns TWC wind cardinal to equivlant int.
    private readonly static Dictionary<string, int> CardinalToWindIntMap = new(){
        {"CALM", 0},
        {"N", 1},
        {"NNE", 2},
        {"NE", 3},
        {"ENE", 4},
        {"E", 5},
        {"ESE", 6},
        {"SE", 7},
        {"SSE", 8},
        {"S", 9},
        {"SSW", 10},
        {"SW", 11},
        {"WSW", 12},
        {"W", 13},
        {"WNW", 14},
        {"NW", 15},
        {"NNW", 16},
        {"VAR", 17}
    };

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
                Expiration = cc.expirationTimeUtc,
                SkyCondition = cc.iconCodeExtend,
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