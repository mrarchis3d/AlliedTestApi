using Application.Profiles;
using Application.Queries;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MovieDbContext>(); 
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddAutoMapper(typeof(MovieProfile).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPagedMoviesQueryHandler).Assembly));
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var dbContext = services.GetRequiredService<MovieDbContext>();
        dbContext.Database.Migrate();
        dbContext.Initialize();
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while migrating or seeding the database.");
        Console.WriteLine(ex.Message);
    }
}
app.UseCors("AllowSpecificOrigin");
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AlliedTestApi"));
app.MapControllers();
app.Run();