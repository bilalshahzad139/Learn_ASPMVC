using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBPracWithEF.Models;

namespace DBPracWithEF.Controllers
{
    public class BasicUserController : Controller
    {

        public ActionResult Home()
        {
            var flg = IsValidUser();
            if (flg == false)
                return RedirectToAction("Login", "Main");

            return View();
        }

        public ActionResult CreateUser()
        {
            var flg = IsValidUser();
            if (flg == false)
                return RedirectToAction("Login", "Main");

            return View();
        }

        [HttpPost]
        public ActionResult SaveUser(Users user)
        {
            var flg = IsValidUser();
            if (flg == false)
                return RedirectToAction("Login", "Main");

            user.EntryDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;

            UserDAL dal = new UserDAL();
            dal.SaveUser(user);

            return RedirectToAction("ShowAll");

        }

        public ActionResult ShowAll()
        {
            var flg = IsValidUser();
            if (flg == false)
                return RedirectToAction("Login", "Main");

            UserDAL dal = new UserDAL();
            var list = dal.GetAllUsers();
            return View(list);
        }

        public ActionResult EditUser(int id)
        {
            var flg = IsValidUser();
            if (flg == false)
                return RedirectToAction("Login", "Main");

            UserDAL dal = new UserDAL();
            var dto = dal.GetUserById(id);

            return View("CreateUser", dto);
        }
        public ActionResult DeleteUser(int id)
        {
            var flg = IsValidUser();
            if (flg == false)
                return RedirectToAction("Login", "Main");

            UserDAL dal = new UserDAL();
            var dto = dal.DeleteUserById(id);

            return RedirectToAction("ShowAll");
        }


        public Boolean IsValidUser()
        {
            var data = Session["valid"];
           

            if (data != null)
            {
                int a = (int)data;

                if (a == 0)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }


}
