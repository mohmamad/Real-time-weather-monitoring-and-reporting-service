using Newtonsoft.Json.Linq;
using System.Xml;
using WeatherMonitoringAndReportingService;
using WeatherMonitoringAndReportingService.FormatConverter;
using WeatherMonitoringAndReportingService.UpdateBotSittings;

internal class Application
{
    private static void Main(string[] args)
    {
        List<IBots> bots = new List<IBots>();
        IBots sunBot = new SunBot();
        IBots snowBot = new SnowBot();
        IBots rainBot = new RainBot();
        if(SetBotsConfigurations(sunBot , snowBot , rainBot) != "success")
        {
            Console.WriteLine(SetBotsConfigurations(sunBot, snowBot, rainBot) + " please go fix it.");
            while (SetBotsConfigurations(sunBot, snowBot, rainBot) != "success") ;
        }

        bots.Add(sunBot);
        bots.Add(rainBot);
        bots.Add(snowBot);
        string weatherInput = "";
        while (weatherInput != "exit")
        {
            Console.WriteLine("Enter weather Data: ");
            weatherInput = Console.ReadLine();


            FormatChanger formatChanger = new FormatChanger();
            IInputFormatConverter inputFormat = DetermineInputFormat(weatherInput);

            if (inputFormat != null)
            {
                BotActivation botActivation = new BotActivation();

                formatChanger.SetInputFormatConverter(inputFormat);
                Weather weather = formatChanger.ApplyFormatConverter(weatherInput);

                List<string> messages = botActivation.ReportMessages(weather, bots);

                foreach (string message in messages)
                {
                    Console.WriteLine(message);
                }
               
            }
            else
            {
                Console.WriteLine("not a recognised input format!");
            }
        }
    }

    public static string SetBotsConfigurations(IBots sunBot , IBots snowBot , IBots rainBot )
    {
        BotsSettings settings = new BotsSettings();
        NotifyBots notifyBots = new NotifyBots();
        const string botsConfigFilePath = "C:\\Users\\GoldenTech\\Desktop\\study\\intern\\C#\\exercise\\WeatherMonotiringAndReportingService\\BotsConfiguration.txt";
        if(!File.Exists(botsConfigFilePath)) { return "Configuration File Not Found!"; }

        
        notifyBots.AddObserver(sunBot);
        notifyBots.AddObserver(snowBot);
        notifyBots.AddObserver(rainBot);
        try
        {
            JObject configJObject = new JObject(JObject.Parse(File.ReadAllText(botsConfigFilePath)));
            notifyBots.SetSettings(configJObject);
            return "success";
        }
        catch (Exception ex) { return "Configuration File Content Must Be In JSON Format!"; }
        
        
    }

    public static IInputFormatConverter DetermineInputFormat(string weatherInput)
    {
        try
        {
            XmlDocument xmlInput = new XmlDocument();
            xmlInput.LoadXml(weatherInput);
            return new XmlFormatConverter();
        }
        catch (Exception ex)
        {
            try
            {
                JObject jsonWeather = JObject.Parse(weatherInput);
            }
            catch { return null; }
            return new JsonFormatConverter();
        }
    }
}