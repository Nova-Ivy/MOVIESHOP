using VanillaMovieShop.Models;
using VanillaMovieShop.Models.Db;

namespace VanillaMovieShop.Services
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
    }
}
