using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class GameSetMatchUpPlayerProfileConfiguration : IEntityTypeConfiguration<GameSetMatchUpPlayerProfile>
    {
        public void Configure(EntityTypeBuilder<GameSetMatchUpPlayerProfile> builder)
        {
            builder
                .HasMany(p => p.SentMessages)
                .WithOne(m => m.SenderProfile)
                .HasForeignKey(m => m.SenderProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(p => p.ReceivedMessages)
                .WithOne(m => m.ReceiverProfile)
                .HasForeignKey(m => m.ReceiverProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
