using digitalEpisodeAppApi.Models;
using digitalEpisodeAppApi.Data;
using digitalEpisodeAppApi.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

//using Microsoft.AspNetCore.Http.HttpResults;

namespace digitalEpisodeAppApi.Services;

public class UserService : IUserService
{
    private readonly TvSeriesDbContext _Ucontext;

    public UserService(TvSeriesDbContext Ucontext)
    {
        _Ucontext = Ucontext;

    }

    public async Task<List<UsersModel>> GetAllUsers()
    {
        var user = await _Ucontext.Users.ToListAsync();
        return user;
    }

    public async Task<UsersModel?>? GetSingleUser(int id)
    {

        var user = await _Ucontext.Users.FindAsync(id);
        if (user is null)
            return null;
        return user;
    }
/*
    public async Task<List<UsersModel>> AddUser(UsersModel user)
    {
        _Ucontext.Users.Add(user);
        await _Ucontext.SaveChangesAsync();
        return await _Ucontext.Users.ToListAsync();
    }
*/
    public async Task<List<UsersModel>?>? UpdateUser(int id, UsersModel requestUser)
    {
        var user = await _Ucontext.Users.FindAsync(id);
        if (user is null)
            return null;
        user.UserId = requestUser.UserId;
        user.Username = requestUser.Username;
        user.surname = requestUser.surname;
        user.name = requestUser.name;
        user.Email = requestUser.Email;
        user.password = requestUser.password;
        user.passwordAgain = requestUser.passwordAgain;

        //değişiklikleri kaydetmemiz gerekiyor.
        await _Ucontext.SaveChangesAsync();

        return await _Ucontext.Users.ToListAsync();
    }

    public async Task<List<UsersModel>?>? DeleteUser(int id)
    {
        var user = await _Ucontext.Users.FindAsync(id);
        if (user is null)
            return null;
        _Ucontext.Users.Remove(user);
        await _Ucontext.SaveChangesAsync();

        return await _Ucontext.Users.ToListAsync();
    }

    public async Task<UsersModel?> LoginUser(UserLoginRequestDto userLoginRequestDto)
    {
        var user = await _Ucontext.Users.FirstOrDefaultAsync(x => x.Email == userLoginRequestDto.Email);
        if (user == null || user.password != userLoginRequestDto.password)
        {
            return null;
        }

        return user;
    }

    public async Task<UsersModel> RegisterUser(UserRegisterRequestDto userRegisterRequestDto)
    {
        UsersModel usersModel = new()
        { Email = userRegisterRequestDto.Email,
            Username = userRegisterRequestDto.Username,
            name =userRegisterRequestDto.name,
            surname= userRegisterRequestDto.surname,
            phoneNumber = userRegisterRequestDto.phoneNumber,
                password=userRegisterRequestDto.password,
                passwordAgain =userRegisterRequestDto.passwordAgain,
        };
        _Ucontext.Users.Add(usersModel);
        await _Ucontext.SaveChangesAsync();
        return usersModel;
    }

}
        
       