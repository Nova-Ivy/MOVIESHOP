using Microsoft.AspNetCore.Mvc;
using VanillaMovieShop.Models.Db;
//using VanillaMovieShop.Services; 

namespace VanillaMovieShop.Controllers
{
    public class CustomerController : Controller
    {
        //private readonly IMovieService _movieService;
        //private readonly ICustomerService _customerService;
        

        //public CustomerController ICustomerService _customerService)
        //{ 
        //  _customerService = customerService;          
        //}

    public IActionResult Index()
    {
        //insert list/ VM return list / VM
            return View();
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
            //_customerService.AddCustomer(customer);
            return RedirectToAction("Index");
        }
        return View(customer);
    }
    public IActionResult Details(Customer customer)
    {
        //_customerService.ViewCustomer(customer)
            return View(customer);

    }
    public IActionResult Delete(Customer customer)
    {
        if (ModelState.IsValid)
        {
            //_customerService.DeleteCustomer(customer);
            return RedirectToAction("Index");
        }
        return View(customer);
        }


    }
}
