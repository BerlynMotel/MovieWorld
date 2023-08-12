using movie.domain.Model;

namespace movie.application.Abstractions.Services;

public interface ICinemaWorldService
{
    public Task<MovieList> GetMovies();
    public Task<MovieData> GetMovieById(string id);
}
