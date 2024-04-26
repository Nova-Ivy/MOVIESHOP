using VanillaMovieShop.Models.Db;

namespace VanillaMovieShop.Models.ViewModels
{
    public class CustomerVM
    {
       public List <Customer> Customers { get; set; } = new List <Customer> ();
    }
}
