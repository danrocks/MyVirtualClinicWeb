using System.Web;
using System.Web.Mvc;

namespace MyVirtualClinicWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // Put authentication on whole web-site, except actions that specifically allow anonymous access 
            //http://www.davidhayden.me/blog/asp.net-mvc-4-allowanonymous-attribute-and-authorize-attribute
            filters.Add(new System.Web.Mvc.AuthorizeAttribute());
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
