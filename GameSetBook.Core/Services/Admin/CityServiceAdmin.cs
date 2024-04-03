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

        public async Task<IEnumerable<CityAdminViewModel>> GetAllCitiesAsync()
        {
            var cities = await repository.GetAllReadOnly<City>()
                .Select(c => new CityAdminViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    CountryName = c.Country.Name
                })
                .ToListAsync();

            return cities;
        }
    }
}
