namespace GameSetBook.Core.Models.Admin.Statistics
{
    public class ClubStatisticsViewModel
    {
        public int NumberOfClubsRegistered { get; set; }

        public int NumberOfActiveClubs { get; set; }

        public int NumberOfNotActiveClubs { get; set; }

        public int NumberOfClubsForApproval { get; set; }

        public int NumberOfClubsWithLowRating { get; set; }
    }
}
