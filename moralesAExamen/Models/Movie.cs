using SQLite;

namespace moralesAExamen.Models
{
    [Table("Movies")]
    public class Movie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Genero { get; set; } = string.Empty;

        public int AnioEstreno { get; set; }

        public int Calificacion { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}