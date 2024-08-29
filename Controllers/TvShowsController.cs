
using digitalEpisodeAppApi.Dto;
using digitalEpisodeAppApi.Models;
using digitalEpisodeAppApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace digitalEpisodeAppApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TvShowsController : ControllerBase
{

    private readonly ITvShowsService _tvShowsService;

    public TvShowsController(ITvShowsService tvShowsService)
    {
        _tvShowsService = tvShowsService;
    }

    [HttpGet, Route("[action]")]
    public async Task<ActionResult<List<TvShowsModel>>> GetAllShows()
    {
        return await _tvShowsService.GetAllShows();

    }

    //getirme
    [HttpGet, Route("[action]")]

    public async Task<ActionResult<List<TvShowsModel>>> GetSingleShow(int id)


    {
        var result = await _tvShowsService.GetSingleShow(id);
        if (result is null)
            return NotFound("hero not found");
        return Ok(result);


    }
    /*
    //ekleme
    [HttpPost, Route("[action]")]

    public async Task<ActionResult<List<TvShowsModel>>> AddShows(TvShowsModel shows)
    {

        var result =await _tvShowsService.AddShows(shows);
        return Ok(result);

    }
    */
    //güncelleme
    [HttpPut, Route("[action]")]
    //buraya da parametre verebiliriz.

    public async Task<ActionResult<List<TvShowsModel>>> UpdateShows(int id, TvShowsModel requestShows)
        //buradan da parametre alabiliriz.
    {
        var result = await _tvShowsService.UpdateShows(id, requestShows);
        if (result is null)
            return NotFound("hero not found");
        return Ok(result);



    }

    //silme metodu
    [HttpDelete, Route("[action]")]


    public async Task<ActionResult<List<TvShowsModel>>> DeleteShows(int id)

    {
        var result = await _tvShowsService.DeleteShows(id)!;
        if (result is null)
            return NotFound("hero not found");

        return Ok(result);
    }
    //ekleme
    [HttpPost,Route("[action]")]

    public async Task<ActionResult<TvShowsModel>> AddShows (TvShowsRequestDto tvShowsRequestDto )
    {

        var result =await _tvShowsService.AddShows(tvShowsRequestDto);
        return Ok(result);

    }

}
