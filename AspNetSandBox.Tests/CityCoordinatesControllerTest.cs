using AspNetSandBox.Controllers;
using System;
using System.IO;
using Xunit;

namespace AspNetSandBox.Tests
{
    public class CityCoordinatesControllerTest
    {
        [Fact]
        public void ConvertResponseToCityCoordinatesLondonTest()
        {
            //Assume

            string content = LoadJsonFromResource();
            var controller = new CityCoordinatesController();

            //Act

            var output = controller.ConvertResponseToCityCoordinates(content);

            //Assert

            var cityCoordinatesForLondon = ((CityCoordinates[])output)[0];
            Assert.Equal((decimal)-0.1257, cityCoordinatesForLondon.Longitude);
            Assert.Equal((decimal)51.5085, cityCoordinatesForLondon.Latitude);
        }

        [Fact]
        public void ConvertResponseToCityCoordinatesBrasovTest()
        {
            //Assume

            string content = LoadJsonFromResource();
            var controller = new CityCoordinatesController();

            //Act

            var output = controller.ConvertResponseToCityCoordinates(content);

            //Assert

            var cityCoordinatesForBrasov = ((CityCoordinates[])output)[1];
            Assert.Equal((decimal)25.3333, cityCoordinatesForBrasov.Longitude);
            Assert.Equal((decimal)45.75, cityCoordinatesForBrasov.Latitude);
        }

        [Fact]
        public void ConvertResponseToCityCoordinatesMoscowTest()
        {
            //Assume

            string content = LoadJsonFromResource();
            var controller = new CityCoordinatesController();

            //Act

            var output = controller.ConvertResponseToCityCoordinates(content);

            //Assert

            var cityCoordinatesForMoscow = ((CityCoordinates[])output)[2];
            Assert.Equal((decimal)37.6156, cityCoordinatesForMoscow.Longitude);
            Assert.Equal((decimal)55.7522, cityCoordinatesForMoscow.Latitude);
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
