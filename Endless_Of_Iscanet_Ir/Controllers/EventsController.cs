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
    [RoutePrefix("Events")]
[Authorize(Roles ="Admin")]
    public class EventsController : BaseController
    {
        private Iscanet_Context db = new Iscanet_Context();
        private Event db1 = new Event();

        // GET: Events
        [Route("Index")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }
        [Route("Details/{id}")]
        [AllowAnonymous]

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }
        [Route("Create")]
      
        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UploadFile(FileSize = 1000 * 1024 * 1024)]
        [Route("Create")]
        public ActionResult Create([Bind(Include = "EventId,Event_Writer,Event_Title,Event_Des,Event_Date,PostId,Related_Tags,Abstract_Description,FileName,CommentId")] Event @event, HttpPostedFileBase file, string filename)
        {

            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string RootRelativePath = "~/Content/Files/EventFiles/" + file.FileName;
                    string strFinal = Server.MapPath(RootRelativePath);
                    file.SaveAs(strFinal);
                    db.Gallerydb.Add(new DocumentionGallery() { DocumentName = file.FileName, DocumentDate = DateTime.Now, DocumentRoute = strFinal, FileType = file.ContentType });
                    @event.FileName = RootRelativePath;
                    @event.Event_Date = System.DateTime.Now;
                    @event.FileName = file.FileName;
                    ViewBag.filename = @event.FileName;
                    //  db.SaveChanges();
                }

                @event.Event_Date = DateTime.Now;
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }
        [HttpGet]
        [Route("GetPosts")]
        [AllowAnonymous]


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
        [AllowAnonymous]

        [HttpGet]
        public PartialViewResult GetComments(int PostId)
        {
            IQueryable<CommentsVM> Comments = db.Comments.Where(Current => Current.Events.EventId == PostId).Select(Current => new CommentsVM
            {
                ComID = Current.CommentId,
                CommentDate = Current.CommentedDate,
                CommentMsg = Current.CommentMsg
            }).AsQueryable();
            return PartialView("~/Views/Shared/CommentPartialViews/_EventComments.cshtml", Comments);
        }
        [Route("AddComments")]
        [AllowAnonymous]
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
            return RedirectToAction("GetComments", "Events", new { PostId = PostId });

        }
        [HttpGet]
        [Route("GetReplies")]

        [AllowAnonymous]

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

        [AllowAnonymous]
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
            return RedirectToAction("GetReplies", "Events", new { ComID = ComID });

        }
        [Route("Edit/{id}")]
  

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }
        [Route("DeleteEvents")]
      

        public ActionResult DeleteEvents()
        {
            return View(db.Events.ToList());

        }
        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit")]


        public ActionResult Edit([Bind(Include = "EventId,Event_Writer,Eevent_Title,Eevent_Des,Event_Date,PostId,Related_Tags,Abstract_Description")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }
        [Route("Delete/{id}")]
        

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }


        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id}")]
    
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
