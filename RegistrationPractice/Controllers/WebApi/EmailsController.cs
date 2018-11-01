﻿using System;
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
        private LoggerWrapper loggerwrapper = new LoggerWrapper();


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
            string emailbody = emailrecipientsplus.emailbody;
            string fromaddress = emailrecipientsplus.fromaddress;
            string itemdescription = emailrecipientsplus.itemdescription;



            var _usermanager = RegistrationPractice.Startup.exportUserManager;
            ApplicationUser publisher = await _usermanager.FindByIdAsync(emailrecipientsplus.pid);

            emailrecipients.pidrealemailaddress = publisher.Email;
            ApplicationUser browser = await _usermanager.FindByIdAsync(emailrecipientsplus.bid);
            emailrecipients.bidrealemailaddress = browser.Email;
            //eventually delete
            emailrecipients.bidrealemailaddress = browser.Email;
            emailrecipients.pidrealemailaddress = publisher.Email;
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

            bool wroteemailrecipients = false;
            try
            {
                emailrecipientsplus = null;
                db.EmailRecipients.Add(emailrecipients);
                await db.SaveChangesAsync();
                loggerwrapper.PickAndExecuteLogging("ad response added to database");

                var f1 = new FakeEmail { FakeEmailChars = emailrecipients.pidfakeemailaddress };
                var f2 = new FakeEmail { FakeEmailChars = emailrecipients.bidfakeemailaddress };
                try
                {


                    db.FakeEmails.Add(f1);
                    db.FakeEmails.Add(f2);
                    await db.SaveChangesAsync();
                    loggerwrapper.PickAndExecuteLogging("fake emails added to database");
                }
                catch (Exception e)
                {
                    try
                    {
                        db.FakeEmails.Remove(f1);
                        db.FakeEmails.Remove(f2);
                        await db.SaveChangesAsync();
                        loggerwrapper.PickAndExecuteLogging("fake emails removed to database");
                    }
                    catch (Exception f)
                    {
                        loggerwrapper.PickAndExecuteLogging("fake emails not added to database. Delete Manually");
                        throw new Exception();
                    }
                    throw new Exception();

                }
                wroteemailrecipients = true;
            }
            catch (Exception e)
            {
                loggerwrapper.PickAndExecuteLogging("ad response not to database. No roll back required");
                return BadRequest(ModelState);
            }

            if (wroteemailrecipients) //now will be writing email table
            {
                Email email = new Email();
                email.fromaddress = String.Format("{0}{1}", emailrecipients.pidfakeemailaddress, "@awolr.com");
                email.toaddress = publisher.Email;
                email.emailbody = emailbody;

                email.ItemDescription = itemdescription;
                email.subject = String.Format("{0}|{1}", "Message from awolr.com", email.ItemDescription);
                try
                {
                    db.Emails.Add(email);
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {

                }
            }












            return CreatedAtRoute("DefaultApi", new
            {
                id = emailrecipientsplus.Id
            }, emailrecipientsplus);
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