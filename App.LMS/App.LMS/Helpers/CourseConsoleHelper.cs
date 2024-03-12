using Library.LMS.Models;
using Library.LMS.Services;

namespace APP.LMS.Helpers
{

	internal class CourseConsoleHelper
	{
		private ConsoleService courseService = new ConsoleService();

		public void CreateCourse()
		{
			Console.WriteLine("What is the name of the course?");
			string name = Console.ReadLine() ?? string.Empty;
			Console.WriteLine("What is the code of the course?");
			var code = Console.ReadLine() ?? string.Empty;
			Console.Writeline("Enter a description.");
			var descrition = Console.ReadLine() ?? string.Empty;

			Course c = new Course { Code = code, Name = name, Description = description};

			courseService.Add(c);

			courseService.courseList.ForEach(x => Console.WriteLine(x));
		}

	}

}