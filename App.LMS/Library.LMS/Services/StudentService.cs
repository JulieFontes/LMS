using Library.LMS.Models;
using Library.LMS.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Services
{
    public class StudentService
    {
        private static StudentService? _instance;
        public IEnumerable<Student?> Students {
            get { return FakeDatabase.People.Where(p => p is Student).Select(p => p as Student); }
        }

        private StudentService()
        {

        }

        public static StudentService Current
        {
            get { 
                if(_instance == null)
                    _instance = new StudentService();
                return _instance;
            }
        }

        public void Add(Person s) 
        { FakeDatabase.People.Add(s); }

        public void Remove(Person s) 
        { FakeDatabase.People.Remove(s  ); }

        //returns a reference to students found. If returned list type instead w ToList(), it would be a deep copy 
        public IEnumerable<Student?> Search(string query) 
        { return Students.Where(s => (s != null) && s.Name.ToUpper().Contains(query.ToUpper())); }

    }
}
