using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Review;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static GameSetBook.Common.ValidationConstatns.DateTimeFormats;

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
                    AddedDateOn = r.CreatedOn.ToString(DateTimeFormat, CultureInfo.InvariantCulture)
                })
                .ToListAsync();

            return reviews;
        }

        public async Task<ReviewAdminViewModel> GetDetailsViewModel(int id)
        {
            var model = await repository.GetAllReadOnly<Review>()
                .Where(r => r.Id == id)
                .Select(r => new ReviewAdminViewModel()
                {
                    Id = r.Id,
                    ClubId = r.ClubId,
                    Description = r.Description,
                    Rate = r.Rate,
                    Title = r.Title,
                    ReviewerName = r.Reviewer.FirstName + " " + r.Reviewer.LastName,
                    ReviewerEmail = r.Reviewer.Email,
                    ClubName = r.Club.Name,
                    AddedDateOn = r.CreatedOn.ToString(DateTimeFormat, CultureInfo.InvariantCulture)                   
                })
                .FirstAsync();

            return model;
        }

        public async Task<ReviewReviseAdminFormModel> GetReviewReviseModelAsync(int id)
        {
            var model = await repository.GetAllReadOnly<Review>()
                .Where(r => r.Id == id)
                .Select(r => new ReviewReviseAdminFormModel()
                {
                    Id = r.Id,
                    ClubId = r.ClubId,
                    Description = r.Description,
                    Rating = r.Rate,
                    Title = r.Title,
                    ReviewerEmail = r.Reviewer.Email,
                    ClubName = r.Club.Name,
                    DateAddedOn = r.CreatedOn.ToString(DateTimeFormat, CultureInfo.InvariantCulture)
                })
                .FirstAsync();

            return model;
        }

        public async Task ReviseAsync(ReviewReviseAdminFormModel model)
        {
            var review = await repository.GetAll<Review>()
                .FirstAsync(r => r.Id == model.Id);

            review.Title=model.Title;
            review.Description=model.Description;
            review.Rate = model.Rating;

            await repository.SaveChangesAsync();
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
