using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Endless_Of_Iscanet_Ir.Controllers
{
    [RoutePrefix("Roles")]
    public class RolesController : Controller
    {
        ApplicationDbContext context;
        public RolesController()
        {
            context = new ApplicationDbContext();
        }
        [Route("Index")]
        // GET: Roles
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }
        [Route("Create")]

        public ActionResult Create()
        {
            var Roles = new IdentityRole();

            return View(Roles);
        }
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return View("Index");
        }
    }
}