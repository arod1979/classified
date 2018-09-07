using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using RegistrationPractice.Classes;
using RegistrationPractice.Entities;
using RegistrationPractice.Models;

namespace RegistrationPractice.Controllers.WebApi
{

    public class EmailsController : ApiController
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Emails
        public IQueryable<Email> GetEmails()
        {
            return db.Emails;
        }

        // GET: api/Emails/5
        [ResponseType(typeof(Email))]
        public async Task<IHttpActionResult> GetEmail(int id)
        {
            Email email = await db.Emails.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }

            return Ok(email);
        }

        // PUT: api/Emails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmail(int id, Email email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != email.Id)
            {
                return BadRequest();
            }

            db.Entry(email).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Emails
        [ResponseType(typeof(Email))]
        [ValidateAntiForgeryTokenOnAllPosts]
        public async Task<IHttpActionResult> PostEmail([FromBody]Email email)
        {

            var _usermanager = RegistrationPractice.Startup.exportUserManager;
            ApplicationUser user = await _usermanager.FindByIdAsync(email.pid);
            email.toaddress = user.Email;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Emails.Add(email);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = email.Id }, email);
        }

        // DELETE: api/Emails/5
        [ResponseType(typeof(Email))]
        public async Task<IHttpActionResult> DeleteEmail(int id)
        {
            Email email = await db.Emails.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }

            db.Emails.Remove(email);
            await db.SaveChangesAsync();

            return Ok(email);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmailExists(int id)
        {
            return db.Emails.Count(e => e.Id == id) > 0;
        }
    }
}