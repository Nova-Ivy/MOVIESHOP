using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VanillaMovieShop.Models;
using VanillaMovieShop.Models.ViewModels;
using VanillaMovieShop.Services;

namespace VanillaMovieShop.Controllers
{
	public class HomeController : Controller
	{
        private readonly IMovieService _movieService;
        private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger, IMovieService movieService)
		{
			_logger = logger;
			_movieService = movieService;

		}

		public IActionResult Index()
		{
			
			var movieList = _movieService.GetMovies();
			FrontVM frontVM = new FrontVM()
			{

				//NewestMovies = _movieService.GetMoviesByLatest(),
				NewestMovies = movieList.OrderByDescending(x => x.ReleaseYear).Take(5).ToList(),
                OldestMovies = movieList.OrderBy(x => x.ReleaseYear).Take(5).ToList(),
                PopularMovies = movieList.OrderByDescending(m => m.OrderRows.Count).Take(5).ToList(),
                CheapestMovies = movieList.OrderBy(x => x.Price).Take(5).ToList(),

            };

            return View(frontVM);
        }

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
