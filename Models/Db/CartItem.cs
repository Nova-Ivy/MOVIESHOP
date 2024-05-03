using System.ComponentModel.DataAnnotations;

namespace VanillaMovieShop.Models.Db
{
    public class CartItem
    {
        
        public int Count { get; set; }
        public int Subtotal { get; set; }
        public Movie Movie { get; set; }
    }
}
