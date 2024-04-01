using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .HasOne(c=>c.Club)
                .WithMany(c=>c.Reviews)
                .HasForeignKey(c=>c.ClubId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(c => c.Booking)
                .WithOne(c => c.Review)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(cr => !cr.Club.IsDeleted);
        }
    }
}
