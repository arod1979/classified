using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;

namespace RegistrationPractice.Classes.TrackLocation
{



    public class TrackLocation
    {

        TrackLocation()
        {
        }

        string city;
        private readonly Dictionary<string, GeoCoordinate> canadianlbs =
            new Dictionary<string, GeoCoordinate>
            {
                {"Winnipeg", new GeoCoordinate(49.899, -97.141) }
            };

        private readonly Dictionary<string, GeoCoordinate> americanlbs =
        new Dictionary<string, GeoCoordinate>
        {

        };







        public string GetLocation(GeoCoordinate city, Dictionary<string, GeoCoordinate> database)
        {
            return database.OrderBy(x => x.Value.GetDistanceTo(city))
                       .First().Key;
        }
    }
}