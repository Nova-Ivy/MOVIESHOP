

using VanillaMovieShop.Models.Db;

namespace VanillaMovieShop.Models.ViewModels
{
    public class CartVM
    {
        public int Id { get; set; }

        public CartVM() 
        {
            CartItems = new List<CartItemVM>();
        }
        public List<CartItemVM> CartItems { get; set; }
        public decimal Total { get; set; }
    }
}
