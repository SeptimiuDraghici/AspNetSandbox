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
                    Latitude = jsonCityCoordinates.Value<decimal>("lat")
                };
            })
            .ToArray();
        }
    }
}
