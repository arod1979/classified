using RegistrationPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationPractice.Classes.Globals
{

    public static class PostTypeDBIDs
    {
        //replace generic repository

        static readonly ApplicationDbContext db = new ApplicationDbContext();
        public static int stolendbid = db.PostTypes.SingleOrDefault(pt => pt.PostTypeText == "stolen").Id;
        public static int lostdbid = db.PostTypes.SingleOrDefault(pt => pt.PostTypeText == "lost").Id;
        public static int founddbid = db.PostTypes.SingleOrDefault(pt => pt.PostTypeText == "found").Id;

        public static int GetCityPrimaryKey(string city)
        {
            return db.Locations.Where(loc => loc.LocationText == city).SingleOrDefault().Id;
        }
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