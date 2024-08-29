using digitalEpisodeAppApi.Dto;
using digitalEpisodeAppApi.Models;

namespace digitalEpisodeAppApi.Services;

public interface IUserService
{
    Task<List<UsersModel>> GetAllUsers();
    Task<UsersModel?> GetSingleUser(int id);
    //Task<List<UsersModel>>  AddUser(UsersModel user);
    Task<List<UsersModel>?> UpdateUser(int id,UsersModel requestUser);
    Task<List<UsersModel>?> DeleteUser(int id);
    Task<UsersModel?> LoginUser (UserLoginRequestDto userLoginRequestDto);
    Task<UsersModel> RegisterUser(UserRegisterRequestDto userRegisterRequestDto);
    
}
