﻿using System.Web;
using System.Web.Mvc;

namespace AA21_程式打死結卡住了___ASP.NET_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
