using RegistrationPractice.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RegistrationPractice.Classes.Globals
{

    public class Constants
    {
        //replace generic repository

        private ApplicationDbContext db;
        public Constants()
        {
            db = new ApplicationDbContext("DefaultConnection");
            if (HttpContext.Current == null) //testing
            {
                HttpContext.Current = new HttpContext(
                new HttpRequest("", "https://awolr.com", ""),
                 new HttpResponse(new StringWriter())
                );
            }
        }


        public string servername
        {
            get { return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority); }
        }

        public int stolendbid
        {
            get { return db.PostTypes.SingleOrDefault(pt => pt.PostTypeText == "stolen").Id; }
        }

        public int lostdbid
        {
            get { return db.PostTypes.SingleOrDefault(pt => pt.PostTypeText == "lost").Id; }
        }

        public int founddbid
        {
            get { return db.PostTypes.SingleOrDefault(pt => pt.PostTypeText == "found").Id; }
        }


        public int GetCityPrimaryKey(string city)
        {

            return db.Locations.Where(loc => loc.LocationText == city.ToLower()).SingleOrDefault().Id;
        }

        public static string[] posttypes = { "lost", "Lost", "stolen", "Stolen", "found", "Found" };
    }

    public static class CityListing
    {
        public static String[] countrylist = { "usa", "canada" };
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