using AutoMapper;
using Microsoft.Extensions.Logging;
using movie.application.Abstractions.Services;
using movie.data.Clients;
using movie.domain.Enums;
using movie.domain.Model;
using MD = movie.data.Model.MovieList;
using MDD = movie.data.Model.MovieData;

namespace movie.data.Implementations;

public class CinemaWorldService : ICinemaWorldService
{
    private readonly ILogger<CinemaWorldService> _logger; 
    private readonly IMovieClient _client;
    private readonly IMapper _mapper;

    public CinemaWorldService(IMovieClient client, ILogger<CinemaWorldService> logger, IMapper mapper)
    {
        _logger = logger;
        _client = client;
        _mapper = mapper;
    }

    public async Task<MovieData> GetMovieById(string id)
    {
        _logger.LogDebug($"Fetching all cinema world movie {id}.");
        MDD data = await _client.GetMoviesById(MovieType.Cinema, id);

        return _mapper.Map<MovieData>(data);
    }

    public async Task<MovieList> GetMovies()
    {
        _logger.LogDebug("Fetching all cinema world movies.");

        // Note: if further data processing is needed. Do it here not in the client.
        MD movies = await _client.GetMovies(MovieType.Cinema);

        MovieList ml = _mapper.Map<MovieList>(movies);
        ml.Movies = ml.Movies.Select(i => { i.Origin = MovieType.Cinema; return i; }).OrderByDescending(x => x.Year).ToList();
        return ml;
    }
}
