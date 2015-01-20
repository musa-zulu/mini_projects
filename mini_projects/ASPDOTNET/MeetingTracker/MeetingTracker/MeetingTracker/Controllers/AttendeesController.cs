using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MeetingTracker.Models;
using MeetingTracker.Context;

namespace MeetingTracker.Controllers
{
    public class AttendeesController : Controller
    {
        private readonly MeetingContext _db = new MeetingContext();

        // GET: /Attendees/
        public ActionResult Index()
        {
            var attendeeses = _db.Attendeeses.Include(a => a.Meeting).Include(a => a.Person);
            return View(attendeeses.ToList());
        }

        // GET: /Attendees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendees attendees = _db.Attendeeses.Find(id);
            if (attendees == null)
            {
                return HttpNotFound();
            }
            return View(attendees);
        }

        // GET: /Attendees/Create
        public ActionResult Create()
        {
            ViewBag.MeetingId = new SelectList(_db.Meetings, "MeetingId", "MeetingDescription");
            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "FirstName");
            return View();
        }

        // POST: /Attendees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AttendeesId,MeetingId,PersonId")] Attendees attendees)
        {
            if (ModelState.IsValid)
            {
                _db.Attendeeses.Add(attendees);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MeetingId = new SelectList(_db.Meetings, "MeetingId", "MeetingDescription", attendees.MeetingId);
            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "FirstName", attendees.PersonId);
            return View(attendees);
        }

        // GET: /Attendees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendees attendees = _db.Attendeeses.Find(id);
            if (attendees == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeetingId = new SelectList(_db.Meetings, "MeetingId", "MeetingDescription", attendees.MeetingId);
            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "FirstName", attendees.PersonId);
            return View(attendees);
        }

        // POST: /Attendees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AttendeesId,MeetingId,PersonId")] Attendees attendees)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(attendees).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MeetingId = new SelectList(_db.Meetings, "MeetingId", "MeetingDescription", attendees.MeetingId);
            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "FirstName", attendees.PersonId);
            return View(attendees);
        }

        // GET: /Attendees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendees attendees = _db.Attendeeses.Find(id);
            if (attendees == null)
            {
                return HttpNotFound();
            }
            return View(attendees);
        }

        // POST: /Attendees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendees attendees = _db.Attendeeses.Find(id);
            _db.Attendeeses.Remove(attendees);
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
