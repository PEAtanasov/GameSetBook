using GameSetBook.Core.Models.Club;
using GameSetBook.Infrastructure.Common;

namespace GameSetBook.Core.Contracts
{
    public interface IClubService
    {
       Task<IEnumerable<ClubViewModel>> GetAllClubsAsync();
    }
}
