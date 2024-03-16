using App.LMS.Helpers;
using Library.LMS.Models;
using Library.LMS.Services;
using System.ComponentModel.Design;
using System.Xml.Serialization;

namespace APP.LMS.Helpers
{

	internal class CourseConsoleHelper
	{
		public void CreateCourse()
		{
			Console.WriteLine("What is the name of the course?");
			string name = Console.ReadLine() ?? string.Empty;
			Console.WriteLine("What is the code of the course?");
			var code = Console.ReadLine() ?? string.Empty;
			Console.WriteLine("Enter a description.");
			var description = Console.ReadLine() ?? string.Empty;

			Console.WriteLine("What students would you like to add to this course? ('q' to quit)");
			bool keepAdding = true;
			List<Person> roster = new List<Person>();

			while(keepAdding)
			{
				StudentService.Current.Students.Where(s => !roster.Any(s2 => s2.Id == s.Id)).ToList().ForEach(Console.WriteLine());
				
				string selection = "Q";
				if(StudentService.Current.Students.Any(s => !Any(s2 => s2.Id == s.Id)))
					selection = Console.ReadLine() ?? string.Empty;

				if (selection.Equals("Q", StringComparison.InvariantCultureIgnoreCase)) 
					keepAdding = false;
			}else {

				string SelectedId = string.Parse();
				Person SelectedStudent = studentServices.Current.Students.FirstOrDefault(s => s.Id == SelectedId);

				if (SelectedStudent != null)
					roster.Add(SelectedStudent);

			}
			//Roster.AddRange(roster)?
			CourseService.Current.Add(Course(Name = name, Code = code, Description = description, Roster = roster));

			CourseService.Current.Courses.ForEach(x => Console.WriteLine(x));
		}

		public void ListCourses()
		{ courseService.Current.Courses.ForEach(x => Console.WriteLine(x)); }

		public void UpdateCourse() { }

		public void SearchCourses() {
            Console.WriteLine("Enter a query: ");
            string? query = Console.ReadLine();

            if (query == null)
            {
                Console.WriteLine("Invalid Query.");
                return;
            }

            courseService.Current.Search(query).ToList().ForEach(s => Console.WriteLine(s));
        }
	}

}