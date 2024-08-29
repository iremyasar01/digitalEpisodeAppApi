using digitalEpisodeAppApi.Dto;
using digitalEpisodeAppApi.Models;
using digitalEpisodeAppApi.Services;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace digitalEpisodeAppApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class MoviesController : ControllerBase
{

    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet, Route("[action]")]
    public async Task<ActionResult<List<MoviesModel>>> GetAllMovies()
    {
        return await _movieService.GetAllMovies();

    }

    //getirme
    [HttpGet, Route("[action]")]

    public async Task<ActionResult<List<MoviesModel>>> GetSingleMovie(int id)


    {
        var result = await _movieService.GetSingleMovie(id);
        if (result is null)
            return NotFound("hero not found");
        return Ok(result);


    }
/*
    //ekleme
    [HttpPost, Route("[action]")]

    public async Task<ActionResult<List<MoviesModel>>> AddMovie(MoviesModel movies)
    {

        var result = await _movieService.AddMovie(movies);
        return Ok(result);

    }

*/
    //güncelleme
    [HttpPut, Route("[action]")]
    //buraya da parametre verebiliriz.

    public async Task<ActionResult<List<MoviesModel>>> UpdateMovie(int id, MoviesModel requestMovies)
        //buradan da parametre alabiliriz.
    {
        var result = await _movieService.UpdateMovie(id, requestMovies);
        if (result is null)
            return NotFound("hero not found");
        return Ok(result);



    }

    //silme metodu
    [HttpDelete, Route("[action]")]


    public async Task<ActionResult<List<MoviesModel>>> DeleteMovie(int id)

    {
        var result = await _movieService.DeleteMovie(id)!;
        if (result is null)
            return NotFound("hero not found");

        return Ok(result);
    }
    //ekleme
    [HttpPost,Route("[action]")]

    public async Task<ActionResult<MoviesModel>> AddMovie (MoviesRequestDto moviesRequestDto )
    {

        var result =await _movieService.AddMovie(moviesRequestDto);
        return Ok(result);

    }
}