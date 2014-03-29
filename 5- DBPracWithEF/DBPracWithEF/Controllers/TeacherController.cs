using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBPracWithEF.Models;

namespace DBPracWithEF.Controllers
{
    public class TeacherController : Controller
    {

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult TeacherView()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveTeacher(TeacherDTO dto)
        {

            TeacherDAL dal = new TeacherDAL();
            dal.SaveTeacher(dto);

            var obj = new
            {
                success = true,
                message = "Record has been saved successfully"
            };

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            TeacherDAL dal = new TeacherDAL();
            var list = dal.GetAll();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetById(int tid)
        {
            TeacherDAL dal = new TeacherDAL();
            var obj = dal.GetById(tid);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteById(int tid)
        {
            TeacherDAL dal = new TeacherDAL();
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
