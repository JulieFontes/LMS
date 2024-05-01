using System;
using Library.LMS.Models;
using Library.LMS.Utilities;
using Newtonsoft.Json;

namespace Library.LMS.Services
{
    public class CourseService
    {
        private static CourseService? _instance;
            
        public static CourseService Current
        {
            get
            {
                if (_instance == null)
                    _instance = new CourseService();
                return _instance;
            }
        }
        public List<Course> Courses
        {
            get
            {
                string? response = new WebRequestHandler().Get("/Course").Result;

                if (response == null)
                    return new List<Course>();

                List<Course> courses = JsonConvert.DeserializeObject<List<Course>>(response) ?? new List<Course>();
                return courses;
            }
        }

        public void AddCourse(Course c) 
		{
            var handler = new WebRequestHandler().Post("/Course/AddOrUpdate", c);
        }

        public void RemoveCourse(Course c) 
        {
            var handler = new WebRequestHandler().Delete($"/Course/Delete/{c.Code}");
        }

        public void AddStudentToCourse(string code, Student s)
        {
            //FakeDatabase.Courses.Find(c => c.Code == code)?.AddStudent(s);
        }
		
        public IEnumerable<Course> Search(string query)
        { 
			return Courses.Where
				(s => s.Name.ToUpper().Contains(query.ToUpper())
				|| s.Code.ToUpper().Contains(query.ToUpper())
				|| s.Description.ToUpper().Contains(query.ToUpper())
            ); 
		}

        public Course? GetByCode(string code)
        {
            string response = new WebRequestHandler().Get($"/Course/{code}").Result;
            Course? course = JsonConvert.DeserializeObject<Course?>(response);
            return course;
        }
    }
}
