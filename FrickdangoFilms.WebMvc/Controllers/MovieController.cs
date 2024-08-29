using System.Net;
using FrickdangoFilms.Models.Movies;
using FrickdangoFilms.Services.Genre;
using FrickdangoFilms.Services.Movie;
using FrickdangoFilms.Services.MPAA_Rating;
using FrickdangoFilms.Services.Theater;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FrickdangoFilms.WebMvc.Controllers ;

public class MovieController : Controller
{
private readonly IMovieService _movieService; 
private readonly IGenreService _genreService; 
private readonly ITheaterService _theaterService; 
private readonly IMPAA_RatingService _mpaaRatingsService;
public MovieController(IMovieService movieService, IGenreService genreService, ITheaterService theaterService, IMPAA_RatingService ratingServcie) 
{
    _movieService = movieService;  
    _genreService = genreService; 
    _theaterService = theaterService;
    _mpaaRatingsService = ratingServcie;
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
public async Task<IActionResult> Create() 
{ 
    var genres = await _genreService.GetAllGenresAsync();
    ViewBag.Genres = new SelectList(genres, "Id", "MovieGenre");
    
    var theaters = await _theaterService.GetAllTheaterAsync(); 
    ViewBag.Theaters = new SelectList(theaters, "Id", "TheaterName");
   
   var ratings = await _mpaaRatingsService.GetAllMPAARatingAsync();
   ViewBag.Ratings = new SelectList( ratings, "Id", "MovieRating");

   
    return View();
} 

//Get Genre 



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
       var genres = await _genreService.GetAllGenresAsync();
    ViewBag.Genres = new SelectList(genres, "Id", "MovieGenre");

   var theaters = await _theaterService.GetAllTheaterAsync();
   ViewBag.Theaters = new SelectList(theaters, "Id", "TheaterName");

    var ratings = await _mpaaRatingsService.GetAllMPAARatingAsync();
    ViewBag.Ratings = new SelectList(ratings, "Id", "MovieRating");
    
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