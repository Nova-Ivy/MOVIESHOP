using Microsoft.EntityFrameworkCore;
using VanillaMovieShop.Data;
using VanillaMovieShop.Models.Db;

namespace VanillaMovieShop.Services
{
    public class OrderService : IOrderService
    {
        private readonly VanillaDbContext _db;
        private readonly IConfiguration _configuration;
   
        public OrderService(VanillaDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        public List<Order> GetAllOrders()
        {
            var orders = _db.Orders.ToList();
            return orders;
        }

        public Order GetOrderById(int id)
        {
            var orders = _db.Orders.FirstOrDefault(o => o.Id == id);
            return orders;
        }

        public void AddOrder(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
        }
        public void EditOrder(Order order)
        {
            _db.Orders.Update(order);
            _db.SaveChanges();
        }
        public void DeleteOrder(Order order)
        {
            _db.Orders.Remove(order);
            _db.SaveChanges();
        }
        public List<Order> GetCustomerOrders(string email)
        {
            var customer = _db.Customers.FirstOrDefault(c => c.Email == email);

            if (customer == null)
            {
                return null;
            }
            var customerOrders = _db.Orders
                  .Where(o => o.CustomerId == customer.Id)
                  .Include(o => o.OrderRows)
                      .ThenInclude(or => or.Movie)
                      .Include(o => o.Customer)
                  .ToList();

            return customerOrders;
        }



    }
}
