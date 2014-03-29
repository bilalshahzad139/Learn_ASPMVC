using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBPracWithEF.Models;

namespace DBPracWithEF.Controllers
{
    public class JSBasicUserController : Controller
    {

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult CreateUser()
        {

            return View();
        }

        [HttpPost]
        public JsonResult SaveUser(Users user)
        {

            user.EntryDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;

            UserDAL dal = new UserDAL();
            dal.SaveUser(user);

            var obj = new
            {
                success = true,
                message = "Record has been saved successfully"
            };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowAll()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            UserDAL dal = new UserDAL();
            var list = dal.GetAllUsers();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }



}
