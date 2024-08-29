using digitalEpisodeAppApi.Models;
using digitalEpisodeAppApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace digitalEpisodeAppApi.Controllers;


[Route("api/[controller]")]
[ApiController]

public class FavMoviesController: ControllerBase
{
        private readonly IFavMoviesService _favoriteMovieService;

        public FavMoviesController(IFavMoviesService favoriteMovieService)
        {
            _favoriteMovieService = favoriteMovieService;
        }

        [HttpPost,Route("[action]")]
        public async Task<IActionResult> AddFavoriteMovieAsync(int userId, int moviesId)
        {
            await _favoriteMovieService.AddFavoriteMovieAsync(userId, moviesId);
            return Ok();
        }

        [HttpDelete, Route("[action]")]
        public async Task<IActionResult> RemoveFavoriteMovieAsync(int userId, int moviesId)
        {
            await _favoriteMovieService.RemoveFavoriteMovieAsync(userId, moviesId);
            return Ok();
        }

        [HttpGet, Route("[action]")]
        public async Task<ActionResult<IEnumerable<MoviesModel>>> GetFavoritesMoviesAsync(int userId)
        {
            var favorites = await _favoriteMovieService.GetFavoritesMoviesAsync(userId);
            return Ok(favorites);
        }
    }

