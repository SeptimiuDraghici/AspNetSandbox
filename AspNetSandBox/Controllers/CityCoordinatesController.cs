using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AspNetSandBox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityCoordinatesController : ControllerBase
    {
        private const float KELVIN_CONSTANT = 273.15f;

        [HttpGet]
        public IEnumerable<CityCoordinates> Get()
        {
            var client = new RestClient("api.openweathermap.org/data/2.5/weather?q=London&appid=33a7b8b2ffb63bb3514e58a43a77ccf9");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return ConvertResponseToCityCoordinates(response.Content);
        }

        public IEnumerable<CityCoordinates> ConvertResponseToCityCoordinates(string content)
        {
            var json = JObject.Parse(content);

            return Enumerable.Range(0, 3).Select(index =>
            {
                var jsonCityCoordinates = json["cities"][index]["coord"];
                var jsonCityLongitude = jsonCityCoordinates.Value<decimal>("lon");
                var jsonCityLatitude = jsonCityCoordinates.Value<decimal>("lat");

                return new CityCoordinates
                {
                    Longitude = jsonCityLongitude,
                    Latitude = jsonCityLatitude
                };
            })
            .ToArray();
        }
    }
}
