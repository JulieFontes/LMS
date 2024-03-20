namespace MAUI.LMS.Views;
using MAUI.LMS.ViewModels;

public partial class StudentView : ContentPage
{
	public StudentView()
	{
		InitializeComponent();
		BindingContext = new StudentViewViewModel();
	}
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}