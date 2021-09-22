using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using System.Data.SqlClient;
using Infrastructrues;
using Endless_Of_Iscanet_Ir.Infrastructrues;
using Gnostice.StarDocsSDK;

namespace Endless_Of_Iscanet_Ir.Controllers
{
    [RoutePrefix("Books")]
    [Authorize(Roles = "Admin")]

    public class BooksController : BaseController
    {
        private Iscanet_Context db = new Iscanet_Context();
        private Book db1 = new Book();
        // GET: Books
        [Route("Index")]
        [AllowAnonymous]

        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }
        [Route("DeleteBooks")]
        public ActionResult DeleteBooks()
        {
            return View(db.Books.ToList());
        }
        [Route("Details/{id}")]
        [AllowAnonymous]

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Route("Create")]

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UploadFile(FileSize = 1000 * 1024 * 1024)]
        [Route("Create")]
        public ActionResult Create([Bind(Include = "BookId,Book_writer,Book_Title,Book_Des,Book_Date,Book_file_Name,CommentId,DocumentId,Abstract_Description")] Book book, HttpPostedFileBase file, string fileName)
        {
            if (ModelState.IsValid)
            {
                if (file !=null && file.ContentLength>0)
                {

                string RootRelativePath = "~/Content/Files/BookFiles/" + file.FileName;
                string strFinal = Server.MapPath(RootRelativePath);
                file.SaveAs(strFinal);
                    book.Book_file_Name = file.FileName;
                db.Gallerydb.Add(new DocumentionGallery() { DocumentName = file.FileName, DocumentDate = DateTime.Now, DocumentRoute = strFinal, FileType = file.ContentType });
               // db1.Book_Date = System.DateTime.Now;
            
                }

                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            return View(book);

        }
        //[Route("FileReader")]
        //[HttpPost]


        //public ActionResult FileReader(string filename)
        //{
        //    string PhysicalFilePath = Server.MapPath(filename);
        //    ViewerSettings VeiwerSettings = new ViewerSettings();
        //    VeiwerSettings.VisibleFileOperationControls.Open = true;
        //    ViewResponse ViewResponse = MvcApplication.starDocs.Viewer.CreateView(new FileObject(PhysicalFilePath), null, VeiwerSettings);
        //    return new RedirectResult(ViewResponse.Url);

        //}
        [Route("Edit/{id}")]
       

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
    

        public ActionResult Search(string Search_Text)
        {

            return View();
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit")]
        public ActionResult Edit([Bind(Include = "BookId,Book_writer,Book_Title,Book_Des,Book_Date,Book_file_Name,CommentId,DocumentId,Abstract_Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }
        [Route("Delete/{id}")]
      

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
