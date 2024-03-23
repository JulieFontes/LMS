using System;
using Library.LMS.Models;
using Library.LMS.Database;

namespace Library.LMS.Services
{
    public class CourseService
    {
        private static CourseService? _instance;
        
        private CourseService()
        {
            
        }

        public static CourseService Current
        {
            get
            {
                if (_instance == null)
                    _instance = new CourseService();
                return _instance;
            }
        }

        public void Add(Course c) 
		{ FakeDatabase.Courses.Add(c); }
	
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
    }
}
