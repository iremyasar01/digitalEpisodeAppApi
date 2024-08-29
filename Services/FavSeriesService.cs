using digitalEpisodeAppApi.Models;

using digitalEpisodeAppApi.Data;

namespace digitalEpisodeAppApi.Services;

public class FavSeriesService : IFavService
{
    
        private readonly TvSeriesDbContext _context;

        public FavSeriesService(TvSeriesDbContext context)
        {
            _context = context;
        }

        public async Task AddToFavListSeriesAsync(int userId, int seriesId)
        {
            var favSeries = new FavSeriesModel { UserId = userId, SeriesId  = seriesId };
            _context.FavSeries.Add(favSeries);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromFavSeriesListAsync(int userId, int tvShowId)
        {
            var watchList = await _context.FavSeries
                .FirstOrDefaultAsync(w => w.UserId == userId && w.SeriesId == tvShowId);

            if (watchList != null)
            {
                _context.FavSeries.Remove(watchList);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TvShowsModel>> GetFavSeriesListAsync(int userId)
        {
            return await _context.FavSeries
                .Where(w => w.UserId == userId)
                .Select(w => w.TvShows)
                .ToListAsync();
        }
    }

    
