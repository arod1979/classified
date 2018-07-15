using RegistrationPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationPractice.Classes.Globals
{

    public static class PostTypeDBIDs
    {
        static readonly ApplicationDbContext db = new ApplicationDbContext();
        public static int stolendbid = db.PostTypes.SingleOrDefault(pt => pt.PostTypeText == "stolen").Id;
        public static int lostdbid = db.PostTypes.SingleOrDefault(pt => pt.PostTypeText == "lost").Id;
        public static int founddbid = db.PostTypes.SingleOrDefault(pt => pt.PostTypeText == "found").Id;

    }

    public static class GlobalVariables
    {
        
        

       


    }
}