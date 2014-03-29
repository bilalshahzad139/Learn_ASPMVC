using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicMVCApp.Controllers
{
    //A requests lands to controller after going through ASP.NET Request Pipeline, it fires the corresponding 'action' method
    //Here Class should inherit 'Controller' class and class name should contain 'Controller' word as prefix (a convention to follow)
    public class StudentController : Controller
    {
        //Here action name is 'Index' and by default HTTP verb is 'GET'
        //To calls this method user will type /Student/Index in URL
        public ActionResult Index()
        {
            /* Here we may call our model for business logic & Data Access
             * Then this action should return something of type 'ActionResult'
             */

            //ViewBag is a 'dynamic' type variable which can be used to pass data to 'views'
            //here Data is a dynamically created property which will be used in view to access provided content
            ViewBag.Data = "by Index action";
            ViewBag.Title = "Hello World";
            //Here we are saying, search a html file named Index.cshtml (a view) in 'Views/Student' folder
            return View();
        }


        //Here action name is 'MainView' and by default HTTP verb is 'GET'
        //To calls this method user will type /Student/MainView in URL
        public ActionResult MainView()
        {
            /* Here we may call our model for business logic & Data Access
             * Then this action should return something of type 'ActionResult'
             */

            //ViewBag is a 'dynamic' type variable which can be used to pass data to 'views'
            //here Data is a dynamically created property which will be used in view to access provided content
            ViewBag.Data = "by MainView action";

            //Here we are saying, search a html file named 'Index.cshtml' (a view) in '~/Views/Student' folder
            return View("Index");
        }


        //Here action name is 'MainView2' and by default HTTP verb is 'GET'
        //To calls this method user will type /Student/MainView2 in URL
        public ActionResult MainView2()
        {
            /* Here we may call our model for business logic & Data Access
             * Then this action should return something of type 'ActionResult'
             */

            //ViewBag is a 'dynamic' type variable which can be used to pass data to 'views'
            //here Data is a dynamically created property which will be used in view to access provided content
            ViewBag.Data = "by MainView2 action";

            //Here we are saying, search a html file named Index.cshtml (a view) in '~/Views/Student' folder
            //Here we are providing a layout file
            return View("Index", "_MyLayout");
        }

        //Here action name is 'Show' and by default HTTP verb is 'GET'
        //To calls this method user will type /Student/Show in URL
        public ActionResult Show()
        {
            //IF we don't provide any parameter to 'View()' it searches for view named as action name i.e. 'Show' in this case
            return View();
        }


        //Here action name is 'Show2' and by default HTTP verb is 'GET'
        //To calls this method user will type /Student/Show2 in URL
        public ActionResult Show2()
        {
            //Create an anonymous object to pass to 'View'
            //In normal cases, this will come from 'Model'
            BasicMVCApp.Models.Student std = new Models.Student();
            std.StudentID = 1;
            std.Name = "Bilal";
            std.Address = "Lahore";
            std.Age = 200;


            /*
             * We can pass a single object to View which is called a 'Model' or 'ViewModel'
             * This object can be a single object, a complex, a List of Objects etc.
             * We'll have to set 'model' property with the 'Type' of this Object in view file at start
             */
            return View(std);
        }

    }
}
