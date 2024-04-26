using Library.LMS.Models;
using Library.LMS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.LMS.ViewModels
{
    internal class CourseDetailViewModel
    {
        public CourseDetailViewModel(string? code = null)
        {
            if (code != null)
            {
                isUpdating = true;
                LoadByCode(code);
            }
            else
            {
                isUpdating = false;
                roster = new List<Student>();
            }
            NotifyPropertyChanged(nameof(PageTitle));
        }

        private List<Student> roster;

        public List<Student> TempRoster     //save students in here as they are added with the + then add to roster when its closing
        { get => roster; }

        public void AddToRoster()
        { 
            foreach(Student s in TempRoster)
                TempRoster.Add(s); 
        }

        public void RemoveFromRoster(Student s)
        { TempRoster.Remove(s); }

        private Course course;

        public Student SelectedStudent;

        private bool isUpdating;

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
            set { if (course != null) course.Prefix = value; }
        }

        public string CourseCode
        {
            get => course?.Code ?? string.Empty;
        }

        public string PageTitle
        {
            get
            {
                if (isUpdating) return "Update Course";

                return "Add Course";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RefreshCourseView()
        {
            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Id));
            NotifyPropertyChanged(nameof(Prefix));
            NotifyPropertyChanged(nameof(Description));
        }
        public void AddCourse(string? code) 
        {
            if (code == null)
            {
                CourseService.Current.AddCourse(new Course { Name = Name, Description = Description, Prefix = Prefix, Roster = TempRoster });
            }
            else {
                Course refToUpdate = CourseService.Current.GetByCode(CourseCode) ?? new Course();
                refToUpdate.Name = Name;
                refToUpdate.Description = Description;
                refToUpdate.Prefix = Prefix;
                refToUpdate.Roster = TempRoster;
            }
            Shell.Current.GoToAsync("//Instructor");
        }


        private void LoadByCode(string code)
        {
            Course course = CourseService.Current.GetByCode(code) ?? new Course();
            if (course == null)
                return;

            this.course = course;

            RefreshCourseView();
        }
    }
}
