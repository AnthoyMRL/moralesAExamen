using moralesAExamen.ViewModels;

namespace moralesAExamen.Views;

public partial class MovieListPage : ContentPage
{
    private readonly MovieListViewModel _viewModel;

    public MovieListPage(MovieListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.OnAppearing();
    }
}