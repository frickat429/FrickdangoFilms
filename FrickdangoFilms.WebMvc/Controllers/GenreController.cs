using System.Net;
using FrickdangoFilms.Data.Entities;
using FrickdangoFilms.Models.Genre;
using FrickdangoFilms.Services.Genre;
using Microsoft.AspNetCore.Mvc;

namespace FrickdangoFilms.WebMvc.Controllers ;

public class GenreController : Controller 
{
private readonly IGenreService _genreService; 
public GenreController(IGenreService genreService) 
{
    _genreService = genreService;
} 

[HttpGet] 
public async Task<IActionResult> Index() 
{
    var genres = await _genreService.GetAllGenresAsync();
    return View(genres);
} 
public async Task<IActionResult> Details(int id) 
{
    var genre = await _genreService.GetGenreByIdAsync(id); 
    if (genre == null) 
    {
        return NotFound();
    } 
    return View(genre);
}

//Get create 
public IActionResult Create()
{
    return View();
}

[HttpPost] 
public async Task<IActionResult>  Create(GenreCreateViewModel model ) 
{
    if(ModelState.IsValid) 
    {
        await _genreService.CreateGenreAsync(model);
        return RedirectToAction(nameof(Index));
    }
    return View(model);
}
}