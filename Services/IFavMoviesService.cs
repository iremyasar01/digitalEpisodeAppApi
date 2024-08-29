using digitalEpisodeAppApi.Models;

namespace digitalEpisodeAppApi.Services;

public interface IFavMoviesService 

{
        Task AddFavoriteMovieAsync(int userId, int moviesId);
        Task RemoveFavoriteMovieAsync(int userId, int moviesId);
        Task<IEnumerable<MoviesModel>> GetFavoritesMoviesAsync(int userId);
 
  
}