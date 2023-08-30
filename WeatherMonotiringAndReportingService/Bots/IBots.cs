using Newtonsoft.Json.Linq;

namespace WeatherMonitoringAndReportingService.UpdateBotSittings
{
    public interface IBots
    {
        public void SetBotConfiguration(JObject sittings);
        public string GetBotMessage(Weather weather);
    }
}
