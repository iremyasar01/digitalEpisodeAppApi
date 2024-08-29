using digitalEpisodeAppApi.Services;
using digitalEpisodeAppApi.Models;
using digitalEpisodeAppApi.Data;

public class FavMoviesService : IFavMoviesService
{
    private readonly TvSeriesDbContext _FMcontext;

    public FavMoviesService(TvSeriesDbContext FMcontext)
    {
        _FMcontext = FMcontext;
    }

    public async Task AddFavoriteMovieAsync(int userId, int moviesId)
    {
        var favMovie = new FavMoviesModel { UserId = userId, MovieId = moviesId };
        _FMcontext.FavMovies.Add(favMovie);
        await _FMcontext.SaveChangesAsync();
    }

    public async Task RemoveFavoriteMovieAsync(int userId, int moviesId)
    {
        var favMovie = await _FMcontext.FavMovies
            .FirstOrDefaultAsync(f => f.UserId == userId && f.MovieId == moviesId);

        if (favMovie != null)
        {
            _FMcontext.FavMovies.Remove(favMovie);
            await _FMcontext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<MoviesModel>> GetFavoritesMoviesAsync(int userId)
    {
        return await _FMcontext.FavMovies
            .Where(f => f.UserId == userId)
            .Select(f => f.Movies)
            .ToListAsync();
    }
}