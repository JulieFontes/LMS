using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LMS_Library.Services;

namespace LMS_Library.Models
{
    public class Student : Person
    {
        public Dictionary<int, double> Grades { get; set; }

        public StudentClassification Classification { get; set; }

        public Student()
        { Grades = new Dictionary<int, double>(); }
        public Student(string _name, StudentClassification cl)
        { 
            Grades = new Dictionary<int, double>();
            Classification = cl;
            Name = _name;
            Id = newId(_name);
        }
        public enum StudentClassification
        {
            Freshman, Sophomore, Junior, Senior
        }
        public override string ToString()
        {
            return $"[{Id}] {Name} - {Classification}";
        }

        private string newId(string _name)
        {
            _name = _name.ToLower();
            string id = string.Empty;

            if (char.IsLetter(_name[0]))
                id += _name[0];

            for (int i = 1; i < _name.Length; ++i)
            {
                if (_name[i] == ' ') {
                    id += _name[++i];
                }
            }

            int currentYear = DateTime.Now.Year;
            id += currentYear.ToString().Substring(2);

            id = lastValidId(id);

            return id;
        }

        private string lastValidId(string id)
        {
            foreach (Student s in StudentService.Current.Students) {
                if (s.Id == id)
                {
                    id += 'a';
                }
            }

            return id;
        }
    }
}
