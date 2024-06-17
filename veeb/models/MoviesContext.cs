using Microsoft.EntityFrameworkCore;

namespace veeb.models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie(1, "Inception", 8.8, 2010, "https://image.url/inception.jpg", "Christopher Nolan"),
                new Movie(2, "The Matrix", 8.7, 1999, "https://image.url/matrix.jpg", "Lana Wachowski, Lilly Wachowski"),
                new Movie(3, "Interstellar", 8.6, 2014, "https://image.url/interstellar.jpg", "Christopher Nolan"),
                new Movie(4, "The Godfather", 9.2, 1972, "https://image.url/godfather.jpg", "Francis Ford Coppola"),
                new Movie(5, "Pulp Fiction", 8.9, 1994, "https://image.url/pulpfiction.jpg", "Quentin Tarantino")
            );
        }
    }
}
