using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationPractice.Classes
{
    public class ManageURL
    {
        public string createcommaseperatedcity(string url)
        {
            //new_york_NY
            try
            {
                string[] urlsegments = url.Split('-');
                string city = string.Empty;
                int len = urlsegments.Length;
                for (int x = 0; x < (len - 1); x++)
                {
                    city += urlsegments[x];

                    if ((len - x) <= 2) //
                    { city += ", "; }
                    else
                    { city += " "; }

                }
                city += urlsegments[urlsegments.Length - 1];
                return city;
            }
            catch (Exception e)
            {
                return "failure";
            }
        }
    }
}