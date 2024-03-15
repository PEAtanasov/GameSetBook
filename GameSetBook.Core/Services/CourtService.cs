using Microsoft.EntityFrameworkCore;

using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Court;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using static GameSetBook.Common.ErrorMessageConstants;

namespace GameSetBook.Core.Services
{
    public class CourtService : ICourtService
    {
        public readonly IRepository repository;

        public CourtService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateInitialAsync(CourtCreateFormModel[] model)
        {
            int clubId = model[0].ClubId;

            var club = await repository.GetByIdAsync<Club>(clubId) ?? throw new ArgumentException(ClubDoesNotExist);

            if (await ClubHasCourts(clubId))
            {
                throw new ArgumentException(ClubHasExistingCourts);
            }

            Court court;

            foreach (var c in model)
            {
                court = new Court()
                {
                    Name = c.Name,
                    ClubId = clubId,
                    IsLighted = c.IsLighted,
                    IsIndoor = c.IsIndoor,
                    PricePerHour = c.PricePerHour,
                    Surface = c.Surface,
                };

                club.Courts.Add(court);
            }

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ClubHasCourts(int clubId)
        {
            return await repository.GetAllReadOnly<Court>()
                .Where(c => c.ClubId == clubId)
                .AnyAsync();
        }

        public async Task<CourtEditFormModel> GetCourtEditFormModelAsync(int courtId)
        {
            var court = await repository.GetAllReadOnly<Court>()
                .Include(c=>c.Club)
                .FirstOrDefaultAsync(c => c.Id == courtId) 
                ?? throw new ArgumentException("The court does not exist");

            var model = new CourtEditFormModel()
            {
                Id = court.Id,
                Name = court.Name,
                ClubId = court.ClubId,
                IsIndoor = court.IsIndoor,
                IsLighted = court.IsLighted,
                PricePerHour = court.PricePerHour,
                Surface = court.Surface,
                IsActive = court.IsActive,
                ClubOwnerId = court.Club.ClubOwnerId
            };

            return model;
        }

        public async Task Edit(CourtEditFormModel model)
        {
            var courtToEdit = await repository.GetAll<Court>()
                .Where(c => c.Id == model.Id)
                .Include(c => c.Club)
                .FirstOrDefaultAsync();

            if (courtToEdit == null)
            {
                throw new ArgumentException("The court does not exist");
            }

            courtToEdit.Name = model.Name;
            courtToEdit.PricePerHour = model.PricePerHour;
            courtToEdit .Surface = model.Surface;
            courtToEdit.IsLighted= model.IsLighted;
            courtToEdit.IsIndoor = model.IsIndoor;
            courtToEdit.IsActive= model.IsActive;

            await repository.SaveChangesAsync();
        }
    }
}
