using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using Endless_Of_Iscanet_Ir.Infrastructrues;

namespace Endless_Of_Iscanet_Ir.Controllers
{
    [RoutePrefix("CongressRegisterForms")]
    [Authorize(Roles = "Admin")]

    public class CongressRegisterFormsController : BaseController
    {
        private Iscanet_Context db = new Iscanet_Context();
        [Route("Index")]
        // GET: CongressRegisterForms
        public ActionResult Index()
        {
            return View(db.RegisterForms.ToList());
        }
        [Route("Details/{id}")]
        [AllowAnonymous]

        // GET: CongressRegisterForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongressRegisterForm congressRegisterForm = db.RegisterForms.Find(id);
            if (congressRegisterForm == null)
            {
                return HttpNotFound();
            }
            return View(congressRegisterForm);
        }
        [Route("Create")]
        [AllowAnonymous]


        // GET: CongressRegisterForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CongressRegisterForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        [AllowAnonymous]


        public ActionResult Create([Bind(Include = "ItemId,Email,Phone,Expert,Mediecial_Org_Id,DateOfRegister,FullName")] CongressRegisterForm congressRegisterForm)
        {
            if (ModelState.IsValid)
            {
                db.RegisterForms.Add(congressRegisterForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(congressRegisterForm);
        }
        [Route("Edit/{id}")]


        // GET: CongressRegisterForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongressRegisterForm congressRegisterForm = db.RegisterForms.Find(id);
            if (congressRegisterForm == null)
            {
                return HttpNotFound();
            }
            return View(congressRegisterForm);
        }

        // POST: CongressRegisterForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit")]

        public ActionResult Edit([Bind(Include = "ItemId,Email,Phone,Expert,Mediecial_Org_Id,DateOfRegister,FullName")] CongressRegisterForm congressRegisterForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congressRegisterForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(congressRegisterForm);
        }
        [Route("Delete/{id}")]

        // GET: CongressRegisterForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongressRegisterForm congressRegisterForm = db.RegisterForms.Find(id);
            if (congressRegisterForm == null)
            {
                return HttpNotFound();
            }
            return View(congressRegisterForm);
        }

        // POST: CongressRegisterForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("DeleteConfirmed/{id}")]

        public ActionResult DeleteConfirmed(int id)
        {
            CongressRegisterForm congressRegisterForm = db.RegisterForms.Find(id);
            db.RegisterForms.Remove(congressRegisterForm);
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
