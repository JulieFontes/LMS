using Library.LMS.Models;
using Library.LMS.Services;

namespace APP.LMS.Helpers
{

    internal class CourseConsoleHelper
	{
        private StudentService studentService;
        private CourseService courseService;

        public CourseConsoleHelper()
        {
            studentService = StudentService.Current;
            courseService = CourseService.Current;
        }

        public void CreateCourse(Course? selectedC = null)
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

			while (keepAdding)
			{
				studentService.Students.Where(s => !roster.Any(s2 => s2.Id == s.Id)).ToList().ForEach(Console.WriteLine);

				string selection = "Q";
				if (studentService.Students.Any(s => !roster.Any(s2 => s2.Id == s.Id)))
					selection = Console.ReadLine() ?? string.Empty;

				if (selection.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
				{
					keepAdding = false;
				}
				else
				{

					Person? SelectedStudent = studentService.Students.FirstOrDefault(s => s.Id == selection);

					if (SelectedStudent != null)
						roster.Add(SelectedStudent);

				}
			}

			Console.WriteLine("Would you like to add assignments? (y/n)");
			string assignResponse = Console.ReadLine() ?? "N";

			List<Assignment> assignments = new List<Assignment>();
			if (assignResponse.Equals("Y", StringComparison.InvariantCultureIgnoreCase)) {
				bool cont = true;
				while (cont) {
					Console.WriteLine("Name: ");
					string AssignName = Console.ReadLine() ?? string.Empty;
					Console.WriteLine("Description: ");
					string AssignDescription = Console.ReadLine() ?? string.Empty;
					Console.WriteLine("Total Points: ");
					decimal totalPoints = decimal.Parse(Console.ReadLine() ?? "100");
					Console.WriteLine("Due Date: ");
					DateTime dueDate = DateTime.Parse(Console.ReadLine() ?? "01/01/1900");

					assignments.Add(new Assignment { Name = AssignName, Description = AssignDescription, TotalAvailablePoints = totalPoints, DueDate = dueDate });
					
					Console.WriteLine("Add more assignments? (y/n)");
					assignResponse = Console.ReadLine() ?? "N";
					if (assignResponse.Equals("N", StringComparison.InvariantCultureIgnoreCase))
						cont = false;
				}
			}

			bool isNewCourse = false;
			if (selectedC == null) {
				isNewCourse = true;
				selectedC = new Course();
			}

			selectedC.Name = name;
            selectedC.Description = description;
			selectedC.Code = code;
            selectedC.Roster = new List<Person>(); selectedC.Roster.AddRange(roster);
			selectedC.Assignments = new List<Assignment>(); selectedC.Assignments.AddRange(assignments);

			if (isNewCourse)
				courseService.AddCourse(selectedC);

        }

		public void UpdateCourse() 
			{
			Console.WriteLine("Enter the course code for the course you would like to update: ");
			SearchCourses();

			string? selection = Console.ReadLine();

			Course? selectedC = courseService.Courses.FirstOrDefault(c => c.Code.Equals(selection, StringComparison.InvariantCultureIgnoreCase));

			if (selection != null)
				CreateCourse(selectedC);
			
		}

		public void ListCourses()
		{ courseService.Courses.ForEach(x => Console.WriteLine(x)); }

		public void SearchCourses(string? query = null) {
			if (string.IsNullOrEmpty(query))
				courseService.Courses.ForEach(c => Console.WriteLine(c));
			else {
				courseService.Search(query).ToList().ForEach(c => Console.WriteLine(c));
			}

			Console.WriteLine("Select a course: ");
			string code = Console.ReadLine() ?? string.Empty;

			Course? selectedC = courseService.Courses.FirstOrDefault(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));

			if (selectedC != null)
				Console.WriteLine(selectedC.DetailDisplay);
		}
	}

}