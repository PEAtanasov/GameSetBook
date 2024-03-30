using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Club;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Core.Services.Admin
{
    public class ClubServiceAdmin : IClubServiceAdmin
    {
        private readonly IRepository repository;

        public ClubServiceAdmin(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<PendingClubViewModel>> AllPendingClubs()
        {
            return await repository.GetAllReadOnly<Club>()
                .Where(c => c.IsAproovedByAdmin == false)
                .Select(c => new PendingClubViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    NumberOfCourts = c.NumberOfCourts,
                    RegisteredOn = c.RegisteredOn,
                    City = c.City.Name,
                    ClubOwner = c.ClubOwner.UserName,
                    ClubOwnerStatus = c.ClubOwner.UserName != null
                })
                .ToListAsync();
        }
    }
}
