using Newtonsoft.Json.Linq;

namespace WeatherMonitoringAndReportingService.UpdateBotSittings
{
    public class BotsConfigurations
    {
        const string BotsSettingsFilePath = "C:\\Users\\GoldenTech\\Desktop\\study\\intern\\C#\\exercise\\WeatherStation\\WeatherMonotiringAndReportingService\\BotsConfiguration.txt";
        public JObject GetAllSettings()
        {
            string jsonData = File.ReadAllText(BotsSettingsFilePath);
            return JObject.Parse(jsonData);
        }

        public string SetBotConfigurations(List<IBots> bots)
        {
            if (File.Exists(BotsSettingsFilePath))
            {
                foreach (var bot in bots)
                {
                    bot.SetBotConfiguration(GetAllSettings());
                }
                return "Success!";
            }
            return "The Configuration File Does Not Exist!";

        }
    }
}
