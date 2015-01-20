using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MeetingTracker.Models;
using MeetingTracker.Context;

namespace MeetingTracker.Controllers
{
    public class MeetingItemController : Controller
    {
        private readonly MeetingContext _db = new MeetingContext();

        // GET: /MeetingItem/
        public ActionResult Index()
        {
            var meetingitems = _db.MeetingItems.Include(m => m.Person);
            return View(meetingitems.ToList());
        }

        public ActionResult CurrentStatus(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingItemStatus meetingitem = _db.MeetingItemStatuses.Find(id) ;
            if (meetingitem == null)
            {
                return HttpNotFound();
            }

            return View(meetingitem);
        }


        // GET: /MeetingItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingItem meetingitem = _db.MeetingItems.Find(id);
            if (meetingitem == null)
            {
                return HttpNotFound();
            }
            return View(meetingitem);
        }

        // GET: /MeetingItem/Create
        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "FirstName");
            return View();
        }

        // POST: /MeetingItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MeetingItemId,PersonId,MeetingItemDescription,StartDate,DueDate,Priority,Status,PercentageCompleted,CompletedDate")] MeetingItem meetingitem)
        {
            if (ModelState.IsValid)
            {
                _db.MeetingItems.Add(meetingitem);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "FirstName", meetingitem.PersonId);
            return View(meetingitem);
        }

        // GET: /MeetingItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingItem meetingitem = _db.MeetingItems.Find(id);
            if (meetingitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "FirstName", meetingitem.PersonId);
            return View(meetingitem);
        }

        // POST: /MeetingItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MeetingItemId,PersonId,MeetingItemDescription,StartDate,DueDate,Priority,Status,PercentageCompleted,CompletedDate")] MeetingItem meetingitem)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(meetingitem).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "FirstName", meetingitem.PersonId);
            return View(meetingitem);
        }

        // GET: /MeetingItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingItem meetingitem = _db.MeetingItems.Find(id);
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
            MeetingItem meetingitem = _db.MeetingItems.Find(id);
            _db.MeetingItems.Remove(meetingitem);
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
