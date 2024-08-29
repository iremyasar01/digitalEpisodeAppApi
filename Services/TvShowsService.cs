
using digitalEpisodeAppApi.Data;
using digitalEpisodeAppApi.Dto;
using digitalEpisodeAppApi.Models;
using digitalEpisodeAppApi.Services;

public class TvShowsService : ITvShowsService
{

        private readonly TvSeriesDbContext _context;

        public TvShowsService(TvSeriesDbContext context)
        {
            _context = context;

        }
        public async Task<List<TvShowsModel>> GetAllShows()
        {
            var shows = await _context.TvShows.ToListAsync();
            return shows;
        }

        public async Task<TvShowsModel?>? GetSingleShow(int id)
        {
          
            var shows = await _context.TvShows.FindAsync(id);
            if (shows is null)
                return null;
            return shows;
        }
/*
        public async Task<List<TvShowsModel>> AddShows(TvShowsModel shows)
        {
            _context.TvShows.Add(shows);
            await _context.SaveChangesAsync();
            return await _context.TvShows.ToListAsync();
        }
        */

        public async Task<List<TvShowsModel>?>? UpdateShows(int id, TvShowsModel requestShows)
        {
            var shows = await _context.TvShows.FindAsync(id);
            if (shows is null)
                return null;
            shows.SeriesId = requestShows.SeriesId;
            shows.SeriesName = requestShows.SeriesName;
            shows.SeriesPosterPath = requestShows.SeriesPosterPath;
            shows.SeriesOverview = requestShows.SeriesOverview;
            shows.SeriesCountry= requestShows.SeriesCountry;
            shows.SeriesVote = requestShows.SeriesVote;
            shows.Genre = requestShows.Genre;
            
            //değişiklikleri kaydetmemiz gerekiyor.
            await _context.SaveChangesAsync();
                  
            return await _context.TvShows.ToListAsync();
        }

        public async Task<List<TvShowsModel>?>? DeleteShows(int id)
        {
            var shows = await _context.TvShows.FindAsync(id);
            if (shows is null)
                return null;
            _context.TvShows.Remove(shows);
            await _context.SaveChangesAsync();

            return await _context.TvShows.ToListAsync();
        }
        public async Task<TvShowsModel> AddShows (TvShowsRequestDto tvShowsRequestDto)
        {
            TvShowsModel tvModel = new()
            {SeriesName = tvShowsRequestDto.SeriesName,
                SeriesPosterPath = tvShowsRequestDto.SeriesPosterPath,
                SeriesOverview = tvShowsRequestDto.SeriesOverview,
                SeriesCountry = tvShowsRequestDto.SeriesCountry,
                SeriesVote = tvShowsRequestDto.SeriesVote,
                Genre = tvShowsRequestDto.Genre,
            };
            _context.TvShows.Add(tvModel);
            await _context.SaveChangesAsync();
            return tvModel;
        }
}
    

