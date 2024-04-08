using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Country;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRepository repository;

        public CountryService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<CountryServiceModel>> GetAllCountriesAsync()
        {
            var countries = await repository.GetAllReadOnly<Country>()
                .Select(c => new CountryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return countries;
        }
    }
}
