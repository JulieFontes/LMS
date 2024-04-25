using MAUI.LMS.ViewModels;
namespace MAUI.LMS.Views;

[QueryProperty(nameof(CourseId), "courseId")]

public partial class CourseDetailView : ContentPage
{
    public int CourseId { get; set; }

	public CourseDetailView()
	{
		InitializeComponent();
	}

    private void OnArriving(object sender, EventArgs e)
    {
        BindingContext = new PersonDetailViewModel();
    }

    private void OnLeaving(object sender, EventArgs e)
    {
        BindingContext = null;
    }

    private void AddStudentToCourse(object sender, EventArgs e)
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