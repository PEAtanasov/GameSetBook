using GameSetBook.Core.Models.Admin.Review;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface IReviewServiceAdmin
    {
        Task<IEnumerable<ReviewAdminViewModel>> AllClubReviews(int clubId);
    }
}
