using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherMonitoringAndReportingService.UpdateBotSittings;
using WeatherMonitoringAndReportingService;
using AutoFixture;

namespace WeatherMonitoringAndREportService.Tests
{
    public class WeatherStationTests
    {
        private readonly BotsConfigurations botsConfigurations;
        private readonly Fixture _fixture;
        private readonly Weather _weather;
        private readonly List<IBots> bots;

        public WeatherStationTests()
        {
            botsConfigurations = new BotsConfigurations();
            _fixture = new Fixture();
            _weather = _fixture.Create<Weather>();
            bots = new List<IBots> { new RainBot(), new SunBot(), new SnowBot() };
        }

        [Theory]
        [InlineData(40, 80, new string[] { "It looks like it's about to pour down!", null, null })]
        [InlineData(40, 40, new string[] { "Wow, it's a scorcher out there!", null, null })]
        [InlineData(-1, 90, new string[] { "It looks like it's about to pour down!", null, null })]
        public void WeatherStationShould(int expectedTempreture, int expectedHumidity, string[] expectedMessage)
        {
            //arrange
            botsConfigurations.SetBotConfigurations(bots);
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
