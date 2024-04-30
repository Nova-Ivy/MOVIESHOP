using VanillaMovieShop.Models.Db;

namespace VanillaMovieShop.Models.ViewModels
{
    public class FrontVM
    {
        public List<Movie> PopularMovies { get; set; } = new List<Movie>();
        public List<Movie> NewestMovies { get; set; }
        public List<Movie> OldestMovies { get; set; }
        public List<Movie> CheapestMovies { get; set; } 
        public List<Movie> ExpensiveMovies { get; set; } = new List<Movie>();
    }
}
