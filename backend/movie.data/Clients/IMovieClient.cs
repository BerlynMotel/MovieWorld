using movie.domain.Enums;
using movie.data.Model;

namespace movie.data.Clients;

public interface IMovieClient
{
    public Task<MovieList> GetMovies(MovieType type);
    public Task<MovieData> GetMoviesById(MovieType type, string id);
}
