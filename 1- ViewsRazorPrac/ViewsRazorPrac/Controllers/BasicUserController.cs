using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewsRazorPrac.Models;

namespace ViewsRazorPrac.Controllers
{
    public class BasicUserController : Controller
    {
        
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult RazorPracView()
        {
            return View();
        }
        public ActionResult ViewBagPrac()
        {
            //ViewBag is of type dynamic.

            //We are adding two parameters to 'ViewBag' to pass to View
            ViewBag.ID = 1;
            ViewBag.Message = "Hello World";

            BasicUserDTO dto = new BasicUserDTO();
            dto.UserName = "Bilal";
            dto.Company = "Testing";

            //Adding dto as 'Object'
            ViewBag.Data = dto;

            return View();
        }

        public ActionResult ViewDataPrac()
        {
            ViewBag.Title = "ViewData Practice";

            //ViewBag & ViewData can be used alternatively
            //ViewData is of type 'ViewDataDictionary', data are stored against Key,Value pair format

            //We are adding two parameters to 'ViewData' to pass to View
            ViewData["ID"]= 1;
            ViewData["Message"] = "Hello World";


            //This will overwrite ViewData 'ID' value
            ViewBag.ID = 2;

            BasicUserDTO dto = new BasicUserDTO();
            dto.UserName = "Bilal";
            dto.Company = "Testing";

            //Adding as 'Object'
            ViewData["Data"] = dto;

            return View();
        }

        public ActionResult HtmlHelperPrac1()
        {
            return View();
        }
        public ActionResult HtmlHelperPrac2()
        {
            return View();
        }

        public ActionResult TestView()
        {
            return View();
        }

        public ActionResult PartialViewPrac()
        {
            return PartialView();
        }
    }

    
}
