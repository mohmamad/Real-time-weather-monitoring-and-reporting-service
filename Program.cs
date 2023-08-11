using WeatherMonitoringAndReportingService;
using WeatherMonitoringAndReportingService.UpdateBotSittings;

internal class Program
{
    private static void Main(string[] args)
    {
        string xml = "<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>";
        IInputFormatConverter inputFormatConverter = new XmlFormatConverter();
        Console.WriteLine(inputFormatConverter.ConvertToWeather(xml).Location);
    }
}