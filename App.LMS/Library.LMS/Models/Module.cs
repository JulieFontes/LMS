using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Library.Models
{
    public class Module
    {
        public string Name { get; set; }

        public string Description { get; set; }

        List<ContentItem> Content;

        public Module() {
            Name = string.Empty;
            Description = string.Empty;
            Content = new List<ContentItem>();
        }
    }
}
