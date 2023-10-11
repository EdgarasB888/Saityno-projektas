using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MoviesRegisterRest.Data;
using MoviesRegisterRest.Data.Dtos.Directors;
using MoviesRegisterRest.Data.Dtos.Movies;
using MoviesRegisterRest.Data.Dtos.MovieStudio;
using MoviesRegisterRest.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<DirectorValidators>();
builder.Services.AddValidatorsFromAssemblyContaining<MovieStudioValidators>();
builder.Services.AddValidatorsFromAssemblyContaining<MovieValidators>();

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