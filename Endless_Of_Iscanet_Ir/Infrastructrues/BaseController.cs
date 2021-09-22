using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Endless_Of_Iscanet_Ir.Infrastructrues
{
    public class BaseController:Controller
    {
        public BaseController()
        {
            CultureInfo oci = new CultureInfo("fa-IR");
            Thread.CurrentThread.CurrentCulture = oci;
            Thread.CurrentThread.CurrentUICulture = oci;
        }
        protected override void ExecuteCore()
        {
            int culture = 0;
            if (this.Session == null || this.Session["CurrentCulture"] == null)
            {
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["Culture"], out culture);
                this.Session["CurrentCulture"] = culture;
            }
            else
            {
                culture = (int)this.Session["CurrentCulture"];
            }

            CultureHelper.CurrentCulture = culture;
            base.ExecuteCore();
        }
        protected override bool DisableAsyncSupport
        {
            get { return true; }
        }
    }
}