using GameSetBook.Core.Models.Admin.Court;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface ICourtServiceAdmin
    {
        Task<CourtAdminFormModel> GetEditModelAsync(int id);

        Task<bool> ExistAsync(int id);

        Task EditAsync(CourtAdminFormModel model);
    }
}
