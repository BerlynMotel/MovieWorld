namespace movie.data.Model;

public class MovieList
{
    public List<Movie> Movies { get; set; } = new List<Movie>();
}
public class Movie
{
    public Movie() { }
    public string Title { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
    public string ID { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Poster { get; set; } = string.Empty;
}
