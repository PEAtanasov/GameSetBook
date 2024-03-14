using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Court;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Core.Services
{
    public class CourtService : ICourtService
    {
        public readonly IRepository repository;
        public CourtService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateInitialAsync(CourtFormModel[] model)
        {
            int clubId = model[0].ClubId;

            var club = await repository.GetByIdAsync<Club>(clubId) ?? throw new ArgumentException("The club does not exist");
            
            if (await ClubHasCourts(clubId))
            {
                throw new ArgumentException("The club has existing courts");
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
            bool hascourts= await repository.GetAllReadOnly<Court>()
                .Where(c => c.ClubId == clubId)
                .AnyAsync();

            return hascourts;
        }
    }

}
