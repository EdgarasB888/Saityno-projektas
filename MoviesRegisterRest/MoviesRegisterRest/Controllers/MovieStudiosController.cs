using Microsoft.AspNetCore.Mvc;
using MoviesRegisterRest.Data.Dtos.Directors;
using MoviesRegisterRest.Data.Dtos.MovieStudio;
using MoviesRegisterRest.Data.Repositories;
using MoviesRegisterRest.Data.Entities;

namespace MoviesRegisterRest.Controllers;

[ApiController]
[Route("api/moviestudios")]
public class MovieStudiosController : ControllerBase
{
    private readonly IMovieStudiosRepository _MovieStudiosRepository;

    public MovieStudiosController(IMovieStudiosRepository MovieStudiosRepository)
    {
        _MovieStudiosRepository = MovieStudiosRepository;
    }

    // AutoMapper
    [HttpGet]
    public async Task<IEnumerable<MovieStudioDto>> GetMany()
    {
        var movieStudios = await _MovieStudiosRepository.GetManyAsync();

        return movieStudios.Select(o => new MovieStudioDto(o.Id, o.Name, o.Address, o.Phone, o.Email));
    }

    [HttpGet]
    [Route("{movieStudioId}")]
    public async Task<ActionResult<MovieStudioDto>> Get(int movieStudioId)
    {
        var movieStudio = await _MovieStudiosRepository.GetAsync(movieStudioId);

        if (movieStudio == null)
        {
            return NotFound();
        }

        return new MovieStudioDto(movieStudio.Id, movieStudio.Name, movieStudio.Address, movieStudio.Phone, movieStudio.Email);
    }

    [HttpPost]
    public async Task<ActionResult<MovieStudioDto>> Create(CreateMovieStudioDto createMovieStudioDto)
    {
        var movieStudio = new MovieStudio
        {
            Name = createMovieStudioDto.Name,
            Address = createMovieStudioDto.Address,
            Phone = createMovieStudioDto.Phone,
            Email = createMovieStudioDto.Email,
        };

        await _MovieStudiosRepository.CreateAsync(movieStudio);

        //201
        return Created("", new MovieStudioDto(movieStudio.Id, movieStudio.Name, movieStudio.Address, movieStudio.Phone, movieStudio.Email));
    }

    [HttpPut]
    [Route("{movieStudioId}")]
    public async Task<ActionResult<MovieStudioDto>> Update(int movieStudioId, UpdateMovieStudioDto updateMovieStudioDto)
    {
        var movieStudio = await _MovieStudiosRepository.GetAsync(movieStudioId);

        if (movieStudio == null)
        {
            return NotFound();
        }

        movieStudio.Name = updateMovieStudioDto.Name;
        movieStudio.Address = updateMovieStudioDto.Address;
        movieStudio.Phone = updateMovieStudioDto.Phone;
        movieStudio.Email = updateMovieStudioDto.Email;

        await _MovieStudiosRepository.UpdateAsync(movieStudio);

        return Ok(new MovieStudioDto(movieStudio.Id, movieStudio.Name, movieStudio.Address, movieStudio.Phone, movieStudio.Email));
    }

    [HttpDelete]
    [Route("{movieStudioId}")]
    public async Task<ActionResult> Remove(int movieStudioId)
    {
        var movieStudio = await _MovieStudiosRepository.GetAsync(movieStudioId);

        if (movieStudio == null)
        {
            return NotFound();
        }

        await _MovieStudiosRepository.DeleteAsync(movieStudio);

        //204
        return NoContent();
    }
}