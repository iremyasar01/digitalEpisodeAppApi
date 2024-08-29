namespace digitalEpisodeAppApi.Dto;

public class TvShowsRequestDto
{
    public string SeriesName { get; set; } = String.Empty;
    public string SeriesPosterPath { get; set; } = String.Empty;
    public string SeriesOverview { get; set; } =String.Empty;
    public string SeriesCountry { get; set; }=String.Empty;
    public double SeriesVote { get; set; }
    public string Genre { get; set; }=String.Empty;
}