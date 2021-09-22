using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Gnostice.StarDocsSDK;
namespace Endless_Of_Iscanet_Ir
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static StarDocs starDocs;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            starDocs = new StarDocs(new ConnectionInfo(new Uri(" https://api.gnostice.com/stardocs/v1"), "5bede857785e4d0db7517a7c1f8e9c93", "187320ac509c4b37ab5f979adfcd4779"));
            starDocs.Auth.loginApp();

        }
    }
}
