using GameSetBook.Core.Models.Booking;

namespace GameSetBook.Core.Contracts
{
    public interface IBookingService
    {

        Task<int> AddAsync(BookingCreateFormModel model);

        Task<BookingEditFormModel> GetBookingToEditAsync(int id);

        Task EditAsync(BookingEditFormModel model);

        Task DeleteAsync(int id);

        Task<bool> AreDateAndHourValidAsync(DateTime date, int hour, int courtId);

        Task<bool> BookingExistAsync(DateTime date, int hour, int courtId);

        Task<bool> ExistByIdAsync(int id);

        Task<bool> IsClubOwnerAllowedToEditAsync(int id, string ownerId);

        Task<AllBookingsSortingModel> GetBookingSortingServiceModelAsync(AllBookingsSortingModel queryModel, string userId);

        Task<bool> IsBookingClientAsync(int bookingId, string userId);

        Task<bool> IsCancelableAsync(int bookingId);

        Task<bool> HasReviewAsync(int bookingId);
    }
}
