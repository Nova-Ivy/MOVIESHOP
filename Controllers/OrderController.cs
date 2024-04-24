using Microsoft.AspNetCore.Mvc;

namespace VanillaMovieShop.Controllers
{
    public class OrderController : Controller
    {
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

        public IActionResult OrderHistory() 
        {
            return View();
        }

    }
}
