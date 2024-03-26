using GameSetBook.Core.Models.Court;

namespace GameSetBook.Core.Contracts
{
    public interface ICourtService
    {
        Task CreateInitialAsync(CourtCreateFormModel[] model);

        Task<CourtEditFormModel> GetCourtEditFormModelAsync(int courtId);

        Task Edit(CourtEditFormModel model);

        Task<IEnumerable<CourtScheduleViewModel>> GetAllCourtsScheduleAsync(int clubId, DateTime date);

        Task<IEnumerable<CourtDetailsViewModel>> GetAllCourtsDetails(int clubId);

        Task<bool> CourtExist(int id);

        Task<decimal> GetPrice(int id);

        Task<bool> IsCourtInOwnerClub(int courtId, string UserId);
    }
}
