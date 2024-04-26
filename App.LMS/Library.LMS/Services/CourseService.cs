using System;
using Library.LMS.Models;
using Library.LMS.Database;

namespace Library.LMS.Services
{
    public class CourseService
    {
        private static CourseService? _instance;
        
        private CourseService()
        { }

        public static CourseService Current
        {
            get
            {
                if (_instance == null)
                    _instance = new CourseService();
                return _instance;
            }
        }

        public void AddCourse(Course c) 
		{ FakeDatabase.Courses.Add(c); }

        public void AddStudentToCourse(string code, Student s)
        {
            FakeDatabase.Courses.Find(c => c.Code == code)?.AddStudent(s);
        }
	
		public List<Course> Courses
        { get { return FakeDatabase.Courses; } }
		
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
            return FakeDatabase.Courses.FirstOrDefault(s => s.Code == code);
        }
    }
}
