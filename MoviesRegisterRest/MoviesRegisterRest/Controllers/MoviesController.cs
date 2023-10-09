using Microsoft.AspNetCore.Mvc;
using MoviesRegisterRest.Data.Dtos.Directors;
using MoviesRegisterRest.Data.Dtos.Movies;
using MoviesRegisterRest.Data.Entities;
using MoviesRegisterRest.Data.Repositories;


namespace MoviesRegisterRest.Controllers;

[ApiController]
[Route("api/movies")]
public class MoviesController : ControllerBase
{
    private readonly IMoviesRepository _MoviesRepository;

    public MoviesController(IMoviesRepository MoviesRepository)
    {
        _MoviesRepository = MoviesRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<MovieDto>> GetMany()
    {
        var movies = await _MoviesRepository.GetManyAsync();

        return movies.Select(o => new MovieDto(o.Id, o.Name, o.Genre, o.PlotSummary, o.Budget, o.ProductionStatus, o.OriginCountry));
    }

    [HttpGet]
    [Route("{movieId}")]
    public async Task<ActionResult<MovieDto>> Get(int movieId)
    {
        var movie = await _MoviesRepository.GetAsync(movieId);

        if (movie == null)
        {
            return NotFound();
        }

        return new MovieDto(movie.Id, movie.Name, movie.Genre, movie.PlotSummary, movie.Budget, movie.ProductionStatus, movie.OriginCountry);
    }

    [HttpPost]
    public async Task<ActionResult<MovieDto>> Create(CreateMovieDto createMovieDto)
    {
        var movie = new Movie
        {
            Name = createMovieDto.Name,
            Genre = createMovieDto.Genre,
            PlotSummary = createMovieDto.PlotSummary,
            Budget = createMovieDto.Budget,
            ProductionStatus = createMovieDto.ProductionStatus,
            OriginCountry = createMovieDto.OriginCountry,
        };

        await _MoviesRepository.CreateAsync(movie);

        //201
        return Created("", new MovieDto(movie.Id, movie.Name, movie.Genre, movie.PlotSummary, movie.Budget, movie.ProductionStatus, movie.OriginCountry));
    }

    [HttpPut]
    [Route("{movieId}")]
    public async Task<ActionResult<MovieDto>> Update(int movieId, UpdateMovieDto updateMovieDto)
    {
        var movie = await _MoviesRepository.GetAsync(movieId);

        if (movie == null)
        {
            return NotFound();
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
    public async Task<ActionResult> Remove(int movieId)
    {
        var movie = await _MoviesRepository.GetAsync(movieId);

        if (movie == null)
        {
            return NotFound();
        }

        await _MoviesRepository.DeleteAsync(movie);

        //204
        return NoContent();
    }
}

