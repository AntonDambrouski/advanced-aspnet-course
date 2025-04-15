using Microsoft.AspNetCore.Mvc;
using NicksSchoolDiary.Domain.Interfaces;
using NicksSchoolDiary.Domain.Models;
using NicksSchoolDiary.Domain.Services;


namespace NicksSchoolDiary.Api.Controllers
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
        public async Task<IEnumerable<StudentClass>> Get()
        {
            var studentClasses = await _studentClassService.GetStudentClassesAsync();
            if (studentClasses == null)
            {
                return new List<StudentClass>();
            }
            return studentClasses;
        }

        // GET /<StudentClassesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentClass>> Get(int id)
        {
            StudentClass? studentClass = await _studentClassService.GetClassAsync(id);
            if (studentClass == null)
            {
                return NotFound(id);
            }
            return Ok(studentClass);
        }

        [HttpGet("{id}/students")]
        public async Task<ActionResult<List<Student>>> GetStudents(int id)
        {
            List<Student> students = await _studentService.GetStudentsByClassIdAsync(id);
            if (students == null)
            {
                return Ok(new List<Student>());
            }
            return Ok(students);
        }

        // POST /<StudentClassesController>
        [HttpPost]
        public async Task<ActionResult<StudentClass>> Post([FromBody] StudentClass studentClass)
        {                   
            var existedClass = await _studentClassService.GetClassAsync(studentClass.Id);
            if (existedClass != null)
            {
                studentClass.Id = 0;
            }
            var addedClass = await _studentClassService.AddClassAsync(studentClass);
            return CreatedAtAction(nameof(Get), new { id = addedClass.Id }, addedClass);
        }

        // PUT /<StudentClassesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentClass>> Put(int id, [FromBody] StudentClass studentClass)
        {

            var studentClassForUpdate = await _studentClassService.GetClassAsync(id);
            if (studentClassForUpdate is null)
            {
                return BadRequest(id);
            }
            studentClassForUpdate.Name = studentClass.Name;
            var updatedClass = await  _studentClassService.UpdateClassAsync(studentClassForUpdate);
            return Ok(updatedClass);
        }

        // DELETE /<StudentClassesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var studentClass = await _studentClassService.GetClassAsync(id);
            if (studentClass is null)
            {
                return BadRequest(id);
            }
            var deleteStatus = await _studentClassService.DeleteClassAsync(id);
            if (!deleteStatus)
            {
                return NotFound(id);
            }
            return Ok();
        }
    }
}
