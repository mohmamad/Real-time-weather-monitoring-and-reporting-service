using WeatherMonitoringAndReportingService.UpdateBotSittings;

namespace WeatherMonitoringAndReportingService
{
    public class Weather
    {
        public string Location;
        public double Humidity;
        public double Temperature;
    }

    public class WeatherStation
    {
        private List<IBots> Observers = new List<IBots>();

        public void AddObserver(IBots bot)
        {
            Observers.Add(bot);
        }
        public void RemoveObserver(IBots bot)
        {
            Observers.Remove(bot);
        }

        public List<string> NotifyAll(Weather weather)
        {
            List<string> reportMessages = new List<string>();
            foreach (var observer in Observers)
            {
                reportMessages.Add(observer.GetBotMessage(weather));
            }
            return reportMessages;
        }
    }
}
