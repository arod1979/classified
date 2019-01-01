using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationPractice.Models.ViewModels
{
    public class LocationListing
    {
        public LocationListing()
        {

        }

        public string city;
        public string regionabbreviation;
        public string country;

    }

    public class Region_LocationListing
    {
        public string region;
        public List<LocationListing> locationlistings;
    }


}