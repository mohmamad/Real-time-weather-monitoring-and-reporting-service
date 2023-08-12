using WeatherMonitoringAndReportingService.UpdateBotSittings;

namespace WeatherMonitoringAndReportingService
{
    public class BotActivation
    {
        public List<string> ReportMessages(Weather weatherData , List<IBots> bots)
        {
            List<IBots> activatedBots = EnabledBots(bots);
            activatedBots = BotsToActivate(weatherData , activatedBots);

            List<string> messages = new List<string>();
            foreach (IBots bot in activatedBots)
            {
                messages.Add(bot.GetSettings().Message);
            }

            return messages;
        }

        public List<IBots> EnabledBots(List<IBots> bots) 
        {
            List<IBots> enabledBots = new List<IBots>();    
            foreach (var bot in bots)
            {
                if(bot.GetSettings().Enabled)
                    enabledBots.Add(bot);
            }
            return enabledBots;
        }

        public List<IBots> BotsToActivate(Weather weatherData, List<IBots> bots)
        {
            List<IBots> activatedBots = new List<IBots>();
            foreach (var bot in bots)
            {
                if (bot.GetSettings().BotName == "SnowBot")
                {
                    if (bot.GetSettings().Threshold > weatherData.Temperature)
                    {
                        activatedBots.Add(bot);
                    }
                }
                else if (bot.GetSettings().BotName == "SunBot")
                {
                    if (bot.GetSettings().Threshold < weatherData.Temperature)
                    {
                        activatedBots.Add(bot);
                    }
                }
                    
                else if (bot.GetSettings().BotName == "RainBot")
                {
                    if (bot.GetSettings().Threshold < weatherData.Humidity)
                    {
                        activatedBots.Add(bot);
                    }
                }
                        
            }
            return activatedBots;
        }
    }
}
