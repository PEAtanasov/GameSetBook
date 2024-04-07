using GameSetBook.Core.Models.Club;

namespace GameSetBook.Core.Contracts
{
    public interface IClubService
    {
        Task<IEnumerable<ClubServiceViewModel>> GetAllClubsAsync();

        Task<AllClubsSortingModel> GetClubSortingServiceModelAsync(AllClubsSortingModel model);

        Task<int> GetClubIdByNameAsync(string name);

        Task<ClubDetailsViewModel> GetClubDetailsAsync(int id);

        Task<ClubInfoViewModel> GetClubIfnoAsync(int id);

        Task<bool> ExsitAsync(int id);

        Task CreateAsync(ClubFormModel model);

        Task<bool> ExsitByNameAsync(string name);

        Task<bool> ExsitByNameAsync(int id, string name);

        Task<bool> IsClubAprooved(int id);

        Task<bool> ClubWithOwnerIdExistAsync(string ownerId);

        Task<bool> IsTheOwnerOfTheClubAsync(int clubId, string userId);

        Task<int> GetClubIdByOwnerIdAsync(string ownerId);

        Task<ClubFormModel> GetEditFormModelAsync(int clubId);

        Task EditAsync(ClubFormModel model);

        Task<bool> ClubHasCourts(int clubId);

        Task<int> NumberOfCourtsAsync(int clubId);

        Task<int?> GetClubIdByBookingId(int bookingId);
    }
}
