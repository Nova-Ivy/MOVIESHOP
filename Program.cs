using Microsoft.EntityFrameworkCore;
using VanillaMovieShop.Data;
using VanillaMovieShop.Services;

namespace VanillaMovieShop
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
            var connectionString = builder.Configuration.GetConnectionString("LocalConnection") ?? throw new InvalidCastException("Default Connection not found");

			builder.Services.AddDbContext<VanillaDbContext>(
			options => options.UseSqlServer(connectionString)
			);

			builder.Services.AddScoped<IMovieService, MovieService>();

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(20));

            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

            

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
