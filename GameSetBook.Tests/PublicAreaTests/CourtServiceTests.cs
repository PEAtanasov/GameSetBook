using GameSetBook.Core.Contracts;
using GameSetBook.Core.Services;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Data;
using GameSetBook.Infrastructure.Models;
using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Tests.PublicAreaTests
{
    [TestFixture]
    public class CourtServiceTests
    {
        private ApplicationDbContext dbContext;

        private IRepository repository;
        private ICourtService service;

        private IEnumerable<Booking> bookings;
        private IEnumerable<Review> reviews;
        private IEnumerable<Club> clubs;
        private IEnumerable<Court> courts;

        private ApplicationUser user1;
        private ApplicationUser user2;
        private ApplicationUser user3;
        private ApplicationUser clubOwner1;
        private ApplicationUser clubOwner2;
        private ApplicationUser clubOwner3;

        private Country country;

        private City city;

        private Club club1;
        private Club club2;
        private Club club3;

        private Court court1;
        private Court court2;
        private Court court3;
        private Court notActiveCourt4;
        private Court court5;
        private Court court6;
        private Court court7;

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
                Id = "userId",
                UserName = "user@usermail.com",
                NormalizedUserName = "user@usermail.com".ToUpper(),
                Email = "user@usermail.com",
                NormalizedEmail = "user@usermail.com".ToUpper(),
                FirstName = "Test",
                LastName = "Testov",
                PhoneNumber = "111111111"
            };

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

            clubOwner2 = new ApplicationUser()
            {
                Id = "newOwnerId"
            };

            user2 = new ApplicationUser()
            {
                Id = "newUserId"
            };

            clubOwner3 = new ApplicationUser()
            {
                Id = "newOwner3Id"
            };

            user3 = new ApplicationUser()
            {
                Id = "newUser3Id"
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
                ClubOwnerId = "clubOwnerId",
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
                ClubOwnerId = "newOwnerId",
                IsAproovedByAdmin = true,
            };

            club3 = new Club()
            {
                Id = 2,
                CityId = 1,
                ClubOwnerId = "newOwnerId",
                IsAproovedByAdmin = true,
            };

            court1 = new Court()
            {
                Id = 1,
                Name = "No1",
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
                Name = "Court1 Club2",
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
                Name = "Court2 Club2",
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
                Name = "Court3 Club2",
                ClubId = 2,
                IsActive = false,
                IsIndoor = false,
                IsLighted = true,
                PricePerHour = 20,
                Surface = Common.Enums.Surface.Clay,
            };

            court5 = new Court()
            {
                Id = 5,
                Name = "Court1 Club3",
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
                Name = "Court2 Club3",
                ClubId = 3,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                PricePerHour = 40,
                Surface = Common.Enums.Surface.Hard,
            };

            court7 = new Court()
            {
                Id = 7,
                Name = "Court3 Club3",
                ClubId = 3,
                IsActive = true,
                IsIndoor = false,
                IsLighted = false,
                PricePerHour = 40,
                Surface = Common.Enums.Surface.Grass,
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
                BookingDate = DateTime.Now.AddDays(1),
            };

            booking8 = new Booking()
            {
                Id = 8,
                CourtId = 2,
                ClientId = "userId",
                Hour = 12,
            };

            booking9 = new Booking()
            {
                Id = 9,
                CourtId = 3,
                ClientId = "userId",
                Hour = 10,
                BookingDate = DateTime.Now.AddDays(1),
            };

            booking10 = new Booking()
            {
                Id = 10,
                CourtId = 3,
                ClientId = "userId",
                Hour = 11,
                BookingDate = DateTime.Now.AddDays(1),
            };

            bookingDeleted1 = new Booking()
            {
                Id = 11,
                CourtId = 3,
                ClientId = "userId",
                Hour = 12,
                IsDeleted = true,
                BookingDate = DateTime.Now.AddDays(1),
            };

            booking12 = new Booking()
            {
                Id = 12,
                CourtId = 5,
                ClientId = "userId",
                Hour = 10,
                BookingDate = DateTime.Now.AddDays(1),
            };

            booking13 = new Booking()
            {
                Id = 13,
                CourtId = 5,
                ClientId = "userId",
                Hour = 11,
                BookingDate = DateTime.Now.AddDays(1),
            };

            booking14 = new Booking()
            {
                Id = 14,
                CourtId = 5,
                ClientId = "newOwner3Id",
                Hour = 12,
                BookingDate = DateTime.Now.AddDays(1),
            };
            booking15 = new Booking()
            {
                Id = 15,
                CourtId = 6,
                ClientId = "newOwner3Id",
                Hour = 10,
                BookingDate = DateTime.Now.AddDays(1),
            };
            booking16 = new Booking()
            {
                Id = 16,
                CourtId = 6,
                ClientId = "newOwner3Id",
                Hour = 11,
                BookingDate = DateTime.Now.AddDays(1),
            };
            booking17 = new Booking()
            {
                Id = 17,
                CourtId = 6,
                ClientId = "newOwner3Id",
                Hour = 12,
                BookingDate = DateTime.Now.AddDays(1),
            };
            booking18 = new Booking()
            {
                Id = 18,
                CourtId = 6,
                ClientId = "newOwner3Id",
                Hour = 17,
                BookingDate = DateTime.Now.AddDays(1),
            };
            bookingDeleted2 = new Booking()
            {
                Id = 19,
                CourtId = 6,
                ClientId = "newOwner3Id",
                Hour = 10,
                IsDeleted = true,
                BookingDate = DateTime.Now.AddDays(1),
            };
            booking20 = new Booking()
            {
                Id = 20,
                CourtId = 4,
                ClientId = "newOwner3Id",
                Hour = 11,
                BookingDate = DateTime.Now.AddDays(1),
            };

            review1 = new Review()
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

            review2 = new Review()
            {
                Id = 10,
                BookingId = 2,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-10),
                Rate = 1
            };

            review3 = new Review()
            {
                Id = 11,
                BookingId = 3,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-9),
                Rate = 2
            };

            review4 = new Review()
            {
                Id = 12,
                BookingId = 4,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-8),
                Rate = 3
            };

            review5 = new Review()
            {
                Id = 13,
                BookingId = 5,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-7),
                Rate = 4
            };
            review6 = new Review()
            {
                Id = 14,
                BookingId = 6,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-6),
                Rate = 5
            };
            review7 = new Review()
            {
                Id = 15,
                BookingId = 7,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-5),
                Rate = 6
            };
            review8 = new Review()
            {
                Id = 16,
                BookingId = 8,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-4),
                Rate = 7
            };
            review9 = new Review()
            {
                Id = 17,
                BookingId = 9,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-3),
                Rate = 8
            };
            review10 = new Review()
            {
                Id = 18,
                BookingId = 10,
                ClubId = 2,
                ReviewerId = "newUserId",
                CreatedOn = DateTime.Now.AddDays(-2),
                Rate = 9
            };

            clubs = new List<Club>() { club1, club2, club3 };

            courts = new List<Court>() { court1, court2, court3, notActiveCourt4, court5, court6, court7 };

            bookings = new List<Booking>()
            {
                booking1,booking2,booking3,booking4, booking5, booking6, booking7, booking8, booking9, booking10, bookingDeleted1,booking12,booking13,booking14,booking15, booking16, booking17, booking18, booking20
            };

            reviews = new List<Review>()
            {
                review1,review2,review3, review4, review5, review6, review7, review8, review9, review10
            };


            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GameSetBookTestInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ApplicationDbContext(options);

            await dbContext.AddAsync(user1);
            await dbContext.AddAsync(clubOwner1);
            await dbContext.AddAsync(user2);
            await dbContext.AddAsync(clubOwner2);
            await dbContext.AddAsync(user3);
            await dbContext.AddAsync(clubOwner3);
            await dbContext.AddAsync(country);
            await dbContext.AddAsync(city);
            await dbContext.AddRangeAsync(clubs);
            await dbContext.AddRangeAsync(courts);
            await dbContext.AddRangeAsync(bookings);
            await dbContext.AddRangeAsync(reviews);
            await dbContext.SaveChangesAsync();

            repository = new Repository(dbContext);
            service = new CourtService(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task a()
        {

        }
    }
}
