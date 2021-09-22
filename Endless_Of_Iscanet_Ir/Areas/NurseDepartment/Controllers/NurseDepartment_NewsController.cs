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

    public class NurseDepartment_NewsController : Controller
    {
        private Iscanet_Context db = new Iscanet_Context();
        [AllowAnonymous]
        // GET: NurseDepartment/NurseDepartment_News
        public ActionResult Index()
        {
            return View(db.Nurse_LastNews.ToList());
        }
        [AllowAnonymous]

        // GET: NurseDepartment/NurseDepartment_News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NurseDep_News nurseDep_News = db.Nurse_LastNews.Find(id);
            if (nurseDep_News == null)
            {
                return HttpNotFound();
            }
            return View(nurseDep_News);
        }

        // GET: NurseDepartment/NurseDepartment_News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NurseDepartment/NurseDepartment_News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NurseDep_NewsId,News_Title,News_Abstract,News_Author,News_Description,FileName,Date")] NurseDep_News nurseDep_News)
        {
            if (ModelState.IsValid)
            {
                db.Nurse_LastNews.Add(nurseDep_News);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nurseDep_News);
        }

        // GET: NurseDepartment/NurseDepartment_News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NurseDep_News nurseDep_News = db.Nurse_LastNews.Find(id);
            if (nurseDep_News == null)
            {
                return HttpNotFound();
            }
            return View(nurseDep_News);
        }

        // POST: NurseDepartment/NurseDepartment_News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NurseDep_NewsId,News_Title,News_Abstract,News_Author,News_Description,FileName,Date")] NurseDep_News nurseDep_News)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nurseDep_News).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nurseDep_News);
        }

        // GET: NurseDepartment/NurseDepartment_News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NurseDep_News nurseDep_News = db.Nurse_LastNews.Find(id);
            if (nurseDep_News == null)
            {
                return HttpNotFound();
            }
            return View(nurseDep_News);
        }

        // POST: NurseDepartment/NurseDepartment_News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NurseDep_News nurseDep_News = db.Nurse_LastNews.Find(id);
            db.Nurse_LastNews.Remove(nurseDep_News);
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
