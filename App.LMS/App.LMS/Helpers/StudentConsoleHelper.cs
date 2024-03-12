using Library.LMS.Models;
using Library.LMS.Services;

namespace App.LMS.Helpers 
{

    internal class StudentConsoleHelper 
    {
        private StudentService studentService = new StudentService();
        
        public void CreateStudent() {

            
            
                Console.WriteLine("Enter a name: ");
                string? name = Console.ReadLine();
                Console.WriteLine("Enter the student's classification: [Freshman (1), Sophomore (2), Junior (3), Senior (4)]");
                string classification = Console.ReadLine() ?? string.Empty;
                PersonClassification classEnum = PersonClassification.Freshman;

                if (classification == "2")
                    classEnum = PersonClassification.Sophomore;
                else if (classification == "3")
                    classEnum = PersonClassification.Junior;
                else if (classification == "4")
                    classEnum = PersonClassification.Senior;

                var student = new Person { Name = name ?? string.Empty, Classification = classEnum };

                studentService.studentList.Add(student);

                studentService.List;
                
            
            
        }

        public void ListStudents()
        { studentService.Students.ForEach(s => Console.WriteLine(s)) }

        public void SearchandListStudents(){ 
            Console.WriteLine("Enter a query: ");
            string query = Console.ReadLine();
            
            if(query == null){
                Console.WriteLine("Invalid Query.");
                return;
            }

            studentService.Search(query).ToList().ForEach(s => Console.WriteLine(s));

        }
    }

}
