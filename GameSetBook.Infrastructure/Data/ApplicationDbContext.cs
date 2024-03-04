using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Club> Clubs { get; set; } = null!;
        public DbSet<Court> Courts { get; set; } = null!;
        public DbSet<GameSetMatchUpProfile> GameSetMatchUpProfiles { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
    }
}
