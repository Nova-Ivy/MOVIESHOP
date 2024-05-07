using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net.Mail;
using VanillaMovieShop.Models.Db;
using VanillaMovieShop.Models.ViewModels;
using VanillaMovieShop.Services;


namespace VanillaMovieShop.Controllers
{
    public class CustomerController : Controller
    {
        //private readonly IMovieService _movieService;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var item = new CustomerVM();
            item.Customers = _customerService.GetCustomers();
            return View(item);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.AddCustomer(customer);
                return RedirectToAction("PlaceOrder", "Order", new { emailAdress = customer.Email });
            }
            return View(customer);
        }
        public IActionResult Details(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            return View(customer);
        }
        public IActionResult Edit(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if(ModelState.IsValid)
            {
                _customerService.EditCustomer(customer);
                return RedirectToAction("Index"); 
            }
            return View(customer);
        }
        public IActionResult Delete(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            return View(customer);                        
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {           
                _customerService.DeleteCustomer(customer);    
                return RedirectToAction("Index");            
        }    
    }
}
