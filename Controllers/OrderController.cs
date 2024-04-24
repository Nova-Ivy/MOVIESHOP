using Microsoft.AspNetCore.Mvc;
using VanillaMovieShop.Services;

namespace VanillaMovieShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMovieService _movieService;

        public OrderController(ICustomerService customerService, IMovieService movieService)
        {
            _customerService = customerService;
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PlaceOrder()
        {
            return View();
        }
        public IActionResult OrderDetails() 
        {
            return View();
        }
    }
}
