using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using GameSetBook.Infrastructure.Data.Configurations;
using GameSetBook.Infrastructure.Models;
using GameSetBook.Infrastructure.Models.Identity;

namespace GameSetBook.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Club> Clubs { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Court> Courts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new ClubConfiguration());  
            builder.ApplyConfiguration(new CourtConfiguration());
            builder.ApplyConfiguration(new BookingConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());

            base.OnModelCreating(builder);
        }
    }

}
