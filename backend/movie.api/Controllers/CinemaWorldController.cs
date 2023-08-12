using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using movie.api.Shared;
using movie.application.Features.CinemaWorld.GetCinemaWorldMovieByIdQuery;
using movie.application.Features.CinemaWorld.GetCinemaWorldMoviesQuery;
using movie.domain.Model;

namespace movie.api.Controllers;

[Route("api/[controller]")]
public class CinemaWorldController : BaseController
{
    public CinemaWorldController(IMediator mediator, IMapper mapper) : base(mediator, mapper){}

    [HttpGet]
    [Route("All")]
    [ProducesResponseType(typeof(MovieList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMovies()
        => await ExecuteQuery<GetCinemaWorldMoviesQuery, MovieList>();

    [HttpGet]
    [Route("Id")]
    [ProducesResponseType(typeof(MovieData), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMovie([FromQuery] string id)
    {
        GetCinemaWorldMovieByIdQuery query = new();
        query.Id = id;

        return await ExecuteQuery<GetCinemaWorldMovieByIdQuery, MovieData>(query);
    }
        

}
