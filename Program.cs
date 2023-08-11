using WeatherMonitoringAndReportingService;
using WeatherMonitoringAndReportingService.FormatConverter;
using WeatherMonitoringAndReportingService.UpdateBotSittings;

internal class Program
{
    private static void Main(string[] args)
    {
        string xml = "{\"Location\": \"City Name\", \"Temperature\": 32, \"Humidity\": 40}";
        IInputFormatConverter inputFormatConverter = new JsonFormatConverter();
        Console.WriteLine(inputFormatConverter.ConvertToWeather(xml).Temperature);
    }
}