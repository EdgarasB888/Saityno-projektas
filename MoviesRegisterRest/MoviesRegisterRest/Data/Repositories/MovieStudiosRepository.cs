using Microsoft.EntityFrameworkCore;
using MoviesRegisterRest.Data.Entities;

namespace MoviesRegisterRest.Data.Repositories;

public interface IMovieStudiosRepository
{
    Task<MovieStudio?> GetAsync(int directorId, int movieStudioId);
    Task<IReadOnlyList<MovieStudio?>> GetManyAsync(int directorId);
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

    public async Task<MovieStudio?> GetAsync(int directorId, int movieStudioId)
    {
        var director = _webDbContext.Directors.FirstOrDefault(o => o.Id == directorId);
        if (director == null)
        {
            return null;
        }
        return await _webDbContext.MovieStudios.Include(o => o.Director).FirstOrDefaultAsync(o => o.Id == movieStudioId && o.Director.Id == directorId);
    }

    public async Task<IReadOnlyList<MovieStudio?>> GetManyAsync(int directorId)
    {
        return await _webDbContext.MovieStudios.Include(o => o.Director).Where(o => o.Director.Id == directorId).ToListAsync();
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
