namespace MAUI.LMS.Views;
using MAUI.LMS.ViewModels;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
		InitializeComponent();
		BindingContext = new InstructorViewViewModel();
	}
}