using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegistrationPractice.Entities;
using RegistrationPractice.Models;
using System.IO;
using RegistrationPractice.HelperMethods;
using Microsoft.AspNet.Identity;
using Classes.Profanity.Logic;
using PagedList;

namespace RegistrationPractice.Controllers
{
    public class ItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly ProfanityFilter pf = new ProfanityFilter(new List<string>
        {
                "bad",
                "ugly",
                "danger"
        });

        //allan rodkin

        public async Task<ActionResult> UserPosts()
        {
            string useremail = (string)System.Web.HttpContext.Current.Session["UserEmail"];
            var items = db.Items.Where(i => i.OwnerUserEmail == useremail);
            return View(await items.ToListAsync());
        }

        // GET: Items
        public async Task<ActionResult> Index(string searchTerm)
        {
            var items = db.Items.Include(i => i.Category).Include(i => i.Location);
            if (!String.IsNullOrEmpty(searchTerm))
                
            {
                items = items.Where(i => i.Description.ToUpper().Contains(searchTerm.ToUpper())
                || i.AdditionalNotes.ToUpper().Contains(searchTerm.ToUpper())
               );


            }
            

            return View(await items.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            
            Item item = new Item();

            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryText");
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "LocationText");

            //allan rodkin. this should be replaced with session variable
            string useremail = (string)System.Web.HttpContext.Current.Session["UserEmail"];
            item.OwnerUserEmail = useremail;
            //
            item.EmailRelayAddress = "";
            item.CreationDate = System.DateTime.Now;
            item.Visits = 0;
            item.Returned = false;
            item.HideItem = false;


            return View("Create", item);
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,LostOrFoundItem,NoReward,ItemReward,Description,LocationID,CategoryID,CreationDate,EmailRelayAddress,AdditionalNotes,Visits,Returned,OwnerUserEmail,imageURL,imageTitle,HideItem")] Item item, HttpPostedFileBase files)
        {
            if (ModelState.IsValid)
            {
                //profanity check
                bool textContainsProfanity = pf.ValidateTextContainsProfanity(item.Description);
                if (textContainsProfanity)
                {
                    //item.Description = pf.CleanTextProfanity(item.Description);
                    ViewBag.Message = "Post contains profanity. Cannot submit.";
                    return View("Profanity");
                }

                //string email = (string)(Session["UserEmail"]);
                //item.OwnerUserEmail = email;




                //allan rodkin image code
                if (files != null)
                {
                    string time = DateTime.UtcNow.ToString();
                    time = time.Replace(" ", "-");
                    time = time.Replace(":", "-");
                    time = time.Replace("/", "-");
                    var filename = Path.GetFileName(time + Path.GetFileName(files.FileName));
                    var path = Path.Combine(Server.MapPath("~/photos"), filename);
                    string[] paths = path.Split('.');
                    string filetype = paths[1];

                    string fullpath = String.Format("{0}.{1}", paths[0], paths[1]);
                    files.SaveAs(fullpath);
                    item.imageURL = "http://localhost:55645/photos/" + filename;
                    //
                }

                db.Items.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryText", item.CategoryID);
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "LocationText", item.LocationID);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryText", item.CategoryID);
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "LocationText", item.LocationID);
            if (item.imageURL != null) ViewBag.ImageUrl = item.imageURL;
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,LostOrFoundItem,NoReward,ItemReward,Description,LocationID,CategoryID,CreationDate,EmailRelayAddress,AdditionalNotes,Visits,Returned,OwnerUserEmail,imageURL,imageTitle,HideItem")] Item item, HttpPostedFileBase files)
        {
            if (ModelState.IsValid)
            {
                //profanity check
                bool textContainsProfanity = pf.ValidateTextContainsProfanity(item.Description);
                if (textContainsProfanity)
                {
                    //item.Description = pf.CleanTextProfanity(item.Description);
                    Item item2 = await db.Items.FindAsync(item.Id);
                    db.Items.Remove(item2);
                    await db.SaveChangesAsync();
                    
                    ViewBag.Message = "Post contains profanity. Cannot submit.";
                    return View("Profanity");
                }

                //allan rodkin image code
                if (files != null)
                {
                    string time = DateTime.UtcNow.ToString();
                    time = time.Replace(" ", "-");
                    time = time.Replace(":", "-");
                    time = time.Replace("/", "-");
                    var filename = Path.GetFileName(time + Path.GetFileName(files.FileName));
                    var path = Path.Combine(Server.MapPath("~/photos"), filename);
                    string[] paths = path.Split('.');
                    string filetype = paths[1];

                    string fullpath = String.Format("{0}.{1}", paths[0], paths[1]);
                    files.SaveAs(fullpath);
                    item.imageURL = "http://localhost:55645/photos/" + filename;
                    //
                }

                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryText", item.CategoryID);
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "LocationText", item.LocationID);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Item item = await db.Items.FindAsync(id);
            db.Items.Remove(item);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
