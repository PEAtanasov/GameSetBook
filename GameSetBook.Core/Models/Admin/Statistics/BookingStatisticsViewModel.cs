namespace GameSetBook.Core.Models.Admin.Statistics
{
    public class BookingStatisticsViewModel
    {
        public int NumberOfTotalBookings { get; set; }

        public int NumberOfCanceledBookings { get; set; }

        public int NumberOfBookingsBookedByClubOwners { get; set; }

        public int NumberOfBookinsBookedByUsers { get; set; }

        public int NumberOfBookingsBookedToday { get; set; }
    }
}
