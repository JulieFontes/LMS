﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.LMS.Models;

namespace MAUI.LMS.ViewModels
{
    internal class MainViewModel
    {
        public List<Person> Students { get; set; } = new List<Person>();
    }
}