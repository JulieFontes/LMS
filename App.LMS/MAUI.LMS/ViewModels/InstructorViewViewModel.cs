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

        public Person? SelectedPerson { get; set; }

        private string query;
        public string Query 
        { 
            get => query;
            set { 
                query = value; 
                NotifyPropertyChanged(nameof(People)); 
            }
        }
        public ObservableCollection<Person> People
        {
            get 
            {
                var filteredlist = StudentService.Current.Students.Where(
                    s => s.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty));
                return new ObservableCollection<Person>(filteredlist); 
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(People));
        }

        public void AddEnrollmentClick(Shell s)
        {
            s.GoToAsync($"//PersonDetail?personId={"\0"}"); 
        }

        public void EditEnrollmentClick(Shell s)
        {
            if (SelectedPerson == null)
                return;

            string idParam = SelectedPerson.Id;
            s.GoToAsync($"//PersonDetail?personId={idParam}");
        }

        public void RemoveEnrollmentClick() 
        {
            if (SelectedPerson == null)
                return;

            StudentService.Current.Remove((Student)SelectedPerson);
            RefreshView();
        }
    }
}
