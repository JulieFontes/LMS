using App.LMS.Helpers;
using APP.LMS.Helpers;
using Library.LMS.Models;

namespace CanvasApp
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            var studentHelper = new StudentConsoleHelper();
            var courseHelper = new CourseConsoleHelper();

            bool keepGoing = true;

            while (keepGoing) {
                Console.WriteLine("Do maintanence on:\nS. Student\nC. Courses?");
                Console.WriteLine("EXIT/QUIT ");
                string choice = Console.ReadLine()?.ToUpper() ?? string.Empty;
                switch (choice) 
                {
                    case "S":
                        ShowStudentMenu(studentHelper);
                        break;

                    case "C":
                        ShowCourseMenu(courseHelper);
                        break;

                    case "EXIT":
                    case "QUIT":
                        keepGoing = false;
                        break;

                    default:
                        Console.WriteLine("\nInvalid option.\n");
                        break;                     
                }

            }

        }

        static void ShowStudentMenu(StudentConsoleHelper studentHelper) 
        {
            Console.WriteLine("Select an action:\n " + "A. Add a student\nUS. Update Student \nB. List all enrolled students\nC. Search for a student");
            string choice = Console.ReadLine() ?? string.Empty;
            
            switch (choice.ToUpper()) 
            {
                case "A":
                    studentHelper.CreateStudent();
                    break;
                case "US":
                    studentHelper.UpdateStudent();
                    break;

                case "B":
                    studentHelper.ListStudents();
                    break;

                case "C":
                    studentHelper.SearchStudents();
                    break;

            }
        }

        static void ShowCourseMenu(CourseConsoleHelper courseHelper)
        {
            Console.WriteLine("Select an action:\n" + "D.Add a course\nUC.Update a Course\nE.List all courses\nF.Search Courses\n");
            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice.ToUpper())
            {
                case "D":
                    courseHelper.CreateCourse();
                    break;

                case "UC":
                    courseHelper.UpdateCourse();
                    break;

                case "E":
                    courseHelper.ListCourses();
                    break;

                case "F":
                    courseHelper.SearchCourses();
                    break;
            }
        }
    }
}