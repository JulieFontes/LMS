using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    public class Course
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        List<Person> Roster;
        List<Module> Modules;
        List<Assignment> Assingments;

        public Course() {
            Name = string.Empty;
            Description = string.Empty;
            Code = string.Empty;

            Roster = new List<Person>();
            Modules = new List<Module>();
            Assingments = new List<Assignment>();
        }

        public override string ToString(){
            return $"{Code} - {Name}";
        }
    }
}
