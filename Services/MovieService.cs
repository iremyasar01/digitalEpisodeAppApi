using digitalEpisodeAppApi.Models;

using digitalEpisodeAppApi.Data;
using digitalEpisodeAppApi.Dto;

namespace digitalEpisodeAppApi.Services;

public class MovieService : IMovieService
{
      private readonly TvSeriesDbContext _Mcontext;
    
            public MovieService(TvSeriesDbContext Mcontext)
            {
                _Mcontext = Mcontext;
    
            }
            public async Task<List<MoviesModel>> GetAllMovies()
            {
                var movies = await _Mcontext.Movies.ToListAsync();
                return movies;
            }
    
            public async Task<MoviesModel?>? GetSingleMovie(int id)
            {
              
                var movies = await _Mcontext.Movies.FindAsync(id);
                if (movies is null)
                    return null;
                return movies;
            }
           /*
            public async Task<List<MoviesModel>> AddMovie(MoviesModel movies)
            {
                _Mcontext.Movies.Add(movies);
                await _Mcontext.SaveChangesAsync();
                return await _Mcontext.Movies.ToListAsync();
            }
    */
            public async Task<List<MoviesModel>?>? UpdateMovie(int id, MoviesModel requestMovie)
            {
                var movie = await _Mcontext.Movies.FindAsync(id);
                if (movie is null)
                    return null;
                movie.MovieId = requestMovie.MovieId;
                movie.MovieName = requestMovie.MovieName;
                movie.posterPath = requestMovie.posterPath;
                movie.movieOverview= requestMovie.movieOverview;
                movie.movieCountry = requestMovie.movieCountry;
                movie.Genre = requestMovie.Genre;
                
                //değişiklikleri kaydetmemiz gerekiyor.
                await _Mcontext.SaveChangesAsync();
                      
                return await _Mcontext.Movies.ToListAsync();
            }
    
            public async Task<List<MoviesModel>?>? DeleteMovie(int id)
            {
                var movie = await _Mcontext.Movies.FindAsync(id);
                if (movie is null)
                    return null;
                _Mcontext.Movies.Remove(movie);
                await _Mcontext.SaveChangesAsync();
    
                return await _Mcontext.Movies.ToListAsync();
            }
            public async Task<MoviesModel> AddMovie (MoviesRequestDto moviesRequestDto)
            {
                MoviesModel moviesModel = new()
                { MovieName = moviesRequestDto.MovieName,
                    posterPath = moviesRequestDto.posterPath,
                    movieOverview = moviesRequestDto.movieOverview,
                    movieCountry = moviesRequestDto.movieCountry,
                    vote = moviesRequestDto.vote,
                    Genre = moviesRequestDto.Genre,
                };
                _Mcontext.Movies.Add(moviesModel);
                await _Mcontext.SaveChangesAsync();
                return moviesModel;
            }
}