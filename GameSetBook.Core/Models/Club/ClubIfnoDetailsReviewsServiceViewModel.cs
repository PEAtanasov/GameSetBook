using GameSetBook.Core.Models.Review;

namespace GameSetBook.Core.Models.Club
{
    public class ClubIfnoDetailsReviewsServiceViewModel
    {
        public int ClubId { get; set; }

        public ClubInfoViewModel ClubInfo { get; set; } = null!;

        public ClubDetailsViewModel ClubDetails { get; set; } = null!;

        public IEnumerable<ReviewViewModel> Reviews { get; set; } = new List<ReviewViewModel>();
    }
}
