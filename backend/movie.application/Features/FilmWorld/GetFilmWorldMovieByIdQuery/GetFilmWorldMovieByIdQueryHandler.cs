using movie.application.Abstractions.Queries;
using movie.application.Abstractions.Services;
using movie.domain.Model;

namespace movie.application.Features.FilmWorld.GetFilmWorldMovieByIdQuery;

public class GetFilmWorldMovieByIdQueryHandler : IQueryHandler<GetFilmWorldMovieByIdQuery, MovieData>
{
    private readonly IFilmWorldService _filmWorldService;
    public GetFilmWorldMovieByIdQueryHandler(IFilmWorldService filmWorldService)
    {
        _filmWorldService = filmWorldService;
    }
    public async Task<MovieData> Handle(GetFilmWorldMovieByIdQuery request, CancellationToken cancellationToken)
    {   
        //Note: if there's any condition or processing needed for request param. Put it here.
        return await _filmWorldService.GetMovieById(request.Id);
    }
}
