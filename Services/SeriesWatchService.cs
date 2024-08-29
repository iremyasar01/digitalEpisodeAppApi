using digitalEpisodeAppApi.Models;

using digitalEpisodeAppApi.Data;

namespace digitalEpisodeAppApi.Services;

public class SeriesWatchService : ISeriesWatchService
{
    
    
        private readonly TvSeriesDbContext _context;

        public SeriesWatchService(TvSeriesDbContext context)
        {
            _context = context;
        }

        public async Task AddToWatchListSeriesAsync(int userId, int seriesId)
        {
            var SerieswatchList = new SeriesWatchModel { UserId = userId, SeriesId = seriesId };
            _context.SeriesWatch.Add(SerieswatchList);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromWatchListSeriesAsync(int userId, int seriesId)
        {
            var SerieswatchList = await _context.SeriesWatch
                .FirstOrDefaultAsync(w => w.UserId == userId && w.SeriesId == seriesId);

            if (SerieswatchList != null)
            {
                _context.SeriesWatch.Remove(SerieswatchList);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TvShowsModel>> GetWatchListShowsAsync(int userId)
        {
            return await _context.SeriesWatch
                .Where(w => w.UserId == userId)
                .Select(w => w.tvShows)
                .ToListAsync();
        }
    }

