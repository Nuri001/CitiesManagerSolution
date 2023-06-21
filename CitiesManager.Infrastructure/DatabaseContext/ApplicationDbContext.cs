using CitiesManager.Core.Entities;
using CitiesManager.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CitiesManager.Infrastructure.DatabaseContext
{
	public class ApplicationDbContext: IdentityDbContext<ApplicationUser,ApplicationRole,Guid> 
	{
		public ApplicationDbContext(DbContextOptions options) : base(options) { }

		public ApplicationDbContext() { }

		public virtual DbSet<City> Cities { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<City>().HasData(new City { CityID=Guid.Parse("B9BC23F6-E88D-4DE3-AA20-C7A1B33E7F0C"),
			CityName="New York"});
			modelBuilder.Entity<City>().HasData(new City { CityID = Guid.Parse("ED760560-E2AA-4C42-9932-085CC3A252DE"),
				CityName = "London"
			});
			modelBuilder.Entity<City>().HasData(new City { CityID = Guid.Parse("0235B75E-479C-4554-A59B-8B2CED2EEBCA"),
				CityName = "Los Angeles"
			});
			modelBuilder.Entity<City>().HasData(new City { CityID = Guid.Parse("5952EBC3-B5A0-4BFB-9A31-73ADC581CFF6"),
				CityName = "Chicago"
			});
			modelBuilder.Entity<City>().HasData(new City { CityID = Guid.Parse("A7E4857B-1309-4FD8-8C61-439229E67E7A"),
				CityName = "Houston"
			});



		}
	}
}
