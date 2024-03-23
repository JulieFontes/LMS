using Library.LMS.Models;
using Library.LMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Library.LMS.Models.Student;

namespace MAUI.LMS.ViewModels
{
    public class PersonDetailViewModel
    {
        public string? Name { get; set; }

        public char ClassificationChar { get; set; }

        public PersonDetailViewModel(string id)
        {
            if(id == string.Empty)
            LoadById(id);    
        }

        private void LoadById(string id)
        { 
            
        }

        public void AddPerson()
        {
            
            Student.StudentClassification classification = Student.StudentClassification.Freshman;
            switch (ClassificationChar)
            {
                case 'F':
                    classification = Student.StudentClassification.Freshman;
                    break;
                case 'O':
                    classification = StudentClassification.Sophomore;
                    break;
                case 'J':
                    classification = StudentClassification.Junior;
                    break;
                case 'S':
                    classification = StudentClassification.Senior;
                    break;
            }
            StudentService.Current.Add(new Student { Name = Name, Classification = classification });
            Shell.Current.GoToAsync("//Instructor");
        }
    }
}
