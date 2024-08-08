using System.ComponentModel.DataAnnotations;

namespace FrickdangoFilms.Data.Entities;

public class Theater 
{ 
    [Required]
    public int Id { get; set; } 
    
    [Required] 
    [MaxLength(100)]
    public string? TheaterName { get; set; }
}