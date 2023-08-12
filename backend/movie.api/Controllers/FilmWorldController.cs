using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using movie.api.Shared;
using movie.application.Features.FilmWorld.GetFilmWorldMovieByIdQuery;
using movie.application.Features.FilmWorld.GetFilmWorldMoviesQuery;
using movie.domain.Model;

namespace movie.api.Controllers;

[Route("api/[controller]")]
public class FilmWorldController : BaseController
{
    public FilmWorldController(IMediator mediator, IMapper mapper) : base(mediator, mapper){}

    [HttpGet]
    [Route("All")]
    [ProducesResponseType(typeof(MovieList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMovies()
        => await ExecuteQuery<GetFilmWorldMoviesQuery, MovieList>();

    [HttpGet]
    [Route("Id")]
    [ProducesResponseType(typeof(MovieData), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMovie([FromQuery] string id)
    {
        GetFilmWorldMovieByIdQuery query = new();
        query.Id = id;

        return await ExecuteQuery<GetFilmWorldMovieByIdQuery, MovieData>(query);
    }
        

}
