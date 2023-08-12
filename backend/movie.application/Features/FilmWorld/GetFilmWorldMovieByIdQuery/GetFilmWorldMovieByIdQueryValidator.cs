using FluentValidation;

namespace movie.application.Features.FilmWorld.GetFilmWorldMovieByIdQuery;

public class GetFilmWorldMovieByIdQueryValidator : AbstractValidator<GetFilmWorldMovieByIdQuery>
{
    public GetFilmWorldMovieByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}