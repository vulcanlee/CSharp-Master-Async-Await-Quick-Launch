using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AA21_程式打死結卡住了___ASP.NET_MVC.Controllers
{
    public class DefaultController : Controller
    {
        string baseURI =
            "https://backendhol.azurewebsites.net/api/performance";

        // GET: Default

        #region 這裡程式碼 會 打死結
        //public ActionResult Index()
        //{
        //    var sumTask = SumAsync(168, 89);
        //    var result = sumTask.Result;
        //    return View();
        //}
        #endregion

        #region (這裡程式碼不會打死結) 全部都使用 async await 就可以解決囉
        public async Task<ActionResult> Index()
        {
            var result = await SumAsync(168, 89);

            return View();
        }
        #endregion

        async Task<string> SumAsync(int a, int b)
        {
            var client = new HttpClient();
            var endPoint = $"{baseURI}/add/{a}/{b}/2";
            var task = client.GetStringAsync(endPoint);
            var result = await task;
            return result;
        }
    }
}