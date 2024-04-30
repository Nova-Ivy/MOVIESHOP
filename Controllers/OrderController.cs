using Microsoft.AspNetCore.Http;
using VanillaMovieShop.Extensions;
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
      
        //public IActionResult AddToCart(int movieId)

        //{

        //    var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart") ?? new List<int>();
        //    cartList.Add(movieId);

        //   HttpContext.Session.Set<List<int>>("ShoppingCart", cartList);

        //   return RedirectToAction("Index", "Movie");

     
        //}

        [HttpPost]
        public IActionResult AddToCart(int movieId)
        {
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart") ?? new List<int>();
            cartList.Add(movieId);
            HttpContext.Session.Set<List<int>>("ShoppingCart", cartList);
            return Json(new { Value = cartList.Count() });
        }
    }
}
