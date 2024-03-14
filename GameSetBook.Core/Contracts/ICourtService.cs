using GameSetBook.Core.Models.Court;

namespace GameSetBook.Core.Contracts
{
    public interface ICourtService
    {
        Task<bool> ClubHasCourts(int clubId);
        Task CreateInitialAsync(CourtFormModel[] model);
    }
}
