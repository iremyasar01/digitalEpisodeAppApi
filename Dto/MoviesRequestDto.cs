namespace digitalEpisodeAppApi.Dto;

public class MoviesRequestDto
{
    public string MovieName { get; set; }=String.Empty;
    
    public string posterPath { get; set; }=String.Empty;
    public string movieOverview { get; set; }=String.Empty;
    public string movieCountry { get; set; }= String.Empty;
    public string vote { get; set; }= String.Empty;
    public string Genre { get; set; } =String.Empty;
}