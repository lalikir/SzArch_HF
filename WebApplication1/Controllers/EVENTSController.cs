using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EVENTSController : Controller
    {
        private EventDBEntities2 db = new EventDBEntities2();

        // GET: EVENTS
        public ActionResult Index()
        {
            return View(db.EVENTS.ToList());
        }

        // GET: EVENTS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTS eVENTS = db.EVENTS.Find(id);
            if (eVENTS == null)
            {
                return HttpNotFound();
            }
            return View(eVENTS);
        }

        // GET: EVENTS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EVENTS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EVENT_ID,NAME,DATE,NUM_OF_TICKET")] EVENTS eVENTS)
        {
            if (ModelState.IsValid)
            {
                db.EVENTS.Add(eVENTS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eVENTS);
        }

        // GET: EVENTS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTS eVENTS = db.EVENTS.Find(id);
            if (eVENTS == null)
            {
                return HttpNotFound();
            }
            return View(eVENTS);
        }

        // POST: EVENTS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EVENT_ID,NAME,DATE,NUM_OF_TICKET")] EVENTS eVENTS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eVENTS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eVENTS);
        }

        // GET: EVENTS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTS eVENTS = db.EVENTS.Find(id);
            if (eVENTS == null)
            {
                return HttpNotFound();
            }
            return View(eVENTS);
        }

        // POST: EVENTS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EVENTS eVENTS = db.EVENTS.Find(id);
            db.EVENTS.Remove(eVENTS);
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
