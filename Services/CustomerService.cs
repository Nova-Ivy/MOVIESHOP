using VanillaMovieShop.Data;
using VanillaMovieShop.Models;

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
    }
}
