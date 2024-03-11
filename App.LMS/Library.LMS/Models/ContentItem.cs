﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LMS.Models
{
    internal class ContentItem
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string? Path { get; set; }

        public ContentItem() {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}