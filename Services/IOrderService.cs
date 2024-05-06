using VanillaMovieShop.Models.Db;

namespace VanillaMovieShop.Services
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        public void AddOrder(Order order);
        public void EditOrder(Order order);
        public void DeleteOrder(Order order);
        List<Order> GetCustomerOrders(string email);

      
    }

}
