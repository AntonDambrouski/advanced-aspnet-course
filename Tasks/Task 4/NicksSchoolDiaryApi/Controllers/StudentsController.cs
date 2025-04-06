using Microsoft.AspNetCore.Mvc;
using NicksSchoolDiaryApi.Services;
using NicksSchoolDiaryApi.Models;
using NicksSchoolDiaryApi.Filters;


namespace SchoolDiaryApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly IStudentService _studentService;
        private readonly IStudentClassService _studentClassService;

        public StudentsController(IStudentService studentService, IStudentClassService studentClassService)
        {
            _studentService = studentService;
            _studentClassService = studentClassService;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _studentService.GetAllStudents();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            Student? student = _studentService.GetStudentById(id);
            if (student is null)
            {
                return NotFound();
            }
            return Ok(student);
        }


        // POST api/<StudentController>
        [HttpPost]
        [TypeFilter(typeof(CheckClassIdFilterAttribute))]
        public ActionResult Post([FromBody] Student student)
        {
            var studentId = _studentService.GetAllStudents()?.Max(x => x.Id) ?? 0;
            int maxid = studentId + 1;
            student.Id = maxid;
            _studentService.AddStudent(student);
            return CreatedAtAction(nameof(Get), new { id = maxid }, student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Student student)
        {
            if (_studentService.GetStudentById(id) is null)
            {
                return BadRequest();
            }
            Student newStudent = new Student()
            {
                Id = id,
                Name = student.Name,
                DateOfBirth = student.DateOfBirth,
                StudentClassId = student.StudentClassId
            };
            _studentService.UpdateStudent(newStudent);
            return Ok(newStudent);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_studentService.GetStudentById(id) is null)
            {
                return BadRequest();
            }
            _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}
