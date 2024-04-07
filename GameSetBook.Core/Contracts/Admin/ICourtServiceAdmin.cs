using GameSetBook.Core.Models.Admin.Court;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface ICourtServiceAdmin
    {
        Task<CourtAdminEditFormModel> GetEditModelAsync(int id);

        Task<bool> ExistAsync(int id);

        Task EditAsync(CourtAdminEditFormModel model);

        Task AddAsync(CourtAdminCreateFormModel model);

        Task<CourtAdminViewModel> GetViewModelForDeleteAsync(int id);

        /// <summary>
        /// Hard delete court and its bookings from database. Sets club NumberOfCourts.
        /// </summary>
        /// <param name="id">Court identifier</param>
        /// <param name="clubId">Club identifier where the current court belongs</param>
        /// <returns></returns>
        Task DeleteAsync(int id, int clubId);

        Task CreateInitialAsync(CourtAdminCreateFormModel[] model);

        Task<IEnumerable<CourtScheduleAdminViewModel>> GetCourtScheduleAsync(int clubId, DateTime date, int workingHourStart, int workingHourEnd);
    }
}
