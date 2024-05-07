using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VanillaMovieShop.Data;
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

        public List<Customer> GetCustomers()
        {   var customers = _db.Customers.ToList();
            return customers; 
        }
        public Customer GetCustomerById(int id)
        {
            var customer = _db.Customers.FirstOrDefault(c=>c.Id == id);
            return customer; 
        }
        public List<Customer> GetCustomersByFname()
        {
            var customer = _db.Customers.OrderBy(c => c.FirstName).ToList();
            return customer; 
        }
        public List<Customer> GetCustomersByLname()
        {
            var customer = _db.Customers.OrderBy(c => c.LastName).ToList();
            return customer;
        }

        public Customer GetCustomersByEmail(string email)
        {
            var customer = _db.Customers.Where(c => c.Email == email).FirstOrDefault();
            return customer!;
        }

        public void AddCustomer(Customer customer)
        { 
            _db.Customers.Add(customer);
            _db.SaveChanges();
        }
        public void ViewCustomers(int id)
        {
            _db.Customers.All(c => c.Id == id);
            _db.SaveChanges(); 
        }
        public void EditCustomer(Customer customer)
        {
            _db.Customers.Update(customer);
            _db.SaveChanges();
        }    
        public void DeleteCustomer(Customer customer)
        {
            _db.Customers.Remove(customer);
            _db.SaveChanges();
        }
    }
}
