using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasQueryFilter(c => c.Clubs.Any(cl => !cl.IsDeleted));
        }
    }
}
