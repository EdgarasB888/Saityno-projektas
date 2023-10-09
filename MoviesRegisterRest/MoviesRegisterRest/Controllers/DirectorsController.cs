using Microsoft.AspNetCore.Mvc;
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
    [HttpGet]
    public async Task<IEnumerable<DirectorDto>> GetMany()
    {
        var Directors = await _DirectorsRepository.GetManyAsync();

        return Directors.Select(o => new DirectorDto(o.Id, o.FullName, o.Gender, o.Country, o.BirthDate, o.RegisterDate, o.Biography, o.SpokenLanguages, o.Address, o.Phone, o.Email, o.IsAvailable));
    }

    // api/Directors/{DirectorId}
    [HttpGet]
    [Route("{DirectorId}")]
    public async Task<ActionResult<DirectorDto>> Get(int DirectorId)
    {
        var Director = await _DirectorsRepository.GetAsync(DirectorId);

        if (Director == null)
        {
            return NotFound();
        }
        
        return new DirectorDto(Director.Id, Director.FullName, Director.Gender, Director.Country, Director.BirthDate, Director.RegisterDate, Director.Biography, Director.SpokenLanguages, Director.Address, Director.Phone, Director.Email, Director.IsAvailable);
    }
    
    // api/Directors
    [HttpPost]
    public async Task<ActionResult<DirectorDto>> Create(CreateDirectorDto createDirectorDto)
    {
        var Director = new Director
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

        await _DirectorsRepository.CreateAsync(Director);
        
        //201
        return Created("", new DirectorDto(Director.Id, Director.FullName, Director.Gender, Director.Country, Director.BirthDate, Director.RegisterDate, Director.Biography, Director.SpokenLanguages, Director.Address, Director.Phone, Director.Email, Director.IsAvailable));
        //return CreatedAtAction("GetDirector", new { DirectorId = Director.Id}, new DirectorDto(Director.FullName, Director.Gender, Director.Role, Director.Country, Director.BirthDate, Director.RegisterDate, Director.Biography, Director.SpokenLanguages, Director.Address, Director.Phone, Director.Email, Director.IsAvailable));
    }
    
    // api/Directors/{DirectorId}
    [HttpPut]
    [Route("{DirectorId}")]
    public async Task<ActionResult<DirectorDto>> Update(int DirectorId, UpdateDirectorDto updateDirectorDto)
    {
        var Director = await _DirectorsRepository.GetAsync(DirectorId);

        if (Director == null)
        {
            return NotFound();
        }

        Director.FullName = updateDirectorDto.FullName;
        Director.Gender = updateDirectorDto.Gender;
        Director.Country = updateDirectorDto.Country;
        Director.BirthDate = updateDirectorDto.BirthDate;
        Director.Biography = updateDirectorDto.Biography;
        Director.SpokenLanguages = updateDirectorDto.SpokenLanguages;
        Director.Address = updateDirectorDto.Address;
        Director.Phone = updateDirectorDto.Phone;
        Director.Email = updateDirectorDto.Email;
        Director.IsAvailable = updateDirectorDto.IsAvailable;

        await _DirectorsRepository.UpdateAsync(Director);

        return Ok(new DirectorDto(Director.Id, Director.FullName, Director.Gender, Director.Country, Director.BirthDate, Director.RegisterDate, Director.Biography, Director.SpokenLanguages, Director.Address, Director.Phone, Director.Email, Director.IsAvailable));
    }
    
    // api/Directors/{DirectorId}
    [HttpDelete]
    [Route("{DirectorId}")]
    public async Task<ActionResult> Remove(int DirectorId)
    {
        var Director = await _DirectorsRepository.GetAsync(DirectorId);

        if (Director == null)
        {
            return NotFound();
        }

        await _DirectorsRepository.DeleteAsync(Director);
        
        //204
        return NoContent();
    }
}