using GameSetBook.Core.Models.Admin.Statistics;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface IStatisticService
    {
        Task<ClubStatisticsViewModel> GetClubsStatisticsAsync();

        BookingStatisticsViewModel GetBookingStatistics(DateTime date);

        CourtStatisticsViewModel GetCourtStatistics();
    }
}
