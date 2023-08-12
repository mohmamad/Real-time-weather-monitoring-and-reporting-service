using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.UpdateBotSittings
{
    public interface IBots
    {
        public void SetBotConfiguration(JObject sittings);
        public string GetBotMessage(Weather weather);
    }
}
