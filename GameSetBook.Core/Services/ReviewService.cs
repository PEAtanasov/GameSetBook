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
    }
}
