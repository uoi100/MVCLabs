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
    public class CourseRegistrationsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: CourseRegistrations
        public ActionResult Index()
        {
            var courseRegistrations = db.CourseRegistrations.Include(c => c.Course).Include(c => c.Student);
            return View(courseRegistrations.ToList());
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
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName");
            return View();
        }

        // POST: CourseRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseRegistrationID,CourseID,StudentID,Grade")] CourseRegistration courseRegistration)
        {
            if (ModelState.IsValid)
            {
                db.CourseRegistrations.Add(courseRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", courseRegistration.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", courseRegistration.StudentID);
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
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", courseRegistration.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", courseRegistration.StudentID);
            return View(courseRegistration);
        }

        // POST: CourseRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseRegistrationID,CourseID,StudentID,Grade")] CourseRegistration courseRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", courseRegistration.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", courseRegistration.StudentID);
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
