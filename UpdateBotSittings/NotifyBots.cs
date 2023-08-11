using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.UpdateBotSittings
{
    public class NotifyBots
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

        public void SetSettings(JObject settings)
        {
            NotifyAll(settings);
        }

        public void NotifyAll(JObject settings)
        {
            foreach (var observer in Observers)
            {
                observer.UpdateBotsSettings(settings);
            }
        }
    }
}
