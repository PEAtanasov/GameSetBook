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
        public async Task<IEnumerable<CountryViewModel>> GetAllCountriesAsync()
        {
            var countries = await repository.GetAllReadOnly<Country>()
                .Select(c => new CountryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return countries;
        }
    }
}
