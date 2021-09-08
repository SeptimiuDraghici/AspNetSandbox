using System;

namespace AspNetSandBox
{
    /// <summary>Model for CityController Objects to use for getting coordinates from city name.</summary>
    public class CityCoordinates
    {
        /// <summary>Gets or sets the longitude of a city.</summary>
        /// <value>The longitude.</value>
        public decimal Longitude { get; set; }

        /// <summary>Gets or sets the latitude of a city.</summary>
        /// <value>The latitude.</value>
        public decimal Latitude { get; set; }
    }
}
