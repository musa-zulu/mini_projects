using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MeetingTracker.Models;
using MeetingTracker.Context;

namespace MeetingTracker.Controllers
{
    public class MeetingController : Controller
    {
        private readonly MeetingContext _db = new MeetingContext();

        // GET: /Meeting/
        public ActionResult Index()
        {
            var meetings = _db.Meetings.Include(m => m.MeetingType);
            return View(meetings.ToList());
        }

  
        // GET: /Meeting/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = _db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }


        public ActionResult Minutes(int? id)
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

        // GET: /Meeting/Create
        public ActionResult Create()
        {
            ViewBag.MeetingTypeId = new SelectList(_db.MeetingTypes, "MeetingTypeId", "MeetingTypeDescription");
            return View();
        }

        // POST: /Meeting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MeetingId,MeetingDescription,MeetingDate,StartTime,EndTime,Location,MeetingTypeId")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _db.Meetings.Add(meeting);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MeetingTypeId = new SelectList(_db.MeetingTypes, "MeetingTypeId", "MeetingTypeDescription", meeting.MeetingTypeId);
            return View(meeting);
        }

        // GET: /Meeting/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = _db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeetingTypeId = new SelectList(_db.MeetingTypes, "MeetingTypeId", "MeetingTypeDescription", meeting.MeetingTypeId);
            return View(meeting);
        }

        // POST: /Meeting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MeetingId,MeetingDescription,MeetingDate,StartTime,EndTime,Location,MeetingTypeId")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(meeting).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MeetingTypeId = new SelectList(_db.MeetingTypes, "MeetingTypeId", "MeetingTypeDescription", meeting.MeetingTypeId);
            return View(meeting);
        }

        // GET: /Meeting/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = _db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // POST: /Meeting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meeting meeting = _db.Meetings.Find(id);
            _db.Meetings.Remove(meeting);
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
