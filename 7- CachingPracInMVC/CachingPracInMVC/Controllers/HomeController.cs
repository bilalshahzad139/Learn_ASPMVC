using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CachingPracInMVC.Controllers
{
    public class HomeController : Controller
    {
        //For 120 seconds, this page will be cached, 
        //Location can have Client, Server, ServerAndClient, DownStream, None
        [OutputCache(Duration=120, VaryByParam="Name", Location=System.Web.UI.OutputCacheLocation.ServerAndClient)]
        public ActionResult Index()
        {
            return View();
        }

    }
}
