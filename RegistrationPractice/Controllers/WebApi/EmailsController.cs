using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
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
        private readonly EmailsDbContext db = new EmailsDbContext();

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
        public async Task<IHttpActionResult> PostEmail([FromBody]EmailRecipientsPlus emailrecipientsplus)
        {

            EmailRecipients emailrecipients = new EmailRecipients();



            var _usermanager = RegistrationPractice.Startup.exportUserManager;
            ApplicationUser publisher = await _usermanager.FindByIdAsync(emailrecipientsplus.pid);

            emailrecipients.pidrealemailaddress = publisher.Email;
            ApplicationUser browser = await _usermanager.FindByIdAsync(emailrecipientsplus.bid);
            emailrecipients.bidrealemailaddress = browser.Email;
            //eventually delete
            emailrecipientsplus.bidrealemailaddress = browser.Email;
            emailrecipientsplus.pidrealemailaddress = publisher.Email;
            //
            emailrecipients.anonymoustipcheckbox = emailrecipientsplus.anonymoustipcheckbox;
            emailrecipients.foundcheckbox = emailrecipientsplus.foundcheckbox;
            emailrecipients.lostcheckbox = emailrecipientsplus.lostcheckbox;
            emailrecipients.stolencheckbox = emailrecipientsplus.stolencheckbox;
            emailrecipients.IdItem = emailrecipientsplus.IdItem;
            emailrecipients.pidfakeemailaddress = System.IO.Path.GetRandomFileName();
            emailrecipients.bidfakeemailaddress = System.IO.Path.GetRandomFileName();
            emailrecipients.bid = emailrecipientsplus.bid;
            emailrecipients.pid = emailrecipientsplus.pid;

            try
            {
                db.EmailRecipients.Add(emailrecipients);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(ModelState);
            }


            Email email = new Email();

            email.toaddress = publisher.Email;
            email.emailbody = emailrecipientsplus.emailbody;
            email.fromaddress = emailrecipientsplus.fromaddress;









            return CreatedAtRoute("DefaultApi", new { id = emailrecipientsplus.Id }, emailrecipientsplus);
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