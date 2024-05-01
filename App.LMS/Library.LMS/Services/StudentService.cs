using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.LMS.Models;
using Library.LMS.Utilities;
using Newtonsoft.Json;

namespace Library.LMS.Services
{
    public class StudentService
    {
        private static StudentService? _instance;
        public List<Student> Students 
        {
            get 
            {
                string? response = new WebRequestHandler().Get("/Student").Result;
                //if (response == null)
                //    return new List<Student>();
                List<Student> students = JsonConvert.DeserializeObject<List<Student>>(response) ?? new List<Student>();
                return students;
            }
        }

        public static StudentService Current
        {
            get {
                if (_instance == null)
                {
                    _instance = new StudentService();
                }
                return _instance;
            }
        }

        public void Add(Person target) 
        {
            var handler = new WebRequestHandler().Post("/Student/AddOrUpdate", target);
        }
        
        public void Remove(Person target) 
        {
            var handler = new WebRequestHandler().Delete($"/Student/Delete/{target.Id}"); 
        }

        //returns a reference to students found. If returned list type instead w ToList(), it would be a deep copy 
        public IEnumerable<Student?> Search(string query) 
        { return Students.Where(s => (s != null) && s.Name.ToUpper().Contains(query.ToUpper())); }

        public Student? GetById(string id)
        {
            string response = new WebRequestHandler().Get($"/Student/Student/{id}").Result;
            Student? student = JsonConvert.DeserializeObject<Student?>(response);
            return student;
        }

    }
}
