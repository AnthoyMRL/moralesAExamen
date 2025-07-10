using moralesAExamen.ViewModels;

namespace moralesAExamen.Views;

public partial class AddMoviePage : ContentPage
{
    public AddMoviePage(AddMovieViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}