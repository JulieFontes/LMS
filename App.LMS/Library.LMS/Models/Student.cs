using Library.LMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.LMS.Models
{
    public class Student : Person
    {
        public Dictionary<int, double> Grades { get; set; }

        public StudentClassification Classification { get; set; }

        public Student()
        { Grades = new Dictionary<int, double>(); }
        
        //public Student(string _name, StudentClassification cl)
        //{ 
        //    Grades = new Dictionary<int, double>();
        //    Classification = cl;
        //    Name = _name;
        //}

        public enum StudentClassification
        {
            Freshman, Sophomore, Junior, Senior
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Classification}";
        }

    }
}
