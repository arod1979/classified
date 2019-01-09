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
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Items", action = "CountryIndex" }
            );

            routes.MapRoute(
                name: "ItemDetails",
                url: "Items/Details/{id}",
                defaults: new { controller = "Items", action = "Details" }
            );

            routes.MapRoute(
                name: "ItemDetailsState",
                url: "Items/Details/",
                defaults: new { controller = "Items", action = "Details" }
            );




            routes.MapRoute(
                name: "EditItem",
                url: "Items/Edit/{id}",
                defaults: new { controller = "Items", action = "Edit" }
            );



            routes.MapRoute(
            name: "CityIndex",
                url: "Items/{country}/{province}/cityindex/{city}",
                defaults: new { controller = "Items", action = "cityindex" }
            );

            routes.MapRoute(
            name: "CityIndexDetailsView",
                url: "Items/{country}/{province}/cityindex/{city}/{posttypefilter}",
                defaults: new { controller = "Items", action = "cityindex" }
            );

            routes.MapRoute(
            name: "CityIndexPost",
                url: "Items/{country}/{province}/cityindex/{city}/{posttypefilter}/create",
                defaults: new { controller = "Items", action = "create" }
            );

            routes.MapRoute(
            name: "FilterCityIndexPost",
                url: "Items/{country}/{province}/cityindex/{city}/{posttypefilter}/{search}",
                defaults: new { controller = "Items", action = "cityindex" }
            );

            routes.MapRoute(
                name: "DeleteItem",
                url: "Items/Delete/{id}",
                defaults: new { controller = "Items", action = "Delete" }
            );






            routes.MapRoute(
                name: "CountryIndex",
                url: "{controller}/{action}",
                defaults: new { controller = "Items", action = "countryindex", country = "canada" }
            );






        }
    }
}
