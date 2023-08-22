using Newtonsoft.Json.Linq;

namespace WeatherMonitoringAndReportingService.UpdateBotSittings
{
    public class RainBot : IBots
    {
        private bool Enabled { get; set; }
        private double HumidityThreshold { get; set; }
        private string Message { get; set; }

        public string GetBotMessage(Weather weather)
        {
            if (!Enabled)
                return null;
            if (HumidityThreshold < weather.Humidity)
                return Message;
            return null;
        }


        public void SetBotConfiguration(JObject Configuration)
        {
            JObject rainBotSettings = (JObject)Configuration["RainBot"];
            Enabled = (bool)rainBotSettings["enabled"];
            HumidityThreshold = (double)rainBotSettings["humidityThreshold"];
            Message = (string)rainBotSettings["message"];

        }


    }
}
