using Library.LMS.Models;
using Library.LMS.Services;
using System.Security.Cryptography.X509Certificates;

namespace App.LMS.Helpers 
{

    internal class StudentConsoleHelper 
    {

        private StudentService studentService;
        private CourseService courseService;

        public StudentConsoleHelper() {
            studentService = StudentService.Current;
            courseService = CourseService.Current;
        }
        
        public void CreateStudent(Person? selectedS = null) {

            Console.WriteLine("What is the student's ID?");
            string ID = Console.ReadLine() ?? string.Empty;
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

            bool isCreate = false;
            if (selectedS == null) {
                isCreate = true;
                selectedS = new Person();
            }

            selectedS.Id = ID;
            selectedS.Name = name;
            selectedS.Classification = classEnum;

            if (isCreate)
                studentService.Add(selectedS);

        }

        public void UpdateStudent()
        {
            Console.WriteLine("Select a student to update: (Use ID)");
            ListStudents();

            string? selectionStr = Console.ReadLine();
            if (selectionStr != null)
            {
                var selectedStudent = studentService.Students.FirstOrDefault(s => s.Id == selectionStr);
                if (selectedStudent != null)
                {
                    CreateStudent(selectedStudent);
                }
            }
        }

        public void ListStudents()
        { studentService.Students.ForEach(s => Console.WriteLine(s)); }

        public void SearchStudents()
        {
            Console.WriteLine("Enter a query: ");
            string? query = Console.ReadLine();

            if (query == null)
            {
                Console.WriteLine("Invalid Query.");
                return;
            }

            studentService.Search(query).ToList().ForEach(s => Console.WriteLine(s));
        }

        
    }

}
