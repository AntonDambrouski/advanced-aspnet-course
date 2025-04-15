using Microsoft.AspNetCore.Mvc;
using NicksSchoolDiary.Domain.Services;
using NicksSchoolDiary.Domain.Models;
using NicksSchoolDiary.Api.Filters;
using NicksSchoolDiary.Domain.Interfaces;


namespace NicksSchoolDiary.Api.Controllers
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
        public async Task<IEnumerable<Student>> Get()
        {
            return await _studentService.GetAllStudentsAsync();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            Student? student = await _studentService.GetStudentByIdAsync(id);
            if (student is null)
            {
                return NotFound();
            }
            return Ok(student);
        }


        // POST api/<StudentController>
        [HttpPost]
        [TypeFilter(typeof(CheckClassIdFilterAttribute))]
        public async Task<ActionResult> Post([FromBody] Student student)
        {
            var createdStudent = await _studentService.AddStudentAsync(student);
            return CreatedAtAction(nameof(Get), new { id = createdStudent.Id }, createdStudent);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Student student)
        {
            if ( await _studentService.GetStudentByIdAsync(id) is null)
            {
                return BadRequest(student);
            }
            student.Id = id;
            var updatedStudent = await _studentService.UpdateStudentAsync(student);
            return Ok(updatedStudent);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (await _studentService.GetStudentByIdAsync(id) is null)
            {
                return BadRequest(id);
            }
            var deleteStatus = await _studentService.DeleteStudentAsync(id);
            if (!deleteStatus)
            {
                return NotFound(id);
            }
            return Ok();
        }
    }
}
