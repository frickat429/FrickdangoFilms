using FrickdangoFilms.Services.MPAA_Rating;
using Microsoft.AspNetCore.Mvc;

namespace FrickdangoFilms.WebMvc.Controllers ;

public class MPAA_RatingController : Controller 
{
  private readonly IMPAA_RatingService _mpaaRatingService; 
  public MPAA_RatingController(IMPAA_RatingService mpaaRatingService)
    {
    _mpaaRatingService = mpaaRatingService; 
    } 

    public async Task<IActionResult> Index() 
    {
        var mpaaRating = _mpaaRatingService.GetAllMPAARatingAsync(); 
        return View(mpaaRating);
    } 

    public async Task<IActionResult> Details(int id)
    {
    var mpaaRating = await _mpaaRatingService.GetMPAARatingByIdAsync(id); 
    if(mpaaRating == null)
    {
      return NotFound();
    }
    return View(mpaaRating);
    } 
    
  
}