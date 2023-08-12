using Serilog;

namespace movie.api.Plumbing;

public static class LoggerStartUp
{
    internal static LoggerConfiguration ConfigureCustomLogging(this LoggerConfiguration loggerConfiguration, IConfiguration configuration)
    {
        loggerConfiguration.ReadFrom.Configuration(configuration);

        return loggerConfiguration;
    }
}
