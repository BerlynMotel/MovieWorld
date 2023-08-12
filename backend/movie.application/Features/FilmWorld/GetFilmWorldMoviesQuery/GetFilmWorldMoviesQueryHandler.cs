using movie.application.Abstractions.Queries;
using movie.application.Abstractions.Services;
using movie.domain.Model;

namespace movie.application.Features.FilmWorld.GetFilmWorldMoviesQuery;

public class GetFilmWorldMoviesQueryHandler : IQueryHandler<GetFilmWorldMoviesQuery, MovieList>
{
    private readonly ICinemaWorldService _cinemaWorldService;
    public GetFilmWorldMoviesQueryHandler(ICinemaWorldService cinemaWorldService)
    {
        _cinemaWorldService= cinemaWorldService;
    }
    public async Task<MovieList> Handle(GetFilmWorldMoviesQuery request, CancellationToken cancellationToken)
    {
        //Note: if there's any condition or processing needed for request param. Put it here.
        return await _cinemaWorldService.GetMovies();
    }
}
