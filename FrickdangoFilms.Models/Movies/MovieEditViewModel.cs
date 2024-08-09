namespace FrickdangoFilms.Models.Movies ;

public class MovieEditViewModel
{
    public string? MovieTitle { get; set; }
    public string? MovieDescription { get; set; } 
    public int RuntimeInMinutes { get; set; } 
    public int GenreId { get; set; } 
    public int MPAA_RatingId { get; set; } 
    public int TheaterId { get; set; }
}