using GameSetBook.Core.Models.Court;

namespace GameSetBook.Core.Models.Club
{
    public class MyClubDetailsServiceModel
    {
        public int ClubId { get; set; }

        public ClubInfoViewModel Info { get; set; } = null!;

        public ClubDetailsViewModel Details { get; set; } = null!;

        public IEnumerable<CourtDetailsViewModel> Courts { get; set; } = new List<CourtDetailsViewModel>();
    }
}
