using System.Data;
using System.Net.Http.Json;
using IntelliEncoder1.Core;
using IntelliEncoder1.Records.IS1;
using IntelliEncoder1.Schema.IBM.v3;
using IntelliEncoder1.Schema.IntelliEncoder;

namespace IntelliEncoder1.Inputs.TWC.Data.IS1;

public partial class InputsTWCDataIS1
{



    public async Task<IS1Headline?> Headline(LFRecordLocation location)
    {
        if (location.zoneId == null)
        {
            Logger.Info($"{location.coopId} doesn't have an alert zone.");
            return null;
        }

        IS1Headline data = new()
        {
            Area = location.zoneId
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
                data.Alerts.Add(new()
                {
                    Text = alert.headlineText,
                    Phenomena = alert.phenomena,
                    Significance = alert.significance,
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