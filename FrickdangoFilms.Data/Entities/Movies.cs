using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrickdangoFilms.Data.Entities;

public class Movies
{ 
    [Key]
    public int Id { get; set; } 
    [Required]
    [MaxLength(250)] 
    public string? MovieTitle { get; set; } 
    [Required] 
    [MaxLength(500)]
    public string? MovieDescription { get; set; }
    [Required]
    public int RuntimeInMinutes { get; set; }
    
    
    [ForeignKey(nameof(Genre))]
    public int GenreId { get; set; } 
    public virtual Genre Genre { get; set; } = null;

    
    [ForeignKey(nameof(MPAA_Rating))] 
    public int MPAA_RatingId { get; set; } 
    public virtual MPAA_Rating MPAA_Rating { get; set; } = null; 

    [ForeignKey(nameof(Theater))]
    public int TheaterId { get; set; } 

    public virtual Theater Theater { get; set; } = null;
 }