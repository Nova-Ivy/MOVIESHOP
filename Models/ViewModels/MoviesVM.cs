using VanillaMovieShop.Models.Db;

namespace VanillaMovieShop.Models.ViewModels
{
    public class MoviesVM
    {
        public List<Movie>Movies { get; set; } = new List<Movie>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
