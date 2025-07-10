using SQLite;
using moralesAExamen.Models;

namespace moralesAExamen.Services
{
    public class DatabaseService
    {
        private SQLiteConnection _database;
        private readonly string _databasePath;

        public DatabaseService()
        {
            _databasePath = Path.Combine(FileSystem.AppDataDirectory, "movies.db");
            _database = new SQLiteConnection(_databasePath);
            _database.CreateTable<Movie>();
        }

        public List<Movie> GetMovies()
        {
            return _database.Table<Movie>().OrderByDescending(m => m.FechaRegistro).ToList();
        }

        public int SaveMovie(Movie movie)
        {
            if (movie.Id != 0)
            {
                return _database.Update(movie);
            }
            else
            {
                movie.FechaRegistro = DateTime.Now;
                return _database.Insert(movie);
            }
        }

        public int DeleteMovie(Movie movie)
        {
            return _database.Delete(movie);
        }

        public void CloseConnection()
        {
            _database?.Close();
        }
    }
}