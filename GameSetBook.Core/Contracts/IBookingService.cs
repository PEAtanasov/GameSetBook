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

        Task<bool> IsOwnerAllowedToEdit(int id, string ownerId);
    }
}
