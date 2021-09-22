using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Endless_Of_Iscanet_Ir.Infrastructrues
{
    public class ErrorLogAttribute:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            StreamWriter Ostreamwriter = new StreamWriter(HttpContext.Current.Server.MapPath("~/App_Data/ErrorLog.txt"), true);
            Ostreamwriter.WriteLine("Error Details :  " + filterContext.Exception.Message + "  IP Adreess:  " + HttpContext.Current.Request.UserHostAddress + "  Path : " + HttpContext.Current.Request.PhysicalPath);
            Ostreamwriter.Dispose();
       
        }
    }
}