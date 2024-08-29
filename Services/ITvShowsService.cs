using digitalEpisodeAppApi.Dto;
using digitalEpisodeAppApi.Models;

namespace digitalEpisodeAppApi.Services;

public interface ITvShowsService
{
    Task<List<TvShowsModel>> GetAllShows();
    Task<TvShowsModel?>? GetSingleShow(int id);
    //Task<List<TvShowsModel>>  AddShows(TvShowsModel shows);
    Task<List<TvShowsModel>?>?  UpdateShows(int id,TvShowsModel request);
    Task<List<TvShowsModel>?>? DeleteShows(int id);
    Task<TvShowsModel> AddShows (TvShowsRequestDto tvShowsRequestDto);
}