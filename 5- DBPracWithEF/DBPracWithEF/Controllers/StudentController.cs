using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBPracWithEF.Models;

namespace DBPracWithEF.Controllers
{
    public class StudentController : Controller
    {

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult StudentView()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveStudent(StudentDTO dto)
        {

            StudentDAL dal = new StudentDAL();
            dal.SaveStudent(dto);

            var obj = new
            {
                success = true,
                message = "Record has been saved successfully"
            };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            StudentDAL dal = new StudentDAL();
            var list = dal.GetAll();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetById(int tid)
        {
            StudentDAL dal = new StudentDAL();
            var obj = dal.GetById(tid);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteById(int tid)
        {
            StudentDAL dal = new StudentDAL();
            dal.RemoveById(tid);

            var obj = new
            {
                success = true,
                message = "Record with ID:"+tid+" has been removed successfully"
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }



}
