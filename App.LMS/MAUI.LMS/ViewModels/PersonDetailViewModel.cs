using Library.LMS.Models;
using Library.LMS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.LMS.ViewModels
{
    public class PersonDetailViewModel
    {
        public string? TempName { get; set; }

        public string? Id { get; set; }

        public char ClassificationChar { get; set; }

        public PersonDetailViewModel() { }
        public PersonDetailViewModel(string id)
        {
            if (id != "\0")
                LoadById(id);   
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadById(string? id)
        {

            Student? person = StudentService.Current.GetById(id) as Student;
            if (person != null)
            {
                TempName = person.Name;
                Id = person.Id;
                ClassificationChar = ClassToChar(person.Classification);
            }

            NotifyPropertyChanged(nameof(TempName));
            NotifyPropertyChanged(nameof(ClassificationChar));
        }

        public void AddPerson()
        {
            if(Id == null && TempName != string.Empty)  //also create an ID for the student
                StudentService.Current.Add(new Student { Name = TempName, Classification = CharToClass(ClassificationChar), Id = CreateId() });
            else
            {
                Student refToUpdate = StudentService.Current.GetById(Id) as Student ?? new Student();
                refToUpdate.Name = TempName ?? string.Empty;
                refToUpdate.Classification = CharToClass(ClassificationChar);
            }

            Shell.Current.GoToAsync("//Instructor");
        }

        private char ClassToChar(Student.StudentClassification sc) 
        {
            char c;
            if (sc == Student.StudentClassification.Sophomore)
                c = 'O';
            else if (sc == Student.StudentClassification.Junior)
                c = 'J';
            else if (sc == Student.StudentClassification.Senior)
                c = 'S';
            else
                c = 'F';

            return c;
        }

        private Student.StudentClassification CharToClass(char c)
        {
            Student.StudentClassification classification = Student.StudentClassification.Freshman;
            switch (c)
            {
                case 'O':
                    classification = Student.StudentClassification.Sophomore;
                    break;
                case 'J':
                    classification = Student.StudentClassification.Junior;
                    break;
                case 'S':
                    classification = Student.StudentClassification.Senior;
                    break;
            }
            return classification;
        }

        private string CreateId()
        {
            string newid = string.Empty;

            if (TempName == null)
                return newid;

            TempName = TempName.Trim();
            int length = TempName.Length;
            newid += TempName[0];
            for (int pos = 1; pos < length; ++pos)
            {
                if (TempName[pos] == ' ')
                    newid += TempName[++pos];
            }

            newid = newid.ToLower();

            while (StudentService.Current.ExistsId(newid))  //add random alphabet chars to the end until a unique ID is found
            {
                newid += Convert.ToChar(97);
                StringBuilder strBuilder = new StringBuilder(newid);
                for (int i = 98; i < 123; ++i)
                {
                    strBuilder[length] = Convert.ToChar(i);
                    newid = strBuilder.ToString();
                    if (!StudentService.Current.ExistsId(newid))
                        break;
                }
                ++length;
            }

            return newid;
        }

    }
}
