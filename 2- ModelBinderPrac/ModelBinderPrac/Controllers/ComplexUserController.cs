using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ModelBinderPrac.Models; //To access our classes in this namespace

namespace ModelBinderPrac.Controllers
{
    public class ComplexUserController : Controller
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
        //To show Creat5 Form
        [HttpGet]
        public ActionResult Create5()
        {
            return View();
        }

        //Get data manually by Request
        [HttpPost]
        public ActionResult SaveUser1()
        {
            ComplexUserDTO user = new ComplexUserDTO();

            user.UserName = Request.Form["UserName"]; //Extract data from Request.Form by providing field 'name'
            user.Company = Request["Company"]; //Extract data from Request directly by providing field 'name'
            user.Login = Request["Login"];
            user.Password = Request.Form["Password"];

            user.UserAddress = new Address();
            user.UserAddress.Country = Request.Form["UserAddress.Country"];
            user.UserAddress.City = Request.Form["UserAddress.City"];

            ViewBag.Msg = GetMessage(user);
            return View("Create1");
        }

        //Get data manually by value provider, This data is extracted from 'Request' internally
        [HttpPost]
        public ActionResult SaveUser2(FormCollection values)
        {
            ComplexUserDTO user = new ComplexUserDTO();
            user.UserName = values["UserName"]; //Extract data from FormCollection by providing field 'name'
            user.Company = values["Company"]; 
            user.Login = values["Login"];
            user.Password = values["Password"];

            user.UserAddress = new Address();
            user.UserAddress.Country = values["UserAddress.Country"];
            user.UserAddress.City = values["UserAddress.City"];

            ViewBag.Msg = GetMessage(user);
            return View("Create2");
        }

        //Map 'Request' fields to function parameter list
        [HttpPost]
        public ActionResult SaveUser3(String UserName, String Company, String Login, String Password, Address UserAddress)
        {
            ComplexUserDTO user = new ComplexUserDTO();
            user.UserName = UserName; //Extract data from FormCollection by providing field 'name'
            user.Company = Company;
            user.Login = Login;
            user.Password = Password;
            user.UserAddress = UserAddress;

            ViewBag.Msg = GetMessage(user);
            return View("Create3");
        }

        //DefaultModelBinder will automatically extract data from 'Request' and load into complex type
        [HttpPost]
        public ActionResult SaveUser4(ComplexUserDTO user)
        {
            ViewBag.Msg = GetMessage(user);
            return View("Create4");
        }

        //DefaultModelBinder will automatically extract data from 'Request' and load into complex types
        [HttpPost]
        public ActionResult SaveUser5(ComplexUserDTO user, EducationInfo Edu)
        {
            ViewBag.Msg = GetMessage(user);
            return View("Create5");
        }


        private String GetMessage(ComplexUserDTO user)
        {
            return String.Format("UserName:'{0}',Company:'{1}',Login:'{2}',Password:'{3}',Country:'{4}',City:'{5}'", user.UserName, user.Company, user.Login, user.Password, user.UserAddress.Country, user.UserAddress.City);
        }
    }
}
