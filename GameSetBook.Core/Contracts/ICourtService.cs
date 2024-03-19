using GameSetBook.Core.Models.Court;

namespace GameSetBook.Core.Contracts
{
    public interface ICourtService
    {
        Task<bool> ClubHasCourts(int clubId);

        Task CreateInitialAsync(CourtCreateFormModel[] model);

        Task<CourtEditFormModel> GetCourtEditFormModelAsync(int courtId);

        Task Edit(CourtEditFormModel model);

        Task<IEnumerable<CourtScheduleViewModel>> GetAllCourtsScheduleAsync(int clubId, DateTime? date);
    }
}
