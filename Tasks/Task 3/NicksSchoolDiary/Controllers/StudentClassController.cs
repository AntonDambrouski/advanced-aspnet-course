using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NicksSchoolDiary.Models;
using NicksSchoolDiary.Services;
using NicksSchoolDiary.ViewModels;

namespace NicksSchoolDiary.Controllers
{
    public class StudentClassController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IStudentClassService _studentClassService;
        

        public StudentClassController(IStudentClassService studentClassService, IStudentService studentService)
        {
            _studentClassService = studentClassService;
            _studentService = studentService;
        }        // GET: StudentClassController
        public ActionResult Index()
        {
            var studentClasses = _studentClassService.GetStudentClasses();
            return View(studentClasses);
        }

        // GET: StudentClassController/Details/5
        public ActionResult Details(int id)
        {
            var studentClass = _studentClassService.GetClass(id);
            if (studentClass == null)
            {
                return NotFound();
            }
            StudentClassWithStudents studentClassWithStudents = new StudentClassWithStudents()
            {
                Id = studentClass.Id,
                Name = studentClass.Name,
                Students = _studentService.GetStudentsByClassId(studentClass.Id)
            };
            return View(studentClassWithStudents);
        }

        // GET: StudentClassController/Create
        public ActionResult Create()
        {
            int newId = _studentClassService.GetStudentClasses().Count > 0 ? _studentClassService.GetStudentClasses().Max(x => x.Id) + 1 : 1;
            StudentClass defaultClass = new StudentClass() { Id = newId };
            return View(defaultClass);
        }

        // POST: StudentClassController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentClass studentClass)
        {
            try
            {
                _studentClassService.AddClass(studentClass);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentClassController/Edit/5
        public ActionResult Edit(int id)
        {
            var studentClass = _studentClassService.GetClass(id);
            if (studentClass == null) 
            { 
                return NotFound();
            }                    
            
            return View(studentClass);
        }

        // POST: StudentClassController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentClass student)
        {
            try
            {
                _studentClassService.UpdateClass(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentClassController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var studentClass = _studentClassService.GetClass(id);
            if(studentClass == null)
            {
                return NotFound();
            }
            return View(studentClass);
        }

        // POST: StudentClassController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, StudentClass studentClass)
        {
            try
            {
                if (!_studentService.GetStudentsByClassId(id).Any())
                {
                    _studentClassService.DeleteClass(id);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
