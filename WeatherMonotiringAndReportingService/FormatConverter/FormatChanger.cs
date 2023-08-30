namespace WeatherMonitoringAndReportingService.FormatConverter
{
    public class FormatChanger
    {
        private IInputFormatConverter _inputFormatConverter;

        public void SetInputFormatConverter(IInputFormatConverter _inputFormatConverter)
        {
            this._inputFormatConverter = _inputFormatConverter;
        }

        public Weather ApplyFormatConverter(string UserInput)
        {
            return _inputFormatConverter.ConvertToWeather(UserInput);
        }
    }
}
