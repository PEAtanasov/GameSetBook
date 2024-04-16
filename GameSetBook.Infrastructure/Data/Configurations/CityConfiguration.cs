using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(CitySeed());
        }

        private static IList<City> CitySeed()
        {
            var sofia = new City()
            {
                Id = 1,
                Name = "Sofia",
                CountryId = 1
            };
            var varna = new City()
            {
                Id = 2,
                Name = "Varna",
                CountryId = 1
            };
            var kavarna = new City()
            {
                Id = 3,
                Name = "Kavarna",
                CountryId = 1
            };
            var bucharest = new City()
            {
                Id = 4,
                Name = "Bucharest",
                CountryId = 2
            };
            var constanta = new City()
            {
                Id = 5,
                Name = "Constanta",
                CountryId = 2
            };
            var athens = new City()
            {
                Id = 6,
                Name = "Athens",
                CountryId = 3
            };

            var cities = new List<City>()
            {
                sofia,varna,kavarna,bucharest,constanta,athens
            };

            return cities;
        }

    }
}
