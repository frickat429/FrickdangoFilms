namespace FrickdangoFilms.Models.Movies ;

public class MovieViewModel 
{
    public int Id { get; set; } 
    public string MovieTitle { get; set; } = string.Empty;
    public string MovieDescription { get; set; } = string.Empty;
    public int RuntimeInMinutes { get; set; } 
    public int GenreId { get; set; }
    public string MovieGenre { get; set; } = string.Empty;
    public string MPAA_Rating { get; set; } = string.Empty;
    public int MPAA_RatingId { get; set; }
    public string TheaterName { get; set; } = string.Empty; 
    public int TheaterId { get; set; }
}