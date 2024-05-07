using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VanillaMovieShop.Models.Db;
using VanillaMovieShop.Models.ViewModels;

namespace VanillaMovieShop.Data
{
    public class VanillaDbContext : DbContext
	{
		public VanillaDbContext(DbContextOptions<VanillaDbContext> options) : base(options)
		{

		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<OrderRow> OrderRows { get; set; }
        public DbSet<VanillaMovieShop.Models.ViewModels.CartVM> CartVM { get; set; } = default!;
	}
	
}
