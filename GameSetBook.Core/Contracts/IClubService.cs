using GameSetBook.Core.Models.Club;
using GameSetBook.Infrastructure.Common;

namespace GameSetBook.Core.Contracts
{
    public interface IClubService
    {
        Task<IEnumerable<ClubViewModel>> GetAllClubsAsync();
        Task<ClubDetailsViewModel> GetClubDetailsAsync(int id);
        Task<ClubInfoViewModel> GetClubIfno(int id);
        Task<bool> ClubExsitAsync(int id);
    }
}
