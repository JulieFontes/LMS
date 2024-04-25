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
		(BindingContext as InstructorViewViewModel)?.AddEnrollmentClick(Shell.Current);
	}

    private void BackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		(BindingContext as InstructorViewViewModel)?.RefreshView();
	}

    private void EditEnrollmentClicked(object sender, EventArgs e)
    {
		(BindingContext as InstructorViewViewModel)?.EditEnrollmentClick(Shell.Current);
    }

    private void RemoveEnrollmentClicked(object sender, EventArgs e)
    {
		(BindingContext as InstructorViewViewModel)?.RemoveEnrollmentClick();
    }

	private void AddCourseClicked(object sender, EventArgs e)
	{
		(BindingContext as InstructorViewViewModel)?.AddCourseClick(Shell.Current);

    }

    private void EditCourseClicked(object sender, EventArgs e)
    {
		(BindingContext as InstructorViewViewModel).EditCourseClick(Shell.Current);
    }

    private void RemoveCourseClicked(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel)?.RemoveCourseClick();
    }

    private void Toolbar_CoursesClicked(object sender, EventArgs e)
    {
		(BindingContext as InstructorViewViewModel)?.ShowCourses();
    }

	private void Toolbar_EnrollmentsClicked(object sender, EventArgs e)
	{
        (BindingContext as InstructorViewViewModel)?.ShowEnrollments();
    }
}