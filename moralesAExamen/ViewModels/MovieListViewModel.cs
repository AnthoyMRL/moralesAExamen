using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using moralesAExamen.Models;
using moralesAExamen.Services;
using System.Collections.ObjectModel;

namespace moralesAExamen.ViewModels
{
    public partial class MovieListViewModel : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        [ObservableProperty]
        private ObservableCollection<Movie> movies = new();

        public MovieListViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [RelayCommand]
        private void LoadMovies()
        {
            var movieList = _databaseService.GetMovies();
            Movies.Clear();

            foreach (var movie in movieList)
            {
                Movies.Add(movie);
            }
        }

        public void OnAppearing()
        {
            LoadMovies();
        }
    }
}