using movie.application.Abstractions.Queries;
using movie.domain.Model;

namespace movie.application.Features.CinemaWorld.GetCinemaWorldMovieByIdQuery;

public class GetCinemaWorldMovieByIdQuery : IQuery<MovieData>
{
    public string Id { get; set; } = string.Empty;
}
