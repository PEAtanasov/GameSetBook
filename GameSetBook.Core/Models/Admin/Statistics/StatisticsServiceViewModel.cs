namespace GameSetBook.Core.Models.Admin.Statistics
{
    public class StatisticsServiceViewModel
    {
        public BookingStatisticsViewModel BookingsStatistics { get; set; } = null!;

        public CourtStatisticsViewModel CourtStatistics { get; set; } = null!;

        public ClubStatisticsViewModel ClubStatistics { get; set; } = null!;
    }
}
