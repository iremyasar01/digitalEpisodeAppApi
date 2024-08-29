using digitalEpisodeAppApi.Models;

namespace digitalEpisodeAppApi.Services;

public interface IEpisodeService
{
       
    Task<List<EpisodeModel>> GetAllEpisodes();
    Task<EpisodeModel?>? GetSingleEpisode(int id);
    Task<List<EpisodeModel>> AddEpisode(EpisodeModel episodes);
    Task<List<EpisodeModel>?>?UpdateEpisode(int id,EpisodeModel requestEpisode);
    Task<List<EpisodeModel>?>? DeleteEpisode(int id);
}