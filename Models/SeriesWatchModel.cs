namespace digitalEpisodeAppApi.Models;

public class SeriesWatchModel
{
    public int SeriesWatchId;
    public int UserId { get; set; }
    public UsersModel User { get; set; }

    public int SeriesId{ get; set; }
    public TvShowsModel tvShows { get; set; }
}