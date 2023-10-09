using Microsoft.EntityFrameworkCore;
using MoviesRegisterRest.Data.Entities;

namespace MoviesRegisterRest.Data.Repositories;

public interface IMoviesRepository
{
    Task<Movie?> GetAsync(int directorId, int movieStudioInt, int movieId);
    Task<IReadOnlyList<Movie?>> GetManyAsync(int directorId, int movieStudioId);
    Task CreateAsync(Movie movie);
    Task UpdateAsync(Movie movie);
    Task DeleteAsync(Movie movie);
}

public class MoviesRepository : IMoviesRepository
{
    private readonly WebDbContext _webDbContext;

    public MoviesRepository(WebDbContext webDbContext)
    {
        _webDbContext = webDbContext;
    }

    public async Task<Movie?> GetAsync(int directorId, int movieStudioId, int movieId)
    {
        var director = _webDbContext.Directors.FirstOrDefault(o => o.Id == directorId);
        if (director == null)
        {
            return null;
        }
        
        var movieStudio = _webDbContext.MovieStudios.Include(o => o.Director).FirstOrDefault(o => o.Id == movieStudioId && o.Director.Id == directorId);
        if (movieStudio == null)
        {
            return null;
        }

        return await _webDbContext.Movies.Include(o => o.MovieStudio).FirstOrDefaultAsync(o => o.Id == movieId);
    }

    public async Task<IReadOnlyList<Movie?>> GetManyAsync(int directorId, int movieStudioId)
    {
        return await _webDbContext.Movies.Include(o => o.MovieStudio)
            .Where(o => o.MovieStudio.Id == movieStudioId && o.MovieStudio.Director.Id == directorId).ToListAsync();
    }

    public async Task CreateAsync(Movie movie)
    {
        _webDbContext.Movies.Add(movie);
        await _webDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Movie movie)
    {
        _webDbContext.Movies.Update(movie);
        await _webDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Movie movie)
    {
        _webDbContext.Movies.Remove(movie);
        await _webDbContext.SaveChangesAsync();
    }
}

