using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infrastructrues;
using Models;
using static System.Net.WebRequestMethods;
using Endless_Of_Iscanet_Ir.Infrastructrues;

namespace Endless_Of_Iscanet_Ir.Controllers
{
    [RoutePrefix("Additional_Uploads")]
    public class Additional_UploadsController : BaseController
    {
        private Iscanet_Context db = new Iscanet_Context();
        private DocumentionGallery db1 = new DocumentionGallery();
        // GET: Additional_Uploads
        [Route("Index")]
        public ActionResult Index()
        {
            return View(db.Gallerydb.ToList());
        }

        [Route("Carousel_Picture")]
        [UploadFile(FileSize = 1 * 1024 * 1024)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Carousel_Picture(HttpPostedFileBase file_Upload,DocumentionGallery Carousel_Picture)
        {
            if (file_Upload.ContentLength>0&&file_Upload!=null)
            {
                string RootRealtivePath = "~/Content/Files/Current_Uploads/Carousel_Pictures";
                string strFinal = Server.MapPath(RootRealtivePath);
                file_Upload.SaveAs(strFinal);
                Carousel_Picture.DocumentDate = System.DateTime.Now;
                Carousel_Picture.DocumentName = file_Upload.FileName;
                Carousel_Picture.DocumentRoute = strFinal;
                Carousel_Picture.FileType = file_Upload.ContentType;
                db.Gallerydb.Add(Carousel_Picture);
                db.SaveChanges();
              


            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
        [UploadFile(FileSize = 1 * 1024 * 1024 * 1024)]
        [HttpPost]
        [Route("Gu_Line_Videos")]
        [ValidateAntiForgeryToken]
        public ActionResult Guide_Line_Videos(HttpPostedFileBase Gu_Line_file, DocumentionGallery DGdb)
        {
            if (Gu_Line_file.ContentLength > 0 && Gu_Line_file != null)
            {
                string RootRelativePath = "~/Content/Files/Current_Uploads/Guide_Line_Videos";
                ViewBag.GuideLineFileName = Gu_Line_file.FileName;
                string strFinal = Server.MapPath(RootRelativePath);
                Gu_Line_file.SaveAs(strFinal);
                DGdb.DocumentDate = System.DateTime.Now;
                DGdb.DocumentName = Gu_Line_file.FileName;
                DGdb.DocumentRoute = strFinal;
                db.Gallerydb.Add(DGdb);
                db.SaveChanges();
            }
            return View();
        }
        [UploadFile(FileSize = 1 * 1024 * 1024 * 1024)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Train_Videos_Upload")]
        public ActionResult Train_Videos_Upload(HttpPostedFileBase Tr_file, DocumentionGallery DGdb)
        {
            if (Tr_file.ContentLength > 0 && Tr_file != null)
            {
                string RootRelativePath = "~/Content/Files/Current_Uploads/Train_Videos";
                ViewBag.TrainFileName = Tr_file.FileName;
                string strFinal = Server.MapPath(RootRelativePath);
                Tr_file.SaveAs(strFinal);
                DGdb.DocumentDate = System.DateTime.Now;
                DGdb.DocumentName = Tr_file.FileName;
                DGdb.DocumentRoute = strFinal;
                db.Gallerydb.Add(DGdb);
                db.SaveChanges();
            }
            return View();
        }
        [Route("Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }
     
            DocumentionGallery Gallery = db.Gallerydb.Find(id);
            if (Gallery==null )
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }
            return View(Gallery);
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