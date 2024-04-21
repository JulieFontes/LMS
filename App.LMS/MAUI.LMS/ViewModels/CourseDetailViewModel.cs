using Library.LMS.Models;
using Library.LMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.LMS.ViewModels
{
    internal class CourseDetailViewModel
    {
        public CourseDetailViewModel()
        {
            course = new Course();
        }

        private Course course;

        public int Id { get; set; }

        public string Name {
            get => course?.Name ?? string.Empty;
            set { if (course != null) course.Name = value; }
        }

        public string Description { 
            get => course?.Description ?? string.Empty;
            set { if (course != null) course.Description = value; }
        }

        public string Prefix {
            get => course?.Prefix ?? string.Empty;
            set { if (course != null) course.Name = value; }
        }

        public string CourseCode
        {
            get => course?.Code ?? string.Empty;
        }


        public void AddCourse() 
        {
            if (Id <= 0)
            {
                CourseService.Current.Add(new Course { Name = Name, Description = Description, Prefix = Prefix });
            }
            else {
                var refToUpdate = CourseService.Current.GetById(Id) as Course;
                refToUpdate.Name = Name;
                refToUpdate.Description = Description;
                refToUpdate.Prefix = Prefix;
            }
            Shell.Current.GoToAsync("//Instructor");
        }

        public void AddStudentToCourse() 
        { 
            
        }
    }
}
