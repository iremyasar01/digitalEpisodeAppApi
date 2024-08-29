using digitalEpisodeAppApi.Models;
using digitalEpisodeAppApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace digitalEpisodeAppApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class FavSeriesController: ControllerBase
{
    
        private readonly IFavService _favoriteService;

        public FavSeriesController(IFavService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpPost, Route("[action]")]
        public async Task<IActionResult> AddToFavListSeriesAsync(int userId, int seriesId)
        {
            await _favoriteService.AddToFavListSeriesAsync(userId, seriesId);
            return Ok();
        }

        [HttpDelete, Route("[action]")]
        public async Task<IActionResult> RemoveFromFavSeriesListAsync(int userId, int seriesId)
        {
            await _favoriteService.RemoveFromFavSeriesListAsync(userId, seriesId);
            return Ok();
        }

        [HttpGet, Route("[action]")]
        public async Task<ActionResult<IEnumerable<TvShowsModel>>> GetFavorites(int userId)
        {
            var favorites = await _favoriteService.GetFavSeriesListAsync(userId);
            return Ok(favorites);
        }
    }

