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

    public class NurseDepartment_BooksController : Controller
    {
        private Iscanet_Context db = new Iscanet_Context();

        // GET: NurseDepartment/NurseDepartment_Books
        public ActionResult Index()
        {
            return View(db.Nurse_Books.ToList());
        }

        // GET: NurseDepartment/NurseDepartment_Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NurseDep_Book nurseDep_Book = db.Nurse_Books.Find(id);
            if (nurseDep_Book == null)
            {
                return HttpNotFound();
            }
            return View(nurseDep_Book);
        }

        // GET: NurseDepartment/NurseDepartment_Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NurseDepartment/NurseDepartment_Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Abstract_Description,Description,Author,Date,FileName")] NurseDep_Book nurseDep_Book)
        {
            if (ModelState.IsValid)
            {
                db.Nurse_Books.Add(nurseDep_Book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nurseDep_Book);
        }

        // GET: NurseDepartment/NurseDepartment_Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NurseDep_Book nurseDep_Book = db.Nurse_Books.Find(id);
            if (nurseDep_Book == null)
            {
                return HttpNotFound();
            }
            return View(nurseDep_Book);
        }

        // POST: NurseDepartment/NurseDepartment_Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Abstract_Description,Description,Author,Date,FileName")] NurseDep_Book nurseDep_Book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nurseDep_Book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nurseDep_Book);
        }

        // GET: NurseDepartment/NurseDepartment_Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NurseDep_Book nurseDep_Book = db.Nurse_Books.Find(id);
            if (nurseDep_Book == null)
            {
                return HttpNotFound();
            }
            return View(nurseDep_Book);
        }

        // POST: NurseDepartment/NurseDepartment_Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NurseDep_Book nurseDep_Book = db.Nurse_Books.Find(id);
            db.Nurse_Books.Remove(nurseDep_Book);
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
