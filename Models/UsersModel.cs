namespace digitalEpisodeAppApi.Models;

public class UsersModel
{
    public UsersModel()
    {
        FavSeries = new List<FavSeriesModel>();
        FavMovies = new List<FavMoviesModel>();
        SeriesWatch = new List<SeriesWatchModel>(); 
        MovieWatch = new List<MovieWatchModel>();
        
    }
    public int UserId { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public double phoneNumber { get; set; }
    public string password { get; set; }
    public string passwordAgain { get; set; }
    
    public ICollection<FavMoviesModel> FavMovies { get; set; }
    public ICollection<FavSeriesModel> FavSeries { get; set; }
    
    public ICollection<SeriesWatchModel> SeriesWatch { get; set; }
    public ICollection<MovieWatchModel> MovieWatch { get; set; }
    
}