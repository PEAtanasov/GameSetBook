using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;
using GameSetBook.Common.Enums;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class CourtConfiguration : IEntityTypeConfiguration<Court>
    {
        public void Configure(EntityTypeBuilder<Court> builder)
        {
            builder.HasQueryFilter(c => !c.Club.IsDeleted);
            builder.HasData(CourtSeed());
        }

        private IList<Court> CourtSeed()
        {
            var courts = new List<Court>()
            {
                new Court()
                {
                    Id = 1,
                    ClubId = 1,
                    Name = "No.1",
                    IsActive= true,
                    IsIndoor= false,
                    IsLighted = false,
                    PricePerHour = 20m,
                    Surface = Surface.Clay
                },

                new Court()
                {
                    Id = 2,
                    ClubId = 1,
                    Name = "No.2",
                    IsActive= true,
                    IsIndoor= false,
                    IsLighted = false,
                    PricePerHour = 20m,
                    Surface = Surface.Hard
                }

            };

            return courts;
        }
    }
}
