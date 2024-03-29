﻿using Microsoft.EntityFrameworkCore;

using GameSetBook.Core.Contracts;
using GameSetBook.Core.Enums;
using GameSetBook.Core.Models.City;
using GameSetBook.Core.Models.Club;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Core.Services
{
    public class ClubService : IClubService
    {
        private readonly IRepository repository;

        public ClubService(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<ClubServiceViewModel>> GetAllClubsAsync()
        {
            var model = await repository.GetAllReadOnly<Club>()
                .Where(c => c.IsAproovedByAdmin)
                .Include(c => c.ClubReviews)
                .Select(c => new ClubServiceViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    CityName = c.City.Name,
                    LogoUrl = c.LogoUrl,
                    Prcie = c.Courts.Where(c => c.IsActive)
                        .OrderBy(c => c.PricePerHour)
                        .Select(c => c.PricePerHour)
                        .FirstOrDefault(),
                    NumberofCourts = c.NumberOfCourts,
                    WorkingTimeStart = c.WorkingTimeStart,
                    WorkingTimeEnd = c.WorkingTimeEnd,
                    Rating = c.Rating
                }).ToListAsync();

            return model;
        }

        public async Task<ClubDetailsAndInfoViewModel> GetClubDetailsAndInfoAsync(int id)
        {
            var details = await GetClubDetailsAsync(id);

            var info = await GetClubIfnoAsync(id);

            var model = new ClubDetailsAndInfoViewModel()
            {
                ClubId = id,
                Info = info,
                Details = details
            };

            return model;
        }

        public async Task<ClubDetailsViewModel> GetClubDetailsAsync(int id)
        {
            var club = await repository.GetAllReadOnly<Club>()
                .Where(c => c.IsAproovedByAdmin)
                .Include(c => c.ClubReviews)
                .FirstAsync(c => c.Id == id);

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
                WorkingTimeStart = club.WorkingTimeStart,
                WorkingTimeEnd = club.WorkingTimeEnd,
                Rating = club.Rating
            };

            return model;
        }

        public async Task<ClubInfoViewModel> GetClubIfnoAsync(int id)
        {
            var club = await repository.GetAllReadOnly<Club>()
                .Include(c => c.City)
                .ThenInclude(ct => ct.Country)
                .FirstAsync(c => c.Id == id);

            var model = new ClubInfoViewModel()
            {
                Id = club.Id,
                Email = club.Email,
                Logourl = club.LogoUrl,
                Name = club.Name,
                PhoneNumber = club.PhoneNumber,
                Address = club.Address,
                CityName = club.City.Name,
                CountryName = club.City.Country.Name
            };

            return model;
        }

        public async Task CreateAsync(ClubFormModel model)
        {
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
                HasShower = model.HasShower,
                NumberOfCoaches = model.NumberOfCoaches,
                NumberOfCourts = model.NumberOfCourts,
                PhoneNumber = model.PhoneNumber,
                WorkingTimeStart = model.WorkingTimeStart,
                WorkingTimeEnd = model.WorkingTimeEnd,
                LogoUrl = model.LogoUrl,
                RegisteredOn = DateTime.Now,
            };

            if (String.IsNullOrWhiteSpace(model.LogoUrl))
            {
                model.LogoUrl = Common.ImageSource.DefaultClubLogoUrl;
            }

            await repository.AddAsync(club);
            await repository.SaveChangesAsync();
        }

        public async Task<ClubFormModel> GetEditFormModelAsync(int clubId)
        {
            var club = await repository.GetAllReadOnly<Club>()
                .Where(c => c.Id == clubId)
                .Select(c => new ClubFormModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    CityId = c.CityId,
                    Description = c.Description,
                    Email = c.Email,
                    HasParking = c.HasParking,
                    HasShower = c.HasShower,
                    HasShop = c.HasShop,
                    ClubOwnerId = c.ClubOwnerId,
                    LogoUrl = c.LogoUrl,
                    NumberOfCoaches = c.NumberOfCoaches,
                    PhoneNumber = c.PhoneNumber,
                    WorkingTimeStart = c.WorkingTimeStart,
                    WorkingTimeEnd = c.WorkingTimeEnd
                })
                .FirstAsync();

            return club;
        }

        public async Task EditAsync(ClubFormModel model)
        {
            var club = await repository.GetAll<Club>()
               .Where(c => c.Id == model.Id)
               .FirstAsync();

            club.Name = model.Name;
            club.Description = model.Description;
            club.Address = model.Address;
            club.CityId = model.CityId;
            club.HasParking = model.HasParking;
            club.Email = model.Email;
            club.HasShop = model.HasShop;
            club.HasShower = model.HasShower;
            club.NumberOfCoaches = model.NumberOfCoaches;
            club.PhoneNumber = model.PhoneNumber;
            club.WorkingTimeStart = model.WorkingTimeStart;
            club.WorkingTimeEnd = model.WorkingTimeEnd;
            club.LogoUrl = model.LogoUrl;

            await repository.SaveChangesAsync();
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

        public async Task<int> GetClubIdByNameAsync(string name)
        {
            var club = await repository.GetAllReadOnly<Club>().FirstAsync(c => c.Name == name);

            return club.Id;
        }

        public async Task<bool> ClubExsitAsync(int id)
        {
            var club = await repository.GetAllReadOnly<Club>().FirstOrDefaultAsync(c => c.Id == id);

            if (club == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> ClubExsitByNameAsync(string name)
        {
            return await repository.GetAllWithDeletedReadOnly<Club>().AnyAsync(c => c.Name.ToLower() == name.ToLower());
        }

        public async Task<bool> IsClubAprooved(int id)
        {
            var club = await repository.GetAllReadOnly<Club>().FirstAsync(c => c.Id == id);

            return club.IsAproovedByAdmin;
        }

        public async Task<ClubSortingServiceModel> GetClubSortingServiceModelAsync(
            string? city = null,
            string? searchTerm = null,
            ClubSorting clubSorting = ClubSorting.Newest,
            int currentPage = 1,
            int clubsPerPage = 1)
        {

            var clubsToSort = repository.GetAllReadOnly<Club>()
                .Where(c => c.IsAproovedByAdmin);


            if (city != null)
            {
                clubsToSort = clubsToSort.Where(c => c.City.Name == city);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                clubsToSort = clubsToSort.Where(c => c.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            clubsToSort = clubSorting switch
            {
                ClubSorting.PriceAscending => clubsToSort.OrderBy(c => c.Courts.Select(c => c.PricePerHour).OrderBy(ct => ct).First()),
                ClubSorting.PriceDescending => clubsToSort.OrderByDescending(c => c.Courts.Select(c => c.PricePerHour).OrderBy(ct => ct).First()),
                ClubSorting.NumberOfCourtsAscending => clubsToSort.OrderBy(c => c.NumberOfCourts),
                ClubSorting.NumberOfCourtsDescending => clubsToSort.OrderByDescending(c => c.NumberOfCourts),
                ClubSorting.RatingAscending => clubsToSort.OrderBy(c => c.ClubReviews.Any() ? c.ClubReviews.Average(r => r.Rate) : 0),
                ClubSorting.RatingDescending => clubsToSort.OrderByDescending(c => c.ClubReviews.Any() ? c.ClubReviews.Average(r => r.Rate) : 0),
                _ => clubsToSort.OrderByDescending(c => c.Id)
            };

            int totalClubs = await clubsToSort.CountAsync();
            var maxPage = Math.Ceiling((double)totalClubs / clubsPerPage);

            if (currentPage > maxPage)
            {
                currentPage = (int)maxPage;
            }
            if (currentPage <= 0)
            {
                currentPage = 1;
            }

            var clubs = await clubsToSort
                .Include(c => c.ClubReviews)
                .Skip((currentPage - 1) * clubsPerPage)
                .Take(clubsPerPage)
                .Select(c => new ClubServiceViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    CityName = c.City.Name,
                    LogoUrl = c.LogoUrl,
                    Prcie = c.Courts.Where(c => c.IsActive).OrderBy(c => c.PricePerHour).Select(c => c.PricePerHour).FirstOrDefault(),
                    NumberofCourts = c.NumberOfCourts,
                    WorkingTimeStart = c.WorkingTimeStart,
                    WorkingTimeEnd = c.WorkingTimeEnd,
                    Rating = c.Rating
                })
                .ToListAsync();

            return new ClubSortingServiceModel()
            {
                Clubs = clubs,
                TotalClubCount = totalClubs
            };
        }

        public async Task<bool> ClubWithOwnerIdExistAsync(string ownerId)
        {
            return await repository.GetAllReadOnly<Club>().AnyAsync(c => c.ClubOwnerId == ownerId);
        }

        public async Task<bool> IsTheOwnerOfTheClubAsync(int clubId, string UserId)
        {
            var club = await repository.GetAllReadOnly<Club>().FirstAsync(c => c.Id == clubId);

            return club.ClubOwnerId == UserId;
        }

        public async Task<int> GetClubIdByOwnerIdAsync(string ownerId)
        {
            var club = await repository.GetAllReadOnly<Club>().FirstAsync(c => c.ClubOwnerId == ownerId);

            return club.Id;
        }

        public async Task<bool> ClubHasCourts(int clubId)
        {
            return await repository.GetAllReadOnly<Court>()
                .Where(c => c.ClubId == clubId)
                .AnyAsync();
        }

        public async Task<int> NumberOfCourtsAsync(int clubId)
        {
            var club = await repository.GetAllReadOnly<Club>()
                .FirstAsync(c => c.Id == clubId);

            return club.NumberOfCourts;
        }
    }
}
