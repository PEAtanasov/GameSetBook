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
                .Include(c=>c.Courts)
                .Select(c => new ClubViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    CityName = c.City.Name,
                    LogoUrl = c.LogoUrl,
                    Prcie = c.Courts.OrderBy(c=>c.PricePerHour).Select(c=>c.PricePerHour).FirstOrDefault(),
                    NumberofCourts = c.NumberOfCourts,
                    WorkingTimeStart = c.WorkingTimeStart,
                    WorkingTimeEnd = c.WorkingTimeEnd,
                    //Rating = c.Rating,
                }).ToListAsync();

            return model;
        }
    }
}
