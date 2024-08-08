using System.ComponentModel.DataAnnotations;

namespace FrickdangoFilms.Data.Entities;

public class Genre 
{ 
    [Required]
    public int Id { get; set; } 
    [Required] 
    [MaxLength(100)]
    public string? MovieGenre { get; set; }
}