using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewsRazorPrac.Models;

namespace ViewsRazorPrac.Controllers
{
    public class ComplexUserController : Controller
    {
        
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult DispSimple()
        {
            //Create a dummy object for testing purposes
            ComplexUserDTO obj = new ComplexUserDTO();
            obj.UserName = "Bilal";
            obj.Company = "Testing";
            obj.Country = "Pakistan";

            //here we are passing our model object to view, 
            //At top of view, 'model' should be used to declare type of our object
            //In view, 'Model' property will be used to access this object
            //We can also call this object as 'ViewModel'

            return View(obj);
        }

        public ActionResult DispSimpleHelper()
        {
            //Create a dummy object for testing purposes
            ComplexUserDTO obj = new ComplexUserDTO();
            obj.UserName = "Bilal";
            obj.Company = "Testing";
            obj.Country = "Pakistan";

            //here we are passing our model object to view, 
            //At top of view, 'model' should be used to declare type of our object
            //In view, 'Model' property will be used to access this object
            //We can also call this object as 'ViewModel'

            return View(obj);
        }

        public ActionResult Edit()
        {
            //Create a dummy object for testing purposes
            ComplexUserDTO obj = new ComplexUserDTO();
            obj.UserName = "Bilal";
            obj.Company = "Testing";
            obj.Country = "Pakistan";

            //here we are passing our model object to view, 
            //At top of view, 'model' should be used to declare type of our object
            //In view, 'Model' property will be used to access this object
            //We can also call this object as 'ViewModel'

            return View(obj);
        }

        public ActionResult EditHelper()
        {
            //Create a dummy object for testing purposes
            ComplexUserDTO obj = new ComplexUserDTO();
            obj.UserName = "Bilal";
            obj.Company = "Testing";
            obj.Country = "Pakistan";

            //here we are passing our model object to view, 
            //At top of view, 'model' should be used to declare type of our object
            //In view, 'Model' property will be used to access this object
            //We can also call this object as 'ViewModel'

            return View(obj);
        }


        public ActionResult DispList()
        {
            //Create a dummy List of objects for testing purposes

            List<ComplexUserDTO> list = new List<ComplexUserDTO>();
            
            ComplexUserDTO obj = new ComplexUserDTO();
            obj.UserName = "Bilal";
            obj.Company = "Testing";
            obj.Country = "Pakistan";

            list.Add(obj);

            obj = new ComplexUserDTO();
            obj.UserName = "Bilal 1";
            obj.Company = "Testing 1";
            obj.Country = "Pakistan 1";

            list.Add(obj);

            obj = new ComplexUserDTO();
            obj.UserName = "Bilal 2";
            obj.Company = "Testing 2";
            obj.Country = "Pakistan 2";

            list.Add(obj);


            //here we are passing our model object to view, 
            //At top of view, 'model' should be used to declare type of our object
            //In view, 'Model' property will be used to access this object
            //We can also call this object as 'ViewModel'

            return View(list);
        }

        public ActionResult DispListHelper()
        {
            //Create a dummy List of objects for testing purposes

            List<ComplexUserDTO> list = new List<ComplexUserDTO>();

            ComplexUserDTO obj = new ComplexUserDTO();
            obj.UserName = "Bilal";
            obj.Company = "Testing";
            obj.Country = "Pakistan";

            list.Add(obj);

            obj = new ComplexUserDTO();
            obj.UserName = "Bilal 1";
            obj.Company = "Testing 1";
            obj.Country = "Pakistan 1";

            list.Add(obj);

            obj = new ComplexUserDTO();
            obj.UserName = "Bilal 2";
            obj.Company = "Testing 2";
            obj.Country = "Pakistan 2";

            list.Add(obj);


            //here we are passing our model object to view, 
            //At top of view, 'model' should be used to declare type of our object
            //In view, 'Model' property will be used to access this object
            //We can also call this object as 'ViewModel'

            return View(list);
        }

        public ActionResult Third()
        {
            //Create a dummy object for testing purposes
            ComplexUser2DTO obj = new ComplexUser2DTO();
            obj.UserName = "Bilal";
            obj.Company = "Testing";

            Address adr1 = new Address();
            adr1.Country = "Pakistan";
            adr1.City = "Lahore";

            //Set address object in our main object
            obj.UserAddress = adr1;

            //here we are passing our model object to view, 
            //At top of view, 'model' should be used to declare type of our object
            //In view, 'Model' property will be used to access this object
            //We can also call this object as 'ViewModel'

            return View(obj);
        }

        
    }

    
}
