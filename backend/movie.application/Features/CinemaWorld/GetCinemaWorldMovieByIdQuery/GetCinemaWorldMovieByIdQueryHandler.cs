using movie.application.Abstractions.Queries;
using movie.application.Abstractions.Services;
using movie.domain.Model;

namespace movie.application.Features.CinemaWorld.GetCinemaWorldMovieByIdQuery;

public class GetCinemaWorldMovieByIdQueryHandler : IQueryHandler<GetCinemaWorldMovieByIdQuery, MovieData>
{
    private readonly ICinemaWorldService _cinemaWorldService;
    public GetCinemaWorldMovieByIdQueryHandler(ICinemaWorldService cinemaWorldService)
    {
        _cinemaWorldService = cinemaWorldService;
    }
    public async Task<MovieData> Handle(GetCinemaWorldMovieByIdQuery request, CancellationToken cancellationToken)
    {   
        //Note: if there's any condition or processing needed for request param. Put it here.
        return await _cinemaWorldService.GetMovieById(request.Id);
    }
}
