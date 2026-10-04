// This generates current observation data for the IntelliStar 1.

using IntelliEncoder1.Core;
namespace IntelliEncoder1.Records;

public class CurrentConditions : DataRecord
{
    // Location
    public string Location = "";
    // Expiration Time
    public long Expiration = ((DateTimeOffset)DateTime.UtcNow.AddHours(1)).ToUnixTimeSeconds();

    // skyCondition -> Icon Code Extended
    public int SkyCondition = 3200;
    // temp -> Temperature
    public int Temperature = 0;
    // humidity -> Relative Humidity
    public int RelativeHumidity = 0;
    // feelsLikeIndex -> Feels Like/Apparent Temperature (nullable)
    public int? FeelsLike = null;
    // heatIndex -> Heat Index (nullable)
    public int? HeatIndex = null;
    // uvIndex -> Ultraviolet Index
    public int UVIndex = 0;
    // dewpoint -> Dew Point
    public int DewPoint = 0;
    // pressureAltimeter -> Pressure Altimeter
    public double Pressure = 0.0;
    // visibility -> Visibility
    public double Visibility = 0.0;
    // windDirection -> Wind Direction (in cardinal, turned into equivalent int)
    public int WindDirection = 0;
    // windSpeed -> Wind Speed
    public int WindSpeed = 0;
    // gusts -> Wind Gusts (nullable)
    public int? WindGusts = null;
    // windChill -> Wind Chill (nullable)
    public int? WindChill = null;
    // pressure -> Mean Sea Level
    public double MeanSeaLevel = 0.0;
    // pressureTendency -> Pressure Tendency
    public int PressureTendency = 0;

    protected override async Task<string> GenerateInternal()
    {

        // Define base string.
        string recordBody = $"""

        # Current Conditions
        Log.info("IntelliEncoder 1 - Sending Current Conditions data for location {Location}...")

        # Generate data object.
        data = twc.Data()
        data.skyCondition = {SkyCondition} # Icon Code Extended
        data.temp = {Temperature} # Current Temperature
        data.humidity = {RelativeHumidity} # Relative Humidity
        data.feelsLikeIndex = {(FeelsLike == null ? "None" : FeelsLike.Value)} # Feels Like
        data.heatIndex = {(HeatIndex == null ? "None" : HeatIndex.Value)} # Heat Index
        data.uvIndex = {UVIndex} # UV Index
        data.dewpoint = {DewPoint} # Dew Point
        data.altimeter = {Pressure} # Pressure (Altimeter)
        data.visibility = {Visibility} # Visibility
        data.windDirection = {WindDirection} # Wind Direction
        data.windSpeed = {WindSpeed} # Wind Speed
        data.gusts = {(WindGusts == null ? "None" : WindGusts.Value)} # Wind Gusts
        data.windChill = {(WindChill == null ? "None" : WindChill.Value)} # Wind Chill
        data.pressure = {MeanSeaLevel} # Pressure (Mean Sea Level)
        data.pressureTendency = {PressureTendency} # Pressure (Tendency)

        # Set data.
        wxdata.setData("{Location}", "obs", data, {Expiration})

        # Finish!
        Log.info("IntelliEncoder 1 - Current Conditions for {Location} processed!")
        """;

        return recordBody;
    }
}