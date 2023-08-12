using FluentValidation;

namespace movie.application.Features.CinemaWorld.GetCinemaWorldMovieByIdQuery;

public class GetCinemaWorldMovieByIdQueryValidator : AbstractValidator<GetCinemaWorldMovieByIdQuery>
{
    public GetCinemaWorldMovieByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}