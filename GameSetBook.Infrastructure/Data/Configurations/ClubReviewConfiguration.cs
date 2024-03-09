using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class ClubReviewConfiguration : IEntityTypeConfiguration<ClubReview>
    {
        public void Configure(EntityTypeBuilder<ClubReview> builder)
        {
            builder
                .HasOne(c=>c.Club)
                .WithMany(c=>c.ClubReviews)
                .HasForeignKey(c=>c.ClubId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(cr => !cr.Club.IsDeleted);
        }
    }
}
