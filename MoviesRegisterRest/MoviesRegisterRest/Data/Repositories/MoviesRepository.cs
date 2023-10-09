using Microsoft.EntityFrameworkCore;
using MoviesRegisterRest.Data.Entities;

namespace MoviesRegisterRest.Data.Repositories;

public interface IMoviesRepository
{
    Task<Movie?> GetAsync(int movieId);
    Task<IReadOnlyList<Movie?>> GetManyAsync();
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

    public async Task<Movie?> GetAsync(int movieId)
    {
        return await _webDbContext.Movies.FirstOrDefaultAsync(o => o.Id == movieId);
    }

    public async Task<IReadOnlyList<Movie?>> GetManyAsync()
    {
        return await _webDbContext.Movies.ToListAsync();
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

