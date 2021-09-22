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

    public class NurseDepartment_ArticlesController : Controller
    {
        private Iscanet_Context db = new Iscanet_Context();

        // GET: NurseDepartment/NurseDepartment_Articles
        public ActionResult Index()
        {
            return View(db.Nurse_Articles.ToList());
        }

        // GET: NurseDepartment/NurseDepartment_Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NurseDep_Article nurseDep_Article = db.Nurse_Articles.Find(id);
            if (nurseDep_Article == null)
            {
                return HttpNotFound();
            }
            return View(nurseDep_Article);
        }

        // GET: NurseDepartment/NurseDepartment_Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NurseDepartment/NurseDepartment_Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,FileName,Date,Author")] NurseDep_Article nurseDep_Article)
        {
            if (ModelState.IsValid)
            {
                db.Nurse_Articles.Add(nurseDep_Article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nurseDep_Article);
        }

        // GET: NurseDepartment/NurseDepartment_Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NurseDep_Article nurseDep_Article = db.Nurse_Articles.Find(id);
            if (nurseDep_Article == null)
            {
                return HttpNotFound();
            }
            return View(nurseDep_Article);
        }

        // POST: NurseDepartment/NurseDepartment_Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,FileName,Date,Author")] NurseDep_Article nurseDep_Article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nurseDep_Article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nurseDep_Article);
        }

        // GET: NurseDepartment/NurseDepartment_Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NurseDep_Article nurseDep_Article = db.Nurse_Articles.Find(id);
            if (nurseDep_Article == null)
            {
                return HttpNotFound();
            }
            return View(nurseDep_Article);
        }

        // POST: NurseDepartment/NurseDepartment_Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NurseDep_Article nurseDep_Article = db.Nurse_Articles.Find(id);
            db.Nurse_Articles.Remove(nurseDep_Article);
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
