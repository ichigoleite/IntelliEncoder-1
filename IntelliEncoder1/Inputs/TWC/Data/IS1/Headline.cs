using System.Data;
using System.Net.Http.Json;
using IntelliEncoder1.Core;
using IntelliEncoder1.Records.IS1;
using IntelliEncoder1.Schema.IBM.v3;
using IntelliEncoder1.Schema.IntelliEncoder;

namespace IntelliEncoder1.Inputs.TWC.Data.IS1;

public partial class InputsTWCDataIS1
{
    // there's only lines for flash flood warning, severe thunderstorm warning, and tornado warning
    // therefore we only include PILs for those, everything else it wouldn't matter anyways - IL
    public static Dictionary<string, string[]> PhenomenaToPIL = new()
    {
        // Rain/Flood
        {"FF_W", ["FFW", "001"]},
        {"FA_W", ["FFW", "001"]},
        {"FF_W", ["FFW", "001"]},
        {"FF_W", ["FFW", "001"]},
        {"flood_W", ["FFW", "001"]},
        {"flood_WR", ["FFW", "001"]},
        {"flood_WO", ["FFW", "001"]},
        {"flood_WY", ["FFW", "001"]},
        {"TFL_A", ["FFW", "001"]},
        {"TFL_W", ["FFW", "001"]},
        {"TRF_A", ["FFW", "001"]},
        {"TRF_W", ["FFW", "001"]},
        {"TRF_S", ["FFW", "001"]},
        {"TFL_A", ["FFW", "001"]},
        {"FL_W", ["FFW", "001"]},
        // Thunderstorm
        {"SV_W", ["SVR", "001"]},
        {"TO_W", ["TOR", "001"]},
        {"TTS_A", ["SVR", "001"]},
        {"TTS_W", ["SVR", "001"]},
        {"TTS_S", ["SVR", "001"]},
        {"TTS_Y", ["SVR", "001"]},
    };

    public async Task<IS1Headline?> Headline(LFRecordLocation location)
    {
        if (location.zoneId == null)
        {
            Logger.Info($"{location.coopId} doesn't have an alert zone.");
            return null;
        }

        IS1Headline data = new()
        {
            Area = location.zoneId,
            County = location.cntyId
        };

        // Grab data.
        try
        {
            AlertsHeadlinesResponse? alerts = await Client.GetFromJsonAsync<AlertsHeadlinesResponse>($"https://api.weather.com/v3/alerts/headlines?areaId={location.zoneId}:{location.siteId}&language={TWCConfig.Language}&format=json&apiKey={TWCConfig.APIKey}");

            if (alerts == null)
            {
                throw new NoNullAllowedException("TWC API returned null!");
            }

            foreach (Alert alert in alerts.alerts)
            {
                string key = $"{alert.phenomena}_{alert.significance}";
                string[]? pil = null;
                if (PhenomenaToPIL.ContainsKey(key))
                {
                    pil = PhenomenaToPIL[key];
                }
                data.Alerts.Add(new()
                {
                    Text = alert.headlineText,
                    Phenomena = alert.phenomena,
                    Significance = alert.significance,
                    PIL = pil?[0] ?? "SVS",
                    PILExt = pil?[1] ?? "001",
                    Expiration = DateTimeOffset.FromUnixTimeSeconds(alert.expireTimeUTC).DateTime
                });
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