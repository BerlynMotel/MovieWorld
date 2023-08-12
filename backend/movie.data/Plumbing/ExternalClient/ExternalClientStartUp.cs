using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using movie.data.Clients;

namespace movie.data.Plumbing.ExternalClient;

public static class ExternalClientStartUp
{
    public static void AddExternalClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<ExternalClientOptions>()
        .Bind(configuration.GetSection(ExternalClientOptions.Key));


        var clientOptions = configuration.GetSection(ExternalClientOptions.Key).Get<ExternalClientOptions>();

        services.AddHttpClient<IMovieClient, MovieClient>(client =>
        {
            client.BaseAddress = new Uri(clientOptions.BaseUrl);
        }).AddHttpMessageHandler(sp =>
        {
            var handler = new AuthorizationHeaderHandler(clientOptions.AccessToken);
            return handler;
        });
    }

    private class AuthorizationHeaderHandler : DelegatingHandler
    {
        private readonly string _accessToken;

        public AuthorizationHeaderHandler(string accessToken)
        {
            _accessToken = accessToken;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("x-access-token", _accessToken);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
