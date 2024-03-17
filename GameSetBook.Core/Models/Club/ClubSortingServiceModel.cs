namespace GameSetBook.Core.Models.Club
{
    public class ClubSortingServiceModel
    {
        public ClubSortingServiceModel()
        {
            Clubs = new List<ClubServiceViewModel>();
        }
        public int TotalClubCount { get; set; }

        public IEnumerable<ClubServiceViewModel> Clubs { get; set; }
    }
}
