using System.IO;
using AspNetSandBox.Controllers;
using AspNetSandBox.Models;
using Xunit;

namespace AspNetSandBox.Tests
{
    /// <summary>Tests for getting city coordinates from city name.</summary>
    public class CityCoordinatesControllerTest
    {
        /// <summary>Test for getting coordinates of London.</summary>
        [Fact]
        public void ConvertResponseToCityCoordinatesLondonTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new CityCoordinatesController();

            // Act
            var output = controller.ConvertResponseToCityCoordinates(content);

            // Assert
            var cityCoordinatesForLondon = ((CityCoordinates[])output)[0];
            Assert.Equal(-0.1257M, cityCoordinatesForLondon.Longitude);
            Assert.Equal(51.5085M, cityCoordinatesForLondon.Latitude);
        }

        /// <summary>Test for getting coordinates of Brasov.</summary>
        [Fact]
        public void ConvertResponseToCityCoordinatesBrasovTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new CityCoordinatesController();

            // Act
            var output = controller.ConvertResponseToCityCoordinates(content);

            // Assert
            var cityCoordinatesForBrasov = ((CityCoordinates[])output)[1];
            Assert.Equal(25.3333M, cityCoordinatesForBrasov.Longitude);
            Assert.Equal(45.75M, cityCoordinatesForBrasov.Latitude);
        }

        /// <summary>Test for getting coordinates of Moscow.</summary>
        [Fact]
        public void ConvertResponseToCityCoordinatesMoscowTest()
        {
            // Assume
            string content = LoadJsonFromResource();
            var controller = new CityCoordinatesController();

            // Act
            var output = controller.ConvertResponseToCityCoordinates(content);

            // Assert
            var cityCoordinatesForMoscow = ((CityCoordinates[])output)[2];
            Assert.Equal(37.6156M, cityCoordinatesForMoscow.Longitude);
            Assert.Equal(55.7522M, cityCoordinatesForMoscow.Latitude);
        }

        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.DataFromCityCoordinatesAPI.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
