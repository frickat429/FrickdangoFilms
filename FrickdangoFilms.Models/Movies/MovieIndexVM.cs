namespace FrickdangoFilms.Models.Movies;

public class MovieIndexVM
{
    public int Id { get; set; } 
    public string MovieTitle { get; set; } = string.Empty;
    public string MPAA_Rating { get; set; } = string.Empty;
}