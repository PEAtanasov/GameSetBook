using GameSetBook.Core.Models.Admin.Club;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface IClubServiceAdmin
    {
        Task<IEnumerable<PendingClubViewModel>> AllPendingClubs();
    }
}
