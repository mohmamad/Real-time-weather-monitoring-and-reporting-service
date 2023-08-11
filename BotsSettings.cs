using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService
{
    public class Settings
    {
        public bool Enabled { get; set; }
        public double Threshold { get; set; }
        public string Message { get; set; }
    }
    public class BotsSettings
    {
        const string BotsSettingsFilePath = "C:\\Users\\GoldenTech\\Desktop\\WeatherTest.txt";
        public JObject GetAllSettings()
        {
            string jsonData = File.ReadAllText(BotsSettingsFilePath);
            return JObject.Parse(jsonData);
        }
    }
}
