using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Endless_Of_Iscanet_Ir.Controllers
{
    [RoutePrefix("OfficialLetters")]
    [Authorize(Roles = "Admin")]

    public class OfficialLettersController : Controller
    {
        private Iscanet_Context db = new Iscanet_Context();

        // GET: OfficialLetters
        [AllowAnonymous]
        [Route("Index")]
        public ActionResult Index()
        {
            return View(db.OfficalLetters.ToList());
        }
        [Route("Details/{id}")]
        // GET: OfficialLetters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficialLetter officialLetter = db.OfficalLetters.Find(id);
            if (officialLetter == null)
            {
                return HttpNotFound();
            }
            return View(officialLetter);
        }
        [Route("Create")]
        // GET: OfficialLetters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfficialLetters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]

        public ActionResult Create([Bind(Include = "Id,FileName,Date,Title")] OfficialLetter officialLetter,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file!=null &&file.ContentLength>0)
                {
                    string filename = "~/Content/Files/OfficalDocuments/" + file.FileName;
                    string strFinal = Server.MapPath(filename);
                    file.SaveAs(strFinal);
                    officialLetter.FileName = file.FileName;
                }
                db.OfficalLetters.Add(officialLetter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(officialLetter);
        }
        [Route("Edit/{id}")]
        // GET: OfficialLetters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficialLetter officialLetter = db.OfficalLetters.Find(id);
            if (officialLetter == null)
            {
                return HttpNotFound();
            }
            return View(officialLetter);
        }

        // POST: OfficialLetters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]
        public ActionResult Edit([Bind(Include = "Id,FileName,Date,Title")] OfficialLetter officialLetter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(officialLetter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(officialLetter);
        }

        // GET: OfficialLetters/Delete/5
        [Route("Delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficialLetter officialLetter = db.OfficalLetters.Find(id);
            if (officialLetter == null)
            {
                return HttpNotFound();
            }
            return View(officialLetter);
        }

        // POST: OfficialLetters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            OfficialLetter officialLetter = db.OfficalLetters.Find(id);
            db.OfficalLetters.Remove(officialLetter);
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
