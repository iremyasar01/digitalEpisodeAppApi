using digitalEpisodeAppApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace digitalEpisodeAppApi.Controllers;
using digitalEpisodeAppApi.Services;

[Route("api/[controller]")]
[ApiController]


public class SeriesWatchController : ControllerBase
{
    private readonly ISeriesWatchService _serieswatchListService;

        public SeriesWatchController(ISeriesWatchService serieswatchListService)
        {
            _serieswatchListService = serieswatchListService;
        }

        [HttpPost, Route("[action]")]
        public async Task<IActionResult> AddToWatchListSeriesAsync(int userId, int seriesId)
        {
            await _serieswatchListService.AddToWatchListSeriesAsync(userId, seriesId);
            return Ok();
        }

        [HttpDelete, Route("[action]")]
        public async Task<IActionResult> RemoveFromWatchListSeriesAsync(int userId, int seriesId)
        {
            await _serieswatchListService.RemoveFromWatchListSeriesAsync(userId, seriesId);
            return Ok();
        }

        [HttpGet, Route("[action]")]
        public async Task<ActionResult<IEnumerable<TvShowsModel>>> GetSeriesWatchList(int userId)
        {
            var seriesWatchList = await _serieswatchListService.GetWatchListShowsAsync(userId);
            return Ok(seriesWatchList);
        }
    }

    
