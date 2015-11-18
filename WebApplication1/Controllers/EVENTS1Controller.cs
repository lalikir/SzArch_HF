using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bll;

namespace WebApplication1.Controllers
{
    public class EVENTS1Controller : Controller
    {
        private EventDBEntities db = new EventDBEntities();

        // GET: EVENTS1
        public ActionResult Index()
        {
            return View(db.EVENTS.ToList());
        }

        // GET: EVENTS1/Details/5
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

        // GET: EVENTS1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EVENTS1/Create
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

        // GET: EVENTS1/Edit/5
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

        // POST: EVENTS1/Edit/5
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

        // GET: EVENTS1/Delete/5
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

        // POST: EVENTS1/Delete/5
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
