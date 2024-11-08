﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Library.LMS.Models;
using Library.LMS.Services;

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
        public ObservableCollection<Student> EnrolledStudents
        {
            get
            {
                var filteredList = StudentService.Current.Students
                    .Where(
                    s => s.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty));

                return new ObservableCollection<Student>(filteredList);
            }
        }

        public ObservableCollection<Course> Courses
        {
            get
            {
                var filteredList = CourseService.Current.Courses
                    .Where(
                    c => c.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty));
                return new ObservableCollection<Course>(filteredList);
            }
        }

        public bool IsEnrollmentsVisible { get; set; }
        public bool IsCoursesVisible { get; set; }

        private string? query;

        public string Query
        {
            get => query ?? "";
            set
            {
                query = value;
                NotifyPropertyChanged(nameof(EnrolledStudents));
                NotifyPropertyChanged(nameof(Courses));
            }
        }

        public void ShowEnrollments()
        {
            IsEnrollmentsVisible = true;
            IsCoursesVisible = false;
            NotifyPropertyChanged("IsEnrollmentsVisible");
            NotifyPropertyChanged("IsCoursesVisible");
        }

        public void ShowCourses()
        {
            IsCoursesVisible = true;
            IsEnrollmentsVisible = false;
            NotifyPropertyChanged("IsCoursesVisible");
            NotifyPropertyChanged("IsEnrollmentsVisible");
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(EnrolledStudents));
            NotifyPropertyChanged(nameof(Courses));
        }

        public void AddEnrollmentClick(Shell s)
        {
            s.GoToAsync("//PersonDetail");
        }

        public void EditEnrollmentClick(Shell s)
        {
            if (SelectedPerson == null)     //if they have not selected a student when they press 'Edit'
                return;

            s.GoToAsync($"//PersonDetail?personId={SelectedPerson.Id}");
        }

        public void RemoveEnrollmentClick()
        {
            if (SelectedPerson == null)
                return;

            StudentService.Current.Remove(SelectedPerson);
            NotifyPropertyChanged(nameof(EnrolledStudents));
        }

        public void AddCourseClick(Shell s)
        {
            s.GoToAsync($"//CourseDetail");
        }

        public void EditCourseClick(Shell s)
        {
            if (SelectedCourse == null)
                return;

            s.GoToAsync($"//CourseDetail?courseCode={SelectedCourse.Code}");
        }

        public void RemoveCourseClick()
        {
            if (SelectedCourse == null)
                return;

            CourseService.Current.RemoveCourse(SelectedCourse);
            NotifyPropertyChanged(nameof(Courses));
        }
    }
}
