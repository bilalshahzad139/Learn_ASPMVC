using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewsRazorPrac.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

    }
}
