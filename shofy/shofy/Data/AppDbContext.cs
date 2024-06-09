using System;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shofy.Data;
using shofy.Models;
namespace shofy.Data

{
	public class AppDbContext : IdentityDbContext<AppUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slider>().HasQueryFilter(x => !x.SoftDeleted);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Slider>()
                        .HasData(
           new Slider
           {
               Id = 1,
               Title = "The best tablet Collection 2024",
               Description = "<p>Exclusive offer <span>-35%</span> off this week<img src=\"~/assets/icons/offer-line.svg\" alt=\"\"></p>\n",
               Image = "slider-img-1.png"
           },
          new Slider
          {
              Id = 2,
              Title = "The best note book Collection 2024",
              Description = "<p>Exclusive offer <span>-10%</span> off this week<img src=\"~/assets/icons/offer-line.svg\" alt=\"\"></p>",
              Image = "slider-img-2.png"
          },
          new Slider
          {
              Id = 3,
              Title = "The best tablet Collection 2024",
              Description = "<p>Exclusive offer <span>-10%</span> off this week<img src=\"~/assets/icons/offer-line-red.svg\" alt=\"\"></p>\n",
              Image = "slider-img-3.png"
          }
            );
            modelBuilder.Entity<Category>().HasQueryFilter(x => !x.SoftDeleted);
            modelBuilder.Entity<Category>()
              .HasData(
                new Category
                {
                    Id =1,
                    Name= "Headphones"

                },
                   new Category
                   {
                       Id = 2,
                       Name = "Mobile Tablets"

                   },
                      new Category
                      {
                          Id = 3,
                          Name = "CPU Heat Pipes"

                      },
                        new Category
                        {
                            Id = 4,
                            Name = "Smart Watch"

                        },
                           new Category
                           {
                               Id = 5,
                               Name = "Bluetooth"

                           }

              );

        }
    }
}

