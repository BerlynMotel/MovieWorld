namespace movie.domain.Model;

public class MovieData
{
    public MovieData() { }
    public string Title { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Rated { get; set; } = string.Empty;
    public DateTime Released { get; set; }
    public string Runtime { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string Writer { get; set; } = string.Empty;
    public string Actors { get; set; } = string.Empty;
    public string Plot { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Poster { get; set; } = string.Empty;
    public int Metascore { get; set; }
    public double Rating { get; set; }
    public string Votes { get; set; } = string.Empty;
    public string ID { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public double Price { get; set; }
}
