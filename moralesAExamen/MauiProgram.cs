using moralesAExamen.Services;
using moralesAExamen.ViewModels;
using moralesAExamen.Views;

namespace moralesAExamen;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // Servicios
        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddSingleton<LogService>();

        // ViewModels
        builder.Services.AddTransient<AddMovieViewModel>();
        builder.Services.AddTransient<MovieListViewModel>();
        builder.Services.AddTransient<LogsViewModel>();

        // Views
        builder.Services.AddTransient<AddMoviePage>();
        builder.Services.AddTransient<MovieListPage>();
        builder.Services.AddTransient<LogsPage>();

        return builder.Build();
    }
}