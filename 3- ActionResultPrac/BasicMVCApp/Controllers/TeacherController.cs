using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicMVCApp.Controllers
{
    public class TeacherController : Controller
    {

        //http://msdn.microsoft.com/en-us/library/system.web.mvc.actionresult.aspx
        /* ----------- Types of ActionResult -------------------
         *    
         * 1) ActionResult: ViewResult      
         *   --HelperMethod: View
         *   --Description: Renders a view as a web page, Represents HTML and markup.
         *   --------------------------------------------------
         * 2) PartialViewResult      
         *   --HelperMethod: PartialView
         *   --Description: Section of a view,that can be rendered inside another view 
         *  --------------------------------------------------
         * 3) RedirectResult      
         *   --HelperMethod: Redirect
         *   --Description: Redirect to another action method
         *  --------------------------------------------------
         * 4) RedirectToRouteResult      
         *   --HelperMethod: RedirectToRoute, RedirectToAction
         *   --Description: Redirect to another action method
         *   --------------------------------------------------
         * 5) ContentResult      
         *   --HelperMethod: Content
         *   --Description: Returns a user-defined content type
         *   --------------------------------------------------
         * 6) JsonResult      
         *   --HelperMethod: Json
         *   --Description: Retuns a serialized JSON object, Represents a JavaScript Object Notation result that can be used in an AJAX application.
         *   --------------------------------------------------
         * 7) JavaScriptResult      
         *   --HelperMethod: JavaScript
         *   --Description: Retuns a serialized JSON object
         *   --------------------------------------------------
         * 8) EmptyResult      
         *   --HelperMethod: (None)
         *   --Description: returns a null result, Represents no result.
         *   --------------------------------------------------
         * 9) FileResult      
         *   --HelperMethod: File
         *   --Description: Returns a binary output to write to the response
         *   --------------------------------------------------
         * 10) FileContentResult       
         *   --HelperMethod: File 
         *   --Description: Represents a downloadable file (with the binary content).
         *   --------------------------------------------------
         * 11) FilePathResult        
         *   --HelperMethod: File 
         *   --Description: Represents a downloadable file (with a path).
         *   --------------------------------------------------
         * 12) FileStreamResult        
         *   --HelperMethod: File 
         *   --Description: Represents a downloadable file (with a file stream).
         *   --------------------------------------------------
         */

        //return view
        public ActionResult Home()
        {
            return View();
        }

        //return view
        public ViewResult View_Test()
        {
            return View("Details");
        }

        //return Partial View (means without involving Layout)
        public PartialViewResult PartialView_Test()
        {
            return PartialView("PartialDetails");
        }

        //redirect to another action
        public RedirectResult Redirect_Test()
        {
            //It needs full URL to redirect, it can also redirect to external links
            return Redirect("~/Teacher/Home");

        }

        //redirect to another action
        public RedirectToRouteResult RedirectToAction_Test()
        {
            //It needs action and/or controller from application inside
            return RedirectToAction("View_Test", "Teacher");
        }

        //redirect to a route
        public RedirectToRouteResult RedirectToRoute1_Test()
        {
            var route = new
                {
                    controller = "Student",
                    action = "Index"
                };

            return RedirectToRoute(route);
        }

        //redirect to a named route
        public RedirectToRouteResult RedirectToRoute2_Test()
        {
            //Redirec to route by providing the route named (given while creating route in MapRoute method)
            return RedirectToRoute("specialRoute");
        }

        //redirect to another action
        public ContentResult Content_Test()
        {
            return Content("Testing content", "text/plain");
        }

        //return some HttpStatusCode
        public HttpStatusCodeResult HttpStatusCode_Test(int id)
        {
            switch (id)
            {
                case 410:
                    return new HttpStatusCodeResult(410, "Please remove this link");
                case 404:
                    return new HttpStatusCodeResult(404);
                case 40404:
                    return HttpNotFound();

                case 404404:
                    return HttpNotFound("My Not Found Message");

                default:
                    return new HttpNotFoundResult("file not found");
            }
        }

        //return data as JSON
        public JsonResult Json_Test()
        {
            var obj = new
            {
                id = 1,
                Name = "Bilal"
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        //return JavaScript to run on client side
        public JavaScriptResult JavaScript_Test()
        {
            return JavaScript("alert('hello');");
        }

        //return FilePathResult
        public FilePathResult File1_Test()
        {
            var path = Server.MapPath("~/Docs/test.xlsx");
            //It takes path of file
            return File(path, "application/vnd.ms-excel");
        }

        //return FileStreamResult
        public FileStreamResult File2_Test()
        {
            //to convert virtual path to physical path
            var path = Server.MapPath("~/Docs/user.jpeg");
            var stream = new FileStream(path, FileMode.Open);
            //It takes stream
            return File(stream, "Image/jpeg");
        }

        //return FileContentResult
        public FileContentResult File3_Test()
        {
            var path = Server.MapPath("~/Docs/user.jpeg");
            var stream = new FileStream(path, FileMode.Open);
            var byteArr = ConvertToByteArray(stream);

            //It takes 'Byte Array' and returns 'FileContentResult'
            return File(byteArr, "Image/jpeg");
        }


        //If action returns a result which is not of type 'ActionResult', value is wrapped in 'ContentResult' automatically.
        public int Other_Test()
        {
            return 50;
        }

        public DateTime Other1_Test()
        {
            return DateTime.Now;
        }


        //A utility function to convert stream into byte array
        public static byte[] ConvertToByteArray(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
