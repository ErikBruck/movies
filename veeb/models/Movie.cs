// Models/Movie.cs
namespace veeb.models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public int Year { get; set; }
        public string PosterUrl { get; set; }

        public Movie(int id, string name, double rating, int year, string posterUrl)
        {
            Id = id;
            Name = name;
            Rating = rating;
            Year = year;
            PosterUrl = posterUrl;
        }
    }
}
