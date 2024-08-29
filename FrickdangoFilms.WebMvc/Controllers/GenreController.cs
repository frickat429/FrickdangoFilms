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

//Edit Genre

public async Task<IActionResult> Edit(int id)
{
    var genre = await _genreService.GetGenreByIdAsync(id);
    if (genre == null) 
    {
        return NotFound();
    }
    var model = new GenreEditVM
    {
    MovieGenre = genre.MovieGenre
    };
    return View(model);
}

[HttpPost] 
public async Task<IActionResult> Edit(int id, GenreEditVM model)
{
    if (id != model.Id)
    {
        return View(model);
    }
    if (ModelState.IsValid)
    {
        await _genreService.UpdateGenreAsync(id, model);
        return RedirectToAction(nameof(Index));
    }

    return View(model);
}

//Delete 

public async Task<IActionResult> Delete(int id)
{
    var genre = await _genreService.GetGenreByIdAsync(id);
    if (genre == null)
    {
        return NotFound();
    }
    
    return View(genre);
}

[HttpPost]
[ActionName(nameof(Delete))]

public async Task<IActionResult> ConfirmDelete(int id)
{
    await _genreService.DeleteGenreAsync(id);
    return RedirectToAction(nameof(Index));
}


}