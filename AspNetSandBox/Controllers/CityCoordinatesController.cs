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
    /// <summary>Controller for getting city coordinates by city name.</summary>
    [ApiController]
    [Route("[controller]")]
    public class CityCoordinatesController : ControllerBase
    {
        /// <summary>Gets API call from openweatherAPI to get coordinates.</summary>
        /// <returns>RestResponse Object.</returns>
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

        /// <summary>Converts the response from WeatherForecastAPI call to city coordinates.</summary>
        /// <param name="content">The content.</param>
        /// <returns>Enumerable of CityCoordinates object.</returns>
        [NonAction]
        public IEnumerable<CityCoordinates> ConvertResponseToCityCoordinates(string content)
        {
            var json = JObject.Parse(content);

            return Enumerable.Range(0, 3).Select(index =>
            {
                var jsonCityCoordinates = json["cities"][index]["coord"];

                return new CityCoordinates
                {
                    Longitude = jsonCityCoordinates.Value<decimal>("lon"),
                    Latitude = jsonCityCoordinates.Value<decimal>("lat"),
                };
            })
            .ToArray();
        }
    }
}
