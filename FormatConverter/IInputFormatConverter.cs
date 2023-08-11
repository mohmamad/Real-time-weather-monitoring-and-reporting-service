

namespace WeatherMonitoringAndReportingService.FormatConverter
{
    public interface IInputFormatConverter
    {
        public Weather ConvertToWeather(string weatherInput);
    }
}
