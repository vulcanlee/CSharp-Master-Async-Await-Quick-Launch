using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AA24_無法正常更新物件_ASP.NET_MVC.Controllers
{
    public class DefaultController : Controller
    {
        string baseURI =
      "https://backendhol.azurewebsites.net/api/performance";

        // GET: Default

        #region 這樣的寫法將無法把呼叫 API 的結果傳入到 ViewBag.Name 內
        //public async Task<ActionResult> Index()
        //{
        //    WebClient wc = new WebClient();
        //    wc.DownloadStringCompleted += (s, e) =>
        //    {
        //        ViewBag.Name = "OK" + e.Result;
        //    };
        //    var endPoint = $"{baseURI}/add/99/87/2";
        //    wc.DownloadStringAsync(new Uri(endPoint));
        //    while (wc.IsBusy)
        //    {
        //        Thread.Sleep(30);
        //    }
        //    return View();
        //}
        #endregion

        #region 將原先 EAP 的 API ，改成使用 await 來呼叫便可以解決
        public async Task<ActionResult> Index()
        {
            WebClient wc = new WebClient();

            var endPoint = $"{baseURI}/add/99/87/2";
            var result = await wc.DownloadStringTaskAsync(new Uri(endPoint));
            
            ViewBag.Name = "OK " + result;
            return View();
        }

        #endregion
    }
}