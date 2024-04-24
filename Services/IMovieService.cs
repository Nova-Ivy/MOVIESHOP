using VanillaMovieShop.Models.Db;

namespace VanillaMovieShop.Services
{
    public interface IMovieService
    {

        List<Movie> GetMovies();
        Movie GetMovieById(int id);
        List<Movie> GetMoviesByLeatest();
        List<Movie> GetMoviesByOldest();
        List<Movie> GetCheapestMovies();
        List<Movie> GetPopularMovies();
        void AddMovie(Movie movie);
    }
}
