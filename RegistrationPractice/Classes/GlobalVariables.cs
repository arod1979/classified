using RegistrationPractice.Controllers;
using RegistrationPractice.Entities;
using RegistrationPractice.Models;
using RegistrationPractice.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationPractice.Classes.Globals
{

    public class Constants
    {
        //replace generic repository

        public ApplicationDbContext db = new ApplicationDbContext("DefaultConnection");

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

        //public bool IsUserEmailConfirmed(AccountController accountController)
        //{
        //    string userid = System.Web.HttpContext.Current.Session["UserId"].ToString();

        //    try
        //    {
        //        return accountController.UserManager.IsEmailConfirmedAsync(user.Id)
        //    }
        //    catch (Exception e)
        //    {

        //    }

        //    return true;
        //}

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

        public int Getdbidbyposttype(string posttype)
        {
            if (nameof(founddbid).StartsWith(posttype))
                return founddbid;
            if (nameof(stolendbid).StartsWith(posttype))
                return stolendbid;
            if (nameof(lostdbid).StartsWith(posttype))
                return lostdbid;
            return stolendbid;
        }

        //public IEnumerable<SelectListItem> GetCategorySelectList(string posttypefilter)
        //{

        //    if (posttypefilter == "lost")
        //    {
        //        var categorylist =
        //        db.Category
        //        .Join(db.CategoryPostType,
        //            c => c.Id,
        //            cp => cp.CategoryID,
        //            (c, cp) => new { c, cp })
        //            .Where(z => z.cp.PostTypeID == lostdbid)
        //            .Select(z => z.c)
        //            .ToList();

        //        System.Diagnostics.Debug.WriteLine("apple" + categorylist.Count.ToString());

        //        var categoryselectlist =
        //            categorylist.Select(c => new SelectListItem
        //            {
        //                Text = c.CategoryText,
        //                Value = c.Id.ToString()

        //            }).ToList();

        //        return new SelectList(categoryselectlist, ;





        //    }
        //    else if (posttypefilter == "found")
        //    {
        //        yield return null;
        //    }
        //    else if (posttypefilter == "stolen")
        //    {

        //        yield return null;
        //    }
        //    else
        //    {
        //        Loggers.Logger.Write("Could not build select list for category dropdown");
        //        yield return null;
        //    }
        //}

        public int GetCityPrimaryKey(string city)
        {

            return db.Locations.Where(loc => loc.LocationText == city).SingleOrDefault().Id;
        }

        public static string[] posttypes = { "lost", "Lost", "stolen", "Stolen", "found", "Found" };
    }

    public class CityListing
    {
        public CityListing()
        {
            LoadCities();
        }

        public ApplicationDbContext db = new ApplicationDbContext("DefaultConnection");
        public String[] countrylist = { "usa", "canada" };
        public List<KeyValuePair<string, string[]>> canadian_cities = new List<KeyValuePair<string, string[]>>();

        public static Dictionary<string, List<Region_LocationListing>> region_locationlist_dictionary = new Dictionary<string, List<Region_LocationListing>>();


        public List<string> GetRegions(string country)
        {
            List<string> regions =
                db.Countries.Where(c => c.CountryText.ToUpper() == country.ToUpper())
                .Select(c => c.RegionText)
                .ToList<string>();

            return regions;

        }



        public List<LocationListing> GetCities(string region)
        {
            List<LocationListing> list =
                     db.Locations
                    .Join(db.Countries,
                    l => l.CountryId,
                    c => c.Id,
                    (l, c) => new { l, c })
                    .Where(z => z.c.RegionText == region)
                    .Select(res => new LocationListing { country = res.c.CountryText, city = res.l.LocationText, regionabbreviation = res.c.RegionAbbreviation })
                    .OrderBy(l => l.city)
                    .ToList();

            return list;
        }






        private void LoadCities()
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