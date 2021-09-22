using Endless_Of_Iscanet_Ir.Infrastructrues;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.ViewModels;
using System.Web.Security;
using Gnostice.StarDocsSDK;

namespace Endless_Of_Iscanet_Ir.Controllers
{
    [RoutePrefix("Home")]
    [Authorize(Roles = "Admin")]

    public class HomeController : BaseController
    {
        private Iscanet_Context db = new Iscanet_Context();
        private LastNews LNdb = new LastNews();
        private Event Evdb = new Event();


        //[Authorize]
        [Route("Index")]
        [AllowAnonymous]
        public ActionResult Index(int pageId = 1)
        {
            var index = new IndexViewModels();


            int skip = (pageId - 1) * 3;
            var lstNews = db.LastNews.OrderBy(Current => Current.LastNews_Date).Skip(skip).Take(3).ToList();
            var article = db.Articles.OrderBy(Current => Current.ArticleId).Skip(skip).Take(3).ToList();
            var Eve = db.Events.OrderBy(Current => Current.Event_Date).Skip(skip).Take(3).ToList();
            index.Articles = article;
            index.Events = Eve;
            index.LastNews = lstNews;



            return View(index);

        }
     
        [Route("Cash_Payment")]
        [AllowAnonymous]
        public ActionResult AllCash_Registration()
        {

            return View();
        }
        public ActionResult Online_Pay()
        {
            return View();
        }
        [Route("OfficalDocuments")]
        public ActionResult OfficalDocuments()
        {


            return View();
        }
        [Route("CreateOfficalDocuments")]
        [HttpGet]
        public ActionResult CreateOfficalDocuments()
        {
            return View(db.OfficalLetters.ToList());
        }
        [HttpPost]
        [Route("CreateOfficalDocuments")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOfficalDocuments(OfficalDocumentViewModel Doc, HttpPostedFileBase file)
        {


            if (ModelState.IsValid)
            {

                if (file != null && file.ContentLength > 0)
                {
                    string FileRoot = "~/Content/Files/OfficalDocuments/" + file.FileName;
                    string FinalRoot = Server.MapPath(FileRoot);
                    file.SaveAs(FinalRoot);
                    Doc.FileName = file.FileName;
                    Doc.Date = System.DateTime.Now;
                }
                return RedirectToAction("OfficalDocuments");

            }
            return View(Doc);

        }
        [Route("Logout")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        [Route("Training_Videos")]
        [AllowAnonymous]
        public ActionResult Training_Videos()
        {
            return Redirect("https://www.aparat.com/iscanet");
        }
        [Route("About_Forum")]
        [AllowAnonymous]

        public ActionResult About()
        {
            return View();
        }
        [Route("Contact_Secratariant")]
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Route("Members")]
        [AllowAnonymous]

        public ActionResult Members()
        {
            return View();
        }
        [Route("ChangeCurrentCulture/{id}")]
        [AllowAnonymous]

        public ActionResult ChangeCurrentCulture(int id)
        {
            CultureHelper.CurrentCulture = id;
            Session["CurrentCulture"] = id;
            return Redirect(Request.UrlReferrer.ToString());
        }
        [Route("DirectorBoard")]
        [AllowAnonymous]
        public ActionResult DirectorBoard()
        {
            return View();
        }
        [Route("Coricolum")]


        [HttpGet]
        public ActionResult Coricolum()
        {

            string filename = "~/Content/Files/ArticleFiles/Coricolum.pdf";
            string strFinal = Server.MapPath(filename);
            ViewerSettings VeiwerSettings = new ViewerSettings();
            VeiwerSettings.VisibleFileOperationControls.Open = true;
            ViewResponse ViewResponse = MvcApplication.starDocs.Viewer.CreateView(new FileObject(strFinal), null, VeiwerSettings);
            return new RedirectResult(ViewResponse.Url);


        }
        [Route("Payment")]
        [AllowAnonymous]
        public ActionResult Payment()
        {
            return Redirect("https://Zarinp.al/235386");
        }
        [Route("Echo_Traning")]
        [AllowAnonymous]
        public ActionResult Echo_Traning()
        {
            return View();
        }


    }
}