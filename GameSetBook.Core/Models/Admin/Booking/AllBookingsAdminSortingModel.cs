using GameSetBook.Core.Enums;
using GameSetBook.Core.Models.Admin.Club;
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

        public DateTime? BookingDateFrom { get; set; }

        public DateTime? BookingDateTo { get; set; }

        public DateTime? BookedOnDateFrom { get; set; }

        public DateTime? BookedOnDateTo { get; set; }


        public int CurrentPage { get; init; } = 1;

        public int TotalBookingsCount { get; set; }

        public IEnumerable<BookingAdminServiceViewModel> Bookings { get; set; }
    }
}
