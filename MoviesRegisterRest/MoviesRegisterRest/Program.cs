using Microsoft.EntityFrameworkCore;
using MoviesRegisterRest.Data;
using MoviesRegisterRest.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<WebDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DatabaseConnectionString");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddTransient<IDirectorsRepository, DirectorsRepository>();
builder.Services.AddTransient<IMoviesRepository, MoviesRepository>();
builder.Services.AddTransient<IMovieStudiosRepository, MovieStudiosRepository>();

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();