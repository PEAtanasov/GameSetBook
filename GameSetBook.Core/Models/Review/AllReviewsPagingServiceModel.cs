using GameSetBook.Core.Models.Club;

namespace GameSetBook.Core.Models.Review
{
    public class AllReviewsPagingServiceModel
    {
        public int ClubId { get; set; }

        public string ClubName { get; set; } = string.Empty;

        public int ReviewsPerPage { get; } = 5;

        public int CurrentPage { get; init; } = 1;

        public int TotalReviewCount { get; set; }

        public IEnumerable<ReviewViewModel> Reviews { get; set; } = new List<ReviewViewModel>();

        public ClubInfoViewModel ClubInfo { get; set; } = null!;
    }
}
