using Newtonsoft.Json.Linq;

namespace WeatherMonitoringAndReportingService.FormatConverter
{
    public class JsonFormatConverter : IInputFormatConverter
    {
        public Weather ConvertToWeather(string weatherInput)
        {
            JObject jsonWeather = JObject.Parse(weatherInput);

            return new Weather
            {
                Location = (string)jsonWeather["Location"],
                Temperature = (double)jsonWeather["Temperature"],
                Humidity = (double)jsonWeather["Humidity"]
            };
        }
    }
}
