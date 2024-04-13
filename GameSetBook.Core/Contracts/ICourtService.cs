using GameSetBook.Core.Models.Court;

namespace GameSetBook.Core.Contracts
{
    public interface ICourtService
    {
        Task CreateInitialAsync(CourtCreateFormModel[] model);

        Task AddCourtAsync(CourtCreateFormModel model);

        Task EditAsync(CourtEditFormModel model);

        Task<CourtEditFormModel> GetCourtEditFormModelAsync(int courtId);

        Task<IEnumerable<CourtScheduleViewModel>> GetAllCourtsScheduleAsync(int clubId, DateTime date);

        Task<IEnumerable<CourtDetailsViewModel>> GetAllCourtsDetailsAsync(int clubId);

        Task<bool> ExistAsync(int id);

        Task<decimal> GetPriceAsync(int id);

        Task<bool> IsCourtInClubOfTheOwnerAsync(int courtId, string UserId);

        Task ChangeStatusAsync(int id);
    }
}
