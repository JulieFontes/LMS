using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.LMS.Models;

namespace API.LMS.Database
{
    internal class FakeDatabase
    {
        private static FakeDatabase? _instance = null;
        public static FakeDatabase Current { 
            get{ 
                if(_instance == null)
                    _instance = new FakeDatabase();
                return _instance;
            } 
        }

        private static List<Student> people = new List<Student> {
            new Student { Name = "Maddie C Borb", Classification = Student.StudentClassification.Freshman, Id = "mcb22"},
            new Student { Name = "Bob Jones", Classification = Student.StudentClassification.Junior, Id = "bj23"}
        };

        private static List<Course> courses = new List<Course>();

        public List<Student> Students { get { return people; } }

        public List<Course> Courses { get { return courses; } }

    }
}
