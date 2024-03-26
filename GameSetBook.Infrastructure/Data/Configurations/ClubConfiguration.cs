using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class ClubConfiguration : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.HasQueryFilter(c => !c.IsDeleted);
            builder.HasData(ClubSeed());

        }

        private IList<Club> ClubSeed()
        {
            var clubs = new List<Club>()
            {
                new Club()
                {
                    Id = 1,
                    Name = "First Club",
                    Description = "First Club Description",
                    CityId=1,
                    ClubOwnerId = "82cd50ca-b023-42e5-8344-227d5c45877c",
                    Email = "firstClub@mail.com",
                    PhoneNumber = "+359123456",
                    HasParking = true,
                    HasShop = true,
                    HasShower = true,
                    NumberOfCoaches =2,
                    NumberOfCourts =2,
                    WorkingTimeStart = 8,
                    WorkingTimeEnd = 20,
                    IsAproovedByAdmin = true,
                    RegisteredOn = DateTime.Parse("09-03-2024 10:00"),
                    Address = "First Club Address"
                }
            };

            return clubs;
        }
    }
}
