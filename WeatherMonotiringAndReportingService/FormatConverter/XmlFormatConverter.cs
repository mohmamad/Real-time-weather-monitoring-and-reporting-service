using System.Xml;

namespace WeatherMonitoringAndReportingService.FormatConverter
{
    public class XmlFormatConverter : IInputFormatConverter
    {
        public Weather ConvertToWeather(string weatherInput)
        {
            XmlDocument xmlInput = new XmlDocument();
            xmlInput.LoadXml(weatherInput);

            XmlNodeList location = xmlInput.GetElementsByTagName("Location");
            XmlNodeList temperature = xmlInput.GetElementsByTagName("Temperature");
            XmlNodeList humidity = xmlInput.GetElementsByTagName("Humidity");

            return new Weather
            {
                Location = location[0].InnerText,
                Temperature = double.Parse(temperature[0].InnerText),
                Humidity = double.Parse(humidity[0].InnerText)

            };
        }
    }
}
