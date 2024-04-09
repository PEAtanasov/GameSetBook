using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.City;
using GameSetBook.Core.Models.Admin.Club;
using GameSetBook.Core.Models.Admin.Country;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static GameSetBook.Common.UserConstants;

namespace GameSetBook.Core.Services.Admin
{
    public class CityServiceAdmin : ICityServiceAdmin
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;

        public CityServiceAdmin(IRepository repository, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;   
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

        public async Task<bool> ExistById(int id)
        {
            return await repository.GetAllReadOnly<City>()
                .AnyAsync(c => c.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var city = await repository.GetAll<City>()
                .Where(c => c.Id == id)
                .Include(c => c.Clubs)
                .ThenInclude(club => club.Reviews)
                .Include(c => c.Clubs)
                .ThenInclude(club => club.Courts)
                .ThenInclude(court => court.Bookings)
                .IgnoreQueryFilters()
                .FirstAsync();

            repository.RemoveRange(city.Clubs.SelectMany(club => club.Reviews));
            repository.RemoveRange(city.Clubs.SelectMany(club => club.Courts.SelectMany(court => court.Bookings)));
            repository.RemoveRange(city.Clubs.SelectMany(club => club.Courts));
            repository.RemoveRange(city.Clubs);
            repository.HardDelete(city);

            foreach (var club in city.Clubs)
            {
                var user = await userManager.FindByIdAsync(club.ClubOwnerId);

                await userManager.RemoveFromRoleAsync(user, ClubOwnerRole);
            }

            await repository.SaveChangesAsync();
        }

        public async Task<CityDetailsAdminViewModel> GetCityDetailsAsync(int id)
        {
            var city = await repository.GetAll<City>()
                .Where(c => c.Id == id)
                .Select(c => new CityDetailsAdminViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Clubs = c.Clubs.Select(cl => new ClubSimpleAdminViewModel()
                    {
                        Id = cl.Id,
                        Name = cl.Name,
                    }),
                    Country = new CountryAdminServiceModel()
                    {
                        Id = c.CountryId,
                        Name = c.Country.Name
                    }
                })
                .FirstAsync();

            return city;
        }
    }
}
