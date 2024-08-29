using digitalEpisodeAppApi.Dto;
using digitalEpisodeAppApi.Models;
using digitalEpisodeAppApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace digitalEpisodeAppApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet,Route("[action]")]
    public async Task<ActionResult<List<UsersModel>>> GetAllUsers()
    {
        return await _userService.GetAllUsers();

    }

    //getirme
    [HttpGet, Route("[action]")]

    public async Task<ActionResult<List<TvShowsModel>>> GetSingleUser(int id)


    {
        var result = await _userService.GetSingleUser(id);
        if (result is null)
            return NotFound("hero not found");
        return Ok(result);


    }
    /*
    //ekleme
    [HttpPost,Route("[action]")]

    public async Task<ActionResult<List<UsersModel>>> AddUser(UsersModel user)
    {

        var result =await _userService.AddUser(user);
        return Ok(result);

    }
    */
    //güncelleme
    [HttpPut,Route("[action]")]
    //buraya da parametre verebiliriz.

    public async Task<ActionResult<List<UsersModel>>> UpdateUser(int id, UsersModel requestUser)
        //buradan da parametre alabiliriz.
    {
        var result = await _userService.UpdateUser(id, requestUser);
        if (result is null)
            return NotFound("hero not found");
        return Ok(result);



    }

    //silme metodu
    [HttpDelete,Route("[action]")]


    public async Task<ActionResult<List<UsersModel>>> DeleteUser(int id)

    {
        var result = await _userService.DeleteUser(id);
        if (result is null)
            return NotFound("user not found");

        return Ok(result);
    }
    [HttpPost, Route("[action]")]
    public async Task<ActionResult<UsersModel?>> LoginUser(UserLoginRequestDto userLoginRequestDto)
    {  var result = await _userService.LoginUser(userLoginRequestDto);
        if (result is null)
            return NotFound("users not found");
        return Ok(result);

    
        
    }
    //ekleme
    [HttpPost,Route("[action]")]

    public async Task<ActionResult<UsersModel>> RegisterUser(UserRegisterRequestDto userRegisterRequestDto )
    {

        var result =await _userService.RegisterUser(userRegisterRequestDto);
        return Ok(result);

    }
    
}