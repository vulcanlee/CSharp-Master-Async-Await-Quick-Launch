using System.Web;
using System.Web.Mvc;

namespace AA24_無法正常更新物件_ASP.NET_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
