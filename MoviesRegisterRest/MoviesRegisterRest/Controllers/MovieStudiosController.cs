using Microsoft.AspNetCore.Mvc;
using MoviesRegisterRest.Data.Dtos.Directors;
using MoviesRegisterRest.Data.Dtos.MovieStudio;
using MoviesRegisterRest.Data.Repositories;
using MoviesRegisterRest.Data.Entities;

namespace MoviesRegisterRest.Controllers;

[ApiController]
[Route("api/directors/{directorId}/moviestudios")]
public class MovieStudiosController : ControllerBase
{
    private readonly IDirectorsRepository _DirectorsRepository;
    private readonly IMovieStudiosRepository _MovieStudiosRepository;

    public MovieStudiosController(IDirectorsRepository DirectorsRepository, IMovieStudiosRepository MovieStudiosRepository)
    {
        _DirectorsRepository = DirectorsRepository;
        _MovieStudiosRepository = MovieStudiosRepository;
    }

    // AutoMapper
    [HttpGet]
    public async Task<IEnumerable<MovieStudioDto>> GetMany(int directorId)
    {
        var movieStudios = await _MovieStudiosRepository.GetManyAsync(directorId);
        if(movieStudios == null)
        {
            return Enumerable.Empty<MovieStudioDto>();
        }

        return movieStudios.Select(o => new MovieStudioDto(o.Id, o.Name, o.Address, o.Phone, o.Email, o.Director.Id));
    }

    [HttpGet]
    [Route("{movieStudioId}")]
    public async Task<ActionResult<MovieStudioDto>> Get(int directorId, int movieStudioId)
    {
        var movieStudio = await _MovieStudiosRepository.GetAsync(directorId, movieStudioId);
        if (movieStudio == null)
        {
            return NotFound(new { message = $"Could not find Movie Studio with an Id of {movieStudioId} and Director with an Id of {directorId}" });
        }

        return new MovieStudioDto(movieStudio.Id, movieStudio.Name, movieStudio.Address, movieStudio.Phone, movieStudio.Email, movieStudio.Director.Id);
    }

    [HttpPost]
    public async Task<ActionResult<MovieStudioDto>> Create(int directorId, CreateMovieStudioDto createMovieStudioDto)
    {
        var director = await _DirectorsRepository.GetAsync(directorId);
        if (director == null)
        {
            return NotFound(new { message = $"Could not find Director with an Id of {directorId}" });
        }
        
        var movieStudio = new MovieStudio
        {
            Name = createMovieStudioDto.Name,
            Address = createMovieStudioDto.Address,
            Phone = createMovieStudioDto.Phone,
            Email = createMovieStudioDto.Email,
            Director = director
        };

        await _MovieStudiosRepository.CreateAsync(movieStudio);

        //201
        return Created("", new MovieStudioDto(movieStudio.Id, movieStudio.Name, movieStudio.Address, movieStudio.Phone, movieStudio.Email, movieStudio.Director.Id));
    }

    [HttpPut]
    [Route("{movieStudioId}")]
    public async Task<ActionResult<MovieStudioDto>> Update(int directorId, int movieStudioId, UpdateMovieStudioDto updateMovieStudioDto)
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

        movieStudio.Name = updateMovieStudioDto.Name;
        movieStudio.Address = updateMovieStudioDto.Address;
        movieStudio.Phone = updateMovieStudioDto.Phone;
        movieStudio.Email = updateMovieStudioDto.Email;

        await _MovieStudiosRepository.UpdateAsync(movieStudio);

        return Ok(new MovieStudioDto(movieStudio.Id, movieStudio.Name, movieStudio.Address, movieStudio.Phone, movieStudio.Email, movieStudio.Director.Id));
    }

    [HttpDelete]
    [Route("{movieStudioId}")]
    public async Task<ActionResult> Remove(int directorId, int movieStudioId)
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

        await _MovieStudiosRepository.DeleteAsync(movieStudio);

        //204
        return NoContent();
    }
}