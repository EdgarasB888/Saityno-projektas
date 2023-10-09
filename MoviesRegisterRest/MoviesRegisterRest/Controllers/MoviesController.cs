using Microsoft.AspNetCore.Mvc;
using MoviesRegisterRest.Data.Dtos.Directors;
using MoviesRegisterRest.Data.Dtos.Movies;
using MoviesRegisterRest.Data.Dtos.MovieStudio;
using MoviesRegisterRest.Data.Entities;
using MoviesRegisterRest.Data.Repositories;


namespace MoviesRegisterRest.Controllers;

[ApiController]
[Route("api/directors/{directorId}/moviestudios/{movieStudioId}/movies")]
public class MoviesController : ControllerBase
{
    private readonly IDirectorsRepository _DirectorsRepository;
    private readonly IMovieStudiosRepository _MovieStudiosRepository;
    private readonly IMoviesRepository _MoviesRepository;

    public MoviesController(IDirectorsRepository DirectorsRepository, IMovieStudiosRepository MovieStudiosRepository, IMoviesRepository MoviesRepository)
    {
        _DirectorsRepository = DirectorsRepository;
        _MovieStudiosRepository = MovieStudiosRepository;
        _MoviesRepository = MoviesRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<MovieDto>> GetMany(int directorId, int movieStudioId)
    {
        var movies = await _MoviesRepository.GetManyAsync(directorId, movieStudioId);
        if(movies == null)
        {
            return Enumerable.Empty<MovieDto>();
        }

        return movies.Select(o => new MovieDto(o.Id, o.Name, o.Genre, o.PlotSummary, o.Budget, o.ProductionStatus, o.OriginCountry));
    }

    [HttpGet]
    [Route("{movieId}")]
    public async Task<ActionResult<MovieDto>> Get(int directorId, int movieStudioId, int movieId)
    {
        var movie = await _MoviesRepository.GetAsync(directorId, movieStudioId, movieId);

        if (movie == null)
        {
            return NotFound(new { message = $"Could not find Movie with an Id of {movieId} of Movie Studio with an Id {movieStudioId} and Director with an Id of {directorId}" });
        }

        return new MovieDto(movie.Id, movie.Name, movie.Genre, movie.PlotSummary, movie.Budget, movie.ProductionStatus, movie.OriginCountry);
    }

    [HttpPost]
    public async Task<ActionResult<MovieDto>> Create(int directorId, int movieStudioId, int movieId, CreateMovieDto createMovieDto)
    {
        var director = await _DirectorsRepository.GetAsync(directorId);
        if (director == null)
        {
            return NotFound(new { message = $"Could not find Director with an Id of {directorId}" });
        }
        
        var movieStudio = await _MovieStudiosRepository.GetAsync(directorId, movieStudioId);
        if (movieStudio == null)
        {
            return NotFound(new { message = $"Could not find Movie Studio with an Id of {movieStudioId} and Director with an Id of {directorId}" });
        }
        
        var movie = new Movie
        {
            Name = createMovieDto.Name,
            Genre = createMovieDto.Genre,
            PlotSummary = createMovieDto.PlotSummary,
            Budget = createMovieDto.Budget,
            ProductionStatus = createMovieDto.ProductionStatus,
            OriginCountry = createMovieDto.OriginCountry,
            MovieStudio = movieStudio
        };

        await _MoviesRepository.CreateAsync(movie);

        //201
        return Created("", new MovieDto(movie.Id, movie.Name, movie.Genre, movie.PlotSummary, movie.Budget, movie.ProductionStatus, movie.OriginCountry));
    }

    [HttpPut]
    [Route("{movieId}")]
    public async Task<ActionResult<MovieDto>> Update(int directorId, int movieStudioId, int movieId, UpdateMovieDto updateMovieDto)
    {
        var director = await _DirectorsRepository.GetAsync(directorId);
        if (director == null)
        {
            return NotFound(new { message = $"Could not find Director with an Id of {directorId}" });
        }
        
        var movieStudio = await _MovieStudiosRepository.GetAsync(directorId, movieStudioId);
        if (movieStudio == null)
        {
            return NotFound(new { message = $"Could not find Movie Studio with an Id of {movieStudioId} and Director with an Id of {directorId}" });
        }
        
        var movie = await _MoviesRepository.GetAsync(directorId, movieStudioId, movieId);
        if (movie == null)
        {
            return NotFound(new { message = $"Could not find Movie with an Id of {movieId} of Movie Studio with an Id {movieStudioId} and Director with an Id of {directorId}" });
        }

        movie.Name = updateMovieDto.Name;
        movie.Genre = updateMovieDto.Genre;
        movie.PlotSummary = updateMovieDto.PlotSummary;
        movie.Budget = updateMovieDto.Budget;
        movie.ProductionStatus = updateMovieDto.ProductionStatus;
        movie.OriginCountry = updateMovieDto.OriginCountry;

        await _MoviesRepository.UpdateAsync(movie);

        return Ok(new MovieDto(movie.Id, movie.Name, movie.Genre, movie.PlotSummary, movie.Budget, movie.ProductionStatus, movie.OriginCountry));
    }

    [HttpDelete]
    [Route("{movieId}")]
    public async Task<ActionResult> Remove(int directorId, int movieStudioId, int movieId)
    {
        var director = await _DirectorsRepository.GetAsync(directorId);
        if (director == null)
        {
            return NotFound(new { message = $"Could not find Director with an Id of {directorId}" });
        }
        
        var movieStudio = await _MovieStudiosRepository.GetAsync(directorId, movieStudioId);
        if (movieStudio == null)
        {
            return NotFound(new { message = $"Could not find Movie Studio with an Id of {movieStudioId} and Director with an Id of {directorId}" });
        }
        
        var movie = await _MoviesRepository.GetAsync(directorId, movieStudioId, movieId);
        if (movie == null)
        {
            return NotFound(new { message = $"Could not find Movie with an Id of {movieId} of Movie Studio with an Id {movieStudioId} and Director with an Id of {directorId}" });
        }

        await _MoviesRepository.DeleteAsync(movie);

        //204
        return NoContent();
    }
}

