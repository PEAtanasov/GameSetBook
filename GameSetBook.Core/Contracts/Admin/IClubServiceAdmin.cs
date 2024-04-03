using GameSetBook.Core.Models.Admin.Club;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface IClubServiceAdmin
    {
        Task<IEnumerable<PendingClubViewModel>> AllPendingClubsAsync();

        Task<PendingClubDetailsViewModel> GetPendingClubDetailsAsync(int id);

        Task<ClubEditFormModel> GetClubForEditAsync(int id);

        Task EditAsync(ClubEditFormModel model);

        Task<bool> ClubExistAsync(int id);

        Task<bool> ClubExistIncludingSoftDeletedAsync(int id);

        Task<bool> IsClubApproved(int id);

        Task<string> ApproveAsync(int id);

        Task<string> DeleteAsync(int id);

        Task HardDelete(int id);
    }
}
