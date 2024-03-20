//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//using GameSetBook.Infrastructure.Models;

//namespace GameSetBook.Infrastructure.Data.Configurations
//{
//    internal class TournamentGSMUPlayerProfileConfiguration : IEntityTypeConfiguration<TournamentGSMUPlayerProfile>
//    {
//        public void Configure(EntityTypeBuilder<TournamentGSMUPlayerProfile> builder)
//        {
//            builder
//                .HasKey(tp => new { tp.PlayerProfileId, tp.TournamentId });
              

//            builder
//                .HasOne(tp => tp.PlayerProile)
//                .WithMany(pp => pp.TournamentsGSMUPlayerProfile)
//                .OnDelete(DeleteBehavior.NoAction);

//            builder
//                .HasOne(tp => tp.Tournament)
//                .WithMany(t => t.TournamentGSMUPlayerProfiles)
//                .OnDelete(DeleteBehavior.NoAction);

//            builder
//                .HasQueryFilter(g => !g.PlayerProile.IsDeleted);
//        }
//    }
//}
