using System.Data.SQLite;
using System.Net.Http.Json;
using IntelliEncoder1.Core;
using IntelliEncoder1.Core.IS1;
using IntelliEncoder1.Records.IS1;
using Dapper;
using IntelliEncoder1.Schema.IntelliEncoder;
namespace IntelliEncoder1.Inputs;

public class InputsFlightAwareMain
{
    Logger Logger;
    Config Config;

    public InputsFlightAwareMain(Config config)
    {
        // Set config.
        Config = config;

        // Make logger.
        Logger = new("Inputs - Data Retriever (Main) - FlightAware", config);
    }

    public async Task<IS1DataRecord[]> RetrieveDataIS1(IS1StarConfig starConfig)
    {


        Logger.Info($"Starting flight delay retrieval for IntelliStar 1 {starConfig.HeadendID}...");
        List<IS1DataRecord> dataRecords = [];

        // Grab all airport delays
        try
        {
            List<IS1Delay> delays = [];

            AirportDelaysResponse? airports = await Config.client.GetFromJsonAsync<AirportDelaysResponse>("https://flightxml.flightaware.com/mapi/v13/AirportDelays");

            if (airports != null)
            {
                List<string> addedAP = [];

                // Convert ICAO to IATA.
                string apPath = Path.Combine(AppContext.BaseDirectory, "Custom", "Airports.db");
                SQLiteConnection sqlite = new($"Data Source={apPath}", true);
                sqlite.Open();

                foreach (AirportDelay delay in airports.AirportDelaysResult.delays)
                {
                    string iata = "JFK";
                    var cmd = sqlite.CreateCommand();
                    cmd.CommandText = $"SELECT count(*) FROM airports WHERE icao = '{delay.airport}' LIMIT 1";
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 0)
                    {
                        iata = delay.airport.Substring(1, 3);
                    }
                    else
                    {
                        Airport location = sqlite.QuerySingle<Airport>($"SELECT * FROM airports WHERE icao = '{delay.airport}' LIMIT 1");
                        if (location.iata == null)
                        {
                            iata = delay.airport;
                        }
                        else
                        {
                            iata = location.iata;
                        }
                    }


                    if (addedAP.Contains(iata))
                    {
                        continue;
                    }
                    else
                    {
                        if (starConfig.Airports.Contains(iata))
                        {
                            bool departure = false;
                            bool arrival = false;
                            int deptrend = 0;
                            int arrtrend = 0;
                            foreach (string reason in delay.reasons)
                            {
                                if (reason.Contains("departure"))
                                {
                                    departure = true;
                                    if (reason.Contains("decreasing"))
                                    {
                                        deptrend = 2;
                                    }
                                    else if (reason.Contains("increasing"))
                                    {
                                        deptrend = 1;
                                    }
                                }
                                else if (reason.Contains("arrival") || reason.Contains("inbound"))
                                {
                                    arrival = true;
                                    if (reason.Contains("decreasing"))
                                    {
                                        arrtrend = 2;
                                    }
                                    else if (reason.Contains("increasing"))
                                    {
                                        arrtrend = 1;
                                    }
                                }
                            }

                            delays.Add(new()
                            {
                                Airport = iata,
                                Arrival = new()
                                {
                                    Duration = arrival ? delay.delay_secs : 0,
                                    Trend = arrtrend,
                                    Reason = arrival ? delay.category : "",
                                },
                                Departure = new()
                                {
                                    Duration = departure ? delay.delay_secs : 0,
                                    Trend = deptrend,
                                    Reason = departure ? delay.category : "",
                                },
                            });

                            addedAP.Add(iata);
                        }
                    }
                }

                foreach (string iata in starConfig.Airports)
                {
                    if (!addedAP.Contains(iata))
                    {
                        delays.Add(new()
                        {
                            Airport = iata,
                        });
                    }
                }

                IS1AirportDelays airportDelay = new()
                {
                    Delays = [.. delays]
                };
                dataRecords.Add(airportDelay);
                sqlite.Close();
            }
            else
            {

            }
        }
        catch (Exception e)
        {
            Logger.Error("Could not grab airport delays.");
            Logger.Error(e.ToString());
        }

        Logger.Info($"Grabbed airport delays for IntelliStar 1 {starConfig.HeadendID}...");

        return [.. dataRecords];
    }
}