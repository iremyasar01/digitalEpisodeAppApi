namespace digitalEpisodeAppApi.Dto;

public class UserRegisterRequestDto
{
 
    public string Email { get; set; }= String.Empty;
    public string Username { get; set; }= String.Empty;
    public string name { get; set; }= String.Empty;
    public string surname { get; set; }= String.Empty;
    public double phoneNumber { get; set; }
    public string password { get; set; }= String.Empty;
    public string passwordAgain { get; set; }= String.Empty;
}