﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using RegistrationPractice.DAL;
using Microsoft.AspNet.Identity;
using RegistrationPractice.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Http;
using RegistrationPractice.App_Start;
using RegistrationPractice.Classes;
using RegistrationPractice.Filters;

namespace RegistrationPractice
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private const String ReturnUrlRegexPattern = @"\?ReturnUrl=.*$";

        //public MvcApplication()
        //{
        //    PreSendRequestHeaders += MvcApplicationOnPreSendRequestHeaders;
        //}

        //private void MvcApplicationOnPreSendRequestHeaders(object sender, EventArgs e)
        //{

        //    String redirectUrl = Response.RedirectLocation;

        //    if (String.IsNullOrEmpty(redirectUrl)
        //         || !Regex.IsMatch(redirectUrl, ReturnUrlRegexPattern))
        //    {

        //        return;

        //    }

        //    Response.RedirectLocation = Regex.Replace(redirectUrl,
        //                                               ReturnUrlRegexPattern,
        //                                               String.Empty);
        //}

        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            //GlobalFilters.Filters.Add(new ValidateAntiForgeryTokenOnAllPosts());
            GlobalFilters.Filters.Add(new RequireHttpsAttribute());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            IFilterProvider[] providers = FilterProviders.Providers.ToArray();
            FilterProviders.Providers.Clear();
            FilterProviders.Providers.Add(new ExcludeFilterProvider(providers));

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //BundleTable.EnableOptimizations = true;
            //gmail.RegisterWatch();


            //var container = new SimpleInjector.Container();
            //container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            //// Register your stuff here  
            //container.Register(typeof(IRepository<>), typeof(EFRepository<>).Assembly, Lifestyle.Scoped);
            ////container.Register(typeof(IUserStore<ApplicationUser>), typeof(UserStore<ApplicationUser>).Assembly, Lifestyle.Scoped);



            //container.Register(typeof(ApplicationUserManager));
            //container.Register(typeof(ApplicationSignInManager));
            //container.Register(typeof(UserStore<ApplicationUser>));
            ////container.Register(typeof(IUserStore<ApplicationUser>));


            //container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            //container.Verify();
            //DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
