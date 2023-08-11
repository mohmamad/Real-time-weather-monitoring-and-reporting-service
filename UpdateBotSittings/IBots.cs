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
        public void UpdateBotsSettings(JObject sittings);
        public Settings GetSettings();
    }
}
