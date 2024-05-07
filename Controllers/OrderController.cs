using Microsoft.AspNetCore.Http;
using VanillaMovieShop.Extensions;
using Microsoft.AspNetCore.Mvc;
using VanillaMovieShop.Services;
using VanillaMovieShop.Models.ViewModels;
using VanillaMovieShop.Models.Db;
using System.Linq;
using VanillaMovieShop.Data;
using System.Net.Mail;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace VanillaMovieShop.Controllers
{
	public class OrderController : Controller
	{
		private readonly ICustomerService _customerService;
		private readonly IMovieService _movieService;
		private readonly IOrderService _orderService;

		private readonly VanillaDbContext _dbContext;

		public OrderController(ICustomerService customerService, IMovieService movieService, IOrderService orderService, VanillaDbContext vanillaDbContext)
		{
			_customerService = customerService;
			_movieService = movieService;
			_orderService = orderService;
			_dbContext = vanillaDbContext;

		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult PlaceOrder()
		{
			return View();
		}
		[HttpPost]
		public IActionResult PlaceOrder(string emailAddress)
		{
			// Kod som kollar om kund finns, om inte så skicka vidare till 'Create customer'
			var customer = _customerService.GetCustomersByEmail(emailAddress);
			if (customer == null)
			{
				return RedirectToAction("Create", "Customer");

				customer = _customerService.GetCustomersByEmail(emailAddress);
			}
			customer = _customerService.GetCustomersByEmail(emailAddress);

			var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart") ?? new List<int>();
			var orderId = _orderService.AddOrder(customer, cartList);

			return RedirectToAction("OrderConfirm", new { orderId = orderId });
		}
		public IActionResult OrderConfirm()
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
				foreach (var itemVM in cartItemVM)
				{
					if (itemVM.Movie == mov)
					{
						found = true;
					}
				}

				if (!found)
				{
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
		public IActionResult CustomerOrders()
		{
			return View();
		}
		[HttpPost]
		public IActionResult ShowCustomerOrderList(string email)
		{
			List<Order> customerOrders = _orderService.GetCustomerOrders(email);

			return View(customerOrders);
		}
	}
}
