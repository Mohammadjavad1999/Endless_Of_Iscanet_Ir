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
    [RoutePrefix("OfflinePays")]
    [Authorize(Roles = "Admin")]

    public class OfflinePaysController : Controller
    {
        private Iscanet_Context db = new Iscanet_Context();
        [Route("Index")]
        // GET: OfflinePays
        public ActionResult Index()
        {
            return View(db.Offline_Paies.ToList());
        }
        [Route("Details/{id}")]
       

        // GET: OfflinePays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfflinePay offlinePay = db.Offline_Paies.Find(id);
            if (offlinePay == null)
            {
                return HttpNotFound();
            }
            return View(offlinePay);
        }
        [Route("Create")]
        [AllowAnonymous]
        // GET: OfflinePays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfflinePays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create")]

        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OfflinePayId,FullName,Fathersname,Id,Pay_Id,Born_Place,Born_Date,Medec_Org_Id,Address,Postal_Code,PhoneNumber,Expert,Email,StaticPhone,Description")] OfflinePay offlinePay)
        {
            if (ModelState.IsValid)
            {
                db.Offline_Paies.Add(offlinePay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offlinePay);
        }
        [Route("Edit/{id}")]
        // GET: OfflinePays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfflinePay offlinePay = db.Offline_Paies.Find(id);
            if (offlinePay == null)
            {
                return HttpNotFound();
            }
            return View(offlinePay);
        }
        [Route("Delete_Pays")]
        [AllowAnonymous]
        public ActionResult Delete_Pays()
        {
            return View(db.Offline_Paies.ToList());
        }

        // POST: OfflinePays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit")]
        public ActionResult Edit([Bind(Include = "OfflinePayId,FullName,Fathersname,Id,Pay_Id,Born_Place,Born_Date,Medec_Org_Id,Address,Postal_Code,PhoneNumber,Expert,Email,StaticPhone,Description")] OfflinePay offlinePay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offlinePay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(offlinePay);
        }
        [Route("Delete/{id}")]
        // GET: OfflinePays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfflinePay offlinePay = db.Offline_Paies.Find(id);
            if (offlinePay == null)
            {
                return HttpNotFound();
            }
            return View(offlinePay);
        }
        [Route("Delete")]
        // POST: OfflinePays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfflinePay offlinePay = db.Offline_Paies.Find(id);
            db.Offline_Paies.Remove(offlinePay);
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
