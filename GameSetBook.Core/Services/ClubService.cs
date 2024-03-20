using Microsoft.EntityFrameworkCore;

using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.City;
using GameSetBook.Core.Models.Club;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using static GameSetBook.Common.ErrorMessageConstants;
using GameSetBook.Core.Models.Court;
using GameSetBook.Core.Enums;

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
                .Where(c => c.IsActive && c.IsAproovedByAdmin)
                //.Include(c => c.City)
                //.Include(c => c.Courts)
                .Include(c => c.ClubReviews)
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
                }).ToListAsync();

            return model;
        }

        public async Task<ClubDetailsViewModel> GetClubDetailsAsync(int id)
        {
            var club = await repository.GetAllReadOnly<Club>()
                .Where(c => c.IsAproovedByAdmin == true && c.IsActive == true)
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
                ClubInfo = await GetClubIfnoAsync(club.Id),
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

        public async Task<ClubFormModel> EditAsync(int clubId)
        {
            if (!await ClubExsitAsync(clubId))
            {
                throw new ArgumentException(ClubDoesNotExist);
            }

            var club = await repository.GetAllReadOnly<Club>()
                .Where(c => c.Id == clubId)
                .Include(c => c.Courts)
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
                    NumberOfCourts = c.NumberOfCourts,
                    PhoneNumber = c.PhoneNumber,
                    WorkingTimeStart = c.WorkingTimeStart,
                    WorkingTimeEnd = c.WorkingTimeEnd,
                    Courts = c.Courts.Select(ct => new CourtEditFormModel()
                    {
                        Id = ct.Id,
                        Name = ct.Name,
                        ClubId = ct.ClubId,
                        IsIndoor = ct.IsIndoor,
                        IsLighted = ct.IsLighted,
                        Surface = ct.Surface,
                        PricePerHour = ct.PricePerHour,
                        IsActive = ct.IsActive
                    }).ToList()
                })
                .FirstAsync();

            return club;
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

        public async Task<int> GetClubByIdByNameAsync(string name)
        {
            var club = await repository.GetAllReadOnly<Club>().FirstOrDefaultAsync(c => c.Name == name);
            if (club == null)
            {
                throw new ArgumentException();
            }
            return club.Id;
        }

        public async Task<bool> ClubExsitAsync(int id)
        {
            var club = await repository.GetByIdAsync<Club>(id);

            if (club == null)//|| club.IsActive == false || club.IsAproovedByAdmin == false)
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
                .Where(c => c.IsActive && c.IsAproovedByAdmin);


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

        public async Task<bool> HasClubWithOwnerId(string ownerId)
        {
            return await repository.GetAllReadOnly<Club>().AnyAsync(c => c.ClubOwnerId == ownerId);
        }
    }
}
