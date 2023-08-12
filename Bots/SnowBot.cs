using Newtonsoft.Json.Linq;

namespace WeatherMonitoringAndReportingService.UpdateBotSittings
{
    public class SnowBot : IBots
    {
        private bool Enabled { get; set; }
        private double TemperatureThreshold { get; set; }
        private string Message { get; set; }

        public string GetBotMessage(Weather weather)
        {
            if (!Enabled)
                return null;
            if (TemperatureThreshold > weather.Temperature)
                return Message;
            return null;
        }

        public void SetBotConfiguration(JObject Configuration)
        {
            JObject snowBotSettings = (JObject)Configuration["SnowBot"];
            Enabled = (bool)snowBotSettings["enabled"];
            TemperatureThreshold = (double)snowBotSettings["temperatureThreshold"];
            Message = (string)snowBotSettings["message"];
        }
    }
}
