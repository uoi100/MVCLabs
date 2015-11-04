using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCLab04.Models;

namespace MVCLab04.Controllers
{
    public class CourseRegistrationsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: CourseRegistrations
        public ActionResult Index()
        {
            return View(db.CourseRegistrations.ToList());
        }

        // GET: CourseRegistrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegistration courseRegistration = db.CourseRegistrations.Find(id);
            if (courseRegistration == null)
            {
                return HttpNotFound();
            }
            return View(courseRegistration);
        }

        // GET: CourseRegistrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseRegistrationID,Grade")] CourseRegistration courseRegistration)
        {
            if (ModelState.IsValid)
            {
                db.CourseRegistrations.Add(courseRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseRegistration);
        }

        // GET: CourseRegistrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegistration courseRegistration = db.CourseRegistrations.Find(id);
            if (courseRegistration == null)
            {
                return HttpNotFound();
            }
            return View(courseRegistration);
        }

        // POST: CourseRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseRegistrationID,Grade")] CourseRegistration courseRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseRegistration);
        }

        // GET: CourseRegistrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRegistration courseRegistration = db.CourseRegistrations.Find(id);
            if (courseRegistration == null)
            {
                return HttpNotFound();
            }
            return View(courseRegistration);
        }

        // POST: CourseRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseRegistration courseRegistration = db.CourseRegistrations.Find(id);
            db.CourseRegistrations.Remove(courseRegistration);
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
