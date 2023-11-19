using CoolStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoolStore.DataAccess.Data
{
	public class ApplicationDBContext : IdentityDbContext<IdentityUser>
	{
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{

		}

        public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ApplicationUser> ApplicationUsers {  get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Horror", DisplayOrder = 1 },
				new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
				new Category { Id = 3, Name = "Hentai", DisplayOrder = 3 }
				);
			modelBuilder.Entity<Product>().HasData(
			   new Product
			   {
				   Id = 1,
				   Title = "Fortune of Time",
				   Author = "Billy Spark",
				   Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
				   ISBN = "SWD9999001",
				   ListPrice = 99,
				   Price = 90,
				   Price50 = 85,
				   Price100 = 80,
				   CategoryId = 1,
				   ImgUrl = ""
			   },
			   new Product
			   {
				   Id = 2,
				   Title = "Dark Skies",
				   Author = "Nancy Hoover",
				   Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
				   ISBN = "CAW777777701",
				   ListPrice = 40,
				   Price = 30,
				   Price50 = 25,
				   Price100 = 20,
				   CategoryId = 1,
				   ImgUrl = ""

			   },
			   new Product
			   {
				   Id = 3,
				   Title = "Vanish in the Sunset",
				   Author = "Julian Button",
				   Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
				   ISBN = "RITO5555501",
				   ListPrice = 55,
				   Price = 50,
				   Price50 = 40,
				   Price100 = 35,
				   CategoryId = 2,
				   ImgUrl = ""
			   },
			   new Product
			   {
				   Id = 4,
				   Title = "Cotton Candy",
				   Author = "Abby Muscles",
				   Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
				   ISBN = "WS3333333301",
				   ListPrice = 70,
				   Price = 65,
				   Price50 = 60,
				   Price100 = 55,
				   CategoryId = 3,
				   ImgUrl = ""
			   }
			   ); ;
		}
	}
}
