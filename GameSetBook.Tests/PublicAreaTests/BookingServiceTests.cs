using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Booking;
using GameSetBook.Core.Services;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Data;
using GameSetBook.Infrastructure.Models;
using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Tests.PublicAreaTests
{
    [TestFixture]
    public class BookingServiceTests
    {
        private ApplicationDbContext dbContext;

        private IRepository repository;
        private IBookingService service;

        private IEnumerable<Booking> bookings;
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
                Id = "newOwnerId",
                UserName = "clubowner2@clubowner.com",
                NormalizedUserName = "clubowner2@clubowner.com".ToUpper(),
                Email = "clubowner2@clubowner.com",
                NormalizedEmail = "clubowner2@clubowner.com".ToUpper(),
                FirstName = "Owner2",
                LastName = "Ownerov",
                PhoneNumber = "888888888888"
            };

            user2 = new ApplicationUser()
            {
                Id = "newUserId",
                UserName = "user2@usermail.com",
                NormalizedUserName = "user2@usermail.com".ToUpper(),
                Email = "user2@usermail.com",
                NormalizedEmail = "user2@usermail.com".ToUpper(),
                FirstName = "user2",
                LastName = "Testov",
                PhoneNumber = "9999999999"
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

            clubs = new List<Club>() { club1, club2 };

            courts = new List<Court>() { court1, court2 };

            bookings = new List<Booking>()
            {
                booking1,booking2,booking3,booking4, booking5, booking6, booking7, booking8, booking9, booking10, bookingDeleted
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
            await dbContext.AddAsync(review1);
            await dbContext.SaveChangesAsync();

            repository = new Repository(dbContext);
            service = new BookingService(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task ExistByIdAsync_ShouldReturnTrueIfBookingExistOrFalseIfBookingDoesNotExist()
        {
            var existingBookingId = 1;
            var notExistingBookingId = -2;

            var result1 = await service.ExistByIdAsync(existingBookingId);
            var result2 = await service.ExistByIdAsync(notExistingBookingId);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task BookingExistAsync_ShouldReturnTrueIfBookingExistOrFalseIfBookingDoesNotExist()
        {
            var existingBookingDate = booking3.BookingDate;
            var existingBookingHour = booking3.Hour;
            var existingBookingCourtId = booking3.CourtId;

            var result1 = await service.BookingExistAsync(existingBookingDate, existingBookingHour, existingBookingCourtId);
            var result2 = await service.BookingExistAsync(DateTime.Now.AddDays(1000), 1, existingBookingCourtId);
            var result3 = await service.BookingExistAsync(DateTime.Now.AddDays(1000), existingBookingHour, existingBookingCourtId);
            var result4 = await service.BookingExistAsync(existingBookingDate, -1, existingBookingCourtId);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.False);
            Assert.That(result3, Is.False);
            Assert.That(result4, Is.False);
        }

        [Test]
        public async Task DeleteAsync_ShouldSetBookingToDeleted()
        {
            booking1.IsDeleted = false;
            await dbContext.SaveChangesAsync();

            var cuurentStateOfbooking1 = booking1.IsDeleted;

            await service.DeleteAsync(booking1.Id);

            var stateOfBooking1ResultAfterDelete = booking1.IsDeleted;

            Assert.Multiple(() =>
            {
                Assert.That(cuurentStateOfbooking1, Is.False);
                Assert.That(stateOfBooking1ResultAfterDelete, Is.True);
            });

            Assert.That(cuurentStateOfbooking1, Is.Not.EqualTo(stateOfBooking1ResultAfterDelete));
        }

        [Test]
        public async Task EditAsync_ShouldChangeClientName()
        {
            var currentName = booking1.ClientName;
            var newName = "Name Edited";

            var model = new BookingEditFormModel()
            {
                Id = booking1.Id,
                ClientName = newName,
                BookingDate = booking1.BookingDate,
                PhoneNumber = booking1.PhoneNumber,
                Hour = booking1.Hour,
                Price = booking1.Price
            };

            await service.EditAsync(model);

            Assert.That(newName, Is.Not.EqualTo(currentName));
            Assert.That(booking1.ClientName, Is.EqualTo(newName));
            Assert.That(booking1.ClientName, Is.Not.EqualTo(currentName));
        }

        [Test]
        public async Task AddAsync_CheckIfBookingIsAddedSuccesfullyAndReturnsClubId()
        {
            var model = new BookingCreateFormModel()
            {
                ClientId = user1.Id,
                BookingDate = DateTime.Now.AddDays(100),
                Hour = 12,
                ClientName = user1.FirstName + " " + user1.LastName,
                CourtId = 1,
                PhoneNumber = user1.PhoneNumber,
                IsBookedByOwnerOrAdmin = false,
                Price = 30,
            };

            var totalBookingsBeforeAdding = await dbContext.Bookings.CountAsync();

            int clubId = await service.AddAsync(model);

            var totalBookingsAfterAdding = await dbContext.Bookings.CountAsync();

            Assert.That(totalBookingsAfterAdding, Is.EqualTo(totalBookingsBeforeAdding + 1));
            Assert.That(clubId, Is.EqualTo(club1.Id));
        }

        [Test]
        public async Task IsClubOwnerAllowedToEditAsync_CheckIfTheClubOwnerIsAllowedToEditBooking()
        {
            var ownerId = clubOwner1.Id;
            var anotherClubOwnerId = clubOwner2.Id;

            var result1 = await service.IsClubOwnerAllowedToEditAsync(booking1.Id, ownerId);
            var result2 = await service.IsClubOwnerAllowedToEditAsync(booking1.Id, anotherClubOwnerId);


            Assert.That(result1, Is.True);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task IsBookingClientAsync_CheckIfTheUserIsTheClientOfTheBooking()
        {
            var booking1Id = booking1.Id;
            var user1Id = user1.Id;

            var booking3Id = booking3.Id;
            var user2Id = user2.Id;

            var result1 = await service.IsBookingClientAsync(booking1Id, user1Id);
            var result2 = await service.IsBookingClientAsync(booking3Id, user2Id);

            var result3 = await service.IsBookingClientAsync(booking1Id, user2Id);
            var result4 = await service.IsBookingClientAsync(booking3Id, user1Id);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
            Assert.That(result3, Is.False);
            Assert.That(result4, Is.False);
        }

        [Test]
        public async Task IsCancelableAsync_ShouldReturnFalseIfBookingDateIsLessThanDayTimeNow()
        {
            booking3.BookingDate = DateTime.Now.AddDays(-1);
            await dbContext.SaveChangesAsync();

            var result = await service.IsCancelableAsync(booking3.Id);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task IsCancelableAsync_ShouldReturnFalseIfBookingDateIsEqualToDayTimeNowDateButHourIsNotGreaterOrEqualThenTwoHoursOfDateTimeNowHour()
        {
            booking3.BookingDate = DateTime.Now;
            booking3.Hour = DateTime.Now.AddHours(+2).Hour;
            booking4.BookingDate = DateTime.Now;
            booking4.Hour = DateTime.Now.AddHours(+1).Hour;
            await dbContext.SaveChangesAsync();

            var result1 = await service.IsCancelableAsync(booking3.Id);
            var result2 = await service.IsCancelableAsync(booking4.Id);

            Assert.That(result1, Is.False);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task IsCancelableAsync_ShouldReturnTrueIfBookingDateIsEqualToDayTimeNowDateAndHourIsGreaterThenTwoHoursOfDateTimeNowHour()
        {

            booking3.BookingDate = DateTime.Now;
            booking3.Hour = DateTime.Now.Hour + 3;
            booking4.BookingDate = DateTime.Now;
            booking4.Hour = DateTime.Now.Hour + 5;
            await dbContext.SaveChangesAsync();

            var result1 = await service.IsCancelableAsync(booking3.Id);
            var result2 = await service.IsCancelableAsync(booking3.Id);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
        }

        [Test]
        public async Task IsCancelableAsync_ShouldReturnTrueIfBookingDateIsGreaterThenDateTimeNowWithOneOrMoreDays()
        {

            booking3.BookingDate = DateTime.Now.AddDays(1);
            booking4.BookingDate = DateTime.Now.AddDays(30);
            await dbContext.SaveChangesAsync();

            var result1 = await service.IsCancelableAsync(booking3.Id);
            var result2 = await service.IsCancelableAsync(booking4.Id);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
        }

        [Test]
        public async Task BookingHasReviewAsync_CheckIfTheBookingHasReview()
        {
            var bookingWithoutReviewId = booking2.Id;
            var bookingWithReviewId = booking1.Id;

            var result1 = await service.HasReviewAsync(bookingWithoutReviewId);
            var result2 = await service.HasReviewAsync(bookingWithReviewId);

            Assert.That(result1, Is.False);
            Assert.That(result2, Is.True);
        }

        [Test]
        public async Task GetBookingToEditAsync_CheckIfReturnsModelWithCorrectData()
        {
            var result = await service.GetBookingToEditAsync(booking1.Id);

            Assert.That(result.Id, Is.EqualTo(booking1.Id));
            Assert.That(result.Hour, Is.EqualTo(booking1.Hour));
            Assert.That(result.Price, Is.EqualTo(booking1.Price));
            Assert.That(result.ClientName, Is.EqualTo(booking1.ClientName));
            Assert.That(result.PhoneNumber, Is.EqualTo(booking1.PhoneNumber));
            Assert.That(result.BookingDate, Is.EqualTo(booking1.BookingDate));
        }

        [Test]
        public async Task AreDateAndHourValidAsync_ShouldReturnFalseIfDateIsLessThanDateTimeNowDate()
        {
            var invalidDate1 = DateTime.Now.AddDays(-1);
            var invalidDate2 = DateTime.Now.AddDays(-100);
            var validHour = 12;
            var courtId = court1.Id;

            var result1 = await service.AreDateAndHourValidAsync(invalidDate1, validHour, courtId);
            var result2 = await service.AreDateAndHourValidAsync(invalidDate2, validHour, courtId);

            Assert.That(result1,Is.False);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task AreDateAndHourValidAsync_ShouldReturnFalseIfDateIsEqualToDateTimeNowDateButHourIsLessThanDateTimeNowHour()
        {
            var validDate = DateTime.Now;
            var invalidHour1 = DateTime.Now.Hour - 1;
            var invalidHour2 = DateTime.Now.Hour - 5;
            var courtId = court1.Id;

            var result1 = await service.AreDateAndHourValidAsync(validDate, invalidHour1, courtId);
            var result2 = await service.AreDateAndHourValidAsync(validDate, invalidHour2, courtId);

            Assert.That(result1, Is.False);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task AreDateAndHourValidAsync_ShouldReturnTrueIfDateIsValid()
        {
            var workingTimeStart = club1.WorkingTimeStart;
            var workingTimeEnd = club1.WorkingTimeEnd;

            var date = DateTime.Now.AddDays(1);

            var validHour1 = workingTimeStart + 1;
            var validHour2 = workingTimeEnd - 1;
            var courtId = court1.Id;

            var result1 = await service.AreDateAndHourValidAsync(date, validHour1, courtId);
            var result2 = await service.AreDateAndHourValidAsync(date, validHour2, courtId);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
        }
    }
}
