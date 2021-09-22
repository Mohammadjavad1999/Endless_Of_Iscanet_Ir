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
    [RoutePrefix("Congresses")]
    [Authorize(Roles = "Admin")]

    public class CongressesController : Controller
    {
        private Iscanet_Context db = new Iscanet_Context();
        [Route("Index")]
        [AllowAnonymous]
        // GET: Congresses
        public ActionResult Index()
        {
            return View(db.Congresses.ToList());
        }
        [AllowAnonymous]

        // GET: Congresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Congress congress = db.Congresses.Find(id);
            if (congress == null)
            {
                return HttpNotFound();
            }
            return View(congress);
        }
        [Route("Create")]
       

        // GET: Congresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Congresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CongressId,CongressTitle,Congress_Description,Date,CommentId")] Congress congress)
        {
            if (ModelState.IsValid)
            {
                db.Congresses.Add(congress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(congress);
        }
        [Route("Delete_Congresses")]
        public ActionResult Delete_Congresses()
        {
            return View();
        }
      
        [Route("Edit/{id}")]
        // GET: Congresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Congress congress = db.Congresses.Find(id);
            if (congress == null)
            {
                return HttpNotFound();
            }
            return View(congress);
        }

        // POST: Congresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CongressId,CongressTitle,Congress_Description,Date,CommentId")] Congress congress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(congress);
        }


        // GET: Congresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Congress congress = db.Congresses.Find(id);
            if (congress == null)
            {
                return HttpNotFound();
            }
            return View(congress);
        }

        // POST: Congresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Congress congress = db.Congresses.Find(id);
            db.Congresses.Remove(congress);
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
