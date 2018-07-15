using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RegistrationPractice
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            


            routes.MapRoute(
                name: "ItemDetails",
                url: "Items/Details/{id}",
                defaults: new { controller = "Items", action = "Details" }
            );

           


            routes.MapRoute(
                name: "EditItem",
                url: "Items/Edit/{id}",
                defaults: new { controller = "Items", action = "Edit" }
            );


            routes.MapRoute(
                name: "PostEditItem",
                url: "Items/Edit/",
                defaults: new { controller = "Items", action = "Edit" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{countryname}",
                defaults: new { controller = "Items", action = "CountryIndex", countryname = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Items", action = "Index", id = UrlParameter.Optional }
            //);


        }
    }
}
