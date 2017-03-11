using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CitizensWeb.Models;

namespace CitizensWeb.Controllers
{
    public class CitizensController : Controller
    {
        private CitizensDataBaseEntities db = new CitizensDataBaseEntities();

        // GET: Citizens
        public ActionResult Index()
        {
            return View(db.citizens.ToList());
        }

        // GET: Citizens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Citizens/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "CitizenId,LastName,FirstName,City,BirthDate")] citizen citizen)
        {
            if (ModelState.IsValid)
            {
                db.citizens.Add(citizen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(citizen);
        }

        // GET: Citizens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citizen citizen = db.citizens.Find(id);
            if (citizen == null)
            {
                return HttpNotFound();
            }
            return View(citizen);
        }

        // POST: Citizens/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "CitizenId,LastName,FirstName,City,BirthDate")] citizen citizen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citizen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(citizen);
        }

        // GET: Citizens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citizen citizen = db.citizens.Find(id);
            if (citizen == null)
            {
                return HttpNotFound();
            }
            return View(citizen);
        }

        // POST: Citizens/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            citizen citizen = db.citizens.Find(id);
            db.citizens.Remove(citizen);
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
