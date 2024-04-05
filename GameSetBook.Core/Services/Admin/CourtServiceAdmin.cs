using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Court;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Core.Services.Admin
{
    public class CourtServiceAdmin : ICourtServiceAdmin
    {
        private readonly IRepository repository;

        public CourtServiceAdmin(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CourtAdminEditFormModel> GetEditModelAsync(int id)
        {
            var court = await repository.GetAllReadOnly<Court>()
                .Where(c => c.Id == id)
                .Select(c => new CourtAdminEditFormModel()
                {
                    Id = c.Id,
                    ClubId = c.ClubId,
                    ClubName = c.Club.Name,
                    Name = c.Name,
                    IsActive = c.IsActive,
                    IsIndoor = c.IsIndoor,
                    IsLighted = c.IsLighted,
                    PricePerHour = c.PricePerHour,
                    Surface = c.Surface
                })
                .FirstAsync();

            return court;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.GetAllReadOnly<Court>()
                .AnyAsync(c => c.Id == id);
        }

        public async Task EditAsync(CourtAdminEditFormModel model)
        {
            var court = await repository.GetAll<Court>()
                .FirstAsync(c => c.Id == model.Id);

            court.Name = model.Name;
            court.PricePerHour = model.PricePerHour;
            court.Surface = model.Surface;
            court.IsLighted = model.IsLighted;
            court.IsIndoor = model.IsIndoor;
            court.IsActive = model.IsActive;

            await repository.SaveChangesAsync();
        }

        public async Task AddAsync(CourtAdminCreateFormModel model)
        {
            var court = new Court()
            {
                Name = model.Name,
                PricePerHour = model.PricePerHour,
                Surface = model.Surface,
                IsLighted = model.IsLighted,
                ClubId = model.ClubId,
                IsIndoor = model.IsIndoor,
            };

            var club = await repository
               .GetAllWithDeleted<Club>()
               .FirstAsync(c => c.Id == model.ClubId);

            club.NumberOfCourts += 1;

            await repository.AddAsync(court);

            await repository.SaveChangesAsync();
        }
    }
}
