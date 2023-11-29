using Microsoft.AspNetCore.Mvc;
using MoviesRegisterRest.Data.Dtos.Directors;
using MoviesRegisterRest.Data.Dtos.MovieStudio;
using MoviesRegisterRest.Data.Repositories;
using MoviesRegisterRest.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using MoviesRegisterRest.Auth.Model;
using System.Data;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace MoviesRegisterRest.Controllers;

[ApiController]
[Route("api/directors/{directorId}/moviestudios")]
public class MovieStudiosController : ControllerBase
{
    private readonly IDirectorsRepository _DirectorsRepository;
    private readonly IMovieStudiosRepository _MovieStudiosRepository;
    private readonly IAuthorizationService _authorizationService;

    public MovieStudiosController(IDirectorsRepository DirectorsRepository, IMovieStudiosRepository MovieStudiosRepository,
        IAuthorizationService authorizationService)
    {
        _DirectorsRepository = DirectorsRepository;
        _MovieStudiosRepository = MovieStudiosRepository;
        _authorizationService = authorizationService;
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
    [Authorize(Roles = MoviesWebRoles.MovieStudioCEO)]
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
            Director = director,
            UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub)
        };

        await _MovieStudiosRepository.CreateAsync(movieStudio);

        //201
        return Created("", new MovieStudioDto(movieStudio.Id, movieStudio.Name, movieStudio.Address, movieStudio.Phone, movieStudio.Email, movieStudio.Director.Id));
    }

    [HttpPut]
    [Route("{movieStudioId}")]
    [Authorize(Roles = MoviesWebRoles.MovieStudioCEO)]
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

        var authorizationResult = await _authorizationService.AuthorizeAsync(User, movieStudio, PolicyNames.ResourceOwner);
        if (!authorizationResult.Succeeded)
        {
            return Forbid(); //arba grąžinti 404
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
    [Authorize(Roles = MoviesWebRoles.MovieStudioCEO)]
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

        var authorizationResult = await _authorizationService.AuthorizeAsync(User, movieStudio, PolicyNames.ResourceOwner);
        if (!authorizationResult.Succeeded)
        {
            return Forbid(); //arba grąžinti 404
        }

        await _MovieStudiosRepository.DeleteAsync(movieStudio);

        //204
        return NoContent();
    }
}