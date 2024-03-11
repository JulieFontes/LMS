using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    internal class Assignment
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public float TotalAvailablePoints { get; set; }

        public DateTime DueDate { get; set; }

        public Assignment() {
            Name = string.Empty;
            Description = string.Empty;
            TotalAvailablePoints = 0;
            DueDate = DateTime.MinValue;
        }

        //public override string ToString() { }
    }
}
