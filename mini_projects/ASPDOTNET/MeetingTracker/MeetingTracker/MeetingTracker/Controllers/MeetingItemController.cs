using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeetingTracker.Models;

namespace MeetingTracker.Controllers
{
    public class MeetingItemController : Controller
    {
        private MeetingContext db = new MeetingContext();

        // GET: /MeetingItem/
        public ActionResult Index()
        {
            return View(db.MeetingItems.ToList());
        }

        // GET: /MeetingItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingItem meetingitem = db.MeetingItems.Find(id);
            if (meetingitem == null)
            {
                return HttpNotFound();
            }
            return View(meetingitem);
        }

        // GET: /MeetingItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MeetingItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MeetingItemId,MeetingItemDescription,Priority,PercentageCompleted,Duration")] MeetingItem meetingitem)
        {
            if (ModelState.IsValid)
            {
                db.MeetingItems.Add(meetingitem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meetingitem);
        }

        // GET: /MeetingItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingItem meetingitem = db.MeetingItems.Find(id);
            if (meetingitem == null)
            {
                return HttpNotFound();
            }
            return View(meetingitem);
        }

        // POST: /MeetingItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MeetingItemId,MeetingItemDescription,Priority,PercentageCompleted,Duration")] MeetingItem meetingitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetingitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meetingitem);
        }

        // GET: /MeetingItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingItem meetingitem = db.MeetingItems.Find(id);
            if (meetingitem == null)
            {
                return HttpNotFound();
            }
            return View(meetingitem);
        }

        // POST: /MeetingItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeetingItem meetingitem = db.MeetingItems.Find(id);
            db.MeetingItems.Remove(meetingitem);
            db.SaveChanges();
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
