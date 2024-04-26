using VanillaMovieShop.Models;
using VanillaMovieShop.Models.Db;

namespace VanillaMovieShop.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(int id);
        List<Customer> GetCustomersByFname();
        List<Customer> GetCustomersByLname();
        //List<Customer> GetCustomerByOrderId();

        void AddCustomer(Customer customer);
        void ViewCustomers(int id);
        void EditCustomer(Customer customer);        
        void DeleteCustomer(Customer customer);
        
    }
}
