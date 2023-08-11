using Newtonsoft.Json.Linq;
using System.Xml;
using WeatherMonitoringAndReportingService;
using WeatherMonitoringAndReportingService.FormatConverter;
using WeatherMonitoringAndReportingService.UpdateBotSittings;

internal class Application
{
    private static void Main(string[] args)
    {
        IBots sunBot = new SunBot();
        IBots snowBot = new SunBot();
        IBots rainBot = new SunBot();
        SetBotsConfigurations(sunBot , snowBot , rainBot);
        string weatherInput = "";

        FormatChanger formatChanger = new FormatChanger();
        IInputFormatConverter inputFormat = DetermineInputFormat(weatherInput);
        if(inputFormat != null)
        {
            formatChanger.SetInputFormatConverter(inputFormat);
            Weather weather = formatChanger.ApplyFormatConverter(weatherInput);

        }
        else
        {
            Console.WriteLine("not a recognised input format!");
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

        notifyBots.SetSettings(new JObject(File.ReadAllText(botsConfigFilePath)));
        return "success";
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