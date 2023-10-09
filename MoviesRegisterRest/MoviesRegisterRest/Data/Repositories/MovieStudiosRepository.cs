using Microsoft.EntityFrameworkCore;
using MoviesRegisterRest.Data.Entities;

namespace MoviesRegisterRest.Data.Repositories;

public interface IMovieStudiosRepository
{
    Task<MovieStudio?> GetAsync(int movieStudioId);
    Task<IReadOnlyList<MovieStudio?>> GetManyAsync();
    Task CreateAsync(MovieStudio movie);
    Task UpdateAsync(MovieStudio movie);
    Task DeleteAsync(MovieStudio movie);
}

public class MovieStudiosRepository : IMovieStudiosRepository
{
    private readonly WebDbContext _webDbContext;

    public MovieStudiosRepository(WebDbContext webDbContext)
    {
        _webDbContext = webDbContext;
    }

    public async Task<MovieStudio?> GetAsync(int movieStudioId)
    {
        return await _webDbContext.MovieStudios.FirstOrDefaultAsync(o => o.Id == movieStudioId);
    }

    public async Task<IReadOnlyList<MovieStudio?>> GetManyAsync()
    {
        return await _webDbContext.MovieStudios.ToListAsync();
    }

    public async Task CreateAsync(MovieStudio movieStudio)
    {
        _webDbContext.MovieStudios.Add(movieStudio);
        await _webDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(MovieStudio movieStudio)
    {
        _webDbContext.MovieStudios.Update(movieStudio);
        await _webDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(MovieStudio movieStudio)
    {
        _webDbContext.MovieStudios.Remove(movieStudio);
        await _webDbContext.SaveChangesAsync();
    }
}
