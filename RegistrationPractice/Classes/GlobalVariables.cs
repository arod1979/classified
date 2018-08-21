using RegistrationPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationPractice.Classes.Globals
{

    public static class constants
    {
        //replace generic repository

        static readonly ApplicationDbContext db = new ApplicationDbContext("DefaultConnection");
        //public static readonly string servername = System.Configuration.ConfigurationManager.AppSettings["servername"];
        public static readonly string servername = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
        public static readonly int stolendbid = db.PostTypes.SingleOrDefault(pt => pt.PostTypeText == "stolen").Id;
        public static readonly int lostdbid = db.PostTypes.SingleOrDefault(pt => pt.PostTypeText == "lost").Id;
        public static readonly int founddbid = db.PostTypes.SingleOrDefault(pt => pt.PostTypeText == "found").Id;

        public static int GetCityPrimaryKey(string city)
        {
            return db.Locations.Where(loc => loc.LocationText == city.ToLower()).SingleOrDefault().Id;
        }

        public static string[] posttypes = { "lost", "Lost", "stolen", "Stolen", "found", "Found" };
    }

    public static class CityListing
    {

        public static List<KeyValuePair<string, string[]>> canadian_cities = new List<KeyValuePair<string, string[]>>();

        static CityListing()
        {
            canadian_cities.Add(new KeyValuePair<string, string[]>("ON_CD", new string[] { "thunder bay", "toronto" }));
            canadian_cities.Add(new KeyValuePair<string, string[]>("BC_CD", new string[] { "victoria", "vancouver" }));
            canadian_cities.Add(new KeyValuePair<string, string[]>("MB_CD", new string[] { "winnipeg", "brandon" }));
            canadian_cities.Add(new KeyValuePair<string, string[]>("SK_CD", new string[] { "regina", "saskatoon" }));
            canadian_cities.Add(new KeyValuePair<string, string[]>("AB_CD", new string[] { "edmonton", "calgary" }));
        }



        //BC_CD  = KeyValuePair<string, string[]>(new string[] { "vancouver", "victoria" });
        //readonly static List<string> ON_CD = new List<string>(new string[] { "thunder bay", "toronto" });
        //readonly static List<string> MB_CD = new List<string>(new string[] { "winnipeg", "brandon" });
        //readonly static List<string> SK_CD = new List<string>(new string[] { "saskatoon", "regina" });
        //readonly static List<string> AB_CD = new List<string>(new string[] { "edmonton", "calgary" });
    }


}