using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Review;
using GameSetBook.Core.Services;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Data;
using GameSetBook.Infrastructure.Models;
using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace GameSetBook.Tests.PublicAreaTests
{
    public class ReviewServiceTests
    {
        private ApplicationDbContext dbContext;

        private IRepository repository;
        private IReviewService reviewService;

        private ApplicationUser user;
        private ApplicationUser clubOwner;
        private Country country;
        private City city;
        private Club club;
        private Court court;
        private Booking booking;
        private Review review;

        [SetUp]
        public async Task Setup()
        {

            var hasher = new PasswordHasher<ApplicationUser>();

            user = new ApplicationUser()
            {
                Id = "userId",
                UserName = "user@usermail.com",
                NormalizedUserName = "user@usermail.com".ToUpper(),
                Email = "user@usermail.com",
                NormalizedEmail = "user@usermail.com".ToUpper(),
                FirstName = "Test",
                LastName = "Testov",
                PhoneNumber = "111111111"
            };

            user.PasswordHash = hasher.HashPassword(user, "aaaaaa1");

            clubOwner = new ApplicationUser()
            {
                Id = "clubOwnerId",
                UserName = "clubowner@clubowner.com",
                NormalizedUserName = "clubowner@clubowner.com".ToUpper(),
                Email = "clubowner@clubowner.com",
                NormalizedEmail = "clubowner@clubowner.com".ToUpper(),
                FirstName = "Owner",
                LastName = "Ownerov",
                PhoneNumber = "222222222"
            };

            user.PasswordHash = hasher.HashPassword(clubOwner, "aaaaaa1");

            country = new Country()
            {
                Id = 1,
                Name = "Bulgaria"
            };

            city = new City()
            {
                Id = 1,
                Name = "Sofia",
                CountryId = 1
            };

            club = new Club()
            {
                Id = 1,
                Name = "TestClub",
                Address = "Test Address",
                CityId = 1,
                LogoUrl = "DefaultImage",
                NumberOfCoaches = 1,
                PhoneNumber = "1234567890",
                ClubOwnerId = "fbc3aa46-7418-4ba3-a5e3-a9e8887d063c",
                Description = "Club Description, The best club in town",
                Email = "club@email.com",
                HasParking = true,
                HasShower = true,
                NumberOfCourts = 1,
                RegisteredOn = DateTime.Now.AddDays(-30),
                HasShop = false,
                WorkingTimeEnd = 21,
                WorkingTimeStart = 8,
                IsAproovedByAdmin = true,
            };

            court = new Court()
            {
                Id = 1,
                Name = "No1",
                ClubId = 1,
                IsActive = true,
                IsIndoor = false,
                IsLighted = false,
                PricePerHour = 30,
                Surface = Common.Enums.Surface.Clay,
            };

            booking = new Booking()
            {
                Id = 1,
                ClientId = "55eb5415-58ab-458d-9120-b929b87e911a",
                ClientName = "Test Testov",
                BookingDate = DateTime.Now.AddDays(2),
                CourtId = 1,
                Hour = 16,
                BookedOn = DateTime.Now.AddDays(-1),
                PhoneNumber = "111111111",
                Price = 30,
                IsBookedByOwnerOrAdmin = false,
            };

            review = new Review()
            {
                Id = 1,
                ReviewerId = "userId",
                BookingId = 1,
                Title = "Review Title",
                Description = "Review Description",
                Rate = 10,
                ClubId = 1,
                CreatedOn = DateTime.Now,
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GameSetBookTestInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ApplicationDbContext(options);

            await dbContext.AddAsync(user);
            await dbContext.AddAsync(clubOwner);
            await dbContext.AddAsync(country);
            await dbContext.AddAsync(city);
            await dbContext.AddAsync(club);
            await dbContext.AddAsync(court);
            await dbContext.AddAsync(booking);
            await dbContext.AddAsync(review);
            await dbContext.SaveChangesAsync();

            repository = new Repository(dbContext);
            reviewService = new ReviewService(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task GetAllCountriesAsync_ReturnsCorrectResult()
        {
            var existId = 1;
            var nonExistId = -1;
            var result = await reviewService.ExistAsync(existId);
            var result2 = await reviewService.ExistAsync(nonExistId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(result2, Is.False);
            });
        }

        [Test]
        public async Task IsTheReviewerAsync_ShouldReturnTrueIfTheUserIsTheReviewer()
        {
            var reviewId = 1;
            var reviewerId = "userId";
            var nonReviewerId = "userIdnon";

            var result1 = await reviewService.IsTheReviewerAsync(reviewId, reviewerId);
            var result2 = await reviewService.IsTheReviewerAsync(1, nonReviewerId);

            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.True);
                Assert.That(result2, Is.False);
            });
        }

        [Test]
        public async Task AddReviewAsync_CheckIfReviewIsAddedSuccessfuly()
        {
            var totalReviews = 1;

            var booking = new Booking()
            {
                Id = 2
            };

            ReviewFormModel model = new ReviewFormModel()
            {
                //Id = 2,
                Title = "test",
                Description = "test",
                BookingId = 2,
                ClubId = 1,
                Rate = 1,
                ReviewerId = "userId",
            };
            await reviewService.AddReviewAsync(model);

            var updatedCount = await repository.GetAll<Review>().CountAsync();

            Assert.That(updatedCount, Is.EqualTo(totalReviews + 1));
        }

        [Test]
        public async Task GetReviseModel_ShouldNotReturnNull()
        {
            var result = reviewService.GetReviseModelAsync(1);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task GetReviseModel_ReturnsCorrectModelData()
        {
            var result = await reviewService.GetReviseModelAsync(1);

            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(review.Id));
                Assert.That(result.Title, Is.EqualTo(review.Title));
                Assert.That(result.Description, Is.EqualTo(review.Description));
                Assert.That(result.Rate, Is.EqualTo(review.Rate));
                Assert.That(result.ClubId, Is.EqualTo(review.ClubId));
                Assert.That(result.ReviewerId, Is.EqualTo(review.ReviewerId));
                Assert.That(result.BookingId, Is.EqualTo(review.BookingId));
            });
        }

        [Test]
        public async Task ReviseAsync_UpdatesDataCorrectly()
        {
            var model = new ReviewFormModel()
            {
                Id = 1,
                Title = "Changed",
                Description = "Changed"
            };

            await reviewService.ReviseAsync(model);

            var modelToCompare = await reviewService.GetReviseModelAsync(model.Id);

            Assert.Multiple(() =>
            {
                Assert.That(modelToCompare.Id, Is.EqualTo(model.Id));
                Assert.That(modelToCompare.Title, Is.EqualTo(model.Title));
                Assert.That(modelToCompare.Description, Is.EqualTo(model.Description));
            });
        }

        [Test]
        public async Task GetClubReviewsAsync_CheckIfReturnsAllClubReviews()
        {
            var clubId = 1;

            var allReviewsCount = await dbContext.Reviews
              .Where(r => r.ClubId == clubId).CountAsync();

            var reviews = await reviewService.GetClubReviewsAsync(clubId);

            Assert.That(reviews.Count(), Is.EqualTo(allReviewsCount));
        }
    }
}
