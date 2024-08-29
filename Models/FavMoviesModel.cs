namespace digitalEpisodeAppApi.Models;

public class FavMoviesModel

{
    public int FavMoviesId { get; set; }
    public int UserId { get; set; }
    public UsersModel Users { get; set; }

    public int MovieId { get; set; }
    public MoviesModel Movies { get; set; }
}