namespace MAUI.LMS.Views;
using MAUI.LMS.ViewModels;

public partial class StudentView : ContentPage
{
	public StudentView()
	{
		InitializeComponent();
		BindingContext = new StudentViewViewModel();
	}
}