using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        public ActionResult Index()
        {
            var data = MyDAL.GetAllStudents();
            return View("List",data);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Student stdObj)
        {
            if (ModelState.IsValid)
            {
                var id = MyDAL.SaveStudent(stdObj);
                ViewBag.ID = id;
                return RedirectToAction("Index");
            }

            return View(stdObj);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var stdObj = MyDAL.GetStudentByID(id);

            return View(stdObj);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit(Student stdObj)
        {
            var id = MyDAL.SaveStudent(stdObj);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var stdObj = MyDAL.GetStudentByID(id);

            return View(stdObj);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var stdObj = MyDAL.GetStudentByID(id);

            return View(stdObj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            MyDAL.DeleteStudentByID(id);

            return RedirectToAction("Index");
        }
    }
}
