using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class ClubReviewConfiguration : IEntityTypeConfiguration<ClubReview>
    {
        public void Configure(EntityTypeBuilder<ClubReview> builder)
        {
            builder.HasQueryFilter(cr => !cr.Club.IsDeleted);
        }
    }
}
