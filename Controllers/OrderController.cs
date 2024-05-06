using Microsoft.AspNetCore.Http;
using VanillaMovieShop.Extensions;
using Microsoft.AspNetCore.Mvc;
using VanillaMovieShop.Services;
using VanillaMovieShop.Models.ViewModels;
using VanillaMovieShop.Models.Db;
using System.Linq;

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

        [HttpPost]
        public IActionResult GetCartCount()
        {
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart") ?? new List<int>();
            var count = cartList.Count;
            HttpContext.Session.Set<List<int>>("ShoppingCart", cartList);
            return Json(count);
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart") ?? new List<int>();
            cartList.Add(id);
            var count = cartList.Count;
            HttpContext.Session.Set<List<int>>("ShoppingCart", cartList);
            return Json(count);
        }

        [HttpPost]
        public IActionResult PlusItem(int id)
        {
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart") ?? new List<int>();
            cartList.Add(id);
            var count = cartList.Count;
            HttpContext.Session.Set<List<int>>("ShoppingCart", cartList);
            return Json(count);
        }

        [HttpPost]
        public IActionResult MinusItem(int id)
        {
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart") ?? new List<int>();
            cartList.Remove(id);
            var count = cartList.Count;
            HttpContext.Session.Set<List<int>>("ShoppingCart", cartList);
            return Json(count);
        }
        public IActionResult ShoppingCart()
        {
            List<CartItemVM> cartItemVM = new List<CartItemVM>();
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart").ToList();
            Decimal totalSum = 0;
            foreach (var item in cartList)
            {
                Movie mov = _movieService.GetMovieById(item);
                bool found = false;
                foreach (var itemVM in cartItemVM) { 
                    if (itemVM.Movie == mov)
                    {
                        found = true;
                    }
                }
                
                if (!found) {
                    CartItemVM add = new CartItemVM();
                    add.Movie = mov;
                    add.Quantity = 1;
                    add.Subtotal = mov.Price;
                    totalSum += mov.Price;
                    cartItemVM.Add(add);
                } 
                else
                {
                    CartItemVM old = new CartItemVM();
                    old = cartItemVM.Find(m => m.Movie == mov);
                    old.Quantity++;
                    old.Subtotal += mov.Price;
                    totalSum += mov.Price;
                }
            }

            CartVM cartVM = new CartVM()
            {
                CartItems = cartItemVM,
                Total = totalSum,
            };
            
            return View(cartVM);
        }
    }
}
