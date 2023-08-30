using AutoFixture;
using Newtonsoft.Json.Linq;
using WeatherMonitoringAndReportingService;
using WeatherMonitoringAndReportingService.UpdateBotSittings;

namespace WeatherMonitoringAndREportService.Tests
{
    public class BotsTests
    {
        private readonly Weather _weather;
        private readonly JObject _botJObject;
        private readonly JObject _NestedJOject;
        private readonly Fixture _fixture;

        public BotsTests()
        {
            _botJObject = new JObject();
            _NestedJOject = new JObject();
            _fixture = new Fixture();
            _weather = _fixture.Create<Weather>();
        }
        [Theory]
        [InlineData(10, 80, 70, "It looks like it's about to pour down!", true)]
        [InlineData(40, 40, 50, null, true)]
        [InlineData(20, 85, 80, null, false)]
        public void RainBotShould(int expectedTempreture, int expectedHumidity, int threshold, string expectedMessage, bool enabled)
        {
            //arrange
            _NestedJOject.Add("enabled", enabled);
            _NestedJOject.Add("humidityThreshold", threshold);
            _NestedJOject.Add("message", "It looks like it's about to pour down!");
            _botJObject.Add("RainBot", _NestedJOject);

            var sut = new RainBot();
            sut.SetBotConfiguration(_botJObject);

            _weather.Temperature = expectedTempreture;
            _weather.Humidity = expectedHumidity;
            //act
            string actMessage = sut.GetBotMessage(_weather);

            //assert
            Assert.Equal(expectedMessage, actMessage);
        }

        [Theory]
        [InlineData(40, 80, 30, "Wow, it's a scorcher out there!", true)]
        [InlineData(20, 40, 25, null, true)]
        [InlineData(50, 75, 40, null, false)]
        public void SunBotShould(int expectedTempreture, int expectedHumidity, int threshold, string expectedMessage, bool enabled)
        {
            //arrange
            _NestedJOject.Add("enabled", enabled);
            _NestedJOject.Add("temperatureThreshold", threshold);
            _NestedJOject.Add("message", "Wow, it's a scorcher out there!");
            _botJObject.Add("SunBot", _NestedJOject);

            var sut = new SunBot();
            sut.SetBotConfiguration(_botJObject);

            _weather.Temperature = expectedTempreture;
            _weather.Humidity = expectedHumidity;
            //act
            string actMessage = sut.GetBotMessage(_weather);

            //assert
            Assert.Equal(expectedMessage, actMessage);
        }



        [Theory]
        [InlineData(-3, 80, 0, "Brrr, it's getting chilly!", true)]
        [InlineData(3, 40, 2, null, true)]
        [InlineData(-15, 75, -10, null, false)]
        public void SnowBotShould(int expectedTempreture, int expectedHumidity, int threshold, string expectedMessage, bool enabled)
        {
            //arrange
            _NestedJOject.Add("enabled", enabled);
            _NestedJOject.Add("temperatureThreshold", threshold);
            _NestedJOject.Add("message", "Brrr, it's getting chilly!");
            _botJObject.Add("SnowBot", _NestedJOject);

            var sut = new SnowBot();
            sut.SetBotConfiguration(_botJObject);

            _weather.Temperature = expectedTempreture;
            _weather.Humidity = expectedHumidity;
            //act
            string actMessage = sut.GetBotMessage(_weather);

            //assert
            Assert.Equal(expectedMessage, actMessage);
        }

    }
}