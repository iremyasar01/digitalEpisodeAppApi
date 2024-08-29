namespace digitalEpisodeAppApi.Dto;

public class UserLoginRequestDto
{
    public String Email { get; set; } = String.Empty;
    public String password { get; set; } =String.Empty;
    public String passwordAgain { get; set; }=String.Empty;
}