using FrickdangoFilms.Models.Theater;
using FrickdangoFilms.Services.Theater;
using Microsoft.AspNetCore.Mvc;

namespace FrickdangoFilms.WebMvc.Controllers ;

public class TheaterController : Controller
{
private readonly ITheaterService _theaterService;
public TheaterController(ITheaterService theaterService) 
{
    _theaterService = theaterService;
} 

public async Task<IActionResult> Index()
{
    var theaters = await _theaterService.GetAllTheaterAsync();
    return View(theaters); 
} 

public async Task<IActionResult> Details(int id)
{
    var theater = await _theaterService.GetTheaterByIdAsync(id);
    if (theater == null) 
    {
        return NotFound();
    } 
    return View(theater);
} 

//Theater Create 
public IActionResult Create()
{
    return View();
}

[HttpPost] 
public async Task<IActionResult> Create(TheaterCreateViewModel model)
{
    if(ModelState.IsValid) 
    {
        await _theaterService.CreateTheaterAsync(model);
        return RedirectToAction(nameof(Index));
    }
    return View(model);
}
}