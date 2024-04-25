using MAUI.LMS.ViewModels;
using Library.LMS.Services;
using Library.LMS.Models;

namespace MAUI.LMS.Views;

[QueryProperty(nameof(PersonId), "personId")]

public partial class PersonDetailView : ContentPage
{
	public PersonDetailView()
	{
		InitializeComponent();
	}
    public string? PersonId { get; set; }

    private void OnArriving(object sender, EventArgs e)
    {
        BindingContext = new PersonDetailViewModel(PersonId);
    }
    
    private void OnLeaving(object sender, EventArgs e) 
    {
        BindingContext = null;
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as PersonDetailViewModel).AddPerson();
    }
}