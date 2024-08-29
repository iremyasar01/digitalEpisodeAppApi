namespace digitalEpisodeAppApi.Models;

public class TvShowsModel
{
    public TvShowsModel()
    {
        FavSeries = new List<FavSeriesModel>();
        WatchSeries = new List<SeriesWatchModel>();
    }
    public int SeriesId { get; set; }
    public string SeriesName { get; set; }
    public string SeriesPosterPath{ get; set; }
    public string SeriesOverview { get; set; }
    public string SeriesCountry { get; set; }
    public double SeriesVote { get; set; }
    public string Genre { get; set; }
   
    public ICollection<FavSeriesModel> FavSeries { get; set; }
    public ICollection<SeriesWatchModel> WatchSeries { get; set; }
}