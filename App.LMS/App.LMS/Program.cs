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
                Console.WriteLine("Menu:\nA. Add a student\nUS. Update Student \nB. List all enrolled students\nC. Search for a student" +
                    "\nD. Add a course\nUC. Update a Course\nE. List all courses\nF. Search Courses\nEXIT/QUIT ");
                string choice = Console.ReadLine()?.ToUpper() ?? string.Empty;

                switch (choice) {
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
                    
                    case "EXIT":
                    case "QUIT":
                        keepGoing = false;
                        break;

                    default:
                        Console.WriteLine("\nInvalid menu option.\n");
                        break;                     
                }

            }

        }
    }
}