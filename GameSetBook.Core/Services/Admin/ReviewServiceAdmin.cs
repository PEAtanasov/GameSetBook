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

        public async Task<IEnumerable<ReviewAdminViewModel>> AllClubReviewsAsync(int clubId)
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

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.GetAllReadOnly<Review>()
                .AnyAsync(r => r.Id == id);
        }

        public async Task HardDeleteAsync(int id)
        {
            var review = await repository.GetAll<Review>()
                .FirstAsync(r => r.Id == id);

            repository.HardDelete(review);

            await repository.SaveChangesAsync();
        }
    }
}
