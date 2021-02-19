using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProgrammingExam.App.Services.Interfaces;

namespace WebProgrammingExam.App.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string facultyNumber, string major, string firstName, string lastName)
        {
            string message = _studentService.CreateStudent(facultyNumber, major, firstName, lastName);

            return RedirectToAction("Index", "Home", message);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _studentService.GetStudentById(id);

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, string facultyNumber, string major, string firstName, string lastName)
        {
            string message = _studentService.EditStudent(id, facultyNumber, major, firstName, lastName);

            return RedirectToAction("Index", "Home", message);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            string message = _studentService.DeleteStudent(id);

            return RedirectToAction("Index", "Home", message);
        }
    }
}
