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
    public class CountryServiceAdmin : ICountryServiceAdmin
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;


        public CountryServiceAdmin(IRepository repository, UserManager<ApplicationUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
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

        public async Task<bool> ExistById(int id)
        {
            return await repository.GetAllReadOnly<Country>()
                .AnyAsync(c => c.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var coutnry = await repository.GetAll<Country>()
                 .Where(country => country.Id == id)
                 .Include(country => country.Cities)
                 .ThenInclude(city => city.Clubs)
                 .ThenInclude(club => club.Courts)
                 .ThenInclude(court => court.Bookings)
                 .Include(country => country.Cities)
                 .ThenInclude(city => city.Clubs)
                 .ThenInclude(club => club.Reviews)
                 .IgnoreQueryFilters()
                 .FirstAsync();

            repository.RemoveRange(coutnry.Cities.SelectMany(c => c.Clubs.SelectMany(cl => cl.Reviews)));
            repository.RemoveRange(coutnry.Cities.SelectMany(c => c.Clubs.SelectMany(cl => cl.Courts.SelectMany(ct => ct.Bookings))));
            repository.RemoveRange(coutnry.Cities.SelectMany(c => c.Clubs.SelectMany(cl => cl.Courts)));
            repository.RemoveRange(coutnry.Cities.SelectMany(c => c.Clubs));
            repository.RemoveRange(coutnry.Cities);

            repository.HardDelete(coutnry);

            foreach (var club in coutnry.Cities.SelectMany(c=>c.Clubs))
            {
                var user = await userManager.FindByIdAsync(club.ClubOwnerId);

                await userManager.RemoveFromRoleAsync(user, ClubOwnerRole);
            }

            await repository.SaveChangesAsync();
        }

        public async Task<CountryDetailsAdminViewModel> GetCountryDetailAsync(int id)
        {
            var model = await repository.GetAllReadOnly<Country>()
                .Where(c => c.Id == id)
                .Select(c => new CountryDetailsAdminViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Cities = c.Cities.Select(ct => new CityAdminServiceModel()
                    {
                        Id = ct.Id,
                        Name = ct.Name,
                        CountryName = c.Name
                    }),
                    Clubs = c.Cities.SelectMany(ct => ct.Clubs.Select(cl => new ClubSimpleAdminViewModel()
                    {
                        Id = cl.Id,
                        Name = cl.Name,
                        City = cl.City.Name
                    })),
                })
                .FirstAsync();

            return model;
        }
    }
}
