using Microsoft.Extensions.DependencyInjection;
using movie.domain.Model;

namespace movie.application.Plumbing.AutoMapper;

public static class AutoMapperStartUp
{
    public static void AddCustomAutoMapper(this IServiceCollection services, params Type[] types)
    {
        services.AddAutoMapper(types.Concat(new[] { typeof(Movie) }).ToArray());
    }
}