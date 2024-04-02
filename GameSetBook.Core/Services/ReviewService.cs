using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Review;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository repository;

        public ReviewService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddReview(ReviewFormModel model)
        {
            var review = new Review()
            {
                Title = model.Title,
                Description = model.Description,
                Rate = model.Rate,
                ClubId = model.ClubId,
                ReviewerId = model.ReviewerId,
                BookingId = model.BookingId
            };

            await repository.AddAsync(review);

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(int reviewId)
        {
            return await repository.GetAllReadOnly<Review>()
                .AnyAsync(r => r.Id == reviewId);
        }

        public async Task<bool> IsTheReviewer(int reviewId, string userId)
        {
            var review = await repository.GetAllReadOnly<Review>()
                .FirstAsync(r => r.Id == reviewId);

            return review.ReviewerId == userId;
        }

        public async Task<ReviewFormModel> GetReviseModelAsync(int reviewId)
        {
            var review = await repository.GetAllReadOnly<Review>()
                .Where(r => r.Id == reviewId)
                .Select(r => new ReviewFormModel()
                {
                    Id = r.Id,
                    ReviewerId = r.ReviewerId,
                    BookingId = r.BookingId,
                    ClubId = r.ClubId,
                    Description = r.Description,
                    Rate = r.Rate,
                    Title = r.Title
                })
                .FirstAsync();

            return review;
        }

        public async Task ReviseAsync(ReviewFormModel model)
        {
            var review = await repository.GetAll<Review>()
                .FirstAsync(r => r.Id == model.Id);

            review.Title=model.Title;
            review.Description=model.Description;
            review.Rate = model.Rate;

            await repository.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<ReviewViewModel>> GetClubReviews(int clubId)
        {
            var reviews = await repository.GetAllReadOnly<Review>()
                .Where(r=>r.ClubId==clubId)
                .OrderByDescending(r => r.Id)
                .Select(r=> new ReviewViewModel()
                {
                    Rating = r.Rate,
                    Title = r.Title,
                    Description = r.Description,
                    Author = r.Reviewer.FirstName + " " + r.Reviewer.LastName
                })
                .ToListAsync();

            return reviews;
        }
    }
}
