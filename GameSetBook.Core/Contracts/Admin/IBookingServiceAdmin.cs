using GameSetBook.Core.Models.Admin.Booking;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface IBookingServiceAdmin
    {
        //Task<IEnumerable<BookingAdminServiceViewModel>> GetAllBookingsAsync();

        Task<AllBookingsAdminSortingModel> GetBookingSortingServiceModelAsync(AllBookingsAdminSortingModel queryModel);

        Task<bool> ExistAsync(int id);

        Task CancelAsync(int id);

        Task<bool> BookingExistAsync(DateTime date, int hour, int courtId);

        Task CreateAsync(BookingCreateAdminFormModel model);

        Task<BookingEditAdminFormModel> GetEditModelAsync(int id);

        Task EditAsync(BookingEditAdminFormModel model);
    }
}
