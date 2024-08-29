

using digitalEpisodeAppApi.Models;

namespace digitalEpisodeAppApi.Services;
public interface IFavService
{
        Task AddToFavListSeriesAsync(int userId, int seriesId);
        Task RemoveFromFavSeriesListAsync(int userId, int seriesId);
        Task<IEnumerable<TvShowsModel>> GetFavSeriesListAsync(int userId);
    

}