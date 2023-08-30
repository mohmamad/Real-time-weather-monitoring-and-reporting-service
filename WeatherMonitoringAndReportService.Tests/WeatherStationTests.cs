using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.UpdateBotSittings;
using WeatherMonitoringAndReportingService;
using AutoFixture;
using Newtonsoft.Json.Linq;

namespace WeatherMonitoringAndREportService.Tests
{
    public class WeatherStationTests
    {
        private readonly BotsConfigurations botsConfigurations;
        private readonly Fixture _fixture;
        private readonly Weather _weather;
        private readonly List<IBots> bots;
        private readonly JObject _botJObject;
        private readonly JObject _NestedJOject;

        public WeatherStationTests()
        {
            botsConfigurations = new BotsConfigurations();
            _fixture = new Fixture();
            _weather = _fixture.Create<Weather>();
            bots = new List<IBots> { new RainBot(), new SunBot(), new SnowBot() };
            _botJObject = new JObject();
            _NestedJOject = new JObject();
        }

        [Theory]
        [InlineData(40, 80, new string[] { "It looks like it's about to pour down!", null, null })]
        [InlineData(40, 40, new string[] { "Wow, it's a scorcher out there!", null, null })]
        [InlineData(-1, 90, new string[] { "It looks like it's about to pour down!", null, null })]
        public void WeatherStationShould(int expectedTempreture, int expectedHumidity, string[] expectedMessage)
        {
            //arrange
            _NestedJOject.Add("enabled", true);
            _NestedJOject.Add("humidityThreshold", 70);
            _NestedJOject.Add("message", "It looks like it's about to pour down!");
            _botJObject.Add("RainBot", _NestedJOject);
            bots[0].SetBotConfiguration(_botJObject);

            _NestedJOject.Add("temperatureThreshold", 30);
            _NestedJOject["message"] = "Wow, it's a scorcher out there!";
            _botJObject.Add("SunBot", _NestedJOject);
            bots[1].SetBotConfiguration(_botJObject);

            _NestedJOject["enabled"] = false;
            _NestedJOject["temperatureThreshold"] = 0;
            _NestedJOject["message"] = "Brrr, it's getting chilly!";
            _botJObject.Add("SnowBot", _NestedJOject);

            bots[2].SetBotConfiguration(_botJObject);
            WeatherStation sut = new WeatherStation();

            _weather.Temperature = expectedTempreture;
            _weather.Humidity = expectedHumidity;

            //act
            foreach (IBots bot in bots)
            {
                sut.AddObserver(bot);
            }

            List<string> actMessage = sut.NotifyAll(_weather);

            //assert

            foreach (string message in expectedMessage)
            {
                Assert.Contains(message, actMessage);
            }
        }

    }
}
