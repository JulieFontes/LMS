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
        public ObservableCollection<Person> People
        {
            get 
            { return new ObservableCollection<Person>(StudentService.Current.Students); }
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

        public void AddClick(Shell s)
        {
            string idParam = SelectedPerson?.Id ?? string.Empty;
            s.GoToAsync("//PersonDetail?"); 
        }

        public void RemoveClick() 
        {
            if (SelectedPerson == null)
                return;

            StudentService.Current.Remove(SelectedPerson);
            RefreshView();
        }
    }
}
