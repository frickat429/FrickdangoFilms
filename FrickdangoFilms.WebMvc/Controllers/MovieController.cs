using System.Net;
using FrickdangoFilms.Models.Movies;
using FrickdangoFilms.Services.Movie;
using Microsoft.AspNetCore.Mvc;

namespace FrickdangoFilms.WebMvc.Controllers ;

public class MovieController : Controller
{
private readonly IMovieService _movieService; 
public MovieController(IMovieService movieService) 
{
    _movieService = movieService; 
} 

//Get Movie/Index 
public async Task<IActionResult> Index() 
{
    var movies = await _movieService.GetAllMoviesAsync();
    return View(movies); 
} 

//Get: Movie Deails 
public async Task<IActionResult> Details(int id) 
{
    var movie = await _movieService.GetMovieByIdAsync(id);
    if (movie == null) 
    {
        return NotFound();
    } 
    return View(movie);
} 

//Get Movie/Create 
public IActionResult Create() 
{
    return View();
} 

//Movie Create 
[HttpPost]
public async Task<IActionResult> Create(MovieCreateViewModel model) 
{
    if(ModelState.IsValid) 
    {
        await _movieService.CreateMovieAsync(model); 
        return RedirectToAction(nameof(Index)); 
    } 
    return View(model); 
} 

//Movie Edit 
public async Task<IActionResult> Edit(int id) 
{
    var movie = await _movieService.GetMovieByIdAsync(id);
    if(movie == null) 
    {
        return NotFound();
    } 
    var editModel = new MovieEditViewModel 
    {
        Id  = movie.Id, 
        MovieTitle = movie.MovieTitle, 
        MovieDescription = movie.MovieDescription, 
        RuntimeInMinutes = movie.RuntimeInMinutes, 
        GenreId = movie.GenreId, 
        MPAA_RatingId = movie.MPAA_RatingId,
        TheaterId = movie.TheaterId
    }; 
    return View(editModel);
} 

[HttpPost] 
public async Task<IActionResult> Edit(int id, MovieEditViewModel model) 
{
    if (id != model.Id) 
    {
        return View(model); 
    } 
    if (ModelState.IsValid) 
    {
        await _movieService.UpdateMovieAsync(id, model); 
        return RedirectToAction(nameof(Index)); 
    } 
    return View(model);
} 

//Get Movie Delete 
public async Task<IActionResult> Delete(int id) 
{
    var movie = await _movieService.GetMovieByIdAsync(id);
    if(movie == null) 
    {
        return NotFound();
    } 
    return View(movie); 
} 

//Delete movie 
[HttpPost] 
[ActionName(nameof(Delete))]
public async Task<IActionResult> ConfirmDelete(int id) 
{
    await _movieService.DeleteMovieAsync(id); 
    return RedirectToAction(nameof(Index)); 
}

}