using Library.LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Services
{
    public class StudentService
    {
        public List<Person> studentList = new List<Person>();

        public void Add(Person s) 
        { studentList.Add(s); }

        public List<Person> Students {
            get { 
                return studentList;
            }
        }

    }
}
