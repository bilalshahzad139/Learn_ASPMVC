using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ModelBinderPrac.Models; //To access our classes in this namespace
namespace ModelBinderPrac.Controllers
{
    public class BasicUserController : Controller
    {

        public ActionResult Home()
        {
            return View();
        }


        //To show Creat1 Form
        [HttpGet]
        public ActionResult Create1()
        {
            return View();
        }
        
        //To show Creat2 Form
        [HttpGet]
        public ActionResult Create2()
        {
            return View();
        }
        
        //To show Creat3 Form
        [HttpGet]
        public ActionResult Create3()
        {
            return View();
        }

        //To show Creat4 Form
        [HttpGet]
        public ActionResult Create4()
        {
            return View();
        }


        //Get data manually by Request
        [HttpPost]
        public ActionResult SaveUser1()
        {
            BasicUserDTO user = new BasicUserDTO();

            user.UserName = Request.Form["UserName"]; //Extract data from Request.Form by providing field 'name'
            user.Company = Request["Company"]; //Extract data from Request directly by providing field 'name'
            user.Login = Request["Login"];
            user.Password = Request.Form["Password"];

            ViewBag.Msg = String.Format("UserName:'{0}',Company:'{1}',Login:'{2}',Password:'{3}'",user.UserName,user.Company,user.Login,user.Password);
            return View("Create1");
        }

        //Get data manually by value provider, This data is extracted from 'Request' internally
        [HttpPost]
        public ActionResult SaveUser2(FormCollection values)
        {
            BasicUserDTO user = new BasicUserDTO();
            user.UserName = values["UserName"]; //Extract data from FormCollection by providing field 'name'
            user.Company = values["Company"]; 
            user.Login = values["Login"];
            user.Password = values["Password"];

            ViewBag.Msg = String.Format("UserName:'{0}',Company:'{1}',Login:'{2}',Password:'{3}'", user.UserName, user.Company, user.Login, user.Password);
            return View("Create2");
        }

        //Map 'Request' fields to function parameter list
        [HttpPost]
        public ActionResult SaveUser3(String UserName,String Company,String Login,String Password)
        {
            BasicUserDTO user = new BasicUserDTO();
            user.UserName = UserName; //Extract data from FormCollection by providing field 'name'
            user.Company = Company;
            user.Login = Login;
            user.Password = Password;

            ViewBag.Msg = String.Format("UserName:'{0}',Company:'{1}',Login:'{2}',Password:'{3}'", user.UserName, user.Company, user.Login, user.Password);
            return View("Create3");
        }

        //DefaultModelBinder will automatically extract data from 'Request' and load into complex type
        [HttpPost]
        public ActionResult SaveUser4(BasicUserDTO user)
        {
            ViewBag.Msg = String.Format("UserName:'{0}',Company:'{1}',Login:'{2}',Password:'{3}'", user.UserName, user.Company, user.Login, user.Password);
            return View("Create4");
        }

    }
}
