using digitalEpisodeAppApi.Models;

using digitalEpisodeAppApi.Data;

namespace digitalEpisodeAppApi.Services;


public class MovieWatchService :IMovieWatchService
{
    private readonly TvSeriesDbContext _context;

    public MovieWatchService(TvSeriesDbContext context)
    {
        _context = context;
    }

    public async Task AddToWatchListMovieAsync(int userId, int moviesId)
    {
        var MovieswatchList = new MovieWatchModel { UserId = userId, MovieId = moviesId };
        _context.MoviesWatch.Add(MovieswatchList);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveFromWatchMovieListAsync(int userId, int moviesId)
    {
        var MovieswatchList = await _context.MoviesWatch
            .FirstOrDefaultAsync(w => w.UserId == userId && w.MovieWatchId== moviesId);

        if (MovieswatchList != null)
        {
            _context.MoviesWatch.Remove(MovieswatchList);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<MoviesModel>> GetWatchListMoviesAsync(int userId)
    {
       return await _context.MoviesWatch
            .Where(w => w.UserId == userId)
            .Select(w => w.Movies)
            .ToListAsync();
    }
}