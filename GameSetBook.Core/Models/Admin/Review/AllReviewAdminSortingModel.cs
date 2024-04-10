using GameSetBook.Core.Enums;

namespace GameSetBook.Core.Models.Admin.Review
{
    public class AllReviewAdminSortingModel
    {
        public int ClubId { get; set; }

        public string ClubName { get; set; } = string.Empty;

        public int ReviewsPerPage { get; set; } = 10;

        public int CurrentPage { get; init; } = 1;

        public string SearchTerm {  get; set; } = string.Empty;

        public int TotalReviewCount { get; set; }

        public ReviewSorting ReviewSorting { get; set; }

        public IEnumerable<ReviewAdminViewModel> Reviews { get; set; } = new List<ReviewAdminViewModel>();

    }
}
