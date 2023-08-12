using movie.application.Abstractions.Queries;
using movie.domain.Model;

namespace movie.application.Features.FilmWorld.GetFilmWorldMovieByIdQuery;

public class GetFilmWorldMovieByIdQuery : IQuery<MovieData>
{
    public string Id { get; set; } = string.Empty;
}
