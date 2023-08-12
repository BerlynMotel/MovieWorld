using movie.domain.Enums;

namespace movie.domain.Model;

public class MovieList
{
    public List<Movie> Movies { get; set; } = new List<Movie>();
}
public class Movie
{
    public Movie() { }
    public string Title { get; set; } = string.Empty;
    public int Year { get; set; }
    public string ID { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Poster { get; set; } = string.Empty;
    public MovieType Origin { get; set; }
}
