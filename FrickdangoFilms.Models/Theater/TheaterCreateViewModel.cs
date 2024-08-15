using System.ComponentModel.DataAnnotations;

namespace FrickdangoFilms.Models.Theater ;

public class TheaterCreateViewModel 
{ 
    [Required]
    public string? TheaterName { get; set; }
}