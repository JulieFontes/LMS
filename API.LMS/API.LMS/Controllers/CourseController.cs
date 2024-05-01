using Library.LMS.Utilities;
using Microsoft.AspNetCore.Mvc;
using Library.LMS.Models;
using API.LMS.EC;

namespace API.LMS.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Course> Get() 
        {
            return new CourseEC().Courses;
        }

        [HttpGet("Course/{code}")]
        public Course? GetByCode(string code)
        {
            return new CourseEC().Get(code);
        }

        [HttpDelete("Delete/{code}")]
        public Course? Delete(string code)
        {
            return new CourseEC().Delete(code);
        }

        [HttpPost("AddOrUpdate")]
        public Course? AddOrUpdate([FromBody] Course course)
        {
            return new CourseEC().AddOrUpdate(course);
        }

    }
}