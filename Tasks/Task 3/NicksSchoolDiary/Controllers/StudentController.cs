using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NicksSchoolDiary.Models;
using NicksSchoolDiary.Services;
using NicksSchoolDiary.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace NicksSchoolDiary.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IStudentClassService _studentClassService;
        
        public StudentController(IStudentService studentService, IStudentClassService studentClassService) 
        {
            _studentService = studentService;
            _studentClassService = studentClassService;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var students = _studentService.GetAllStudents();
            List<StudentViewModel> studentList = new List<StudentViewModel>();
            foreach (var student in students) 
            {
                studentList.Add(new StudentViewModel
                {
                    Id = student.Id,
                    Name = student.Name,
                    DateOfBirth = student.DateOfBirth,
                    StudentClassName = _studentClassService.GetClass(student.StudentClassId)?.Name ?? "No Class"
                });
            }
            return View(studentList);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null) 
            {
                return NotFound();
            }
            StudentViewModel studentViewModel = new StudentViewModel()
            {
                Id = student.Id,
                Name = student.Name,
                DateOfBirth = student.DateOfBirth,
                StudentClassName = _studentClassService.GetClass(student.StudentClassId)?.Name ?? "No Class"
            };
            return View(studentViewModel);
        }

        // GET: StudentController/Create
        public ActionResult Create(int studentclassId)
        {
            int newId = _studentService.GetAllStudents().Count > 0 ? _studentService.GetAllStudents().Max(x => x.Id) + 1 : 1;
            Student student = new Student() { Id = newId, DateOfBirth = new DateOnly(2018, 1, 1), StudentClassId = studentclassId};
            ViewData["classlist"] = new SelectList(_studentClassService.GetStudentClasses(), "Id", "Name", studentclassId);
            StudentViewModel studentViewModel = new StudentViewModel() {
                Id = student.Id, 
                Name = student.Name, 
                DateOfBirth = student.DateOfBirth, 
                StudentClassId = student.StudentClassId, 
                StudentClassName = _studentClassService.GetClass(student.StudentClassId)?.Name ?? "No Class" };

            return View(studentViewModel);
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel student)
        {
            try
            {
                ViewData["classlist"] = new SelectList(_studentClassService.GetStudentClasses(), "Id", "Name", student.StudentClassId);

                if (ModelState.IsValid) 
                {
                    _studentService.AddStudent(new Student() { Id = student.Id, DateOfBirth = student.DateOfBirth, Name = student.Name, StudentClassId = student.StudentClassId});

                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View(student);
                }
            }
            catch
            {
                return View(student);
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = _studentService.GetStudentById(id);

            if (student == null) 
            {
                return NotFound();
            }
            ViewData["classlist"] = new SelectList(_studentClassService.GetStudentClasses(), "Id", "Name", student.StudentClassId);
            var studentViewModel = new StudentViewModel()
            {
                Id = student.Id,
                Name = student.Name,
                DateOfBirth = student.DateOfBirth,
                StudentClassName = _studentClassService.GetClass(student.StudentClassId)?.Name ?? "No Class"
            };
            return View(studentViewModel);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                _studentService.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var student = _studentService.GetStudentById(id);
            if(student == null)
            {
                return NotFound();
            }
            var studentViewModel = new StudentViewModel()
            {
                Id = student.Id,
                Name = student.Name,
                DateOfBirth = student.DateOfBirth,
                StudentClassName = _studentClassService.GetClass(student.StudentClassId)?.Name ?? "No Class"
            };  
            return View(studentViewModel);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _studentService.DeleteStudent(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
