using GameSetBook.Core.Models.Review;

namespace GameSetBook.Core.Contracts
{
    public interface IReviewService
    {
        Task AddReview(ReviewFormModel model);

        Task<bool> ExistAsync(int reviewId);

        Task<bool> IsTheReviewer(int reviewId, string userId);

        Task<ReviewFormModel> GetReviseModelAsync(int reviewId);

        Task ReviseAsync(ReviewFormModel model);

        Task<IEnumerable<ReviewViewModel>> GetClubReviews(int clubId);

        Task<AllReviewsPagingServiceModel> GetReviewsPagingModel(AllReviewsPagingServiceModel model);
    }
}
