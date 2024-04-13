using GameSetBook.Core.Contracts;
using GameSetBook.Core.Enums;
using GameSetBook.Core.Models.Review;
using GameSetBook.Core.Services;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Data;
using GameSetBook.Infrastructure.Models;
using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace GameSetBook.Tests.PublicAreaTests
{
    public class ReviewServiceTests
    {
        private ApplicationDbContext dbContext;

        private IRepository repository;
        private IReviewService reviewService;

        private IEnumerable<Booking> bookings;
        private IEnumerable<Review> reviews;
        private IEnumerable<Club> clubs;
        private IEnumerable<Court> courts;

        private ApplicationUser user1;
        private ApplicationUser user2;
        private ApplicationUser clubOwner1;
        private ApplicationUser clubOwner2;
        private Country country;
        private City city;
        private Club club1;
        private Club club2;
        private Court court1;
        private Court court2;
        private Booking bookingOne;
        private Booking bookingTwo;
        private Booking booking1;
        private Booking booking2;
        private Booking booking3;
        private Booking booking4;
        private Booking booking5;
        private Booking booking6;
        private Booking booking7;
        private Booking booking8;
        private Booking booking9;
        private Review reviewOne;
        private Review review1;
        private Review review2;
        private Review review3;
        private Review review4;
        private Review review5;
        private Review review6;
        private Review review7;
        private Review review8;
        private Review review9;

        [SetUp]
        public async Task Setup()
        {

            var hasher = new PasswordHasher<ApplicationUser>();

            user1 = new ApplicationUser()
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

            user1.PasswordHash = hasher.HashPassword(user1, "aaaaaa1");

            clubOwner1 = new ApplicationUser()
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

            user1.PasswordHash = hasher.HashPassword(clubOwner1, "aaaaaa1");

            clubOwner2 = new ApplicationUser()
            {
                Id = "newOwnerId"
            };

            user2 = new ApplicationUser()
            {
                Id = "newUserId"
            };

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

            club1 = new Club()
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

            club2 = new Club()
            {
                Id = 2,
                CityId = 1,
                ClubOwnerId = "NewUserId",
                IsAproovedByAdmin = true,
            };

            court1 = new Court()
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

            court2 = new Court()
            {
                Id = 10,
                ClubId = 2,
                IsActive = true
            };

            bookingOne = new Booking()
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

            bookingTwo = new Booking()
            {
                Id = 2,
                ClientId = "55eb5415-58ab-458d-9120-b929b87e911a",
                ClientName = "Test Testov",
                BookingDate = DateTime.Now.AddDays(3),
                CourtId = 1,
                Hour = 14,
                BookedOn = DateTime.Now.AddDays(-1),
                PhoneNumber = "111111111",
                Price = 30,
                IsBookedByOwnerOrAdmin = false,
            };

            booking1 = new Booking()
            {
                Id = 10,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 10
            };

            booking2 = new Booking()
            {
                Id = 11,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 11,
            };

            booking3 = new Booking()
            {
                Id = 12,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 12,
            };

            booking4 = new Booking()
            {
                Id = 13,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 13,
            };

            booking5 = new Booking()
            {
                Id = 14,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 14,
            };

            booking6 = new Booking()
            {
                Id = 15,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 15,
            };

            booking7 = new Booking()
            {
                Id = 16,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 16,
            };

            booking8 = new Booking()
            {
                Id = 17,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 17,
            };

            booking9 = new Booking()
            {
                Id = 18,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 18,
                IsDeleted = true,
            };

            reviewOne = new Review()
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

            review1 = new Review()
            {
                Id = 10,
                BookingId = 10,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-10),
                Rate = 1
            };

            review2 = new Review()
            {
                Id = 11,
                BookingId = 11,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-9),
                Rate = 2
            };

            review3 = new Review()
            {
                Id = 12,
                BookingId = 12,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-8),
                Rate = 3
            };

            review4 = new Review()
            {
                Id = 13,
                BookingId = 13,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-7),
                Rate = 4
            };
            review5 = new Review()
            {
                Id = 14,
                BookingId = 14,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-6),
                Rate = 5
            };
            review6 = new Review()
            {
                Id = 15,
                BookingId = 15,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-5),
                Rate = 6
            };
            review7 = new Review()
            {
                Id = 16,
                BookingId = 16,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-4),
                Rate = 7
            };
            review8 = new Review()
            {
                Id = 17,
                BookingId = 17,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-3),
                Rate = 8
            };
            review9 = new Review()
            {
                Id = 18,
                BookingId = 18,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-2),
                Rate = 9
            };

            clubs = new List<Club>() { club1, club2 };
            courts = new List<Court>() { court1, court2 };
            bookings = new List<Booking>()
            {
                bookingOne,bookingTwo,booking1,booking2, booking3, booking4, booking5, booking6, booking7, booking8, booking9
            };

            reviews = new List<Review>()
            {
                reviewOne,review1,review2, review3, review4, review5, review6, review7, review8, review9
            };


            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GameSetBookTestInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ApplicationDbContext(options);

            await dbContext.AddAsync(user1);
            await dbContext.AddAsync(clubOwner1);
            await dbContext.AddAsync(user2);
            await dbContext.AddAsync(clubOwner2);
            await dbContext.AddAsync(country);
            await dbContext.AddAsync(city);
            await dbContext.AddRangeAsync(clubs);
            await dbContext.AddRangeAsync(courts);
            await dbContext.AddRangeAsync(bookings);
            await dbContext.AddRangeAsync(reviews);
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
            var totalReviews = reviews.Count();

            ReviewFormModel model = new ReviewFormModel()
            {
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
            var result = await reviewService.GetReviseModelAsync(1);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task GetReviseModel_ReturnsCorrectModelData()
        {
            var result = await reviewService.GetReviseModelAsync(1);

            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(reviewOne.Id));
                Assert.That(result.Title, Is.EqualTo(reviewOne.Title));
                Assert.That(result.Description, Is.EqualTo(reviewOne.Description));
                Assert.That(result.Rate, Is.EqualTo(reviewOne.Rate));
                Assert.That(result.ClubId, Is.EqualTo(reviewOne.ClubId));
                Assert.That(result.ReviewerId, Is.EqualTo(reviewOne.ReviewerId));
                Assert.That(result.BookingId, Is.EqualTo(reviewOne.BookingId));
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

        [Test]
        public async Task GetClubReviewsAsync_CheckIfReturnsAllClubReviewsTestAfterAddingNewReview()
        {
            var clubId = 1;

            ReviewFormModel model = new ReviewFormModel()
            {
                Title = "test",
                Description = "test",
                BookingId = 2,
                ClubId = 1,
                Rate = 1,
                ReviewerId = "userId",
            };

            await reviewService.AddReviewAsync(model);

            var expectedResult1 = 2;
            var expectedResult2 = await dbContext.Reviews
              .Where(r => r.ClubId == clubId).CountAsync();

            var reviews = await reviewService.GetClubReviewsAsync(clubId);

            var actualResult = reviews.Count();

            Assert.That(actualResult, Is.EqualTo(expectedResult1));
            Assert.That(actualResult, Is.EqualTo(expectedResult2));
        }

        [Test]
        public async Task GetReviewsSortingModelAsync_ShouldNotReturnNull()
        {

            var model = new AllReviewsSortingServiceModel()
            {
                ClubId = club2.Id,
                ReviewSorting = ReviewSorting.CreatedOnDescending,
                ReviewsPerPage = int.MaxValue

            };

            var result = await reviewService.GetReviewsSortingModelAsync(model);

            Assert.NotNull(result);
        }

        [Test]
        public async Task GetReviewsSortingModelAsync_ShouldReturnexactNumberOfItems()
        {
            var itemsPerPage1 = 1;
            var itemsPerPage2 = 5;
            var itemsPerPage3 = int.MaxValue;

            var model1 = new AllReviewsSortingServiceModel()
            {
                ClubId = club2.Id,
                ReviewSorting = ReviewSorting.CreatedOnDescending,
                ReviewsPerPage = itemsPerPage1
            };

            var result1 = await reviewService.GetReviewsSortingModelAsync(model1);

            var model2 = new AllReviewsSortingServiceModel()
            {
                ClubId = club2.Id,
                ReviewSorting = ReviewSorting.CreatedOnDescending,
                ReviewsPerPage = itemsPerPage2
            };

            var result2 = await reviewService.GetReviewsSortingModelAsync(model2);

            var model3 = new AllReviewsSortingServiceModel()
            {
                ClubId = club2.Id,
                ReviewSorting = ReviewSorting.CreatedOnDescending,
                ReviewsPerPage = itemsPerPage3
            };

            var result3 = await reviewService.GetReviewsSortingModelAsync(model3);

            var numberOfDeletedBookings = 1;
            var nymberOfBookingsToAnotherClub = 1;

            var expectedResultForTest3 = reviews.Count() - numberOfDeletedBookings - nymberOfBookingsToAnotherClub;

            Assert.That(result1.Reviews.Count(), Is.EqualTo(1));
            Assert.That(result2.Reviews.Count(), Is.EqualTo(5));
            Assert.That(result3.Reviews.Count(), Is.EqualTo(expectedResultForTest3));
        }

        [Test]
        public async Task GetReviewsSortingModelAsync_ShouldreturnOrderedReviewsByDateAddedDescending()
        {
            var model = new AllReviewsSortingServiceModel()
            {
                ClubId = club2.Id,
                ReviewSorting = ReviewSorting.CreatedOnDescending,
                ReviewsPerPage = 3
            };

            var sortedModel = await reviewService.GetReviewsSortingModelAsync(model);

            var expectedResultIds = new List<int>()
            {
                review8.Rate, review7.Rate, review6.Rate
            };

            var actualResult = new List<int>()
            {
                sortedModel.Reviews.Take(1).First().Rating,
                sortedModel.Reviews.Skip(1).Take(1).First().Rating,
                sortedModel.Reviews.Skip(2).Take(1).First().Rating,
            };

            Assert.That(expectedResultIds[0], Is.EqualTo(actualResult[0]));
            Assert.That(expectedResultIds[1], Is.EqualTo(actualResult[1]));
            Assert.That(expectedResultIds[2], Is.EqualTo(actualResult[2]));
        }

        [Test]
        public async Task GetReviewsSortingModelAsync_ShouldreturnOrderedReviewsByDateAddedAscending()
        {
            var model = new AllReviewsSortingServiceModel()
            {
                ClubId = club2.Id,
                ReviewSorting = ReviewSorting.CreatedOnAscending,
                ReviewsPerPage = 3
            };

            var sortedModel = await reviewService.GetReviewsSortingModelAsync(model);

            var expectedResultIds = new List<int>()
            {
                review1.Rate, review2.Rate, review3.Rate
            };

            var actualResult = new List<int>()
            {
                sortedModel.Reviews.Take(1).First().Rating,
                sortedModel.Reviews.Skip(1).Take(1).First().Rating,
                sortedModel.Reviews.Skip(2).Take(1).First().Rating,
            };

            Assert.That(expectedResultIds[0], Is.EqualTo(actualResult[0]));
            Assert.That(expectedResultIds[1], Is.EqualTo(actualResult[1]));
            Assert.That(expectedResultIds[2], Is.EqualTo(actualResult[2]));
        }

        [Test]
        public async Task GetReviewsSortingModelAsync_ShouldreturnOrderedReviewsByRateAscending()
        {
            var model = new AllReviewsSortingServiceModel()
            {
                ClubId = club2.Id,
                ReviewSorting = ReviewSorting.RatingAscending,
                ReviewsPerPage = 3
            };

            var sortedModel = await reviewService.GetReviewsSortingModelAsync(model);

            var expectedResultIds = new List<int>()
            {
                review1.Rate, review2.Rate, review3.Rate
            };

            var actualResult = new List<int>()
            {
                sortedModel.Reviews.Take(1).First().Rating,
                sortedModel.Reviews.Skip(1).Take(1).First().Rating,
                sortedModel.Reviews.Skip(2).Take(1).First().Rating,

            };

            Assert.That(expectedResultIds[0], Is.EqualTo(actualResult[0]));
            Assert.That(expectedResultIds[1], Is.EqualTo(actualResult[1]));
            Assert.That(expectedResultIds[2], Is.EqualTo(actualResult[2]));
        }

        [Test]
        public async Task GetReviewsSortingModelAsync_ShouldreturnOrderedReviewsByRateDescending()
        {
            {
                var model = new AllReviewsSortingServiceModel()
                {
                    ClubId = club2.Id,
                    ReviewSorting = ReviewSorting.RatingDescending,
                    ReviewsPerPage = 3
                };

                var sortedModel = await reviewService.GetReviewsSortingModelAsync(model);

                var expectedResultIds = new List<int>()
            {
                review8.Rate, review7.Rate, review6.Rate
            };

                var actualResult = new List<int>()
            {
                sortedModel.Reviews.Take(1).First().Rating,
                sortedModel.Reviews.Skip(1).Take(1).First().Rating,
                sortedModel.Reviews.Skip(2).Take(1).First().Rating,
            };

                Assert.That(expectedResultIds[0], Is.EqualTo(actualResult[0]));
                Assert.That(expectedResultIds[1], Is.EqualTo(actualResult[1]));
                Assert.That(expectedResultIds[2], Is.EqualTo(actualResult[2]));
            }
        }
    }
}
