﻿using GameSetBook.Core.Models.Admin.Review;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface IReviewServiceAdmin
    {
        Task<IEnumerable<ReviewAdminViewModel>> AllClubReviewsAsync(int clubId);

        Task<bool> ExistAsync(int id);

        Task HardDeleteAsync(int id);
    }
}