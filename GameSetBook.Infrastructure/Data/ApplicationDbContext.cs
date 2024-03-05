using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using GameSetBook.Infrastructure.Models;
using System.Reflection.Emit;

namespace GameSetBook.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Club> Clubs { get; set; } = null!;
        public DbSet<ClubReview> ClubReviews { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Court> Courts { get; set; } = null!;
        public DbSet<GameSetMatchUpPlayerProfile> GameSetMatchUpPlayerProfiles { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<Tournament>  Tournaments { get; set; } = null!;
        public DbSet<TournamentGSMUPlayerProfile> TournamentsGSMUPlayerProfiles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TournamentGSMUPlayerProfile>()
                .HasKey(tp => new { tp.PlayerProfileId, tp.TournamentId });

            builder.Entity<TournamentGSMUPlayerProfile>()
                .HasOne(tp => tp.PlayerProile)
                .WithMany(pp => pp.TournamentsGSMUPlayerProfile)
                .OnDelete(DeleteBehavior.Restrict); // Set OnDelete behavior to Cascade, or noaction

            builder.Entity<TournamentGSMUPlayerProfile>()
                .HasOne(tp => tp.Tournament)
                .WithMany(t => t.TournamentGSMUPlayerProfiles)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<GameSetMatchUpPlayerProfile>()
                .HasMany(p => p.SentMessages)
                .WithOne(m => m.SenderProfile)
                .HasForeignKey(m => m.SenderProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<GameSetMatchUpPlayerProfile>()
                .HasMany(p => p.ReceivedMessages)
                .WithOne(m => m.ReceiverProfile)
                .HasForeignKey(m => m.ReceiverProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }


}
