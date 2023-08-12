namespace movie.data.Plumbing.ExternalClient;

public class ExternalClientOptions
{
    public static readonly string Key = "ExternalAPI";
    public string BaseUrl { get; set; } = string.Empty;
    public string AccessToken { get; set; } = string.Empty;
}
