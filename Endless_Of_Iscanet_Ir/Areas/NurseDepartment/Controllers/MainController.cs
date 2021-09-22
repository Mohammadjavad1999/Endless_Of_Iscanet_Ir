using Endless_Of_Iscanet_Ir.Infrastructrues;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Endless_Of_Iscanet_Ir.Areas.NurseDepartment.Controllers
{
    [Authorize(Roles = "Admin")]

    public class MainController : Controller
    {
        private Iscanet_Context db = new Iscanet_Context();
        [AllowAnonymous]

        // GET: NurseDepartment/Main
        public ActionResult Index(int pageid=1)
        {
            var Main = new MainViewModel();
            int skip = (pageid - 1) * 3;
            var News = db.Nurse_LastNews.OrderBy(lstnews => lstnews.NurseDep_NewsId).Skip(skip).Take(3).ToList();
            var cngrs = db.NurseCongresses.OrderBy(lstnews => lstnews.NurseDepCongressId).Skip(skip).Take(3).ToList();
            var edu = db.Nurse_Courses.OrderBy(lstnews => lstnews.EductionCourcesId).Skip(skip).Take(3).ToList();
            Main.Congress = cngrs;
            Main.EductionCources = edu;
            Main.News = News;
            return View(Main);
        }
        [AllowAnonymous]

        public ActionResult ChangeCurrentCulture(int id)
        {
            CultureHelper.CurrentCulture = id;
            Session["CurrentCulture"] = id;
            return Redirect(Request.UrlReferrer.ToString());
        }
     
    }
}