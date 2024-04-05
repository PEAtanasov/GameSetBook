using GameSetBook.Core.Models.Admin.Court;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface ICourtServiceAdmin
    {
        Task<CourtAdminEditFormModel> GetEditModelAsync(int id);

        Task<bool> ExistAsync(int id);

        Task EditAsync(CourtAdminEditFormModel model);

        Task AddAsync(CourtAdminCreateFormModel model);
    }
}
