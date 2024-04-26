using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.LMS.Models;
using Library.LMS.Services;
using static Library.LMS.Models.Student;

namespace MAUI.LMS.ViewModels
{
    public class PersonDetailViewModel
    {
        public string PageTitle
        {
            get
            { 
                if (isUpdating) return "Update Student";

                return "Add Student";
            }
        }

        public string Name { get; set; }

        public char ClassificationChar { get; set; }

        public string? Id { get; set; }

        private bool isUpdating;

        public PersonDetailViewModel(string? id = null)
        {
            if (id != null)
            {
                isUpdating = true;
                LoadById(id);
            }
            else
                isUpdating = false;
            NotifyPropertyChanged(nameof(PageTitle));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadById(string id)
        {
            Student? person = StudentService.Current.GetById(id) as Student;
            if (person == null)
                return;

            Name = person.Name;
            Id = person.Id;
            ClassificationChar = ClassToChar(person.Classification);

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(ClassificationChar));
        }

        public void AddPerson()
        {
            if (Id == null)
                StudentService.Current.Add(new Student(Name, CharToClass(ClassificationChar)));
            else
            {
                Student refToUpdate = StudentService.Current.GetById(Id) as Student;
                refToUpdate.Name = Name;
                refToUpdate.Classification = CharToClass(ClassificationChar);
            }

            Shell.Current.GoToAsync("//Instructor");
        }

        private char ClassToChar(StudentClassification pc)
        {
            switch (pc)
            {
                case StudentClassification.Senior:
                    ClassificationChar = 'S';
                    break;
                case StudentClassification.Junior:
                    ClassificationChar = 'J';
                    break;
                case StudentClassification.Sophomore:
                    ClassificationChar = 'O';
                    break;
                default:
                    ClassificationChar = 'F';
                    break;
            }
            return ClassificationChar;
        }

        private StudentClassification CharToClass(char c)
        {
            StudentClassification sc;
            switch(c)
            {
                case 'S':
                    sc = StudentClassification.Senior;
                    break;
                case 'J':
                    sc = StudentClassification.Junior;
                    break;
                case 'O':
                    sc = StudentClassification.Sophomore;
                    break;
                default:
                    sc = StudentClassification.Freshman;
                    break;
            }
            return sc;
        }
    }
}
