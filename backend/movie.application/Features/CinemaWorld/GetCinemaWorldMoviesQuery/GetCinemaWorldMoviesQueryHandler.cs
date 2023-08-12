using movie.application.Abstractions.Queries;
using movie.application.Abstractions.Services;
using movie.domain.Model;

namespace movie.application.Features.CinemaWorld.GetCinemaWorldMoviesQuery;

public class GetCinemaWorldMoviesQueryHandler : IQueryHandler<GetCinemaWorldMoviesQuery, MovieList>
{
    private readonly ICinemaWorldService _cinemaWorldService;
    public GetCinemaWorldMoviesQueryHandler(ICinemaWorldService cinemaWorldService)
    {
        _cinemaWorldService= cinemaWorldService;
    }
    public async Task<MovieList> Handle(GetCinemaWorldMoviesQuery request, CancellationToken cancellationToken)
    {
        //Note: if there's any condition or processing needed for request param. Put it here.
        return await _cinemaWorldService.GetMovies();
    }
}
