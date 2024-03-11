using App.LMS.Helpers;
using Library.LMS.Models;

namespace CanvasApp
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            var studentHelper = new StudentConsoleHelper();
            List<Person> studentList = new List<Person>();
            
            while (Console.ReadLine() != "0") {
                studentHelper.CreateStudentRecord();
            }
        
        }
    }
}