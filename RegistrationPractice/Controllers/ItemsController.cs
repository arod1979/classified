﻿using System;
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

namespace RegistrationPractice.Controllers
{
    public class ItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        // GET: Items
        public async Task<ActionResult> Index()
        {
            var items = db.Items.Include(i => i.Category).Include(i => i.Location);
            return View(await items.ToListAsync());
        }

        // GET: UserItems
        //allan rodkin
        public async Task<ActionResult> UserPosts()
        {
            string userid = (string)(Session["CurrentUser"]);
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == userid);
            var items = db.Items.Where(x => x.ApplicationUser.Id == userid);
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
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryText");
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "LocationText");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Description,LocationID,CategoryID,CreationDate,EmailRelayAddress,Reward,AdditionalNotes,Visits,Returned,ApplicationUserId,imageURL,imageTitle,DisplayItem")] Item item, HttpPostedFileBase files)
        {
            

            if (ModelState.IsValid)
            {

                //allan rodkin image code
                if (files!=null)
                { 
                    string time = DateTime.UtcNow.ToString();
                    time = time.Replace(" ", "-");
                    time = time.Replace(":", "-");
                    time = time.Replace("/", "-");
                    var filename = Path.GetFileName(time + Path.GetFileName(files.FileName));
                    var path = Path.Combine(Server.MapPath("~/photos"), filename);
                    string[] paths = path.Split('.');
                    string filetype = paths[1];
                
                    string fullpath = String.Format("{0}.{1}", paths[0], paths[1] );
                    files.SaveAs(fullpath);
                    item.imageURL = "http://localhost:55645/photos/" + filename;
                        //
                }

                
                


                db.Items.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
                //
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
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Description,LocationID,CategoryID,CreationDate,EmailRelayAddress,Reward,AdditionalNotes,Visits,Returned,ApplicationUserId,imageURL,imageTitle,DisplayItem")] Item item)
        {
            if (ModelState.IsValid)
            {
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
