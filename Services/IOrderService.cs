using VanillaMovieShop.Models.Db;

namespace VanillaMovieShop.Services
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        public int AddOrder(Customer customer, List<int> movieIds);
        public void EditOrder(Order order);
        public void DeleteOrder(Order order);
        List<Order> GetCustomerOrders(string email);

      
    }

}
