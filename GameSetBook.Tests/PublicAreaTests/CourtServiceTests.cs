using GameSetBook.Core.Contracts;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Data;
using GameSetBook.Infrastructure.Models.Identity;
using GameSetBook.Infrastructure.Models;
using GameSetBook.Core.Services;
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
        //private IEnumerable<Review> reviews;
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
        private Booking bookingDeleted;

        private Review review1;
        //private Review review2;
        //private Review review3;
        //private Review review4;
        //private Review review5;
        //private Review review6;
        //private Review review7;
        //private Review review8;
        //private Review review9;
        //private Review review10;

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

            booking1 = new Booking()
            {
                Id = 1,
                ClientId = "userId",
                ClientName = "Test Testov",
                BookingDate = DateTime.Now.AddDays(2),
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
                BookingDate = DateTime.Now.AddDays(3),
                CourtId = 1,
                Hour = 14,
                BookedOn = DateTime.Now.AddDays(-1),
                PhoneNumber = "111111111",
                Price = 30,
                IsBookedByOwnerOrAdmin = false,
            };

            booking3 = new Booking()
            {
                Id = 10,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 10,
            };

            booking4 = new Booking()
            {
                Id = 11,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 11,
            };

            booking5 = new Booking()
            {
                Id = 12,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 12,
            };

            booking6 = new Booking()
            {
                Id = 13,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 13,
            };

            booking7 = new Booking()
            {
                Id = 14,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 14,
            };

            booking8 = new Booking()
            {
                Id = 15,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 15,
            };

            booking9 = new Booking()
            {
                Id = 16,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 16,
            };

            booking10 = new Booking()
            {
                Id = 17,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 17,
            };

            bookingDeleted = new Booking()
            {
                Id = 18,
                CourtId = 10,
                ClientId = "newUserId",
                Hour = 18,
                IsDeleted = true,
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

            //review2 = new Review()
            //{
            //    Id = 10,
            //    BookingId = 10,
            //    ClubId = 2,
            //    ReviewerId = "newUserId",
            //    CreatedOn = DateTime.Now.AddDays(-10),
            //    Rate = 1
            //};

            //review3 = new Review()
            //{
            //    Id = 11,
            //    BookingId = 11,
            //    ClubId = 2,
            //    ReviewerId = "newUserId",
            //    CreatedOn = DateTime.Now.AddDays(-9),
            //    Rate = 2
            //};

            //review4 = new Review()
            //{
            //    Id = 12,
            //    BookingId = 12,
            //    ClubId = 2,
            //    ReviewerId = "newUserId",
            //    CreatedOn = DateTime.Now.AddDays(-8),
            //    Rate = 3
            //};

            //review5 = new Review()
            //{
            //    Id = 13,
            //    BookingId = 13,
            //    ClubId = 2,
            //    ReviewerId = "newUserId",
            //    CreatedOn = DateTime.Now.AddDays(-7),
            //    Rate = 4
            //};
            //review6 = new Review()
            //{
            //    Id = 14,
            //    BookingId = 14,
            //    ClubId = 2,
            //    ReviewerId = "newUserId",
            //    CreatedOn = DateTime.Now.AddDays(-6),
            //    Rate = 5
            //};
            //review7 = new Review()
            //{
            //    Id = 15,
            //    BookingId = 15,
            //    ClubId = 2,
            //    ReviewerId = "newUserId",
            //    CreatedOn = DateTime.Now.AddDays(-5),
            //    Rate = 6
            //};
            //review8 = new Review()
            //{
            //    Id = 16,
            //    BookingId = 16,
            //    ClubId = 2,
            //    ReviewerId = "newUserId",
            //    CreatedOn = DateTime.Now.AddDays(-4),
            //    Rate = 7
            //};
            //review9 = new Review()
            //{
            //    Id = 17,
            //    BookingId = 17,
            //    ClubId = 2,
            //    ReviewerId = "newUserId",
            //    CreatedOn = DateTime.Now.AddDays(-3),
            //    Rate = 8
            //};
            //review10 = new Review()
            //{
            //    Id = 18,
            //    BookingId = 18,
            //    ClubId = 2,
            //    ReviewerId = "newUserId",
            //    CreatedOn = DateTime.Now.AddDays(-2),
            //    Rate = 9
            //};

            clubs = new List<Club>() { club1, club2 };
            courts = new List<Court>() { court1, court2 };
            bookings = new List<Booking>()
            {
                booking1,booking2,booking3,booking4, booking5, booking6, booking7, booking8, booking9, booking10, bookingDeleted
            };

            //reviews = new List<Review>()
            //{
            //    review1,review2,review3, review4, review5, review6, review7, review8, review9, review10
            //};


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
            await dbContext.AddAsync(review1);
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
    }
}
