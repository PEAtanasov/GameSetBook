using GameSetBook.Core.Models.Booking;

namespace GameSetBook.Core.Contracts
{
    public interface IBookingService
    {

        Task<int> AddBookingAsync(BookingCreateFormModel model);

        Task<BookingEditFormModel> GetBookingToEditAsync(int id);

        Task EditAsync(BookingEditFormModel model);

        Task DeleteAsync(int id);

        Task<bool> AreDateAndHourValidAsync(DateTime date, int hour, int courtId);

        Task<bool> BookingExistAsync(DateTime date, int hour, int courtId);

        Task<bool> BookingExistById(int id);

        Task<bool> IsClubOwnerAllowedToEdit(int id, string ownerId);

        Task<AllBookingsSortingModel> GetBookingSortingServiceModelAsync(AllBookingsSortingModel queryModel, string userId);

        Task<bool> IsBookingClient(int bookingId, string userId);

        Task<bool> IsCancelable(int bookingId);

        Task<bool> IsUserClientOfBooking(string clientId, int id);

        Task<bool> BookingHasReview(int bookingId);
    }
}
