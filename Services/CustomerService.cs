using VanillaMovieShop.Data;
using VanillaMovieShop.Models;
using VanillaMovieShop.Models.Db;

namespace VanillaMovieShop.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly VanillaDbContext _db;
        private readonly IConfiguration _configuration;
        
        public CustomerService(VanillaDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        public void AddCustomer(Customer customer)
        { 
            _db.Customers.Add(customer);
            _db.SaveChanges();
        }


    }
}
