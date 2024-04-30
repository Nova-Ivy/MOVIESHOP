using VanillaMovieShop.Models.Db;

namespace VanillaMovieShop.Services
{
    public interface IMovieService
    {

        List<Movie> GetMovies();
        Movie GetMovieById(int id);
        List<Movie> GetMoviesByLatest();
        List<Movie> GetMoviesByOldest();
        List<Movie> GetCheapestMovies();
        List<Movie> PopularOrderMovies();
        public void AddMovie(Movie movie);
        public void EditMovie(Movie movie);
        public void DeleteMovie(Movie movie);
    }
}
