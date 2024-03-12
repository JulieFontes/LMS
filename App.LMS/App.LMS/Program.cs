using App.LMS.Helpers;
using Library.LMS.Models;

namespace CanvasApp
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            var studentHelper = new StudentConsoleHelper();
            var courseHelper = new CourseConsoleHelper();
            List<Person> studentList = new List<Person>();

            bool keepGoing = true;

            while (keepGoing) {
                Console.WriteLine("Menu:\nA. Add a student\nUS. Update Student \nB. List all enrolled students\nC. Search for a student\nD. Add a course\nEXIT. ");
                string choice = Console.ReadLine().toUpper() ?? string.Empty;

                switch (choice) {
                    case "A":
                        studentHelper.CreateStudent();
                        break;
                    case "AU":
                        studentHelper.UpdateStudent();
                        break;
                    
                    case "B":
                        studentHelper.ListStudents();
                        break;
                    
                    case "C":
                        studentHelper.SearchandListStudents();
                        break;
                    
                    case "D":
                        courseHelper.CreateCourse();
                        break;

                    case "EXIT":
                        keepGoing = false;
                    default:
                        Console.WriteLine("\nInvalid menu option.\n");
                        break;                     
                }

                Console.WriteLine("\nWould you like to continue? (y/n)");
                string continue = Console.ReadLine().ToLower() ?? "n";

                if (continue == "n")
                    keepGoing = false;
            }

        }
    }
}