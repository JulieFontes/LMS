using Library.LMS.Models;
using Library.LMS.Services;
using System.Security.Cryptography.X509Certificates;

namespace App.LMS.Helpers 
{

    internal class StudentConsoleHelper 
    {
        
        public void CreateStudent() {

            Person selectedS = new Person();

                Console.WriteLine("Enter a name: ");
                string name = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Enter the student's classification: [Freshman (1), Sophomore (2), Junior (3), Senior (4)]");
                string classification = Console.ReadLine() ?? string.Empty;
                PersonClassification classEnum = PersonClassification.Freshman;

                if (classification == "2")
                    classEnum = PersonClassification.Sophomore;
                else if (classification == "3")
                    classEnum = PersonClassification.Junior;
                else if (classification == "4")
                    classEnum = PersonClassification.Senior;
                              
                studentService.Current.Add(new Person { Name = name, Classification = classEnum});
           
        }

        public void UpdateStudent() {
            Console.WriteLine("What student would you like to update?");
            string? name = Console.ReadLine();

            if (name == null)
                return;
            //else update

        }

        public void ListStudents()
        { studentService.Current.Students.ForEach(s => Console.WriteLine(s)); }

        public void SearchStudents()
        {
            Console.WriteLine("Enter a query: ");
            string? query = Console.ReadLine();

            if (query == null)
            {
                Console.WriteLine("Invalid Query.");
                return;
            }

            studentService.Current.Search(query).ToList().ForEach(s => Console.WriteLine(s));
        }

        
    }

}
