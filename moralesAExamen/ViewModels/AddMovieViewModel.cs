using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using moralesAExamen.Models;
using moralesAExamen.Services;

namespace moralesAExamen.ViewModels
{
    public partial class AddMovieViewModel : ObservableObject
    {
        private readonly DatabaseService _databaseService;
        private readonly LogService _logService;

        [ObservableProperty]
        private string titulo = string.Empty;

        [ObservableProperty]
        private string genero = string.Empty;

        [ObservableProperty]
        private int anioEstreno = 2024;

        [ObservableProperty]
        private int calificacion = 3;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        [ObservableProperty]
        private string successMessage = string.Empty;

        public List<string> Generos { get; } = new List<string>
        {
            "Acción", "Aventura", "Comedia", "Drama", "Terror",
            "Ciencia Ficción", "Romance", "Thriller", "Animación", "Documental"
        };

        public AddMovieViewModel(DatabaseService databaseService, LogService logService)
        {
            _databaseService = databaseService;
            _logService = logService;
        }

        [RelayCommand]
        private async Task AddMovie()
        {
            ErrorMessage = string.Empty;
            SuccessMessage = string.Empty;

            // Validaciones
            if (string.IsNullOrWhiteSpace(Titulo))
            {
                ErrorMessage = "El título es obligatorio";
                return;
            }

            if (string.IsNullOrWhiteSpace(Genero))
            {
                ErrorMessage = "El género es obligatorio";
                return;
            }

            if (Calificacion < 3)
            {
                ErrorMessage = "No se pueden agregar películas con calificación menor a 3";
                return;
            }

            if (AnioEstreno < 2024)
            {
                ErrorMessage = "No se pueden agregar películas con año de estreno menor a 2024";
                return;
            }

            try
            {
                var movie = new Movie
                {
                    Titulo = Titulo,
                    Genero = Genero,
                    AnioEstreno = AnioEstreno,
                    Calificacion = Calificacion
                };

                _databaseService.SaveMovie(movie);
                await _logService.WriteLogAsync(Titulo);

                SuccessMessage = $"Película '{Titulo}' agregada exitosamente";
                ClearForm();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error al guardar la película: {ex.Message}";
            }
        }

        [RelayCommand]
        private void ClearForm()
        {
            Titulo = string.Empty;
            Genero = string.Empty;
            AnioEstreno = 2024;
            Calificacion = 3;
            ErrorMessage = string.Empty;
        }
    }
}