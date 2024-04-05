namespace MAUI.LMS.Views;
using MAUI.LMS.ViewModels;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
        InitializeComponent();
        BindingContext = new InstructorViewViewModel();
	}

	private void AddEnrollmentClicked(object sender, EventArgs e) 
	{
        (BindingContext as InstructorViewViewModel).AddEnrollmentClick(Shell.Current);
    }

    private void BackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		(BindingContext as InstructorViewViewModel).RefreshView();
	}

    private void EditEnrollmentClicked(object sender, EventArgs e)
    {
		(BindingContext as InstructorViewViewModel).EditEnrollmentClick(Shell.Current);
    }

    private void RemoveEnrollmentClicked(object sender, EventArgs e)
    {
		(BindingContext as InstructorViewViewModel).RemoveEnrollmentClick();
    }
}