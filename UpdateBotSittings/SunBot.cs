using Newtonsoft.Json.Linq;

namespace WeatherMonitoringAndReportingService.UpdateBotSittings
{
    public class SunBot : IBots
    {
        private bool Enabled { get; set; }
        private double TemperatureThreshold { get; set; }
        private string Message { get; set; }

        public Settings GetSettings()
        {
            Settings settings = new Settings();
            settings.BotName = "SunBot";
            settings.Message = Message;
            settings.Enabled = Enabled;
            settings.Threshold = TemperatureThreshold;
            return settings;
        }

        public void UpdateBotsSettings(JObject settings)
        {
            JObject sunBotSettings = (JObject)settings["SunBot"];
            Enabled = (bool)sunBotSettings["enabled"];
            TemperatureThreshold = (double)sunBotSettings["temperatureThreshold"];
            Message = (string)sunBotSettings["message"];
        }
    }
}
