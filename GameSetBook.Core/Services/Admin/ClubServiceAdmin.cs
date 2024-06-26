﻿using GameSetBook.Common.Enums.EnumExtensions;
using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Enums;
using GameSetBook.Core.Models.Admin.Club;
using GameSetBook.Core.Models.Admin.Court;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using static GameSetBook.Common.ValidationConstatns.DateTimeFormats;

using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace GameSetBook.Core.Services.Admin
{
    public class ClubServiceAdmin : IClubServiceAdmin
    {
        private readonly IRepository repository;

        public ClubServiceAdmin(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<PendingClubViewModel>> AllPendingClubsAsync()
        {
            return await repository.GetAllReadOnly<Club>()
                .Where(c => c.IsAproovedByAdmin == false)
                .Select(c => new PendingClubViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    NumberOfCourts = c.Courts.Count,
                    RegisteredOn = c.RegisteredOn,
                    City = c.City.Name,
                    ClubOwner = c.ClubOwner.UserName,
                    ClubOwnerStatus = !string.IsNullOrWhiteSpace(c.ClubOwner.UserName)
                })
                .ToListAsync();
        }

        public async Task<ClubDetailsAdminViewModel> GetPendingClubDetailsAsync(int id)
        {
            var club = await repository.GetAllReadOnly<Club>()
                .Where(c => c.Id == id && c.IsAproovedByAdmin == false)
                .Select(c => new ClubDetailsAdminViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Email = c.Email,
                    HasParking = c.HasParking,
                    HasShop = c.HasShop,
                    HasShower = c.HasShower,
                    ClubOwner = c.ClubOwner.UserName,
                    Address = c.Address,
                    City = c.City.Name,
                    WorkingTimeStart = c.WorkingTimeStart,
                    WorkingTimeEnd = c.WorkingTimeEnd,
                    IsClubOwnerActive = !string.IsNullOrWhiteSpace(c.ClubOwner.UserName),
                    LogoUrl = c.LogoUrl,
                    PhoneNumber = c.PhoneNumber,
                    NumberOfCoaches = c.NumberOfCoaches,
                    NumberOfCourts = c.NumberOfCourts,
                    RegisteredOn = c.RegisteredOn,
                    ClubOwnerId = c.ClubOwnerId,
                    IsAproovedByAdmin = c.IsAproovedByAdmin,
                    Courts = c.Courts.Select(ct => new CourtAdminViewModel()
                    {
                        Id = ct.Id,
                        ClubId = ct.ClubId,
                        IsActive = ct.IsActive,
                        IsIndoor = ct.IsIndoor,
                        IsLighted = ct.IsLighted,
                        Name = ct.Name,
                        PricePerHour = ct.PricePerHour,
                        Surface = ct.Surface.GetDisplayName()
                    })
                }).FirstAsync();

            return club;
        }

        public async Task<ClubDetailsAdminViewModel> GetClubDetailsAsync(int id)
        {
            var club = await repository.GetAllWithDeletedReadOnly<Club>()
                .Where(c => c.Id == id)
                .Select(c => new ClubDetailsAdminViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Email = c.Email,
                    HasParking = c.HasParking,
                    HasShop = c.HasShop,
                    HasShower = c.HasShower,
                    ClubOwner = c.ClubOwner.UserName,
                    Address = c.Address,
                    City = c.City.Name,
                    WorkingTimeStart = c.WorkingTimeStart,
                    WorkingTimeEnd = c.WorkingTimeEnd,
                    IsClubOwnerActive = !string.IsNullOrWhiteSpace(c.ClubOwner.UserName),
                    LogoUrl = c.LogoUrl,
                    PhoneNumber = c.PhoneNumber,
                    NumberOfCoaches = c.NumberOfCoaches,
                    NumberOfCourts = c.NumberOfCourts,
                    RegisteredOn = c.RegisteredOn,
                    ClubOwnerId = c.ClubOwnerId,
                    IsAproovedByAdmin = c.IsAproovedByAdmin,
                    Courts = c.Courts.Select(ct => new CourtAdminViewModel()
                    {
                        Id = ct.Id,
                        ClubId = ct.ClubId,
                        IsActive = ct.IsActive,
                        IsIndoor = ct.IsIndoor,
                        IsLighted = ct.IsLighted,
                        Name = ct.Name,
                        PricePerHour = ct.PricePerHour,
                        Surface = ct.Surface.GetDisplayName()
                    })
                }).FirstAsync();

            return club;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.GetAllWithDeletedReadOnly<Club>().AnyAsync(c => c.Id == id);
        }

        public async Task<bool> ExistByNameAsync(string name)
        {
            return await repository.GetAllWithDeletedReadOnly<Club>().AnyAsync(c => c.Name.ToLower() == name.ToLower());
        }

        public async Task<bool> ExsitAnotherClubWhitNameAsync(int id, string name)
        {
            return await repository.GetAllWithDeletedReadOnly<Club>().AnyAsync(c => c.Name.ToLower() == name.ToLower() && c.Id != id);
        }

        public async Task<bool> IsClubApprovedAsync(int id)
        {
            var club = await repository.GetAllReadOnly<Club>().FirstAsync(c => c.Id == id);

            return club.IsAproovedByAdmin;
        }

        public async Task<bool> IsDeletedAsync(int id)
        {
            var club = await repository.GetAllWithDeletedReadOnly<Club>()
                .Where(c => c.Id == id)
                .FirstAsync();

            return club.IsDeleted;
        }

        public async Task<string> ApproveAsync(int id)
        {
            var club = await repository.GetAll<Club>()
                .Include(c => c.Courts)
                .FirstAsync(c => c.Id == id);

            foreach (var court in club.Courts)
            {
                court.IsActive = true;
            }

            club.IsAproovedByAdmin = true;

            string clubOwnerId = club.ClubOwnerId;

            await repository.SaveChangesAsync();

            return clubOwnerId;
        }

        public async Task DeleteAsync(int id)
        {
            var club = await repository.GetAll<Club>()
                .Include(c => c.Courts)
                .FirstAsync(c => c.Id == id);

            foreach (var court in club.Courts)
            {
                court.IsActive = false;
            }

            club.IsAproovedByAdmin = false;

            repository.Delete(club);

            await repository.SaveChangesAsync();
        }

        public async Task HardDeleteAsync(int id)
        {
            var club = await repository.GetAllWithDeleted<Club>()
               .Include(c => c.Reviews)
               .Include(c => c.Courts)
               .ThenInclude(ct => ct.Bookings)
               .IgnoreQueryFilters()
               .FirstAsync(c => c.Id == id);

            repository.RemoveRange(club.Reviews);
            repository.RemoveRange(club.Courts.SelectMany(ct => ct.Bookings));
            repository.RemoveRange(club.Courts);

            repository.HardDelete(club);

            await repository.SaveChangesAsync();
        }

        public async Task<ClubEditFormModel> GetClubForEditAsync(int id)
        {
            var club = await repository.GetAllWithDeletedReadOnly<Club>()
                .Where(c => c.Id == id)
                .Include(c => c.Reviews)
                .Select(c => new ClubEditFormModel()
                {
                    Id = c.Id,
                    Address = c.Address,
                    CityId = c.CityId,
                    ClubOwnerName = c.ClubOwner.UserName,
                    Description = c.Description,
                    Name = c.Name,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    HasParking = c.HasParking,
                    HasShop = c.HasShop,
                    HasShower = c.HasShower,
                    LogoUrl = c.LogoUrl,
                    WorkingTimeEnd = c.WorkingTimeEnd,
                    WorkingTimeStart = c.WorkingTimeStart,
                    NumberOfCoaches = c.NumberOfCoaches,
                    NumberOfCourts = c.NumberOfCourts,
                    NumberOfActiveCourts = c.Courts.Where(ct => ct.IsActive == true).Count(),
                    IsAproovedByAdmin = c.IsAproovedByAdmin,
                    IsDeleted = c.IsDeleted,
                    DeletedOn = c.DeletedOn,
                    RegisteredOn = c.RegisteredOn,
                    Rating = c.Rating
                }).FirstAsync();

            return club;
        }

        public async Task EditAsync(ClubEditFormModel model)
        {
            var club = await repository.GetAllWithDeleted<Club>()
               .Where(c => c.Id == model.Id)
               .FirstAsync();

            club.Address = model.Address;
            club.CityId = model.CityId;
            club.PhoneNumber = model.PhoneNumber;
            club.NumberOfCoaches = model.NumberOfCoaches;
            club.Email = model.Email;
            club.Description = model.Description;
            club.Name = model.Name;
            club.LogoUrl = model.LogoUrl;
            club.WorkingTimeStart = model.WorkingTimeStart;
            club.WorkingTimeEnd = model.WorkingTimeEnd;
            club.HasParking = model.HasParking;
            club.HasShop = model.HasShop;
            club.HasShower = model.HasShower;

            await repository.SaveChangesAsync();
        }

        public async Task<AllClubsAdminSortingModel> GetClubSortingModelAsync(AllClubsAdminSortingModel model)
        {
            var clubsToSort = repository.GetAllWithDeletedReadOnly<Club>().Where(c=>c.Courts.Count()>0);

            if (model.Country != null)
            {
                clubsToSort = clubsToSort.Where(c => c.City.Country.Name == model.Country);
            }

            if (model.City != null)
            {
                clubsToSort = clubsToSort.Where(c => c.City.Name == model.City);
            }

            if (!string.IsNullOrEmpty(model.SearchTerm))
            {
                clubsToSort = clubsToSort.Where(c => c.Name.ToLower().Contains(model.SearchTerm.ToLower()));
            }

            clubsToSort = model.ClubSorting switch
            {
                ClubSorting.PriceAscending => clubsToSort.OrderBy(c => c.Courts.Select(c => c.PricePerHour).OrderBy(ct => ct).First()),
                ClubSorting.PriceDescending => clubsToSort.OrderByDescending(c => c.Courts.Select(c => c.PricePerHour).OrderBy(ct => ct).First()),
                ClubSorting.NumberOfCourtsAscending => clubsToSort.OrderBy(c => c.NumberOfCourts),
                ClubSorting.NumberOfCourtsDescending => clubsToSort.OrderByDescending(c => c.NumberOfCourts),
                ClubSorting.RatingAscending => clubsToSort.OrderBy(c => c.Reviews.Any() ? c.Reviews.Average(r => r.Rate) : 0),
                ClubSorting.RatingDescending => clubsToSort.OrderByDescending(c => c.Reviews.Any() ? c.Reviews.Average(r => r.Rate) : 0),
                _ => clubsToSort.OrderByDescending(c => c.Id)
            };

            clubsToSort = model.ClubStatusSorting switch
            {
                ClubStatusSorting.OnlyDeleted => clubsToSort.Where(c => c.IsDeleted == true),
                ClubStatusSorting.OnlyNotDeleted => clubsToSort.Where(c => c.IsDeleted == false),
                ClubStatusSorting.OnlyApproved => clubsToSort.Where(c => c.IsAproovedByAdmin == true),
                ClubStatusSorting.OnlyNotAprooved => clubsToSort.Where(c => c.IsAproovedByAdmin == false),
                _ => clubsToSort
            };

            int totalClubs = await clubsToSort.CountAsync();
            var maxPage = Math.Ceiling((double)totalClubs / model.ClubsPerPage);

            var currentPage = model.CurrentPage;

            if (currentPage > maxPage)
            {
                currentPage = (int)maxPage;
            }
            if (currentPage <= 0)
            {
                currentPage = 1;
            }

            var clubs = await clubsToSort
                .Include(c => c.Reviews)
                .Skip((currentPage - 1) * model.ClubsPerPage)
                .Take(model.ClubsPerPage)
                .Select(c => new ClubAdminServiceViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    CityName = c.City.Name,
                    LogoUrl = c.LogoUrl,
                    Price = c.Courts.OrderBy(c => c.PricePerHour).Select(c => c.PricePerHour).FirstOrDefault(),
                    NumberofCourts = c.NumberOfCourts,
                    WorkingTimeStart = c.WorkingTimeStart,
                    WorkingTimeEnd = c.WorkingTimeEnd,
                    Rating = c.Rating,
                    ClubOwner = c.ClubOwner.UserName,
                    CountryName = c.City.Country.Name,
                    IsApproved = c.IsAproovedByAdmin,
                    IsDeleted = c.IsDeleted,
                    RegisteredOn = c.RegisteredOn,
                })
                .ToListAsync();

            model.Clubs = clubs;
            model.TotalClubCount = totalClubs;

            return model;

        }

        public async Task<ClubHardDeleteAdminServiceModel> GetHardDeleteModelAsync(int id)
        {
            var model = await repository.GetAllWithDeletedReadOnly<Club>()
                .Where(c => c.Id == id)
                .Select(c => new ClubHardDeleteAdminServiceModel()
                {
                    Id = c.Id,
                    ClubOwnerEmail = c.ClubOwner.Email,
                    ClubOwnerId = c.ClubOwnerId,
                    LogoUrl = c.LogoUrl,
                    Name = c.Name,
                    TotalCourtsCount = c.Courts.Count(),
                    TotalReviewsCount = c.Reviews.Count(),
                    TotalBookingsCount = c.Courts.SelectMany(ct => ct.Bookings).Count()
                })
                .FirstAsync();

            return model;
        }

        public async Task<string> GetClubNameAsync(int clubId)
        {
            var club = await repository.GetAllReadOnly<Club>()
                .FirstAsync(c => c.Id == clubId);

            return club.Name;
        }

        public async Task CreateAsync(ClubAdminCreateFormModel model)
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
                IsAproovedByAdmin = false
            };

            if (string.IsNullOrWhiteSpace(model.LogoUrl))
            {
                model.LogoUrl = Common.ImageSource.DefaultClubLogoUrl;
            }

            await repository.AddAsync(club);
            await repository.SaveChangesAsync();
        }

        public async Task<int> GetClubIdByNameAsync(string name)
        {
            var club = await repository.GetAllReadOnly<Club>().FirstAsync(c => c.Name == name);

            return club.Id;
        }

        public async Task<ClubScheduleAdminServiceModel> GetClubScheduleModelAsync(int id, DateTime date)
        {
            string parsedDate = date.ToString(DateOnlyFormat);
            date = DateTime.ParseExact(parsedDate, DateOnlyFormat, CultureInfo.InvariantCulture);

            var club = await repository.GetAllReadOnly<Club>()
                .Where(c => c.Id == id)
                .Select(c => new ClubScheduleAdminServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Date = date,
                    WorkingHourEnd = c.WorkingTimeEnd,
                    WorkingHourStart = c.WorkingTimeStart,
                })
                .FirstAsync();

            return club;
        }

        public async Task<ClubMenuViewModel> GetClubMenuAsync(int id)
        {
            var model = await repository.GetAllWithDeleted<Club>()
                .Where(c => c.Id == id)
                .Select(c => new ClubMenuViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsApproved = c.IsAproovedByAdmin,
                    IsDeleted = c.IsDeleted
                })
                .FirstAsync();

            return model;
        }
    }
}
