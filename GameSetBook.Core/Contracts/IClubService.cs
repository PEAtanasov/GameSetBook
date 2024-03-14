using GameSetBook.Core.Models.City;
using GameSetBook.Core.Models.Club;
using GameSetBook.Infrastructure.Common;

namespace GameSetBook.Core.Contracts
{
    public interface IClubService
    {
        Task<IEnumerable<ClubViewModel>> GetAllClubsReadOnlyAsync();
        Task<int> GetClubByIdByNameAsync(string name);
        Task<ClubDetailsViewModel> GetClubDetailsAsync(int id);
        Task<ClubInfoViewModel> GetClubIfnoAsync(int id);
        Task<bool> ClubExsitAsync(int id);
        Task CreateAsync(ClubFormModel model);
        Task<IEnumerable<CityViewModel>> GetAllCitiesAsync();
        Task<bool> ClubExsitByNameAsync(string name);
    }
}
