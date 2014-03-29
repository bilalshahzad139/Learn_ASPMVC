using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicMVCApp.Models;

namespace BasicMVCApp.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginVerify()
        {
            String login = Request.Form["login"];
            String password = Request.Form["password"];

            Boolean flag = UserDAL.Verify(login, password);

            if (flag == true)
                return RedirectToAction("Dashboard","User");
            else
            {
                ViewBag.ErrMsg = "Invalid User Id/Password";
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult LoginVerify1(FormCollection values)
        {
            String login = values["login"];
            String password = values["password"];

            Boolean flag = UserDAL.Verify(login, password);

            if (flag == true)
                return RedirectToAction("Dashboard", "User");
            else
            {
                ViewBag.ErrMsg = "Invalid User Id/Password";
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult LoginVerify2(string login, string password)
        {
            //String login = Request.Form["txtLogin"];
            //String password = Request.Form["txtPassword"];

            Boolean flag = BasicMVCApp.Models.UserDAL.Verify(login, password);

            if (flag == true)
                return RedirectToAction("Dashboard", "User");
            else
            {
                ViewBag.ErrMsg = "Invalid User Id/Password";
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult LoginVerify3(User user)
        {
            Boolean flag = BasicMVCApp.Models.UserDAL.Verify(user.login, user.password);

            if (flag == true)
                return RedirectToAction("Dashboard", "User");
            else
            {
                ViewBag.ErrMsg = "Invalid User Id/Password";
                return RedirectToAction("Login");
            }
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewUser()
        {
            return View("Registration");
        }

        [HttpPost]
        public ActionResult SaveUser(User user)
        {
            Boolean flag = UserDAL.SaveUser(user);

            if (flag == true)
                return RedirectToAction("Dashboard", "User");
            else
            {
                ViewBag.ErrMsg = "Some issue with data, Try again";
                return View("NewUser");
            }
        }

        [HttpPost]
        public ActionResult SaveUser1([ModelBinder(typeof(CustomBinder))] User user)
        {
            Boolean flag = UserDAL.SaveUser(user);

            if (flag == true)
                return RedirectToAction("Dashboard", "User");
            else
            {
                ViewBag.ErrMsg = "Some issue with data, Try again";
                return View("NewUser");
            }
        }

        [HttpPost]
        public JsonResult SaveUserAjax(User user)
        {
            Boolean flag = UserDAL.SaveUser(user);

            return Json(new
            {
                success = true,
                message = "Successfully Saved"
            });
            
        }


        [HttpGet]
        public ActionResult ShowAll()
        {
            List<User> data = UserDAL.GetAllUsers();
            return View("ShowAllUsers",data);
        }

        [HttpGet]
        public JsonResult ShowAllByAjax()
        {
            List<User> data = UserDAL.GetAllUsers();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login", "User");
        }
    }

//http://msdn.microsoft.com/en-us/magazine/hh781022.aspx
//http://odetocode.com/blogs/scott/archive/2009/04/27/6-tips-for-asp-net-mvc-model-binding.aspx
//http://odetocode.com/blogs/scott/archive/2009/05/05/iterating-on-an-asp-net-mvc-model-binder.aspx
//http://stackoverflow.com/questions/12300281/asp-net-mvc-model-list-binding

    public class CustomBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
                                ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            User obj = new User();

            obj.login = request.Form["login"];
            obj.password = request.Form["password"];
            obj.username= request.Form["username"];
            obj.company = request.Form["company"];

            //obj.UserAddress = new Address();
            //obj.UserAddress.Country = request.Form["UserAddress.Country"];
            //obj.UserAddress.City = request.Form["UserAddress.City"];

            return obj;

        }
    } 

}
