namespace digitalEpisodeAppApi.Models;

public class MovieWatchModel
{
    public int MovieWatchId;
    public int UserId { get; set; }
    public UsersModel User { get; set; }

    public int MovieId{ get; set; }
    public MoviesModel Movies { get; set; }
}