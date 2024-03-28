namespace GameSetBook.Core.Models.Booking
{
    public class BookingSortingServiceModel
    {
        public BookingSortingServiceModel()
        {
            Bookings = new List<BookingInfoServiceViewModel>();
        }
        public int TotalBookingCount { get; set; }

        public IEnumerable<BookingInfoServiceViewModel> Bookings { get; set; }
    }
}
