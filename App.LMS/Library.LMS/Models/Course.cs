using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    public class Course
    {
        private static int lastId = 0;
        public int Id { get; set; }
        public string Prefix { get; set; }
        public string Code { 
            get { return $"{Prefix} {Id}"; } 
        }

        public string Name { get; set; }

        public string Description { get; set; }


        public List<Person> Roster { get; set; }
        public List<Module> Modules { get; set; }
        public List<Assignment> Assignments { get; set; }

        public Course() {
            Name = string.Empty;
            Description = string.Empty;

            Roster = new List<Person>();
            Modules = new List<Module>();
            Assignments = new List<Assignment>();

            Id = ++lastId;
        }

        public override string ToString(){
            return $"{Code} - {Name}";
        }

        public string DetailDisplay {
            get {
                return $"{ToString()}\n{Description}\n\n" +
                    $"Roster:\n{string.Join("\n", Roster.Select(s => s.ToString().ToArray()))}\n\n" +
                    $"Assignments:\n{string.Join("\n", Assignments.Select(a => a.ToString().ToArray()))}"; 
            }
        }
    }
}
