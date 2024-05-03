using VanillaMovieShop.Models.Db;

namespace VanillaMovieShop.Models.ViewModels
{
    public class CartItemVM
    {
        public int Id { get; set; }

        public Movie Movie { get; set; }
        
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; } = 0;

    }
        
    
}
