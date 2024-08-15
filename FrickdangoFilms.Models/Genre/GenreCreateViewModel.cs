using System.ComponentModel.DataAnnotations;

namespace FrickdangoFilms.Models.Genre ;

public class GenreCreateViewModel 
{ 
    [Required]
    public string? MovieGenre { get; set; }
}