using GameSetBook.Core.Enums;
using GameSetBook.Core.Models.City;
using GameSetBook.Core.Models.Club;

namespace GameSetBook.Core.Contracts
{
    public interface IClubService
    {
        Task<IEnumerable<ClubServiceViewModel>> GetAllClubsAsync();

        Task<ClubSortingServiceModel> GetClubSortingServiceModelAsync(
            string? city = null,
            string? searchTearm = null,
            ClubSorting clubSorting = ClubSorting.Newest,
            int currentPage = 1,
            int clubsPerPage = 1);

        Task<int> GetClubIdByNameAsync(string name);

        Task<ClubDetailsAndInfoViewModel> GetClubDetailsAndInfoAsync(int id);

        Task<ClubDetailsViewModel> GetClubDetailsAsync(int id);

        Task<ClubInfoViewModel> GetClubIfnoAsync(int id);

        Task<bool> ClubExsitAsync(int id);

        Task CreateAsync(ClubFormModel model);

        Task<IEnumerable<CityViewModel>> GetAllCitiesAsync();

        Task<bool> ClubExsitByNameAsync(string name);

        Task<bool> IsClubAprooved(int id);

        Task<bool> ClubWithOwnerIdExistAsync(string ownerId);

        Task<bool> IsTheOwnerOfTheClub(int clubId, string userId);

        Task<int> GetClubIdByOwnerId(string ownerId);

        Task<ClubFormModel> GetEditFormModelAsync(int clubId);

        Task EditAsync(ClubFormModel model);
    }
}
