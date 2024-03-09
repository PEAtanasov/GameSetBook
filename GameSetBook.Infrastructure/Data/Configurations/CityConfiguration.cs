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

            builder.HasData(SeedCities());


        }

        private IList<City> SeedCities()
        {
            var cities = new List<City>()
            {
                new City()
                {
                    Id = 1,
                    Name = "Sofia",
                    CountryId = 1

                },

                new City()
                {
                    Id = 2,
                    Name = "Plovdiv",
                    CountryId = 1
                },

                new City()
                {
                    Id = 3,
                    Name = "Sofia",
                    CountryId = 1
                },

                new City()
                {
                    Id = 4,
                    Name = "Bucharest",
                    CountryId = 2
                },

                new City()
                {
                    Id = 5,
                    Name = "Constanta",
                    CountryId = 2
                }
            };

            return cities;
        }
    }
}
