using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Endless_Of_Iscanet_Ir.Areas.NurseDepartment.Controllers
{
    [Authorize(Roles = "Admin")]

    public class EducationCourcesController : Controller
    {
        private Iscanet_Context db = new Iscanet_Context();

        // GET: NurseDepartment/EducationCources
        public ActionResult Index()
        {
            return View(db.Nurse_Courses.ToList());
        }

        // GET: NurseDepartment/EducationCources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationCource educationCource = db.Nurse_Courses.Find(id);
            if (educationCource == null)
            {
                return HttpNotFound();
            }
            return View(educationCource);
        }

        // GET: NurseDepartment/EducationCources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NurseDepartment/EducationCources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EductionCourcesId,Title,Description,Date,Abstract,FileName")] EducationCource educationCource)
        {
            if (ModelState.IsValid)
            {
                db.Nurse_Courses.Add(educationCource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(educationCource);
        }

        // GET: NurseDepartment/EducationCources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationCource educationCource = db.Nurse_Courses.Find(id);
            if (educationCource == null)
            {
                return HttpNotFound();
            }
            return View(educationCource);
        }

        // POST: NurseDepartment/EducationCources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EductionCourcesId,Title,Description,Date,Abstract")] EducationCource educationCource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(educationCource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(educationCource);
        }

        // GET: NurseDepartment/EducationCources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationCource educationCource = db.Nurse_Courses.Find(id);
            if (educationCource == null)
            {
                return HttpNotFound();
            }
            return View(educationCource);
        }

        // POST: NurseDepartment/EducationCources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EducationCource educationCource = db.Nurse_Courses.Find(id);
            db.Nurse_Courses.Remove(educationCource);
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
