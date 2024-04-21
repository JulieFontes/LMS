using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.LMS.Models;
using Library.LMS.Services;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace MAUI.LMS.ViewModels
{
    public class InstructorViewViewModel : INotifyPropertyChanged
    {
        public InstructorViewViewModel()
        {  
            //default open page for InstructorView
            IsEnrollmentsVisible = true;
            IsCoursesVisible = false;
        }

        public Person? SelectedPerson { get; set; }

        public Course? SelectedCourse { get; set; }
        public ObservableCollection<Person> People
        {
            get { return new ObservableCollection<Person>(StudentService.Current.Students); }
        }

        public ObservableCollection<Course> Courses
        {
            get { return new ObservableCollection<Course>(CourseService.Current.Courses); }
        }

        public bool IsEnrollmentsVisible { get; set; }
        public bool IsCoursesVisible { get; set; }

        public void ShowEnrollments()
        {
            IsEnrollmentsVisible = true;
            IsCoursesVisible = false;
            NotifyPropertyChanged(nameof(IsEnrollmentsVisible));
            NotifyPropertyChanged(nameof(IsCoursesVisible));
        }

        public void ShowCourses() 
        {
            IsCoursesVisible = true;
            IsEnrollmentsVisible = false;
            NotifyPropertyChanged(nameof(IsCoursesVisible));
            NotifyPropertyChanged(nameof(IsEnrollmentsVisible));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(People));
            NotifyPropertyChanged(nameof(Courses));
        }

        public void AddEnrollmentClick(Shell s)
        {
            string idParam = SelectedPerson?.Id ?? string.Empty;
            s.GoToAsync("//PersonDetail?"); 
        }

        public void RemoveEnrollmentClick() 
        {
            if (SelectedPerson == null)
                return;

            StudentService.Current.Remove(SelectedPerson);
            RefreshView();
        }

        public void AddCourseClick(Shell s)
        {
            s.GoToAsync($"//CourseDetail");
        }

        public void RemoveCourseClick()
        { 
            
        }
    }
}
