using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.City;
using GameSetBook.Core.Models.City;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Core.Services.Admin
{
    public class CityServiceAdmin : ICityServiceAdmin
    {
        private readonly IRepository repository;

        public CityServiceAdmin(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<CityAdminServiceModel>> GetAllCitiesAsync()
        {
            var cities = await repository.GetAllReadOnly<City>()
                .Select(c => new CityAdminServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    CountryName = c.Country.Name
                })
                .ToListAsync();

            return cities;
        }

        public async Task<bool> ExystByNameAsync(string name, int countryId)
        {
            return await repository.GetAllReadOnly<City>()
                .Where(c => c.CountryId == countryId)
                .AnyAsync(c => c.Name.ToUpper() == name.ToUpper());              
        }

        public async Task AddAsync(CityAddAdminFormModel model)
        {
            var city = new City()
            {
                Name = model.Name,
                CountryId = model.CountryId
            };

            await repository.AddAsync(city);

            await repository.SaveChangesAsync();
        }
    }
}
