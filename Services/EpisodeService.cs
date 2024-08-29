namespace digitalEpisodeAppApi.Services;
using digitalEpisodeAppApi.Models;
using digitalEpisodeAppApi.Data;

public class EpisodeService : IEpisodeService
{
       private readonly TvSeriesDbContext _Econtext;
    
            public EpisodeService(TvSeriesDbContext Econtext)
            {
                _Econtext = Econtext;
    
            }
            public async Task<List<EpisodeModel>> GetAllEpisodes()
            {
                var episode = await _Econtext.Episodes.ToListAsync();
                return episode;
            }
    
            public async Task<EpisodeModel?>? GetSingleEpisode(int id)
            {
              
                var episode = await _Econtext.Episodes.FindAsync(id);
                if (episode is null)
                    return null;
                return episode;
            }
    
            public async Task<List<EpisodeModel>> AddEpisode(EpisodeModel episode)
            {
                _Econtext.Episodes.Add(episode);
                await _Econtext.SaveChangesAsync();
                return await _Econtext.Episodes.ToListAsync();
            }
    
            public async Task<List<EpisodeModel>?>? UpdateEpisode(int id, EpisodeModel requestEpisode)
            {
                var episode = await _Econtext.Episodes.FindAsync(id);
                if (episode is null)
                    return null;
                episode.EpisodeId = requestEpisode.EpisodeId;
                episode.EpisodeName = requestEpisode.EpisodeName;
                episode.EpisodeNumber = requestEpisode.EpisodeNumber;
                episode.EpisodeOverview= requestEpisode.EpisodeOverview;
                episode.vote = requestEpisode.vote;
         
                
                //değişiklikleri kaydetmemiz gerekiyor.
                await _Econtext.SaveChangesAsync();
                      
                return await _Econtext.Episodes.ToListAsync();
            }
    
            public async Task<List<EpisodeModel>?>? DeleteEpisode(int id)
            {
                var episode = await _Econtext.Episodes.FindAsync(id);
                if (episode is null)
                    return null;
                _Econtext.Episodes.Remove(episode);
                await _Econtext.SaveChangesAsync();
    
                return await _Econtext.Episodes.ToListAsync();
            }
}