using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Club;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSetBook.Core.Services
{
    public class ClubService : IClubService
    {
        private readonly IRepository repository;

        public ClubService(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<ClubViewModel>> GetAllClubsAsync()
        {
            var model = await repository.GetAllReadOnly<Club>()
                .Where(c => c.IsActive && c.IsAproovedByAdmin)
                .Include(b => b.City)
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
                .Include(c=>c.City)
                .FirstOrDefaultAsync(c=>c.Id==id);

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
                FullAddress = club.Address,
                CityName = club.City.Name
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
    }
}
