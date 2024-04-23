﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VanillaMovieShop.Models;
using VanillaMovieShop.Models.Db;

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
	}
	
}
