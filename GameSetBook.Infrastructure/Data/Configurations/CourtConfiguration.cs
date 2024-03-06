using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class CourtConfiguration : IEntityTypeConfiguration<Court>
    {
        public void Configure(EntityTypeBuilder<Court> builder)
        {
            builder.HasQueryFilter(c => !c.Club.IsDeleted);
        }
    }
}
