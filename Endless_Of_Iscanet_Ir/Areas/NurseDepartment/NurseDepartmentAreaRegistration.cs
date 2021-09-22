using System.Web.Mvc;

namespace Endless_Of_Iscanet_Ir.Areas.NurseDepartment
{
    public class NurseDepartmentAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NurseDepartment";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NurseDepartment_default",
                "NurseDepartment/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}