using Newtonsoft.Json.Linq;
using System.Xml;
using WeatherMonitoringAndReportingService.FormatConverter;

namespace WeatherMonitoringAndReportingService
{
    public class InputHandler
    {
        public IInputFormatConverter DetermaineInputConverter(string weatherInput)
        {
            try
            {
                JObject jsonWeather = JObject.Parse(weatherInput);
                return new JsonFormatConverter();
            }
            catch (Exception ex)
            {
                try
                {
                    XmlDocument xmlInput = new XmlDocument();
                    xmlInput.LoadXml(weatherInput);
                    return new XmlFormatConverter();
                }
                catch { return null; }
            }
        }
    }
}
