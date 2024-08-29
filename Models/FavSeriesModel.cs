namespace digitalEpisodeAppApi.Models;

public class FavSeriesModel
{
        public int FavSeriesId { get; set; }
        public int UserId { get; set; }
        public UsersModel Users { get; set; }

        public int SeriesId { get; set; }
        public TvShowsModel TvShows { get; set; }
    


}