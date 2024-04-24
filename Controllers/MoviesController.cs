using Microsoft.AspNetCore.Mvc;
using VanillaMovieShop.Models.Db;
using VanillaMovieShop.Models.ViewModels;
using VanillaMovieShop.Services;

namespace VanillaMovieShop.Controllers
{
   
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            var model = new MoviesVM();
            model.Movies = _movieService.GetMovies();

            //var movies = _movieService.GetMovies();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.AddMovie(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public IActionResult Details(int id)
        {
            var movie = _movieService.GetMovieById(id);
            return View(movie);
        }

        public IActionResult MovieByLatest()
        {
            var movies = _movieService.GetMoviesByLatest();
            return View(movies);
        }

        public IActionResult Oldest5Movies()
        {
            var movies = _movieService.GetMoviesByOldest().Take(5);
            return View(movies);
        }
    }

}
