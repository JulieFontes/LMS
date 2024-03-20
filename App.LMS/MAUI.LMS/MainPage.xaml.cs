using MAUI.LMS.ViewModels;

namespace MAUI.LMS
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void InstructorClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Instructor");
        }

        private void StudentClicked(object sender, EventArgs e) 
        {
            Shell.Current.GoToAsync("//Student");
        }
    }

}
