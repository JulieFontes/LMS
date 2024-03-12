using System;
using Library.LMS.Models;

namespace Library.LMS.Services
{
	public class CourseService
	{
		public List<Course> courseList = new List<Course>();

		public void Add(Course c) 
		{ courseList.Add(c); }
	
	}
}
