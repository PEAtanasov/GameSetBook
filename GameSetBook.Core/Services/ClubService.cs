﻿using Microsoft.EntityFrameworkCore;

using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Club;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using GameSetBook.Core.Models.City;

namespace GameSetBook.Core.Services
{
    public class ClubService : IClubService
    {
        private readonly IRepository repository;
        private readonly UserManager<IdentityUser> userManager;

        public ClubService(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<ClubViewModel>> GetAllClubsReadOnlyAsync()
        {
            var model = await repository.GetAllReadOnly<Club>()
                .Where(c => c.IsActive && c.IsAproovedByAdmin)
                .Include(c => c.City)
                .Include(c => c.Courts)
                .Include(c => c.ClubReviews)
                .Select(c => new ClubViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    CityName = c.City.Name,
                    LogoUrl = c.LogoUrl,
                    Prcie = c.Courts.OrderBy(c => c.PricePerHour).Select(c => c.PricePerHour).FirstOrDefault(),
                    NumberofCourts = c.NumberOfCourts,
                    WorkingTimeStart = c.WorkingTimeStart,
                    WorkingTimeEnd = c.WorkingTimeEnd,
                    //Rating = Math.Round(c.ClubReviews.Average(x => x.Rate),1),
                }).ToListAsync();

            return model;
        }

        public async Task<ClubDetailsViewModel> GetClubDetailsAsync(int id)
        {
            var club = await repository.GetByIdAsync<Club>(id);
            if (club == null)
            {
                throw new ArgumentException("The club does not exist");
            }

            var model = new ClubDetailsViewModel()
            {
                Id = club.Id,
                Name = club.Name,
                Description = club.Description,
                NumberOfCoaches = club.NumberOfCoaches,
                NumberOfCourts = club.NumberOfCourts,
                HasParking = club.HasParking,
                HasShower = club.HasShower,
                HasShop = club.HasShop,
                IsActive = club.IsActive,
                WorkingTimeStart = club.WorkingTimeStart,
                WorkingTimeEnd = club.WorkingTimeEnd,
                ClubInfo = await GetClubIfno(club.Id)
            };

            return model;
        }

        public async Task<ClubInfoViewModel> GetClubIfno(int id)
        {
            var club = await repository.GetAllReadOnly<Club>()
                .Include(c => c.City)
                .ThenInclude(ct => ct.Country)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (club == null)
            {
                throw new ArgumentException("The club does not exist");
            }
            var model = new ClubInfoViewModel()
            {
                Id = club.Id,
                Email = club.Email,
                Logourl = club.LogoUrl,
                Name = club.Name,
                PhoneNumber = club.PhoneNumber,
                Address = club.Address,
                CityName = club.City.Name,
                CountryName= club.City.Country.Name
            };

            return model;
        }

        public async Task<bool> ClubExsitAsync(int id)
        {
            var club = await repository.GetByIdAsync<Club>(id);

            if (club == null)
            {
                return false;
            }
            return true;
        }

        public async Task CreateAsync(ClubCreateFormModel model)
        {
            if (await repository.GetAllReadOnly<Club>().AnyAsync(c => c.Name == model.Name))
            {
                throw new ArgumentException("The event already exist");
            }

            var club = new Club()
            {
                Name = model.Name,
                Description = model.Description,
                Address = model.Address,
                CityId = model.CityId,
                ClubOwnerId = model.ClubOwnerId,
                HasParking = model.HasParking,
                Email = model.Email,
                HasShop = model.HasShop,
                IsActive = true,
                HasShower = model.HasShower,
                IsAproovedByAdmin = false,
                NumberOfCoaches = model.NumberOfCoaches,
                NumberOfCourts = model.NumberOfCourts,
                PhoneNumber = model.PhoneNumber,
                WorkingTimeStart = model.WorkingTimeStart,
                WorkingTimeEnd = model.WorkingTimeEnd,
                LogoUrl = model.LogoUrl ?? Common.ImageSource.DefaultClubLogoUrl,
                RegisteredOn = DateTime.Now,
            };

            await repository.AddAsync(club);
            await repository.SaveChangesAsync();
        }

        public async Task<int> GetClubByIdByName(string name)
        {
            var club = await repository.GetAllReadOnly<Club>().FirstOrDefaultAsync(c => c.Name == name);
            if (club==null)
            {
                throw new ArgumentException();
            }
            return club.Id;
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
