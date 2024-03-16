using System;
using Library.LMS.Models;

namespace Library.LMS.Services
{
	public class CourseService
	{
		private	 List<Course> courseList = new List<Course>();
        private static _instance;

        public static CourseService? Current
        {
            get
            {
                if (_instance == null)
                    _instance = new CourseService();
                return _instance;
            }
        }

        private static CourseService()
        {
            studentList = new List<Course>();
        }

        public void Add(Course c) 
		{ courseList.Add(c); }
	
		public List<Course> Courses
		{ get { 
				return courseList; 
			} 
		}

		public void UpdateCourse() { 
			
		}

        public IEnumerable<Course> Search(string query)
        { 
			return courseList.Where
				(s => s.Name.ToUpper().Contains(query.ToUpper())
				|| s.Code.ToUpper().Contains(query.ToUpper())
				|| s.Description.ToUpper().Contains(query.ToUpper())
            ); 
		
		
		}
    }
}
