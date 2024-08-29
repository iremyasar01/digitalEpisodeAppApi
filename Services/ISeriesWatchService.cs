using digitalEpisodeAppApi.Models;

namespace digitalEpisodeAppApi.Services;

public interface ISeriesWatchService
{
    Task AddToWatchListSeriesAsync(int userId, int seriesId);
    Task RemoveFromWatchListSeriesAsync(int userId, int seriesId);
    Task<IEnumerable<TvShowsModel>> GetWatchListShowsAsync(int userId);
}