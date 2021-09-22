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
using Models.ViewModels;

namespace Endless_Of_Iscanet_Ir.Controllers
{
    [RoutePrefix("LastNews")]
    [Authorize(Roles = "Admin")]

    public class LastNewsController : BaseController
    {
        private Iscanet_Context db = new Iscanet_Context();
        private LastNews db1 = new LastNews();
        private Comment db2 = new Comment();
        //This is for upload in news pages
        private DocumentionGallery db3 = new DocumentionGallery();
        [Route("Index")]
        [AllowAnonymous]
        // GET: LastNews
        public ActionResult Index()
        {
            return View(db.LastNews.ToList());
        }
        [Route("Details/{id}")]
        // GET: LastNews/Details/5
        [AllowAnonymous]

        public ActionResult Details(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            LastNews lastNews = db.LastNews.Find(id);



            if (lastNews == null)
            {
                return View("~/Views/Shared/Notfound.cshtml");
            }
            return View(lastNews);
        }
        [HttpGet]
        [Route("GetPosts")]
        public ActionResult GetPosts()
        {
            IQueryable<PostViewModel> Posts = db.Events.Select(Current => new PostViewModel
            {
                PostID = Current.EventId,
                Message = Current.Event_Des,
                Date = Current.Event_Date
            }).AsQueryable();

            return View(Posts);
        }
        [Route("GetComments")]
        

        public PartialViewResult GetComments(int PostId)
        {
            IQueryable<CommentsVM> Comments = db.Comments.Where(Current => Current.Events.EventId == PostId).Select(Current => new CommentsVM
            {
                ComID = Current.CommentId,
                CommentDate = Current.CommentedDate,
                CommentMsg = Current.CommentMsg
            }).AsQueryable();
            return PartialView("~/Views/Shared/CommentPartialViews/_LastNewsComments", Comments);
        }
        [Route("AddComments")]
       

        public ActionResult AddComment(CommentsVM Comment, int PostId)
        {
            Comment Comments = null;
            var EventPost = db.Events.FirstOrDefault(Current => Current.EventId == PostId);
            if (Comment != null)
            {
                Comments = new Comment
                {
                    CommentMsg = Comment.CommentMsg,
                    CommentedDate = Comment.CommentDate
                };
                if (EventPost != null)
                {
                    EventPost.Comments.Add(Comments);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("GetComments", "LastNews", new { PostId = PostId });

        }
        [HttpGet]
        [Route("GetReplies")]
       

        public PartialViewResult GetReplies(int ComID)
        {
            IQueryable<ReplyVM> Replies = db.Replies.Where(Current => Current.Comments.CommentId == ComID).Select(Current => new ReplyVM
            {
                ReplyID = Current.Id,
                CommentMsg = Current.CommentMsg,

            }).AsQueryable();
            return PartialView("~/Views/Shared/_MyReplies.cshtml", Replies);
        }
        [Route("AddReplies")]
       

        public ActionResult AddReplies(ReplyVM Rep, int ComID)
        {
            Reply Replies = null;
            var Comment = db.Comments.FirstOrDefault(Current => Current.CommentId == ComID);
            if (Rep != null)
            {
                Replies = new Reply
                {
                    CommentMsg = Rep.CommentMsg,
                    CommentedDate = DateTime.Now,
                };
                if (Comment != null)
                {
                    Comment.Replies.Add(Replies);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("GetReplies", "LastNews", new { ComID = ComID });

        }
        [Route("Create")]
     

        // get: lastnews/create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LastNews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        [UploadFile(FileSize = 1000 * 1024 * 1024)]
        public ActionResult Create([Bind(Include = "LastNewsId,News_Writer,LastNews_Title,LastNews_Des,LastNews_Date,PostId,Related_Tags,Abstract_Description")] LastNews lastNews, HttpPostedFileBase file, string filename)
        {

            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string RootRelativePath = "~/Content/Files/LastNewsFiles/" + file.FileName;
                    string strFinal = Server.MapPath(RootRelativePath);
                    file.SaveAs(strFinal);
                    lastNews.FileName = file.FileName;
                    filename = lastNews.FileName;
                    ViewBag.filename = lastNews.FileName;
                    db.Gallerydb.Add(new DocumentionGallery() { FileType = file.ContentType, DocumentName = file.FileName, DocumentRoute = strFinal, DocumentDate = DateTime.Today });
                    db1.LastNews_Date = System.DateTime.Now;

                }
                lastNews.LastNews_Date = DateTime.Now;
                db.LastNews.Add(lastNews);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lastNews);
        }
        [Route("Edit/{id}")]
   

        // GET: LastNews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LastNews lastNews = db.LastNews.Find(id);
            if (lastNews == null)
            {
                return HttpNotFound();
            }
            return View(lastNews);
        }

        // POST: LastNews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit")]

        public ActionResult Edit([Bind(Include = "LastNewsId,News_Writer,LastNews_Title,LastNews_Des,LastNews_Date,PostId,Related_Tags,Abstract_Description")] LastNews lastNews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lastNews).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lastNews);
        }
        [Route("Delete/{id}")]
      

        // GET: LastNews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LastNews lastNews = db.LastNews.Find(id);
            if (lastNews == null)
            {
                return HttpNotFound();
            }
            return View(lastNews);
        }

        // POST: LastNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            LastNews lastNews = db.LastNews.Find(id);
            db.LastNews.Remove(lastNews);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("DeleteNews")]
        public ActionResult DeleteNews()
        {
            return View(db.LastNews.ToList());
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
