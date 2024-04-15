using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Enums;
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

        public async Task<AllReviewAdminSortingModel> AllClubReviewsAsync(AllReviewAdminSortingModel model)
        {
            var reviews = repository.GetAllReadOnly<Review>()
                 .Where(r => r.ClubId == model.ClubId)
                 .IgnoreQueryFilters();


            if (!string.IsNullOrWhiteSpace(model.SearchTerm))
            {
                reviews = reviews.Where(r => r.Reviewer.Email.ToUpper().Contains(model.SearchTerm.ToUpper())
                                                       ||r.Title.ToUpper().Contains(model.SearchTerm.ToUpper())
                                                       ||r.Description.ToUpper().Contains(model.SearchTerm.ToUpper()));
            }

            reviews = model.ReviewSorting switch
            {
                ReviewSorting.CreatedOnAscending => reviews.OrderBy(r => r.CreatedOn).ThenBy(r => r.Id),
                ReviewSorting.CreatedOnDescending => reviews.OrderByDescending(r => r.CreatedOn).ThenBy(r => r.Id),
                ReviewSorting.RatingAscending => reviews.OrderBy(r => r.Rate).ThenBy(r => r.Id),
                ReviewSorting.RatingDescending => reviews.OrderByDescending(r => r.Rate).ThenBy(r => r.Id),
                _ => reviews.OrderByDescending(r => r.CreatedOn).ThenByDescending(r => r.Id),
            };

            int totalReviews = reviews.Count();

            var maxPage = Math.Ceiling((double)totalReviews / model.ReviewsPerPage);

            int currentPage = model.CurrentPage;

            if (currentPage > maxPage)
            {
                currentPage = (int)maxPage;
            }
            if (currentPage <= 0)
            {
                currentPage = 1;
            }

            var reviewsToPass = await reviews
                .Skip((currentPage - 1) * model.ReviewsPerPage)
                .Take(model.ReviewsPerPage)
                .Select(r => new ReviewAdminViewModel()
                {
                    Id= r.Id,
                    ClubId=r.ClubId,
                    Rate = r.Rate,
                    Title = r.Title,
                    Description = r.Description,
                    ReviewerName = r.Reviewer.FirstName + " " + r.Reviewer.LastName,
                    AddedDateOn = r.CreatedOn.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                    ReviewerEmail = r.Reviewer.Email,        
                })
                .ToListAsync();

            model.Reviews = reviewsToPass;
            model.TotalReviewCount = totalReviews;

            return model;
        }

        public async Task<ReviewAdminViewModel> GetDetailsViewModelAsync(int id)
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
