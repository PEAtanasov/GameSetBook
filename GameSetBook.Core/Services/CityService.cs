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

        public async Task<IEnumerable<CityViewModel>> GetAllCitiesAsync()
        {
            var cities = await repository.GetAllReadOnly<City>()
                .Select(c => new CityViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();

            return cities;
        }
    }
}
