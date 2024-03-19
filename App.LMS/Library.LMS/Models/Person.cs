﻿namespace Library.LMS.Models
{
    public class Person
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public Dictionary<int, double> Grades { get; set; }

        public PersonClassification Classification { get; set; }

        public string returnId() {
            return Id.ToString();
        }

        public Person()
        {
            Name = string.Empty;
            Grades = new Dictionary<int, double>();
            Id = string.Empty;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} | {Classification}";
        }
    }
    public enum PersonClassification { 
        Freshman, Sophomore, Junior, Senior
    }

}
