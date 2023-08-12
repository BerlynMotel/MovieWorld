using Microsoft.Extensions.DependencyInjection;
using movie.application.Abstractions.Services;
using movie.data.Implementations;

namespace movie.data.CustomImplementations;

public static class CustomImplementationsStartup
{
    public static void AddCustomImplementations(this IServiceCollection services)
    {
        services.AddScoped<ICinemaWorldService, CinemaWorldService>();
        services.AddScoped<IFilmWorldService, FilmWorldService>();
    }
}
