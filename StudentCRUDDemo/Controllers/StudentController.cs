using StudentCRUDDemo.BLL.Services;
using StudentCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentCRUDDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: Student
        public ActionResult Home()
        {
            return View();
        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            if (Session["Role"] == null)
            {
                RedirectToAction("Login","User");
            }
           
            return View(_studentService.GetAllStudents());
           
             
        }

// Get Details Of student By ID
        public ActionResult Details(int id)
        {
            var std = _studentService.GetStudentById(id);
            if (std == null)
            {
                return HttpNotFound();
            }
            return View(std);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.AddStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Edit(int id)
        {
            var std = _studentService.GetStudentById(id);
            if (std == null)
            {
                return HttpNotFound();
            }
            return View(std);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Delete(int id)
        {
            var std = _studentService.GetStudentById(id);
            if (std == null)
            {
                return HttpNotFound();
            }
            return View(std);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }


        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

    }
}
