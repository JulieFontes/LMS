using MAUI.LMS.ViewModels;
namespace MAUI.LMS.Views;

[QueryProperty(nameof(CourseCode), "courseCode")]

public partial class CourseDetailView : ContentPage
{
    public string? CourseCode { get; set; }

	public CourseDetailView()
	{
		InitializeComponent();
	}

    private void OnArriving(object sender, EventArgs e)
    {
        BindingContext = new CourseDetailViewModel(CourseCode);
    }

    private void OnLeaving(object sender, EventArgs e)
    {
        BindingContext = null;
    }

    private void PlusClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailViewModel)?.AddStudentToCourse();
    }

    private void DoneClicked(object sender, EventArgs e) 
	{
        (BindingContext as CourseDetailViewModel)?.AddCourse();
    }

	private void BackClicked(object sender, EventArgs e) 
	{
        Shell.Current.GoToAsync("//Instructor");
    }
}