using FrickdangoFilms.Models.MPAA_Rating;
using FrickdangoFilms.Services.MPAA_Rating;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        var mpaaRating = await _mpaaRatingService.GetAllMPAARatingAsync(); 
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

    public IActionResult Create() 
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(MPAA_RatingCreateViewModel model) 
    {
      if(ModelState.IsValid) 
      {
        await _mpaaRatingService.CreateMovieRatingAsync(model);
        return RedirectToAction(nameof(Index));
      }
      return View(model);
    }
    
    //Edit Rating
    public async Task<IActionResult> Edit(int id)
    {
      var rating = await _mpaaRatingService.GetMPAARatingByIdAsync(id);
      if (rating == null )
      {
        return NotFound();
      }
      var model = new MPAA_RatingEditVM 
      {
        MovieRating = rating.MovieRating
      };
      return View(model);
    }
  [HttpPost]
    public async Task<IActionResult> Edit(int id, MPAA_RatingEditVM model)
    {
      if (id != model.Id)
      {
        return View(model);
      }
      if (ModelState.IsValid)
      {
        await _mpaaRatingService.UpdateMovieRatingAsync(id, model);
        return RedirectToAction(nameof(Index));
      }
      return View(model);
    }
    //Delete 
    public async Task<IActionResult> Delete(int id)
    {
      var rating = await _mpaaRatingService.GetMPAARatingByIdAsync(id);
      if (rating == null) 
      {
        return NotFound();
      }
      return View(rating);
    }
[HttpPost]
[ActionName(nameof(Delete))]

public async Task<IActionResult> ConfirmDelete(int id)
{
  
  await _mpaaRatingService.DeleteMovieRatingAsync(id);
  return RedirectToAction(nameof(Index));
}

}