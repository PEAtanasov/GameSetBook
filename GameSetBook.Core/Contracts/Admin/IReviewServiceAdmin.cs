using GameSetBook.Core.Models.Admin.Review;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface IReviewServiceAdmin
    {
        Task<IEnumerable<ReviewAdminViewModel>> AllClubReviewsAsync(int clubId);

        Task<bool> ExistAsync(int id);

        Task HardDeleteAsync(int id);

        Task<ReviewAdminViewModel> GetDetailsViewModel(int id);

        Task<ReviewReviseAdminFormModel> GetReviewReviseModelAsync(int id);

        Task ReviseAsync(ReviewReviseAdminFormModel model);
    }
}
