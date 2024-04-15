using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Services.Admin;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Data;
using GameSetBook.Infrastructure.Models.Identity;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using GameSetBook.Core.Models.Admin.Review;
using GameSetBook.Core.Enums;

namespace GameSetBook.Tests.AdminAreaTests
{
    [TestFixture]
    public class ReviewServiceAdminTests
    {
        private ApplicationDbContext dbContext;

        private IRepository repository;
        private IReviewServiceAdmin service;

        private IEnumerable<City> cities;
        private IEnumerable<Booking> bookings;
        private IEnumerable<Club> clubs;
        private IEnumerable<Court> courts;
        private IEnumerable<ApplicationUser> users;
        private IEnumerable<Review> reviews;

        private ApplicationUser user1;
        private ApplicationUser user2;
        private ApplicationUser user3;
        private ApplicationUser clubOwner1;
        private ApplicationUser clubOwner2;
        private ApplicationUser clubOwner3;
        private ApplicationUser clubOwner4;
        private ApplicationUser clubOwner5;
        private ApplicationUser clubOwner6;
        private ApplicationUser clubOwner8;
        private ApplicationUser clubOwnerDeletedClub;
        private ApplicationUser clubOwnerWiCourts;
        private ApplicationUser clubOwnerPendingClub1;
        private ApplicationUser clubOwnerPendingClub2;

        private Country country1;
        private Country country2;

        private City city1;
        private City city2;
        private City city3;
        private City city4;

        private Club club1;
        private Club club2;
        private Club club3;
        private Club club4;
        private Club club5;
        private Club club6;
        private Club pendingClub1;
        private Club club8;
        private Club deletedClub;
        private Club clubWithNoCouts;
        private Club pendingClub2;

        private Court court1;
        private Court court2;
        private Court court3;
        private Court notActiveCourt4;
        private Court court5;
        private Court court6;
        private Court court7;
        private Court court8;
        private Court court9;
        private Court court10;
        private Court court11;
        private Court court12;
        private Court court13;
        private Court court14;

        private Booking booking1;
        private Booking booking2;
        private Booking booking3;
        private Booking booking4;
        private Booking booking5;
        private Booking booking6;
        private Booking booking7;
        private Booking booking8;
        private Booking booking9;
        private Booking booking10;
        private Booking bookingDeleted1;
        private Booking booking12;
        private Booking booking13;
        private Booking booking14;
        private Booking booking15;
        private Booking booking16;
        private Booking booking17;
        private Booking booking18;
        private Booking bookingDeleted2;
        private Booking booking20;

        private Review review1;
        private Review review2;
        private Review review3;
        private Review review4;
        private Review review5;
        private Review review6;
        private Review review7;
        private Review review8;
        private Review review9;
        private Review review10;

        [SetUp]
        public async Task Setup()
        {
            user1 = new ApplicationUser()
            {
                Id = "user1",
                UserName = "user@usermail.com",
                NormalizedUserName = "user@usermail.com".ToUpper(),
                Email = "user@usermail.com",
                NormalizedEmail = "user@usermail.com".ToUpper(),
                FirstName = "Test",
                LastName = "Testov",
                PhoneNumber = "111111111"
            };

            user2 = new ApplicationUser()
            {
                Id = "user2"
            };

            user3 = new ApplicationUser()
            {
                Id = "use3"
            };

            clubOwner1 = new ApplicationUser()
            {
                Id = "clubOwnerId1",
                UserName = "clubowner@clubowner.com",
                NormalizedUserName = "clubowner@clubowner.com".ToUpper(),
                Email = "clubowner@clubowner.com",
                NormalizedEmail = "clubowner@clubowner.com".ToUpper(),
                FirstName = "Owner",
                LastName = "Ownerov",
                PhoneNumber = "222222222"
            };

            clubOwner2 = new ApplicationUser()
            {
                Id = "clubOwnerId2"
            };

            clubOwner3 = new ApplicationUser()
            {
                Id = "clubOwnerId3"
            };

            clubOwner4 = new ApplicationUser()
            {
                Id = "clubOwnerId4"
            };

            clubOwner5 = new ApplicationUser()
            {
                Id = "clubOwnerId5"
            };
            clubOwner6 = new ApplicationUser()
            {
                Id = "clubOwnerId6"
            };
            clubOwnerPendingClub1 = new ApplicationUser()
            {
                Id = "clubOwnerId7"
            };
            clubOwner8 = new ApplicationUser()
            {
                Id = "clubOwnerId8"
            };
            clubOwnerDeletedClub = new ApplicationUser()
            {
                Id = "clubOwnerDeletedClub"
            };
            clubOwnerWiCourts = new ApplicationUser()
            {
                Id = "clubOwnerWiCourts"
            };

            clubOwnerPendingClub2 = new ApplicationUser()
            {
                Id = "pendingClubOwner2"
            };

            country1 = new Country()
            {
                Id = 1,
                Name = "Bulgaria"
            };
            country2 = new Country()
            {
                Id = 2,
                Name = "Romania"
            };

            city1 = new City()
            {
                Id = 1,
                Name = "Sofia",
                CountryId = 1
            };
            city2 = new City()
            {
                Id = 2,
                Name = "kavarna",
                CountryId = 1
            };
            city3 = new City()
            {
                Id = 3,
                Name = "Bucharest",
                CountryId = 2
            };
            city4 = new City()
            {
                Id = 4,
                Name = "Constanta",
                CountryId = 2
            };

            club1 = new Club()
            {
                Id = 1,
                Name = "Club1",
                Address = "Test Address",
                CityId = 1,
                LogoUrl = "DefaultImage",
                NumberOfCoaches = 1,
                PhoneNumber = "1234567890",
                ClubOwnerId = "clubOwnerId1",
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
                Name = "Club2",
                CityId = 1,
                ClubOwnerId = "clubOwnerId2",
                IsAproovedByAdmin = true,
                NumberOfCourts = 2,
                WorkingTimeEnd = 21,
                WorkingTimeStart = 8,
                RegisteredOn = DateTime.Now.AddDays(-30),
                HasShop = false,
            };

            club3 = new Club()
            {
                Id = 3,
                CityId = 2,
                Name = "Club3",
                ClubOwnerId = "clubOwnerId3",
                IsAproovedByAdmin = true,
                NumberOfCourts = 1,
                WorkingTimeEnd = 21,
                WorkingTimeStart = 8,
                RegisteredOn = DateTime.Now.AddDays(-30),
                HasShop = true,
            };
            club4 = new Club()
            {
                Id = 4,
                CityId = 2,
                Name = "Club4",
                ClubOwnerId = "clubOwnerId4",
                IsAproovedByAdmin = true,
                NumberOfCourts = 2,
                WorkingTimeEnd = 21,
                WorkingTimeStart = 8,
                RegisteredOn = DateTime.Now.AddDays(-30),
                HasShop = true,
            };
            club5 = new Club()
            {
                Id = 5,
                CityId = 3,
                Name = "Club5",
                ClubOwnerId = "clubOwnerId5",
                IsAproovedByAdmin = true,
                NumberOfCourts = 1,
                WorkingTimeEnd = 21,
                WorkingTimeStart = 8,
                RegisteredOn = DateTime.Now.AddDays(-30),
                HasShop = true,
            };
            club6 = new Club()
            {
                Id = 6,
                CityId = 3,
                Name = "Club6",
                ClubOwnerId = "clubOwnerId6",
                IsAproovedByAdmin = true,
                NumberOfCourts = 2,
                WorkingTimeEnd = 21,
                WorkingTimeStart = 8,
                RegisteredOn = DateTime.Now.AddDays(-30),
                HasShop = true,
            };
            pendingClub1 = new Club()
            {
                Id = 7,
                CityId = 4,
                Name = "Club7",
                ClubOwnerId = "clubOwnerId7",
                IsAproovedByAdmin = false,
                NumberOfCourts = 2,
                WorkingTimeEnd = 21,
                WorkingTimeStart = 8,
                RegisteredOn = DateTime.Now.AddDays(-30),
                HasShop = true,
            };
            club8 = new Club()
            {
                Id = 8,
                CityId = 4,
                Name = "Club8",
                ClubOwnerId = "clubOwnerId8",
                IsAproovedByAdmin = true,
                NumberOfCourts = 2,
                WorkingTimeEnd = 21,
                WorkingTimeStart = 8,
                RegisteredOn = DateTime.Now.AddDays(-30),
                HasShop = true,
            };

            deletedClub = new Club()
            {
                Id = 9,
                CityId = 1,
                Name = "Deleted Club",
                ClubOwnerId = "clubOwnerDeletedClub",
                IsAproovedByAdmin = false,
                IsDeleted = true,
                DeletedOn = DateTime.Now.AddDays(-30),
                NumberOfCourts = 1,
                WorkingTimeEnd = 21,
                WorkingTimeStart = 8,
                RegisteredOn = DateTime.Now.AddDays(-180),
                HasShop = true,
            };

            clubWithNoCouts = new Club()
            {
                Id = 10,
                CityId = 1,
                Name = "Club With No Couts",
                ClubOwnerId = "clubOwnerWiCourts",
                IsAproovedByAdmin = false,
                IsDeleted = false,
                DeletedOn = DateTime.Now.AddDays(-30),
                WorkingTimeEnd = 21,
                WorkingTimeStart = 8,
                RegisteredOn = DateTime.Now.AddDays(-180),
                HasShop = true,
            };

            pendingClub2 = new Club()
            {
                Id = 11,
                CityId = 4,
                Name = "Pending club 2",
                ClubOwnerId = "pendingClubOwner2",
                IsAproovedByAdmin = false,
                NumberOfCourts = 1,
                WorkingTimeEnd = 21,
                WorkingTimeStart = 8,
                RegisteredOn = DateTime.Now.AddDays(-30),
                HasShop = true,
            };

            court1 = new Court()
            {
                Id = 1,
                Name = "No1 club1",
                ClubId = 1,
                IsActive = true,
                IsIndoor = true,
                IsLighted = true,
                PricePerHour = 30,
                Surface = Common.Enums.Surface.Carpet,
            };

            court2 = new Court()
            {
                Id = 2,
                Name = "No1 Club2",
                ClubId = 2,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                PricePerHour = 20,
                Surface = Common.Enums.Surface.Clay,
            };

            court3 = new Court()
            {
                Id = 3,
                Name = "No2 Club2",
                ClubId = 2,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                PricePerHour = 20,
                Surface = Common.Enums.Surface.Clay,
            };

            notActiveCourt4 = new Court()
            {
                Id = 4,
                Name = "No1 Club7",
                ClubId = 7,
                IsActive = false,
                IsIndoor = false,
                IsLighted = true,
                PricePerHour = 20,
                Surface = Common.Enums.Surface.Clay,
            };

            court5 = new Court()
            {
                Id = 5,
                Name = "No1 Club3",
                ClubId = 3,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                PricePerHour = 40,
                Surface = Common.Enums.Surface.Hard,
            };

            court6 = new Court()
            {
                Id = 6,
                Name = "No1 Club4",
                ClubId = 4,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                PricePerHour = 40,
                Surface = Common.Enums.Surface.Hard,
            };

            court7 = new Court()
            {
                Id = 7,
                Name = "No2 Club4",
                ClubId = 4,
                IsActive = true,
                IsIndoor = false,
                IsLighted = false,
                PricePerHour = 40,
                Surface = Common.Enums.Surface.Grass,
            };

            court8 = new Court()
            {
                Id = 8,
                Name = "No1 Club5",
                ClubId = 5,
                IsActive = true,
                IsIndoor = false,
                IsLighted = false,
                PricePerHour = 40,
                Surface = Common.Enums.Surface.Grass,
            };

            court9 = new Court()
            {
                Id = 9,
                Name = "No1 Club6",
                ClubId = 6,
                IsActive = true,
                IsIndoor = false,
                IsLighted = false,
                PricePerHour = 40,
                Surface = Common.Enums.Surface.Clay,
            };

            court10 = new Court()
            {
                Id = 10,
                Name = "No2 Club6",
                ClubId = 6,
                IsActive = true,
                IsIndoor = false,
                IsLighted = false,
                PricePerHour = 40,
                Surface = Common.Enums.Surface.Clay,
            };


            court11 = new Court()
            {
                Id = 11,
                Name = "No1 Club8",
                ClubId = 8,
                IsActive = true,
                IsIndoor = false,
                IsLighted = false,
                PricePerHour = 40,
                Surface = Common.Enums.Surface.Clay,

            };

            court12 = new Court()
            {
                Id = 12,
                Name = "No2 Club8",
                ClubId = 8,
                IsActive = true,
                IsIndoor = false,
                IsLighted = false,
                PricePerHour = 40,
                Surface = Common.Enums.Surface.Clay,
            };

            court13 = new Court()
            {
                Id = 13,
                Name = "No1 Club7",
                ClubId = 7,
                IsActive = false,
                IsIndoor = false,
                IsLighted = false,
                PricePerHour = 40,
                Surface = Common.Enums.Surface.ArtificialGrass,
            };

            court14 = new Court()
            {
                Id = 14,
                Name = "No1 pendingClub2",
                ClubId = 11,
                IsActive = false,
                IsIndoor = false,
                IsLighted = false,
                PricePerHour = 40,
                Surface = Common.Enums.Surface.Hard,
            };

            booking1 = new Booking()
            {
                Id = 1,
                ClientId = "userId",
                ClientName = "Test Testov",
                BookingDate = DateTime.Now.AddDays(1),
                CourtId = 1,
                Hour = 16,
                BookedOn = DateTime.Now.AddDays(-1),
                PhoneNumber = "111111111",
                Price = 30,
                IsBookedByOwnerOrAdmin = false,
                IsDeleted = false
            };

            booking2 = new Booking()
            {
                Id = 2,
                ClientId = "userId",
                ClientName = "Test Testov",
                BookingDate = DateTime.Now.AddDays(1),
                CourtId = 1,
                Hour = 14,
                BookedOn = DateTime.Now.AddDays(-2),
                PhoneNumber = "111111111",
                Price = 30,
                IsBookedByOwnerOrAdmin = false,
            };

            booking3 = new Booking()
            {
                Id = 3,
                CourtId = 1,
                ClientId = "newUserId",
                Hour = 10,
                BookingDate = DateTime.Now.AddDays(1),
            };

            booking4 = new Booking()
            {
                Id = 4,
                CourtId = 1,
                ClientId = "newUserId",
                Hour = 11,
                BookingDate = DateTime.Now.AddDays(1),
            };

            booking5 = new Booking()
            {
                Id = 5,
                CourtId = 2,
                ClientId = "newUserId",
                Hour = 12,
                BookingDate = DateTime.Now.AddDays(1),
            };

            booking6 = new Booking()
            {
                Id = 6,
                CourtId = 2,
                ClientId = "newUserId",
                Hour = 10,
                BookingDate = DateTime.Now.AddDays(1),
            };

            booking7 = new Booking()
            {
                Id = 7,
                CourtId = 2,
                ClientId = "userId",
                Hour = 11,
                BookingDate = DateTime.Now.AddDays(2),
            };

            booking8 = new Booking()
            {
                Id = 8,
                CourtId = 2,
                ClientId = "userId",
                Hour = 12,
                BookingDate = DateTime.Now.AddDays(2),
            };

            booking9 = new Booking()
            {
                Id = 9,
                CourtId = 3,
                ClientId = "userId",
                Hour = 10,
                BookingDate = DateTime.Now.AddDays(2),
            };

            booking10 = new Booking()
            {
                Id = 10,
                CourtId = 3,
                ClientId = "userId",
                Hour = 11,
                BookingDate = DateTime.Now.AddDays(2),
            };

            bookingDeleted1 = new Booking()
            {
                Id = 11,
                CourtId = 3,
                ClientId = "userId",
                Hour = 12,
                IsDeleted = true,
                BookingDate = DateTime.Now.AddDays(2),
            };

            booking12 = new Booking()
            {
                Id = 12,
                CourtId = 5,
                ClientId = "userId",
                Hour = 10,
                BookingDate = DateTime.Now.AddDays(2),
            };

            booking13 = new Booking()
            {
                Id = 13,
                CourtId = 5,
                ClientId = "userId",
                Hour = 11,
                BookingDate = DateTime.Now.AddDays(2),
            };

            booking14 = new Booking()
            {
                Id = 14,
                CourtId = 5,
                ClientId = "newUser3Id",
                Hour = 12,
                BookingDate = DateTime.Now.AddDays(-1),
            };
            booking15 = new Booking()
            {
                Id = 15,
                CourtId = 6,
                ClientId = "newUser3Id",
                Hour = 10,
                BookingDate = DateTime.Now.AddDays(-1),
            };
            booking16 = new Booking()
            {
                Id = 16,
                CourtId = 6,
                ClientId = "newUser3Id",
                Hour = 11,
                BookingDate = DateTime.Now.AddDays(2),
            };
            booking17 = new Booking()
            {
                Id = 17,
                CourtId = 6,
                ClientId = "newUser3Id",
                Hour = 12,
                BookingDate = DateTime.Now.AddDays(2),
            };
            booking18 = new Booking()
            {
                Id = 18,
                CourtId = 6,
                ClientId = "newUser3Id",
                Hour = 13,
                BookingDate = DateTime.Now.AddDays(3),
            };
            bookingDeleted2 = new Booking()
            {
                Id = 19,
                CourtId = 6,
                ClientId = "newUser3Id",
                Hour = 10,
                IsDeleted = true,
                BookingDate = DateTime.Now.AddDays(3),
            };
            booking20 = new Booking()
            {
                Id = 20,
                CourtId = 4,
                ClientId = "newUser3Id",
                Hour = 11,
                BookingDate = DateTime.Now.AddDays(2),
            };

            review1 = new Review()
            {
                Id = 1,
                BookingId = 1,
                ClubId = 1,
                Rate = 10,
                ReviewerId = "user1",
                Title = "review1 title",
                Description = "review1 description",
                CreatedOn = DateTime.Now.AddDays(-10),
            };
            review2 = new Review()
            {
                Id = 2,
                BookingId = 2,
                ClubId = 1,
                Rate = 7,
                ReviewerId = "user1",
                Title = "review2 title",
                Description = "review2 description",
                CreatedOn = DateTime.Now.AddDays(-2),
            };
            review3 = new Review()
            {
                Id = 3,
                BookingId = 3,
                ClubId = 1,
                Rate = 7,
                ReviewerId = "user1",
                Title = "review3 title",
                Description = "review3 description",
                CreatedOn = DateTime.Now.AddDays(-2),
            };
            review4 = new Review()
            {
                Id = 4,
                BookingId = 4,
                ClubId = 2,
                Rate = 8,
                ReviewerId = "user1",
                Title = "review4 title",
                Description = "review4 description",
                CreatedOn = DateTime.Now.AddDays(-2),
            };
            review5 = new Review()
            {
                Id = 5,
                BookingId = 5,
                ClubId = 2,
                Rate = 5,
                ReviewerId = "user2",
                Title = "review5 title",
                Description = "review5 description",
                CreatedOn = DateTime.Now.AddDays(-5),
            };
            review6 = new Review()
            {
                Id = 6,
                BookingId = 6,
                ClubId = 2,
                Rate = 7,
                ReviewerId = "user2",
                Title = "review6 title",
                Description = "review6 description",
                CreatedOn = DateTime.Now.AddDays(-5),
            };
            review7 = new Review()
            {
                Id = 7,
                BookingId = 7,
                ClubId = 2,
                Rate = 7,
                ReviewerId = "user2",
                Title = "review7 title",
                Description = "review7 description",
                CreatedOn = DateTime.Now.AddDays(-4),
            };
            review8 = new Review()
            {
                Id = 8,
                BookingId = 8,
                ClubId = 3,
                Rate = 3,
                ReviewerId = "user3",
                Title = "review8 title",
                Description = "review8 description",
                CreatedOn = DateTime.Now.AddDays(-3),
            };
            review9 = new Review()
            {
                Id = 9,
                BookingId = 9,
                ClubId = 3,
                Rate = 7,
                ReviewerId = "user3",
                Title = "review9 title",
                Description = "review9 description",
                CreatedOn = DateTime.Now.AddDays(-2),
            };
            review10 = new Review()
            {
                Id = 10,
                BookingId = 10,
                ClubId = 3,
                Rate = 7,
                ReviewerId = "user3",
                Title = "review10 title",
                Description = "review10 description",
                CreatedOn = DateTime.Now.AddDays(-1),
            };



            cities = new List<City>()
            {
                city1, city2, city3,city4
            };

            users = new List<ApplicationUser>()
            {
                user1,user2,user3,clubOwner1,clubOwner2,clubOwner3,clubOwner4,clubOwner5,clubOwner6,clubOwnerPendingClub1,clubOwner8,clubOwnerDeletedClub,clubOwnerWiCourts,clubOwnerPendingClub1,clubOwnerPendingClub2
            };

            clubs = new List<Club>() { club1, club2, club3, club4, club5, club6, pendingClub1, club8, deletedClub, clubWithNoCouts, pendingClub2 };

            courts = new List<Court>() { court1, court2, court3, notActiveCourt4, court5, court6, court7, court8, court9, court10, court11, court12, court13, court14 };

            bookings = new List<Booking>()
            {
            booking1,booking2,booking3,booking4, booking5, booking6, booking7, booking8, booking9, booking10, bookingDeleted1,booking12,booking13,booking14,booking15, booking16, booking17, booking18,bookingDeleted2, booking20
            };

            reviews = new List<Review>()
            {
                review1,review2,review3,review4,review5,review6,review7,review8,review9,review10
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GameSetBookTestInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ApplicationDbContext(options);

            await dbContext.AddRangeAsync(users);
            await dbContext.AddAsync(country1);
            await dbContext.AddAsync(country2);
            await dbContext.AddRangeAsync(cities);
            await dbContext.AddRangeAsync(clubs);
            await dbContext.AddRangeAsync(courts);
            await dbContext.AddRangeAsync(bookings);
            await dbContext.AddRangeAsync(reviews);
            await dbContext.SaveChangesAsync();

            repository = new Repository(dbContext);
            service = new ReviewServiceAdmin(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task ExistAsync_ExistingId_ReturnsTrue()
        {
            int existingId = review1.Id;

            bool exists = await service.ExistAsync(existingId);

            Assert.That(exists, Is.True);
        }

        [Test]
        public async Task ExistAsync_NonExistingId_ReturnsFalse()
        {
            int nonExistingId = -1;

            bool exists = await service.ExistAsync(nonExistingId);

            Assert.That(exists, Is.False);
        }

        [Test]
        public async Task GetReviewReviseModelAsync_ExistingId_ReturnsValidModel()
        {
            int existingId = review1.Id;

            var model = await service.GetReviewReviseModelAsync(existingId);

            Assert.That(model, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(model.Id, Is.EqualTo(existingId));
                Assert.That(model.ClubId, Is.EqualTo(review1.ClubId));
                Assert.That(model.Description, Is.EqualTo(review1.Description));
                Assert.That(model.Rating, Is.EqualTo(review1.Rate));
                Assert.That(model.Title, Is.EqualTo(review1.Title));
                Assert.That(model.ReviewerEmail, Is.EqualTo(user1.Email));
                Assert.That(model.ClubName, Is.EqualTo(club1.Name));
                Assert.That(model.DateAddedOn, Is.Not.Empty);
            });
        }

        [Test]
        public async Task ReviseAsync_ExistingModel_UpdatesReview()
        {
            var updatedRate = 5;

            var model = new ReviewReviseAdminFormModel
            {
                Id = review1.Id,
                Title = "Revised Title",
                Description = "Revised Description",
                Rating = updatedRate
            };

            await service.ReviseAsync(model);

            var revisedReview = reviews.FirstOrDefault(r => r.Id == model.Id);
            Assert.That(revisedReview, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(revisedReview.Title, Is.EqualTo(model.Title));
                Assert.That(revisedReview.Description, Is.EqualTo(model.Description));
                Assert.That(revisedReview.Rate, Is.EqualTo(model.Rating));
            });
        }

        [Test]
        public async Task GetDetailsViewModel_ReturnsCorrectViewModel()
        {
            int existingReviewId = review1.Id;

            var result = await service.GetDetailsViewModelAsync(existingReviewId);

            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(existingReviewId));
                Assert.That(result.ClubId, Is.EqualTo(review1.ClubId));
                Assert.That(result.Description, Is.EqualTo(review1.Description));
                Assert.That(result.Rate, Is.EqualTo(review1.Rate));
                Assert.That(result.Title, Is.EqualTo(review1.Title));
                Assert.That(result.ClubName, Is.EqualTo(club1.Name));
                Assert.That(result.AddedDateOn, Is.EqualTo(review1.CreatedOn.ToString("yyyy-MM-dd HH:mm")));
            });
        }

        [Test]
        public async Task HardDeleteAsync_RemovesReviewEntity()
        {
            var existingReviewId = review1.Id;
            var reviewsCountBeforeAct = await dbContext.Reviews.CountAsync();

            await service.HardDeleteAsync(existingReviewId);

            var result = await dbContext.Reviews.FindAsync(existingReviewId);
            var reviewsCountAfterAct = await dbContext.Reviews.CountAsync();
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Null);
                Assert.That(reviewsCountBeforeAct, Is.GreaterThan(reviewsCountAfterAct));
                Assert.That(reviewsCountAfterAct, Is.EqualTo(reviewsCountBeforeAct - 1));
            });
        }

        [Test]
        public async Task AllClubReviewsAsync_FilterByClubId_ReturnsFilteredResults()
        {
            int clubId = club1.Id;
            var model = new AllReviewAdminSortingModel
            {
                ClubId = clubId
            };

            var result = await service.AllClubReviewsAsync(model);

            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.ClubId, Is.EqualTo(clubId));
                Assert.That(result.Reviews.All(r => r.ClubId == clubId), Is.True);
                Assert.That(result.TotalReviewCount, Is.EqualTo(3));
            });
        }

        [Test]
        public async Task AllClubReviewsAsync_FilterBySearchTerm_ReturnsFilteredResults()
        {
            var searchTerm = "review1";
            var model = new AllReviewAdminSortingModel
            {
                SearchTerm = searchTerm
            };

            var result = await service.AllClubReviewsAsync(model);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Reviews.All(r =>
                r.Title.ToUpper().Contains(searchTerm.ToUpper()) ||
                r.Description.ToUpper().Contains(searchTerm.ToUpper()) ||
                r.ReviewerName.ToUpper().Contains(searchTerm.ToUpper()) ||
                r.ReviewerEmail.ToUpper().Contains(searchTerm.ToUpper())
            ), Is.True);
        }

        [Test]
        public async Task AllClubReviewsAsync_SortByCreatedOnAscending_ReturnsSortedResults()
        {
            var model = new AllReviewAdminSortingModel
            {
                ReviewSorting = ReviewSorting.CreatedOnAscending
            };

            var result = await service.AllClubReviewsAsync(model);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Reviews.OrderBy(r => r.AddedDateOn).SequenceEqual(result.Reviews), Is.True);
        }

        [Test]
        public async Task AllClubReviewsAsync_SortByRatingDescending_ReturnsSortedResults()
        {
            var model = new AllReviewAdminSortingModel
            {
                ReviewSorting = ReviewSorting.RatingDescending
            };

            var result = await service.AllClubReviewsAsync(model);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Reviews.OrderByDescending(r => r.Rate).SequenceEqual(result.Reviews), Is.True);
        }
    }
}
