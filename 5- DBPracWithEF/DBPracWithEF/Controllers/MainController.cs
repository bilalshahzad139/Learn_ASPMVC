using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBPracWithEF.Models;

namespace DBPracWithEF.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerifyLogin(String Login,String Password)
        {
            UserDAL dal = new UserDAL();
            var flag = dal.VerifyLogin(Login, Password);
            if (flag == true)
            {
                Session["valid"] = 1;
                return RedirectToAction("Home", "BasicUser");
            }
            else
            {
                Session["valid"] = 0;
                TempData["Msg"] = "Invalid User ID/Password";   
                return RedirectToAction("Login");
            }
        }

    }
}
