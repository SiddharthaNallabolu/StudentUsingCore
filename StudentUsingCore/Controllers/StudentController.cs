using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentUsingCore.Models;

namespace StudentUsingCore.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _studentRepository;

        public StudentController(ApplicationDbContext db)
        {
            _studentRepository = new StudentRepository(db);
        }
        public async Task<IActionResult> Index()
        {
            var students = await _studentRepository.GetAllStudents();
            return View(students);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            if (id == null)
            {
                Student student = new Student();
                return View(student);
            }
            else
            {
                var student = await _studentRepository.GetStudentById(id);
                if(student == null)
                {
                    return NotFound();
                }
                return View(student);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(Student student)
        {
            if (ModelState.IsValid)
            {
                if (student.Id == 0)
                {
                    await _studentRepository.AddStudent(student);
                }
                else
                {
                    var studentFromDb = await _studentRepository.GetStudentById(student.Id);
                    studentFromDb.Name = student.Name;
                    studentFromDb.RollNumber = student.RollNumber;
                    studentFromDb.ClassStudying = student.ClassStudying;
                    studentFromDb.ImageUrl = student.ImageUrl;
                    await _studentRepository.SaveDetails();

                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            await _studentRepository.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
