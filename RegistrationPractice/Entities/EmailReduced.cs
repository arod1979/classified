using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationPractice.Entities
{
    public class EmailReduced
    {
        public string pid { get; set; }
        public string bid { get; set; }
        public int postid { get; set; }
        public string emailbody { get; set; }
        public string fromaddress { get; set; }
    }
}