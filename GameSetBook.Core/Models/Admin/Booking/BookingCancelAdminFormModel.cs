namespace GameSetBook.Core.Models.Admin.Booking
{
    public class BookingCancelAdminFormModel
    {
        public int Id { get; set; }

        public AllBookingsAdminSortingModel filters { get; set; } = null!;
    }
}
