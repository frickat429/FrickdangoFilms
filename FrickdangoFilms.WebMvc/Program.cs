using FrickdangoFilms.Data;
using FrickdangoFilms.Services.Genre;
using FrickdangoFilms.Services.Movie;
using FrickdangoFilms.Services.MPAA_Rating;
using FrickdangoFilms.Services.Theater;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FrickdangoFilmsDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))) ;
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMovieService, MovieService>(); 
builder.Services.AddScoped<IGenreService, GenreService>(); 
builder.Services.AddScoped<ITheaterService, TheaterService>();
builder.Services.AddScoped<IMPAA_RatingService, MPAA_RatingService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
