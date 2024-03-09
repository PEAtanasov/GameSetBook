using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class GameSetMatchUpPlayerProfileConfiguration : IEntityTypeConfiguration<GameSetMatchUpPlayerProfile>
    {
        public void Configure(EntityTypeBuilder<GameSetMatchUpPlayerProfile> builder)
        {
            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
