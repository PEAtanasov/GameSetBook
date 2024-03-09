using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(SeedCountries());
        }

        private IList<Country> SeedCountries()
        {
            var countries = new List<Country>()
            {
                new Country
                {
                    Id = 1,
                    Name = "Bulgaria"
                },

                new Country
                {
                    Id = 2,
                    Name = "Romania"
                }
            };

            return countries;
        }
    }
}
