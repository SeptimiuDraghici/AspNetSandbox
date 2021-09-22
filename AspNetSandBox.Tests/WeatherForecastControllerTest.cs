using System;
using System.IO;
using AspNetSandBox.Controllers;
using AspNetSandBox.Models;
using Xunit;

namespace AspNetSandBox.Tests
{
    /// <summary>Tests for getting weather forecast from API.</summary>
    public class WeatherForecastControllerTest
    {
        /// <summary>Tests weather forecast for tomorrow.</summary>
        [Fact]
        public void ConvertResponseToWeatherForecastTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            // Assert
            var weatherForecastForTomorrow = ((WeatherForecast[])output)[0];
            Assert.Equal("Clear", weatherForecastForTomorrow.Summary);
            Assert.Equal(20, weatherForecastForTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 3), weatherForecastForTomorrow.Date);
        }

        /// <summary>Tests weather forecast for the day after tomorrow.</summary>
        [Fact]
        public void ConvertResponseToWeatherForecastAfterTomorrowTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new WeatherForecastController();

            // Act
            var output = controller.ConvertResponseToWeatherForecast(content);

            // Assert
            var weatherForecastForDayAfterTomorrow = ((WeatherForecast[])output)[1];
            Assert.Equal("Clear", weatherForecastForDayAfterTomorrow.Summary);
            Assert.Equal(23, weatherForecastForDayAfterTomorrow.TemperatureC);
            Assert.Equal(new DateTime(2021, 9, 4), weatherForecastForDayAfterTomorrow.Date);
        }

        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.DataFromOpenWeatherAPI.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
