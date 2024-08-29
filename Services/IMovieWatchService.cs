using digitalEpisodeAppApi.Models;
namespace digitalEpisodeAppApi.Services;



public interface IMovieWatchService
{
    public Task AddToWatchListMovieAsync(int userId, int moviesId);
  public  Task RemoveFromWatchMovieListAsync(int userId, int moviesId);
    public Task<IEnumerable<MoviesModel>> GetWatchListMoviesAsync(int userId);
}