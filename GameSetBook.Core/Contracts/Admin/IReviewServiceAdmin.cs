using GameSetBook.Core.Models.Admin.Club;
using GameSetBook.Core.Models.Admin.Review;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface IReviewServiceAdmin
    {
        Task<AllReviewAdminSortingModel> AllClubReviewsAsync(AllReviewAdminSortingModel model);

        Task<bool> ExistAsync(int id);

        Task HardDeleteAsync(int id);

        Task<ReviewAdminViewModel> GetDetailsViewModelAsync(int id);

        Task<ReviewReviseAdminFormModel> GetReviewReviseModelAsync(int id);

        Task ReviseAsync(ReviewReviseAdminFormModel model);
    }
}
