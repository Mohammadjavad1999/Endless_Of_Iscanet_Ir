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
using Infrastructrues;
using System.IO;
using Gnostice.StarDocsSDK;
namespace Endless_Of_Iscanet_Ir.Controllers
{
    [RoutePrefix("Articles")]
    [Authorize(Roles = "Admin")]

    public class ArticlesController : BaseController
    {
        private Iscanet_Context db = new Iscanet_Context();

        private DocumentionGallery db2 = new DocumentionGallery();


        [Route("Index")]
        [AllowAnonymous]

        // GET: Articles
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }
        [Route("Details/{id}")]
        [AllowAnonymous]

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);


            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }
        [Route("Create")]
 

        // GET: Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UploadFile(FileSize = 1000 * 1024 * 1024)]
        [Route("Create")]

        public ActionResult Create([Bind(Include = "ArticleId,Article_writer,Article_Title,Article_Des,Article_file_Name,Abstract_Description,Article_Date")] Article article, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {


                if (file != null && file.ContentLength > 0)
                {

                    string RootRelativePath = "~/Content/Files/ArticleFiles/" + file.FileName;
                    string strFinal = Server.MapPath(RootRelativePath);
                    file.SaveAs(strFinal);
                    article.Article_file_Name = file.FileName;                                                                                                  
                    ViewBag.PhysicalPath = strFinal.ToString();
                    ViewBag.filename = article.Article_file_Name;

                    db.Gallerydb.Add(new DocumentionGallery() { FileType = file.ContentType, DocumentName = file.FileName, DocumentRoute = strFinal }); //DocumentDate = DateTime.Today 


                }
             //   article.Article_Date = System.DateTime.Now;
                db.Articles.Add(article);
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(article);


        }
        [Route("FileReader")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult FileReader(string filename)
        {
            string PhysicalFilePath = Server.MapPath(filename);
            ViewerSettings VeiwerSettings = new ViewerSettings();
            VeiwerSettings.VisibleFileOperationControls.Open = true;
            ViewResponse ViewResponse = MvcApplication.starDocs.Viewer.CreateView(new FileObject(PhysicalFilePath), null, VeiwerSettings);
            return new RedirectResult(ViewResponse.Url);

        }
  



        [Route("Edit/{id}")]
      

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]

        public ActionResult Edit([Bind(Include = "ArticleId,Article_writer,Article_Title,Article_Des,Article_Date,PostId,Related_Tags,Abstract_Description")] Article article)
        {
            if (ModelState.IsValid)
            {



                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(article);
        }
        [Route("Delete/{id}")]


        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }
        [Route("DeleteArticles")]
     
        public ActionResult DeleteArticles()
        {
            return View(db.Articles.ToList());
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("Delete/{id}")]

        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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
