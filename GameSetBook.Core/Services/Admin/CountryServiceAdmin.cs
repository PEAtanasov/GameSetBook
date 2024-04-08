using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Country;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Core.Services.Admin
{
    public class CountryServiceAdmin : ICountryServiceAdmin
    {
        private readonly IRepository repository;

        public CountryServiceAdmin(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> ExistByNameAsync(string name)
        {
            return await repository.GetAllReadOnly<Country>()
                .AnyAsync(c => c.Name.ToUpper() == name.ToUpper());
        }

        public async Task AddAsync(CountryAddAdminFormModel model)
        {
            var country = new Country()
            {
                Name = model.Name,
            };

            await repository.AddAsync(country);

            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CountryAdminServiceModel>> GetAllCountriesAsync()
        {
            var countries = await repository.GetAllReadOnly<Country>()
                .Select(c => new CountryAdminServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return countries;
        }
    }
}
