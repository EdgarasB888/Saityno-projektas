using Microsoft.EntityFrameworkCore;
using MoviesRegisterRest.Data.Dtos.Directors;
using MoviesRegisterRest.Data.Entities;
using MoviesRegisterRest.Helpers;

namespace MoviesRegisterRest.Data.Repositories;

public interface IDirectorsRepository
{
    Task<Director?> GetAsync(int DirectorId);
    Task<IReadOnlyList<Director?>> GetManyAsync();
    Task<PagedList<Director?>> GetManyAsync(DirectorSearchParameters searchParameters);
    Task CreateAsync(Director Director);
    Task UpdateAsync(Director Director);
    Task DeleteAsync(Director Director);
}

public class DirectorsRepository : IDirectorsRepository
{
    private readonly WebDbContext _webDbContext;
    
    public DirectorsRepository(WebDbContext webDbContext)
    {
        _webDbContext = webDbContext;
    }

    public async Task<Director?> GetAsync(int DirectorId)
    {
        return await _webDbContext.Directors.FirstOrDefaultAsync(o => o.Id == DirectorId);
    }
    
    public async Task<IReadOnlyList<Director?>> GetManyAsync()
    {
        return await _webDbContext.Directors.ToListAsync();
    }
    
    public async Task<PagedList<Director?>> GetManyAsync(DirectorSearchParameters searchParameters)
    {
        var queryable = _webDbContext.Directors.AsQueryable().OrderBy(o => o.Id);

        return await PagedList<Director>.CreateAsync(queryable, searchParameters.PageNumber, searchParameters.PageSize);
    }
    
    public async Task CreateAsync(Director Director)
    {
        _webDbContext.Directors.Add(Director);
        await _webDbContext.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(Director Director)
    {
        _webDbContext.Directors.Update(Director);
        await _webDbContext.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Director Director)
    {
        _webDbContext.Directors.Remove(Director);
        await _webDbContext.SaveChangesAsync();
    }
}