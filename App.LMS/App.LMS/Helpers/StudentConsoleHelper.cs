using Library.LMS.Models;
using Library.LMS.Services;
using System.Security.Cryptography.X509Certificates;

namespace App.LMS.Helpers 
{

    internal class StudentConsoleHelper 
    {
        private StudentService studentService = new StudentService();
        
        public void CreateOrUpdateStudent(Person? studentS = null) {
            
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

                bool isCreate = false;
                if (selectedS != null)
                {
                    isCreate = true;
                    selectedS = new Person();
                }

                selectedS.Name = name;
                selectedS.Classification = classification;

                if(isCreate)    
                    studentService.Add(student);
           
                
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

        

            public void UpdateStudent() {
                Console.WriteLine("Select student to update.");

                ListStudents();
                string? selectionStr = Console.ReadLine();
                if (int.TryParse(selectionStr, out int selectionInt)) {
                    studentService.studentList.Students.FirstOrDefault(s => s.Id == selectionInt);
                }
            }
    }

}
