using Library.LMS.Utilities;
using Microsoft.AspNetCore.Mvc;
using Library.LMS.Models;
using API.LMS.EC;

namespace API.LMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Student> Get()
        {
            return new PersonEC().Students;
        }

        [HttpGet("Student/{id}")]
        public Student? GetById(string id)
        {
            return new PersonEC().GetStudent(id);   
        }

        [HttpDelete("Delete/{id}")]
        public Student? Delete(string id)
        {
            return new PersonEC().Delete(id) as Student;
        }

        [HttpPost("AddOrUpdate")]
        public Student? AddOrUpdate([FromBody] Student student)
        {
            return new PersonEC().AddOrUpdate(student) as Student;
        }
    }
}