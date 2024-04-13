using GameSetBook.Core.Models.Review;

namespace GameSetBook.Core.Contracts
{
    public interface IReviewService
    {
        Task AddReviewAsync(ReviewFormModel model);

        Task<bool> ExistAsync(int reviewId);

        Task<bool> IsTheReviewerAsync(int reviewId, string userId);

        Task<ReviewFormModel> GetReviseModelAsync(int reviewId);

        Task ReviseAsync(ReviewFormModel model);

        Task<IEnumerable<ReviewViewModel>> GetClubReviewsAsync(int clubId);

        Task<AllReviewsSortingServiceModel> GetReviewsSortingModelAsync(AllReviewsSortingServiceModel model);
    }
}
