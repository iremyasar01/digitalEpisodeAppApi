namespace digitalEpisodeAppApi.Models;

public class MoviesModel
{
    public MoviesModel()
    {
        FavMovies = new List<FavMoviesModel>();
        MovieWatch = new List<MovieWatchModel>();
    }
    public int MovieId { get; set; }
    public string MovieName { get; set; }
    
    public string posterPath { get; set; }
    public string movieOverview { get; set; }
    public string movieCountry { get; set; }
    public string vote { get; set; }
    public string Genre { get; set; }
    
    public ICollection<FavMoviesModel> FavMovies { get; set; }
    public ICollection<MovieWatchModel> MovieWatch { get; set; }

}