using Newtonsoft.Json.Linq;

namespace WeatherMonitoringAndReportingService.UpdateBotSittings
{
    public class SunBot : IBots
    {
        public bool Enabled { get; set; }
        public double TemperatureThreshold { get; set; }
        public string Message { get; set; }

        public string GetBotMessage(Weather weather)
        {
            if (!Enabled)
                return null;
            if (TemperatureThreshold < weather.Temperature)
                return Message;
            return null;
        }

        public void SetBotConfiguration(JObject Configuration)
        {
            JObject sunBotSettings = (JObject)Configuration["SunBot"];
            Enabled = (bool)sunBotSettings["enabled"];
            TemperatureThreshold = (double)sunBotSettings["temperatureThreshold"];
            Message = (string)sunBotSettings["message"];
        }
    }
}
