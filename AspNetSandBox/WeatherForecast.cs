using System;

namespace AspNetSandBox
{
    /// <summary>Model for Weather Forecast Controller to get date, temperature and weather forecast.</summary>
    public class WeatherForecast
    {
        /// <summary>Gets or sets the date of WeatherForecast object.</summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the temperature in celcius of WeatherForecast object.</summary>
        /// <value>The temperature c.</value>
        public int TemperatureC { get; set; }

        /// <summary>Gets Weather forecast temperature in fahrenheit converted from celsius.</summary>
        /// <value>The temperature f.</value>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>Gets or sets the summary of WeatherForecast object.</summary>
        /// <value>The summary.</value>
        public string Summary { get; set; }
    }
}
