using GameSetBook.Core.Enums;
using GameSetBook.Core.Models.Club;

namespace GameSetBook.Core.Models.Booking
{
    public class AllBookingsSortingModel
    {
        public AllBookingsSortingModel()
        {
            Bookings = new List<BookingInfoServiceViewModel>();
        }

        public int BookingsPerPage { get; } = 10;

        public string SearchTerm { get; init; } = null!;

        public BookingSorting BookingSorting { get; init; } = BookingSorting.None;

        public int CurrentPage { get; init; } = 1;

        public int TotalBookingCount { get; set; }

        public DateTime? BookingDateFrom { get; set; }

        public DateTime? BookingDateTo { get; set; }

        public IEnumerable<BookingInfoServiceViewModel> Bookings { get; set; }
    }
}
