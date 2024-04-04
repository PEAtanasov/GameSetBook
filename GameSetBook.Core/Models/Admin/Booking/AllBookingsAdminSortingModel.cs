using GameSetBook.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace GameSetBook.Core.Models.Admin.Booking
{
    public class AllBookingsAdminSortingModel
    {
        public AllBookingsAdminSortingModel()
        {
            Bookings = new List<BookingAdminServiceViewModel>();
        }
        public int BookingsPerPage { get; set; } = 20;

        public int? ClubId { get; set; }

        [Display(Name = "Search by name")]
        public string SearchTerm { get; init; } = null!;

        public BookingSorting BookingSorting { get; init; }

        public BookingStatusSorting StatusSorting { get; init; }

        public string? BookingDateFrom { get; set; }

        public string? BookingDateTo { get; set; }

        public string? BookedOnDateFrom { get; set; }

        public string? BookedOnDateTo { get; set; }

        public int CurrentPage { get; init; } = 1;

        public int TotalBookingsCount { get; set; }

        public IEnumerable<BookingAdminServiceViewModel> Bookings { get; set; }
    }
}
