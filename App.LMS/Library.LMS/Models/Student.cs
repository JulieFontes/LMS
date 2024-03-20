using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    public class Student : Person
    {
        public Dictionary<int, double> Grades { get; set; }

        public PersonClassification Classification { get; set; }

        public Student()
        { Grades = new Dictionary<int, double>(); }
        public enum PersonClassification
        {
            Freshman, Sophomore, Junior, Senior
        }
    }
}
