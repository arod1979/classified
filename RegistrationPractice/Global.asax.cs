using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


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
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }
}
