using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MeetingTracker.Models;
using MeetingTracker.Context;

namespace MeetingTracker.Controllers
{
    public class MeetingItemStatusController : Controller
    {
        private readonly MeetingContext _db = new MeetingContext();

        // GET: /MeetingItemStatus/
        public ActionResult Index()
        {
            var meetingitemstatuses = _db.MeetingItemStatuses.Include(m => m.Meeting).Include(m => m.MeetingItem).Include(m => m.Person);
            return View(meetingitemstatuses.ToList());
        }

        // GET: /MeetingItemStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingItemStatus meetingitemstatus = _db.MeetingItemStatuses.Find(id);
            if (meetingitemstatus == null)
            {
                return HttpNotFound();
            }
            return View(meetingitemstatus);
        }

        // GET: /MeetingItemStatus/Create
        public ActionResult Create()
        {
            ViewBag.MeetingId = new SelectList(_db.Meetings, "MeetingId", "MeetingDescription");
            ViewBag.MeetingItemId = new SelectList(_db.MeetingItems, "MeetingItemId", "MeetingItemDescription");
            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "FirstName");
            return View();
        }

        // POST: /MeetingItemStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MeetingItemStatusId,PersonId,MeetingId,MeetingItemId,CurrentStatus,ActionRequired,DateUpdated")] MeetingItemStatus meetingitemstatus)
        {
            if (ModelState.IsValid)
            {
                _db.MeetingItemStatuses.Add(meetingitemstatus);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MeetingId = new SelectList(_db.Meetings, "MeetingId", "MeetingDescription", meetingitemstatus.MeetingId);
            ViewBag.MeetingItemId = new SelectList(_db.MeetingItems, "MeetingItemId", "MeetingItemDescription", meetingitemstatus.MeetingItemId);
            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "FirstName", meetingitemstatus.PersonId);
            return View(meetingitemstatus);
        }

        // GET: /MeetingItemStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingItemStatus meetingitemstatus = _db.MeetingItemStatuses.Find(id);
            if (meetingitemstatus == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeetingId = new SelectList(_db.Meetings, "MeetingId", "MeetingDescription", meetingitemstatus.MeetingId);
            ViewBag.MeetingItemId = new SelectList(_db.MeetingItems, "MeetingItemId", "MeetingItemDescription", meetingitemstatus.MeetingItemId);
            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "FirstName", meetingitemstatus.PersonId);
            return View(meetingitemstatus);
        }

        // POST: /MeetingItemStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MeetingItemStatusId,PersonId,MeetingId,MeetingItemId,CurrentStatus,ActionRequired,DateUpdated")] MeetingItemStatus meetingitemstatus)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(meetingitemstatus).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MeetingId = new SelectList(_db.Meetings, "MeetingId", "MeetingDescription", meetingitemstatus.MeetingId);
            ViewBag.MeetingItemId = new SelectList(_db.MeetingItems, "MeetingItemId", "MeetingItemDescription", meetingitemstatus.MeetingItemId);
            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "FirstName", meetingitemstatus.PersonId);
            return View(meetingitemstatus);
        }

        // GET: /MeetingItemStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingItemStatus meetingitemstatus = _db.MeetingItemStatuses.Find(id);
            if (meetingitemstatus == null)
            {
                return HttpNotFound();
            }
            return View(meetingitemstatus);
        }

        // POST: /MeetingItemStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeetingItemStatus meetingitemstatus = _db.MeetingItemStatuses.Find(id);
            _db.MeetingItemStatuses.Remove(meetingitemstatus);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
