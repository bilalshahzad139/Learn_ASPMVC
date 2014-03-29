using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ModelBinderPrac.Models; //To access our classes in this namespace
namespace ModelBinderPrac.Controllers
{
    public class MoreComplexUserController : Controller
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
        //To show Create6 Form
        [HttpGet]
        public ActionResult Create6()
        {
            return View();
        }

        //To show Create7 Form
        [HttpGet]
        public ActionResult Create7()
        {
            return View();
        }

        //Get data manually by Request
        [HttpPost]
        public ActionResult SaveUser1()
        {
            MoreComplexUserDTO user = new MoreComplexUserDTO();

            user.UserName = Request.Form["UserName"]; //Extract data from Request.Form by providing field 'name'
            user.Company = Request["Company"]; //Extract data from Request directly by providing field 'name'
            user.Login = Request["Login"];
            user.Password = Request.Form["Password"];

            user.UserAddresses = new List<Address>();
     
            /*-------------
             * Here we need some mechanism to parse complex objects arrays to load into our List
             * We can check every key and see which keys are of 'User Address' type
             */
            

            ViewBag.Msg = GetMessage(user);
            return View("Create1");
        }

        //Get data manually by value provider, This data is extracted from 'Request' internally
        [HttpPost]
        public ActionResult SaveUser2(FormCollection values)
        {
            MoreComplexUserDTO user = new MoreComplexUserDTO();
            user.UserName = values["UserName"]; //Extract data from FormCollection by providing field 'name'
            user.Company = values["Company"]; 
            user.Login = values["Login"];
            user.Password = values["Password"];

            user.UserAddresses = new List<Address>();

            /*-------------
             * Here we need some mechanism to parse complex objects arrays to load into our List
             * We can check every key and see which keys are of 'User Address' type
             */

            ViewBag.Msg = GetMessage(user);
            return View("Create2");
        }

        //Map 'Request' fields to function parameter list
        [HttpPost]
        public ActionResult SaveUser3(String UserName, String Company, String Login, String Password, List<Address> UserAddresses)
        {
            MoreComplexUserDTO user = new MoreComplexUserDTO();
            user.UserName = UserName; //Extract data from FormCollection by providing field 'name'
            user.Company = Company;
            user.Login = Login;
            user.Password = Password;
            user.UserAddresses = UserAddresses;

            ViewBag.Msg = GetMessage(user);
            return View("Create3");
        }

        //DefaultModelBinder will automatically extract data from 'Request' and load into complex type
        [HttpPost]
        public ActionResult SaveUser4(MoreComplexUserDTO user)
        {
            ViewBag.Msg = GetMessage(user);
            return View("Create4");
        }

        //DefaultModelBinder will automatically extract data from 'Request' and load into complex types
        [HttpPost]
        public ActionResult SaveUser5(MoreComplexUserDTO user, List<EducationInfo> Edu, List<String> hobbies)
        {
            ViewBag.Msg = GetMessage(user);
            return View("Create5");
        }

        //DefaultModelBinder will automatically extract data from 'Request' and load into complex type
        //http://stackoverflow.com/questions/8598214/mvc3-non-sequential-indices-and-defaultmodelbinder
        //http://stackoverflow.com/questions/12300281/asp-net-mvc-model-list-binding
        [HttpPost]
        public ActionResult SaveUser6(MoreComplexUserDTO user)
        {
            ViewBag.Msg = GetMessage(user);
            return View("Create6");
        }


        //Here we are overriden DefaultModelBinder and now our custom mapping logic is creating 'user' object
        //We can also register our custom ModelBinders at application start
        [HttpPost]
        public ActionResult SaveUser7([ModelBinder(typeof(CustomTestUserBinder))] TestUser user)
        {
            ViewBag.Msg = String.Format("UserName:'{0}',Company:'{1}',DOB:'{2}'", user.UserName, user.Company, user.DOB);
            return View("Create7");
        }


        private String GetMessage(MoreComplexUserDTO user)
        {
            return String.Format("UserName:'{0}',Company:'{1}',Login:'{2}',Password:'{3}'", user.UserName, user.Company, user.Login, user.Password);
        }
    }


    //http://msdn.microsoft.com/en-us/magazine/hh781022.aspx
    //http://odetocode.com/blogs/scott/archive/2009/04/27/6-tips-for-asp-net-mvc-model-binding.aspx
    //http://odetocode.com/blogs/scott/archive/2009/05/05/iterating-on-an-asp-net-mvc-model-binder.aspx
    //http://stackoverflow.com/questions/12300281/asp-net-mvc-model-list-binding

    public class CustomTestUserBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
                                ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            TestUser obj = new TestUser();

            obj.UserName = request.Form["UserName"];
            obj.Company = request.Form["Company"];

            String day = request.Form["day"];
            String month = request.Form["month"];
            String year = request.Form["year"];

            obj.DOB = String.Format("{0}-{1}-{2}", day, month, year);
            

            return obj;

        }
    } 

}
