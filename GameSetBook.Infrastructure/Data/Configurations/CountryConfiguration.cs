using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(CountrySeed());
        }
        private static IList<Country> CountrySeed()
        {
            var bulgaria = new Country()
            {
                Id = 1,
                Name = "Bulgaria",
            };
            var romania = new Country()
            {
                Id = 2,
                Name = "Romania",
            };
            var greece = new Country()
            {
                Id = 3,
                Name = "Greece",
            };
            var countries = new List<Country>()
            {
                bulgaria,romania,greece
            };

            return countries;
        }
    }
}
