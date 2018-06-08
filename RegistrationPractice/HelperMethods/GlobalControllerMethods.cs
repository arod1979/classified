using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace RegistrationPractice.HelperMethods
{
    public static class GlobalFunctions
    {

        public static string GetCurrentUser()
        {
            try
            {
                string username = System.Web.HttpContext.Current.User.Identity.GetUserName();
                return username;

            }
            catch(Exception e)
            {
                return "";
            }
        }
    }
}