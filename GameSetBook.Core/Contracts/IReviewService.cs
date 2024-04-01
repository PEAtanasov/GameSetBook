using GameSetBook.Core.Models.Review;

namespace GameSetBook.Core.Contracts
{
    public interface IReviewService
    {
        Task AddReview(ReviewFormModel model);
    }
}
