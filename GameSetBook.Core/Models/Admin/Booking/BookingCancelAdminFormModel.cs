namespace GameSetBook.Core.Models.Admin.Booking
{
    public class BookingCancelAdminFormModel
    {
        public int Id { get; set; }

        public AllBookingsAdminSortingModel ReturnUrlParameters { get; set; } = null!;
    }
}
