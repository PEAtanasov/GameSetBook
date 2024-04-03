using Microsoft.EntityFrameworkCore;

using GameSetBook.Core.Models.City;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using GameSetBook.Core.Contracts;

namespace GameSetBook.Core.Services
{
    public class CityService : ICityService
    {
        private readonly IRepository repository;

        public CityService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<CityServiceModel>> GetAllCitiesAsync()
        {
            var cities = await repository.GetAllReadOnly<City>()
                .Select(c => new CityServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    CountryName = c.Country.Name
                }).ToListAsync();

            return cities;
        }
    }
}
