using Newtonsoft.Json.Linq;

namespace WeatherMonitoringAndReportingService.UpdateBotSittings
{
    public class RainBot : IBots
    {
        private bool Enabled { get; set; }
        private double HumidityThreshold { get; set; }
        private string Message { get; set; }



        public Settings GetSettings()
        {
            Settings settings = new Settings();
            settings.Message = Message;
            settings.Enabled = Enabled;
            settings.Threshold = HumidityThreshold;
            return settings;
        }

        public void UpdateBotsSettings(JObject settings)
        {
            JObject rainBotSettings = (JObject)settings["RainBot"];
            Enabled = (bool)rainBotSettings["enabled"];
            HumidityThreshold = (double)rainBotSettings["humidityThreshold"];
            Message = (string)rainBotSettings["message"];

        }
    }
}
