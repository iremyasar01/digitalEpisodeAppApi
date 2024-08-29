using digitalEpisodeAppApi.Models;
using digitalEpisodeAppApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace digitalEpisodeAppApi.Controllers;


[Route("api/[controller]")]
[ApiController]


public class MovieWatchController : ControllerBase
{
    private readonly IMovieWatchService _MovieWatchService;

    public MovieWatchController(IMovieWatchService MovieWatchService)
    {
        _MovieWatchService = MovieWatchService;
    }

    [HttpPost, Route("[action]")]
    public async Task<IActionResult> AddToWatchListMovieAsync(int userId, int moviesId)
    {
        await _MovieWatchService.AddToWatchListMovieAsync(userId, moviesId);
        return Ok();
    }

    [HttpDelete, Route("[action]")]
    public async Task<IActionResult> RemoveFromWatchMovieListAsync(int userId, int moviesId)
    {
        await _MovieWatchService.RemoveFromWatchMovieListAsync(userId, moviesId);
        return Ok();
    }

    [HttpGet, Route("[action]")]
    public async Task<ActionResult<IEnumerable<MoviesModel>>> GetWatchListMoviesAsync(int userId)
    {
        var moviesWatchList = await _MovieWatchService.GetWatchListMoviesAsync(userId);
        return Ok(moviesWatchList);
    }
    
}