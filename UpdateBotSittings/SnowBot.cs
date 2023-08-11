using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.UpdateBotSittings
{
    public class SnowBot : IBots
    {
        private bool Enabled { get; set; }
        private double TemperatureThreshold { get; set; }
        private string Message { get; set; }


        public Settings GetSettings()
        {
            Settings settings = new Settings();
            settings.Message = Message;
            settings.Enabled = Enabled;
            settings.Threshold = TemperatureThreshold;
            return settings;
        }

        public void UpdateBotsSettings(JObject settings)
        {

            JObject snowBotSettings = (JObject)settings["SnowBot"];
            Enabled = (bool)snowBotSettings["enabled"];
            TemperatureThreshold = (double)snowBotSettings["temperatureThreshold"];
            Message = (string)snowBotSettings["message"];
        }
    }
}
