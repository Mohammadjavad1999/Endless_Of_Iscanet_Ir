using Infrastructrues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.ViewModels;

namespace Endless_Of_Iscanet_Ir.Areas.UserSetting.Controllers
{
    /// <summary>
    /// this part of this site will be complete in the after phaes 1 the develivery process site
    /// </summary>
    public class UserProfileController : Controller
    {
    private   Iscanet_Context db = new Iscanet_Context();
       
        
        // GET: UserSetting/UserProfile
        public ActionResult Index()
        {
            return View();
        }
        [UploadFile(FileSize = 1000 * 1024 * 1024)]
        public PartialViewResult SetImageProfile(HttpPostedFileBase file,User user)
        {
            if (ModelState.IsValid)
            {


                if (file != null && file.ContentLength > 0)
                {
                    string RootRelativePath = "~/Cotnent/Files/UserProfiles" + file.FileName;
                    string strFilnal = Server.MapPath(RootRelativePath);
                    file.SaveAs(strFilnal);
                    user.ImageProfile = strFilnal;
                }
                db.Users.Add(user);
                db.SaveChanges();
            }

            return PartialView();
            
        }
        public ActionResult Messages()
        {
            return View();
        }
        public ActionResult Articles()
        {
            return View();
        }
         public ActionResult TimeLine()
        {
            return View();
        }
    }
}