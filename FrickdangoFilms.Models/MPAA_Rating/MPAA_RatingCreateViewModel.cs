using System.ComponentModel.DataAnnotations;

namespace FrickdangoFilms.Models.MPAA_Rating;

public class MPAA_RatingCreateViewModel 
{ 
    [Required]
    public string? MovieRating  { get; set; }
}