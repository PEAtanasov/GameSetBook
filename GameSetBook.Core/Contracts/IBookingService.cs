using GameSetBook.Core.Models.Booking;

namespace GameSetBook.Core.Contracts
{
    public interface IBookingService
    {
        Task<bool> AreDateAndHourValidAsync(DateTime date, int hour, int courtId);

        Task<bool> BookingExistAsync(DateTime date, int hour, int courtId);

        Task<int> AddBookingAsync(BookingCreateFormModel model);
    }
}
