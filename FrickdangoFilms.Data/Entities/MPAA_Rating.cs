using System.ComponentModel.DataAnnotations;

namespace FrickdangoFilms.Data.Entities;

public class MPAA_Rating
{
    [Required]
   public int Id { get; set; } 
   [Required] 
   [MaxLength(10)]
   public string? MovieRating { get; set; }
}