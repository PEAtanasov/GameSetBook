using GameSetBook.Core.Models.Court;

namespace GameSetBook.Core.Models.Club
{
    public class MyClubDetailsServiceModel
    {
        public ClubDetailsAndInfoViewModel ClubDetailsAndInfo { get; set; } = null!;

        public IEnumerable<CourtDetailsViewModel> Courts { get; set; } = new List<CourtDetailsViewModel>();
    }
}
