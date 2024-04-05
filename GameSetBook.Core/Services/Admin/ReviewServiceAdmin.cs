using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Review;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Core.Services.Admin
{
    public class ReviewServiceAdmin : IReviewServiceAdmin
    {
        private readonly IRepository repository;

        public ReviewServiceAdmin(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ReviewAdminViewModel>> AllClubReviews(int clubId)
        {
            var reviews = await repository.GetAllReadOnly<Review>()
                .Where(r => r.ClubId == clubId)
                .Select(r => new ReviewAdminViewModel()
                {
                    Id = r.Id,
                    ClubId = r.ClubId,
                    Description = r.Description,
                    Rate = r.Rate,
                    Title = r.Title,
                    ReviewerName = r.Reviewer.FirstName + " " + r.Reviewer.LastName,
                    ReviewerEmail = r.Reviewer.Email,
                })
                .ToListAsync();

            return reviews;
        }
    }
}
