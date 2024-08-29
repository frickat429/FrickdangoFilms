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

//Edit Theater 
public async Task<IActionResult> Edit(int id)
{
    var theater = await _theaterService.GetTheaterByIdAsync(id);
    if (theater == null) 
    {
        return NotFound();
    }
    var model = new TheaterEditVM
    {
    TheaterName = theater.TheaterName
    };
    return View(model);
}

[HttpPost] 
public async Task<IActionResult> Edit(int id, TheaterEditVM model)
{
    if (id != model.Id)
    {
        return View(model);
    }
    if (ModelState.IsValid)
    {
        await _theaterService.UpdateTheaterAsync(id, model);
        return RedirectToAction(nameof(Index));
    }

    return View(model);
}

//Delete 

public async Task<IActionResult> Delete(int id)
{
    var theater = await _theaterService.GetTheaterByIdAsync(id);
    if (theater == null)
    {
        return NotFound();
    }
    return View(theater);
}

[HttpPost]
[ActionName(nameof(Delete))]

public async Task<IActionResult> ConfirmDelete(int id)
{
    await _theaterService.DeleteTheaterAsync(id);
    return RedirectToAction(nameof(Index));
}
}