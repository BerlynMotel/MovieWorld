using Microsoft.Extensions.Logging;
using movie.application.Exceptions;
using movie.domain.Enums;
using movie.data.Model;
using System.Text.Json;

namespace movie.data.Clients;

public class MovieClient : IMovieClient
{
    private readonly HttpClient _client;
    private readonly ILogger<MovieClient> _logger;

    public MovieClient(HttpClient client, ILogger<MovieClient> logger)
    {
        _client = client;
        _logger = logger;
    }

    private async Task<T> ProcessRequest<T>(HttpMethod method, string requestPath)
    {
        using var request = new HttpRequestMessage(method, requestPath);
        using var response = await _client.SendAsync(request);
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound) throw new EntityNotFoundException();

        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var serializedResponse = JsonSerializer.Deserialize<T>(responseString, jsonOptions)!;
        return serializedResponse;
    }

    private async Task<MovieList> GetCinemaWorldMovies()
    {
        try
        {
            var requestPath = Path.Combine(new string[] { _client.BaseAddress!.ToString(), "/api/cinemaworld/movies" });
            return await ProcessRequest<MovieList>(HttpMethod.Get, requestPath);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    private async Task<MovieList> GetFilmWorldMovies()
    {
        try
        {
            var requestPath = Path.Combine(new string[] { _client.BaseAddress!.ToString(), "/api/filmworld/movies" });
            return await ProcessRequest<MovieList>(HttpMethod.Get, requestPath); ;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    private async Task<MovieData> GetCinemaWorldMovie(string id)
    {
        try
        {
            var requestPath = Path.Combine(new string[] { _client.BaseAddress!.ToString(), "/api/cinemaworld/movie/"+id });
            return await ProcessRequest<MovieData>(HttpMethod.Get, requestPath);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
        catch (EntityNotFoundException ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    private async Task<MovieData> GetFilmWorldMovie(string id)
    {
        try
        {
            var requestPath = Path.Combine(new string[] { _client.BaseAddress!.ToString(), "/api/filmworld/movie/" + id });
            return await ProcessRequest<MovieData>(HttpMethod.Get, requestPath);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
        catch (EntityNotFoundException ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
    }

    public Task<MovieList> GetMovies(MovieType type)
    {
        return type switch
        {
            MovieType.Cinema => GetCinemaWorldMovies(),
            MovieType.Film => GetFilmWorldMovies(),
            _ => Task.FromResult(new MovieList()),
        };
    }

    public Task<MovieData> GetMoviesById(MovieType type, string id)
    {
        return type switch
        {
            MovieType.Cinema => GetCinemaWorldMovie(id),
            MovieType.Film => GetFilmWorldMovie(id),
            _ => Task.FromResult(new MovieData()),
        };
    }
}
