using WeatherMonitoringAndReportingService.FormatConverter;
using WeatherMonitoringAndReportingService.UpdateBotSittings;

namespace WeatherMonitoringAndReportingService
{
    public class Application
    {
        public static void Main()
        {
            WeatherStation weatherStation = new WeatherStation();

            IBots sunBot = new SunBot();
            IBots snowBot = new SnowBot();
            IBots rainBot = new RainBot();

            weatherStation.AddObserver(sunBot);
            weatherStation.AddObserver(snowBot);
            weatherStation.AddObserver(rainBot);

            BotsConfigurations botsConfigurations = new BotsConfigurations();
            string isConfigurationSet = botsConfigurations.SetBotConfigurations(new List<IBots>() { sunBot, snowBot, rainBot });
            if (isConfigurationSet != "Success!")
            {
                Console.WriteLine(isConfigurationSet);
                while (true) ;
            }

            string weatherInput = "";
            while (weatherInput != "exit")
            {
                Console.WriteLine("Enter weather data: ");

                InputHandler inputHandler = new InputHandler();
                weatherInput = Console.ReadLine();

                IInputFormatConverter inputFormatConverter = inputHandler.DetermaineInputConverter(weatherInput);

                if (inputFormatConverter != null)
                {
                    Weather weather = inputFormatConverter.ConvertToWeather(weatherInput);

                    List<string> reportMessages = weatherStation.NotifyAll(weather);

                    foreach (string reportMessage in reportMessages)
                    {
                        Console.WriteLine(reportMessage);
                    }
                }
                else
                    Console.WriteLine("Unknown Input Format!");
            }
        }

    }
}
