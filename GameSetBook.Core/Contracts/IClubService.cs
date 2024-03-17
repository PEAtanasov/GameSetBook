using GameSetBook.Core.Enums;
using GameSetBook.Core.Models.City;
using GameSetBook.Core.Models.Club;
using GameSetBook.Infrastructure.Common;

namespace GameSetBook.Core.Contracts
{
    public interface IClubService
    {
        Task<IEnumerable<ClubServiceViewModel>> GetAllClubsAsync();

        Task<ClubSortingServiceModel> GetClubSortingServiceModelAsync(
            string? city=null,
            string? searchTearm=null,
            ClubSorting clubSortign = ClubSorting.Newest,
            int currentPage =1,
            int clubsPerPage = 1);

        Task<int> GetClubByIdByNameAsync(string name);

        Task<ClubDetailsViewModel> GetClubDetailsAsync(int id);

        Task<ClubInfoViewModel> GetClubIfnoAsync(int id);

        Task<bool> ClubExsitAsync(int id);

        Task CreateAsync(ClubFormModel model);

        Task<IEnumerable<CityViewModel>> GetAllCitiesAsync();

        Task<bool> ClubExsitByNameAsync(string name);

        Task<bool> IsClubAprooved(int id);

    }
}
