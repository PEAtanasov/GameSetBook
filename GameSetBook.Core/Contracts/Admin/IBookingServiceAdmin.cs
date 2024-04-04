using GameSetBook.Core.Models.Admin.Booking;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface IBookingServiceAdmin
    {
        //Task<IEnumerable<BookingAdminServiceViewModel>> GetAllBookingsAsync();

        Task<AllBookingsAdminSortingModel> GetBookingSortingServiceModelAsync(AllBookingsAdminSortingModel queryModel);

        Task<bool> ExistAsync(int id);

        Task CancelAsync(int id);
    }
}
