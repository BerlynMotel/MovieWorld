using movie.api.Plumbing.Filters;
using movie.api.Plumbing;
using movie.application.Plumbing.Mediator;
using movie.data.Plumbing.ExternalClient;
using movie.application.Features.CinemaWorld.GetCinemaWorldMoviesQuery;
using Serilog;
using movie.data.CustomImplementations;
using movie.application.Plumbing.AutoMapper;
using movie.data.Plumbing;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.
Log.Logger = new LoggerConfiguration().ConfigureCustomLogging(builder.Configuration).CreateLogger();
Log.Information("Starting application.");

builder.Services.AddExternalClient(builder.Configuration);
builder.Services.AddCustomValidator(typeof(GetCinemaWorldMoviesQueryValidator).Assembly);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddCustomAutoMapper(typeof(Program));
builder.Services.AddCustomMediator();
builder.Services.AddCustomImplementations();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<MediatorExceptionFilter>();
})
.AddJsonOptions(options =>
{
    // Property names are camel-cased by default. Null value for PropertyNamingPolicy ensures property names are unchanged.
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSerilogRequestLogging();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(builder =>
    {
        builder.AllowAnyMethod()
        .AllowAnyOrigin()
        .AllowAnyHeader();
    });
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
