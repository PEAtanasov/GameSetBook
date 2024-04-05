using GameSetBook.Core.Models.Admin.Club;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface IClubServiceAdmin
    {
        Task<IEnumerable<PendingClubViewModel>> AllPendingClubsAsync();

        Task<ClubDetailsAdminViewModel> GetPendingClubDetailsAsync(int id);

        Task<ClubDetailsAdminViewModel> GetClubDetailsAsync(int id);

        Task<ClubEditFormModel> GetClubForEditAsync(int id);

        Task EditAsync(ClubEditFormModel model);

        Task<bool> ExistAsync(int id);

        Task<bool> ClubExistIncludingSoftDeletedAsync(int id);

        Task<bool> IsClubApproved(int id);

        Task<string> ApproveAsync(int id);

        Task<string> DeleteAsync(int id);

        Task HardDelete(int id);

        Task<AllClubsAdminSortingModel> GetClubSortingModel(AllClubsAdminSortingModel model);

        Task<string> GetClubNameAsync(int clubId);
    }
}
