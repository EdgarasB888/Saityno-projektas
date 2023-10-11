using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MoviesRegisterRest.Data;
using MoviesRegisterRest.Data.Dtos.Directors;
using MoviesRegisterRest.Data.Entities;
using MoviesRegisterRest.Data.Repositories;

namespace MoviesRegisterRest.Controllers;

[ApiController]
[Route("api/directors")]
public class DirectorsController : ControllerBase
{
    private readonly IDirectorsRepository _DirectorsRepository;
    
    public DirectorsController(IDirectorsRepository DirectorsRepository)
    {
        _DirectorsRepository = DirectorsRepository;
    }

    // AutoMapper
    //[HttpGet]
    public async Task<IEnumerable<DirectorDto>> GetMany()
    {
        var directors = await _DirectorsRepository.GetManyAsync();

        return directors.Select(o => new DirectorDto(o.Id, o.FullName, o.Gender, o.Country, o.BirthDate, o.RegisterDate, o.Biography, o.SpokenLanguages, o.Address, o.Phone, o.Email, o.IsAvailable));
    }
    
    [HttpGet(Name = "GetTopics")]
    // /directors?pageNumber=1&pageSize=5
    public async Task<IEnumerable<DirectorDto>> GetManyPaging([FromQuery] DirectorSearchParameters searchParameters)
    {
        var directors = await _DirectorsRepository.GetManyAsync(searchParameters);

        var previousPageLink = directors.HasPrevious
            ? CreateTopicsResourceUri(searchParameters, ResourceUriType.PreviousPage)
            : null;
        
        var nextPageLink = directors.HasNext
            ? CreateTopicsResourceUri(searchParameters, ResourceUriType.NextPage)
            : null;

        var paginationMetaData = new
        {
            totalCount = directors.TotalCount,
            pageSize = directors.PageSize,
            currentPage = directors.CurrentPage,
            totalPages = directors.TotalPages,
            previousPageLink,
            nextPageLink
        };
        
        // Pagination:
        // {"resource": {}, "paging": {}}
        Response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationMetaData));

        return directors.Select(o => new DirectorDto(o.Id, o.FullName, o.Gender, o.Country, o.BirthDate, o.RegisterDate, o.Biography, o.SpokenLanguages, o.Address, o.Phone, o.Email, o.IsAvailable));
    }

    // api/Directors/{directorId}
    [HttpGet]
    [Route("{directorId}")]
    public async Task<ActionResult<DirectorDto>> Get(int directorId)
    {
        var director = await _DirectorsRepository.GetAsync(directorId);

        if (director == null)
        {
            return NotFound(new { message = $"Could not find Director with an Id of {directorId}" });
        }
        
        return new DirectorDto(director.Id, director.FullName, director.Gender, director.Country, director.BirthDate, director.RegisterDate, director.Biography, director.SpokenLanguages, director.Address, director.Phone, director.Email, director.IsAvailable);
    }
    
    // api/Directors
    [HttpPost]
    public async Task<ActionResult<DirectorDto>> Create(CreateDirectorDto createDirectorDto)
    {
        var director = new Director
        {
            FullName = createDirectorDto.FullName,
            Gender = createDirectorDto.Gender,
            Country = createDirectorDto.Country,
            BirthDate = createDirectorDto.BirthDate,
            RegisterDate = DateTime.UtcNow,
            Biography = createDirectorDto.Biography,
            SpokenLanguages = createDirectorDto.SpokenLanguages,
            Address = createDirectorDto.Address,
            Phone = createDirectorDto.Phone,
            Email = createDirectorDto.Email,
            IsAvailable = createDirectorDto.IsAvailable
        };

        await _DirectorsRepository.CreateAsync(director);
        
        //201
        return Created("", new DirectorDto(director.Id, director.FullName, director.Gender, director.Country, director.BirthDate, director.RegisterDate, director.Biography, director.SpokenLanguages, director.Address, director.Phone, director.Email, director.IsAvailable));
        //return CreatedAtAction("GetDirector", new { DirectorId = Director.Id}, new DirectorDto(Director.FullName, Director.Gender, Director.Role, Director.Country, Director.BirthDate, Director.RegisterDate, Director.Biography, Director.SpokenLanguages, Director.Address, Director.Phone, Director.Email, Director.IsAvailable));
    }
    
    // api/Directors/{directorId}
    [HttpPut]
    [Route("{directorId}")]
    public async Task<ActionResult<DirectorDto>> Update(int directorId, UpdateDirectorDto updateDirectorDto)
    {
        var director = await _DirectorsRepository.GetAsync(directorId);

        if (director == null)
        {
            return NotFound(new { message = $"Could not find Director with an Id of {directorId}" });
        }

        director.FullName = updateDirectorDto.FullName;
        director.Gender = updateDirectorDto.Gender;
        director.Country = updateDirectorDto.Country;
        director.BirthDate = updateDirectorDto.BirthDate;
        director.Biography = updateDirectorDto.Biography;
        director.SpokenLanguages = updateDirectorDto.SpokenLanguages;
        director.Address = updateDirectorDto.Address;
        director.Phone = updateDirectorDto.Phone;
        director.Email = updateDirectorDto.Email;
        director.IsAvailable = updateDirectorDto.IsAvailable;

        await _DirectorsRepository.UpdateAsync(director);

        return Ok(new DirectorDto(director.Id, director.FullName, director.Gender, director.Country, director.BirthDate, director.RegisterDate, director.Biography, director.SpokenLanguages, director.Address, director.Phone, director.Email, director.IsAvailable));
    }
    
    // api/Directors/{DirectorId}
    [HttpDelete]
    [Route("{directorId}")]
    public async Task<ActionResult> Remove(int directorId)
    {
        var director = await _DirectorsRepository.GetAsync(directorId);

        if (director == null)
        {
            return NotFound(new { message = $"Could not find Director with an Id of {directorId}" });
        }

        await _DirectorsRepository.DeleteAsync(director);
        
        //204
        return NoContent();
    }

    private string? CreateTopicsResourceUri(DirectorSearchParameters directorSearchParameters, ResourceUriType type)
    {
        return type switch
        {
            ResourceUriType.PreviousPage => Url.Link("GetTopics", new
            {
                pageNumber = directorSearchParameters.PageNumber - 1,
                pageSize = directorSearchParameters.PageSize,
            }),
            ResourceUriType.NextPage => Url.Link("GetTopics", new
            {
                pageNumber = directorSearchParameters.PageNumber + 1,
                pageSize = directorSearchParameters.PageSize,
            }),
            _ => Url.Link("GetTopics", new
            {
                pageNumber = directorSearchParameters.PageNumber,
                pageSize = directorSearchParameters.PageSize,
            })
        };
    }
}