using digitalEpisodeAppApi.Dto;
using digitalEpisodeAppApi.Models;

namespace digitalEpisodeAppApi.Services;

public interface IMovieService
{
    
    Task<List<MoviesModel>> GetAllMovies();
    Task<MoviesModel?>? GetSingleMovie(int id);
    //Task<List<MoviesModel>> AddMovie(MoviesModel movies);
    Task<List<MoviesModel>?>?UpdateMovie(int id,MoviesModel requestMovie);
    Task<List<MoviesModel>?>? DeleteMovie(int id);
    Task<MoviesModel> AddMovie(MoviesRequestDto moviesRequestDto);
    
}