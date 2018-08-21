using RegistrationPractice.Classes.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace RegistrationPractice.Classes.Cookies
{
    //public class Cookies
    //{
    //    public Cookies(MySession mysession)
    //    {

    //    }

    //    public void PushCookiesToSession()
    //    {
    //        string currentcity = System.Web.HttpContext.Current.Request.Cookies["currentcity"].Value;
    //        if (currentcity != null)
    //    }


    //}

    public class MyCookies
    {
        public Keys keys = new Keys();
        public HttpCookieCollection cookies = HttpContext.Current.Request.Cookies;

        public class Keys
        {
            public string currentcity = "currentcity";
        }
    }

}