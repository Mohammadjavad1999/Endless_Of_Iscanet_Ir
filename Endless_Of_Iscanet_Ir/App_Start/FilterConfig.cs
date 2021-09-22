using System.Web;
using System.Web.Mvc;
using Infrastructrues;
using Endless_Of_Iscanet_Ir.Infrastructrues;

namespace Endless_Of_Iscanet_Ir
{
    public class FilterConfig
    { 
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorLogAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
