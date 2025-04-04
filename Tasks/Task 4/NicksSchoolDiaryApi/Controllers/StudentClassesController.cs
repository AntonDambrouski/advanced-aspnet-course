using Microsoft.AspNetCore.Mvc;
using NicksSchoolDiaryApi.Models;
using NicksSchoolDiaryApi.Services;

namespace NicksSchoolDiaryApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class StudentClassesController : ControllerBase
    {
        private readonly IStudentClassService _studentClassService;
        private readonly IStudentService _studentService;
        public StudentClassesController(IStudentClassService studentClassService, IStudentService studentService)
        {
            _studentClassService = studentClassService;
            _studentService = studentService;
        }
        // GET: /<StudentClassesController>
        [HttpGet]
        public IEnumerable<StudentClass> Get()
        {
            var studentClasses = _studentClassService.GetStudentClasses();
            if (studentClasses == null) 
            {
                return Enumerable.Empty<StudentClass>();
            }
            return studentClasses;
        }

        // GET /<StudentClassesController>/5
        [HttpGet("{id}")]
        public ActionResult<StudentClass> Get(int id)
        {
            StudentClass? studentClass = _studentClassService.GetClass(id);
            if (studentClass == null) 
            {
                return NotFound();
            }
            return Ok(studentClass);
        }
        
        [HttpGet("{id}/students")]
        public ActionResult<List<Student>> GetStudents(int id)
        {           
            List<Student> students = _studentService.GetStudentsByClassId(id);
            if (students == null)
            {
                return Ok(new List<Student>());
            }
            return Ok(students);
        }

        // POST /<StudentClassesController>
        [HttpPost]
        public ActionResult<StudentClass> Post([FromBody] StudentClass studentClass)
        {
            int maxId = _studentClassService.GetStudentClasses().Max(x=> x.Id) + 1;            
            studentClass.Id = maxId;
            _studentClassService.AddClass(studentClass);
            return CreatedAtAction(nameof(Get), new { id = maxId }, studentClass);
        }

        // PUT /<StudentClassesController>/5
        [HttpPut("{id}")]
        public ActionResult<StudentClass> Put(int id, [FromBody] StudentClass studentClass)
        {          
            if (_studentClassService.GetClass(id) == null)
            {
                return BadRequest();
            }
            StudentClass newStudentClass = new StudentClass()
            {
                Id = id,
                Name = studentClass.Name,                
            };
            _studentClassService.UpdateClass(newStudentClass);
            return Ok(newStudentClass);
        }

        // DELETE /<StudentClassesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_studentClassService.GetClass(id) == null )
            {
                return BadRequest();
            }
            _studentClassService.DeleteClass(id);
            return NoContent();
        }
    }
}
