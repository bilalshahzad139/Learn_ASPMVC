using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using DAL;
namespace MvcApplication3.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        public ActionResult Index()
        {
            var list = MyDAL.GetAllStudents();
            return View("List",list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student stdObj)
        {

            int id = MyDAL.SaveStudent(stdObj);

            return RedirectToAction("Index");
        }



        public ActionResult Details(int id)
        {
            var result = MyDAL.GetStudentByID(id);
            return View("Details", result);
        }

        public ActionResult Edit(int id)
        {
            var result = MyDAL.GetStudentByID(id);
            return View("Edit", result);
        }

        [HttpPost]
        public ActionResult Edit(Student stdObj)
        {
            int id = MyDAL.SaveStudent(stdObj);

            return RedirectToAction("Index");
        }

        [HttpGet]
        
        public ActionResult Delete(int id)
        {
            var result = MyDAL.GetStudentByID(id);
            return View("Delete", result);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteRec(int id)
        {
            MyDAL.DeleteStudentByID(id);
            return RedirectToAction("Index");
        }
    }
}
