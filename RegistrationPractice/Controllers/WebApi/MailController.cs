using RegistrationPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RegistrationPractice.Controllers.WebApi
{
    public class MailController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Mail
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Mail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mail
        public HttpResponseMessage Post([FromBody]string message, string bid, string pid)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT: api/Mail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mail/5
        public void Delete(int id)
        {
        }
    }
}
