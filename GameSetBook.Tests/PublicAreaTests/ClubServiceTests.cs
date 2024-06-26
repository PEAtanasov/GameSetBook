﻿using GameSetBook.Core.Contracts;
using GameSetBook.Core.Enums;
using GameSetBook.Core.Models.Admin.Club;
using GameSetBook.Core.Models.Club;
using GameSetBook.Core.Services;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Data;
using GameSetBook.Infrastructure.Models;
using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Internal;

namespace GameSetBook.Tests.PublicAreaTests
{

    [TestFixture]
    public class ClubServiceTests
    {
        private ApplicationDbContext dbContext;

        private IRepository repository;
        private IClubService service;

        private IEnumerable<City> cities;
        private IEnumerable<Booking> bookings;
        private IEnumerable<Club> clubs;
        private IEnumerable<Court> courts;
        private IEnumerable<ApplicationUser> users;

        private ApplicationUser user1;
        private ApplicationUser user2;
        private ApplicationUser user3;
        private ApplicationUser clubOwner1;
        private ApplicationUser clubOwner2;
        private ApplicationUser clubOwner3;
        private ApplicationUser clubOwner4;
        private ApplicationUser clubOwner5;
        private ApplicationUser clubOwner6;
        private ApplicationUser clubOwner7;
        private ApplicationUser clubOwner8;
        private ApplicationUser clubOwnerDeletedClub;
        private ApplicationUser clubOwnerWiCourts;

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
        private Club club7;
        private Club club8;
        private Club deletedClub;
        private Club clubWithNoCouts;

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

            user2 = new ApplicationUser()
            {
                Id = "newUserId"
            };

            user3 = new ApplicationUser()
            {
                Id = "newUser3Id"
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
            clubOwner7 = new ApplicationUser()
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
            club7 = new Club()
            {
                Id = 7,
                CityId = 4,
                Name = "Club7",
                ClubOwnerId = "clubOwnerId7",
                IsAproovedByAdmin = false,
                NumberOfCourts = 1,
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
                ReviewerId = "userId"
            };
            review2 = new Review()
            {
                Id = 2,
                BookingId = 2,
                ClubId = 1,
                Rate = 7,
                ReviewerId = "userId"
            };



            cities = new List<City>()
            {
                    city1, city2, city3,city4
            };

            users = new List<ApplicationUser>()
            {
                    user1,user2,user3,clubOwner1,clubOwner2,clubOwner3,clubOwner4,clubOwner5,clubOwner6,clubOwner7,clubOwner8,clubOwnerDeletedClub,clubOwnerWiCourts
            };

            clubs = new List<Club>() { club1, club2, club3, club4, club5, club6, club7, club8, deletedClub, clubWithNoCouts };

            courts = new List<Court>() { court1, court2, court3, notActiveCourt4, court5, court6, court7, court8, court9, court10, court11, court12 };

            bookings = new List<Booking>()
            {
                booking1,booking2,booking3,booking4, booking5, booking6, booking7, booking8, booking9, booking10, bookingDeleted1,booking12,booking13,booking14,booking15, booking16, booking17, booking18,bookingDeleted2, booking20
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
            await dbContext.AddAsync(review1);
            await dbContext.AddAsync(review2);
            await dbContext.SaveChangesAsync();

            repository = new Repository(dbContext);
            service = new ClubService(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task IsClubAproovedAsync_ShouldReturnTrueIfClubisApprovedOrFalseIfNot()
        {
            var approvedClubId = 1;
            var notApprovedClubId = 7;

            var result1 = await service.IsClubAproovedAsync(approvedClubId);
            var result2 = await service.IsClubAproovedAsync(notApprovedClubId);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task IsClubAproovedAsync_ShouldReturnFalseIfClubIsDeleted()
        {
            var approvedClubId = deletedClub.Id;

            var result1 = await service.IsClubAproovedAsync(approvedClubId);

            Assert.That(result1, Is.False);

        }

        [Test]
        public async Task ExsitByNameAsync_ShouldReturnTrueIfClubExistOrFalseIfNot()
        {
            var existingClubName1 = "Club1";
            var existingClubName2 = "Club2";
            var notExistingClubName = "Not Exist";

            var result1 = await service.ExsitByNameAsync(existingClubName1);
            var result2 = await service.ExsitByNameAsync(existingClubName2);
            var result3 = await service.ExsitByNameAsync(notExistingClubName);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
            Assert.That(result3, Is.False);
        }

        [Test]
        public async Task ExsitAnotherCluWhitNameAsync_ShoudReturnTrueIfAnotherClubHasThatNameOrFalseIfNot()
        {
            var existingClubName1 = "Club1";
            var existingClubId1 = 1;
            var existingClubName2 = "Club2";
            var existingClubId2 = 2;
            var notExistingClubName = "Not Exist";
            var notExistingClubId = -1;

            var result1 = await service.ExsitAnotherClubWhitNameAsync(existingClubId1, existingClubName2);
            var result2 = await service.ExsitAnotherClubWhitNameAsync(existingClubId2, existingClubName1);
            var result3 = await service.ExsitAnotherClubWhitNameAsync(notExistingClubId, notExistingClubName);
            var result4 = await service.ExsitAnotherClubWhitNameAsync(existingClubId1, existingClubName1);


            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
            Assert.That(result3, Is.False);
            Assert.That(result4, Is.False);
        }

        [Test]
        public async Task ExsitAsync_ShouldReturnTrueIfClubExistOrFalseIfNot()
        {
            var existingClubId = club1.Id;
            var notExistingClubId = -1;

            var result1 = await service.ExsitAsync(existingClubId);
            var result2 = await service.ExsitAsync(notExistingClubId);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task ExsitAsync_ShouldReturnFalseClubIsSetAsDeleted()
        {
            var deletedClubId = deletedClub.Id;

            var result = await service.ExsitAsync(deletedClubId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task ClubWithOwnerIdExistAsync_ShouldReturnTrueIfClubExistOrFalseIfNot()
        {
            var existingClubOwnerId = clubOwner1.Id;
            var notExistingClubOwnerId = "NotExistingClubOwnerId";

            var result1 = await service.ClubWithOwnerIdExistAsync(existingClubOwnerId);
            var result2 = await service.ClubWithOwnerIdExistAsync(notExistingClubOwnerId);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task ClubWithOwnerIdExistAsync_ShouldReturnFalseIfClubExistButSetToDeleted()
        {
            var deletedClubOwnerId = clubOwnerDeletedClub.Id;


            var result = await service.ClubWithOwnerIdExistAsync(deletedClubOwnerId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task IsTheOwnerOfTheClubAsync_ShouldReturnTrueIfUserIsTheOwnerOfTheClub()
        {
            var clubId = club1.Id;
            var clubOwnerId = clubOwner1.Id;
            var notClubOwnerId = clubOwner2.Id;

            var result1 = await service.IsTheOwnerOfTheClubAsync(clubId, clubOwnerId);
            var result2 = await service.IsTheOwnerOfTheClubAsync(clubId, notClubOwnerId);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task GetClubIdByOwnerIdAsync_ShouldReturnClubId()
        {
            var club1Id = club1.Id;
            var clubOwner1Id = clubOwner1.Id;

            var club2Id = club2.Id;
            var clubOwner2Id = clubOwner2.Id;

            var result1 = await service.GetClubIdByOwnerIdAsync(clubOwner1Id);
            var result2 = await service.GetClubIdByOwnerIdAsync(clubOwner2Id);

            Assert.That(result1, Is.Not.EqualTo(result2));
            Assert.That(result1, Is.EqualTo(club1Id));
            Assert.That(result2, Is.EqualTo(club2Id));
        }

        [Test]
        public async Task ClubHasCourtsAsync_ShouldReturnTrueIfClubHasCourtsAndFalseIfNot()
        {
            var clubWithCourtsId = club2.Id;
            var clubWithOutCourtsId = clubWithNoCouts.Id;

            var result1 = await service.ClubHasCourtsAsync(clubWithCourtsId);
            var result2 = await service.ClubHasCourtsAsync(clubWithOutCourtsId);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task NumberOfCourtsAsync_ShoudReturnValueOfTheClubPropertyNumberOfCourts()
        {
            var club1Id = club1.Id;
            var expectedResult1 = club1.NumberOfCourts; ;

            var club2Id = club2.Id;
            var expectedResult2 = club2.NumberOfCourts;

            var result1 = await service.NumberOfCourtsAsync(club1Id);
            var result2 = await service.NumberOfCourtsAsync(club2Id);

            Assert.That(result1, Is.EqualTo(expectedResult1));
            Assert.That(result2, Is.EqualTo(expectedResult2));
        }

        [Test]
        public async Task GetClubIdByBookingIdAsync_ShouldReturnClubId()
        {
            var bookingId1 = booking1.Id;
            var bookingId2 = booking2.Id;

            var expectedResult = club1.Id;

            var result1 = await service.GetClubIdByBookingIdAsync(bookingId1);
            var result2 = await service.GetClubIdByBookingIdAsync(bookingId2);

            Assert.That(result1, Is.EqualTo(expectedResult));
            Assert.That(result2, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task GetClubIdByNameAsync_ShouldReturnClubId()
        {
            var clubName1 = club1.Name;
            var clubName2 = club2.Name;

            var expectedResult1 = club1.Id;
            var expectedResult2 = club2.Id;

            var result1 = await service.GetClubIdByNameAsync(clubName1);
            var result2 = await service.GetClubIdByNameAsync(clubName2);

            Assert.That(result1, Is.Not.EqualTo(result2));
            Assert.That(result1, Is.EqualTo(expectedResult1));
            Assert.That(result2, Is.EqualTo(expectedResult2));
        }

        [Test]
        public async Task GetAllClubsAsync_ShoudReturnCollectionOfAllClubs()
        {
            var totalClubsCountWithoutDeletedAndAprroved = clubs.Where(c => c.IsDeleted == false && c.IsAproovedByAdmin == true).Count();

            var result = await service.GetAllClubsAsync();

            Assert.That(result.Count(), Is.EqualTo(totalClubsCountWithoutDeletedAndAprroved));
        }

        [Test]
        public async Task CreateAsync_CheckIfClubIsAddedSuccessfully()
        {
            var clubsCountBeforeAdding = clubs.Count();
            var clubExistBeforeAdding = await dbContext.Clubs.IgnoreQueryFilters().AnyAsync(c => c.Id == 100);
            var clubToAdd = new ClubFormModel()
            {
                Id = 100,
                Name = "Test Adding",
                ClubOwnerId = "userId",
                CityId = 1,
            };

            await service.CreateAsync(clubToAdd);

            var clubsCountAfterAdding = await dbContext.Clubs.IgnoreQueryFilters().CountAsync();
            var clubExistAfterAdding = await dbContext.Clubs.IgnoreQueryFilters().AnyAsync(c => c.Name == "Test Adding");


            Assert.That(clubsCountAfterAdding, Is.GreaterThan(clubsCountBeforeAdding));
            Assert.That(clubsCountAfterAdding, Is.EqualTo(clubsCountBeforeAdding + 1));
            Assert.That(clubExistBeforeAdding, Is.False);
            Assert.That(clubExistAfterAdding, Is.True);
        }

        [Test]
        public async Task GetClubIfnoAsync_ShouldReturnModelWithCorrectData()
        {
            var expectedClubId = club1.Id;
            var expectedClubName = club1.Name;
            var expectedPhoneNumber = club1.PhoneNumber;
            var expectedEmail = club1.Email;
            var expectedAdress = club1.Address;
            var expectedLogourl = club1.LogoUrl;

            var model = await service.GetClubIfnoAsync(expectedClubId);

            var actualId = model.Id;
            var actualName = model.Name;
            var actualPhoneNumber = model.PhoneNumber;
            var actualEmail = model.Email;
            var actualAdress = model.Address;
            var actualLogourl = model.Logourl;

            Assert.Multiple(() =>
            {
                Assert.That(actualId, Is.EqualTo(expectedClubId));
                Assert.That(actualEmail, Is.EqualTo(expectedEmail));
                Assert.That(actualName, Is.EqualTo(expectedClubName));
                Assert.That(actualPhoneNumber, Is.EqualTo(expectedPhoneNumber));
                Assert.That(actualAdress, Is.EqualTo(expectedAdress));
                Assert.That(actualLogourl, Is.EqualTo(expectedLogourl));
            });
        }

        [Test]
        public async Task GetClubDetailsAsync_ShouldReturnModelWithCorrectData()
        {
            var clubId = 1;

            var expectedClubId = club1.Id;
            var expectedClubName = club1.Name;
            var expectedHasParking = club1.HasParking;
            var expectedHasShower = club1.HasShower;
            var expectedHasShop = club1.HasShop;
            var expectedRating = club1.Rating;
            var expectedDescription = club1.Description;
            var expectedNumberOfCoaches = club1.NumberOfCoaches;
            var expectedNumberOfCourts = club1.NumberOfCourts;
            var expectedWorkingTimeStart = club1.WorkingTimeStart;
            var expectedWorkingTimeEnd = club1.WorkingTimeEnd;

            var model = await service.GetClubDetailsAsync(clubId);

            var actualId = model.Id;
            var actualName = model.Name;
            var actualHasParking = model.HasParking;
            var actualHasShower = model.HasShower;
            var actualHasShop = model.HasShop;
            var actualRating = model.Rating;
            var actualDescription = model.Description;
            var actualNumberOfCoaches = model.NumberOfCoaches;
            var actualNumberOfCourts = model.NumberOfCourts;
            var actualWorkingTimeStart = model.WorkingTimeStart;
            var actualWorkingTimeEnd = model.WorkingTimeEnd;

            Assert.Multiple(() =>
            {
                Assert.That(actualId, Is.EqualTo(expectedClubId));
                Assert.That(actualName, Is.EqualTo(expectedClubName));
                Assert.That(actualHasParking, Is.EqualTo(expectedHasParking));
                Assert.That(actualHasShower, Is.EqualTo(expectedHasShower));
                Assert.That(actualHasShop, Is.EqualTo(expectedHasShop));
                Assert.That(actualRating, Is.EqualTo(expectedRating));
                Assert.That(actualDescription, Is.EqualTo(expectedDescription));
                Assert.That(actualNumberOfCoaches, Is.EqualTo(expectedNumberOfCoaches));
                Assert.That(actualNumberOfCourts, Is.EqualTo(expectedNumberOfCourts));
                Assert.That(actualWorkingTimeStart, Is.EqualTo(expectedWorkingTimeStart));
                Assert.That(actualWorkingTimeEnd, Is.EqualTo(expectedWorkingTimeEnd));
            });
        }

        [Test]
        public async Task GetEditFormModelAsync_ShouldReturnModelWithCorrectData()
        {
            var clubId = 1;

            var expectedClubId = club1.Id;
            var expectedClubName = club1.Name;
            var expectedHasParking = club1.HasParking;
            var expectedHasShower = club1.HasShower;
            var expectedHasShop = club1.HasShop;
            var expectedDescription = club1.Description;
            var expectedNumberOfCoaches = club1.NumberOfCoaches;
            var expectedNumberOfCourts = club1.NumberOfCourts;
            var expectedWorkingTimeStart = club1.WorkingTimeStart;
            var expectedWorkingTimeEnd = club1.WorkingTimeEnd;
            var expectedAdress = club1.Address;
            var expectedCityId = club1.CityId;
            var expectedEmail = club1.Email;
            var expectedClubOwnerId = club1.ClubOwnerId;
            var expectedLogoUrl = club1.LogoUrl;
            var expectedPhoneNumber = club1.PhoneNumber;

            var model = await service.GetEditFormModelAsync(clubId);

            var actualId = model.Id;
            var actualName = model.Name;
            var actualHasParking = model.HasParking;
            var actualHasShower = model.HasShower;
            var actualHasShop = model.HasShop;
            var actualDescription = model.Description;
            var actualNumberOfCoaches = model.NumberOfCoaches;
            var actualNumberOfCourts = model.NumberOfCourts;
            var actualWorkingTimeStart = model.WorkingTimeStart;
            var actualWorkingTimeEnd = model.WorkingTimeEnd;
            var actualAdress = model.Address;
            var actualCityId = model.CityId;
            var actualEmail = model.Email;
            var actualClubOwnerId = model.ClubOwnerId;
            var actualLogoUrl = model.LogoUrl;
            var actualPhoneNumber = model.PhoneNumber;

            Assert.Multiple(() =>
            {
                Assert.That(actualId, Is.EqualTo(expectedClubId));
                Assert.That(actualName, Is.EqualTo(expectedClubName));
                Assert.That(actualHasParking, Is.EqualTo(expectedHasParking));
                Assert.That(actualHasShower, Is.EqualTo(expectedHasShower));
                Assert.That(actualHasShop, Is.EqualTo(expectedHasShop));
                Assert.That(actualDescription, Is.EqualTo(expectedDescription));
                Assert.That(actualNumberOfCoaches, Is.EqualTo(expectedNumberOfCoaches));
                Assert.That(actualNumberOfCourts, Is.EqualTo(expectedNumberOfCourts));
                Assert.That(actualWorkingTimeStart, Is.EqualTo(expectedWorkingTimeStart));
                Assert.That(actualWorkingTimeEnd, Is.EqualTo(expectedWorkingTimeEnd));
                Assert.That(actualAdress, Is.EqualTo(expectedAdress));
                Assert.That(actualCityId, Is.EqualTo(expectedCityId));
                Assert.That(actualEmail, Is.EqualTo(expectedEmail));
                Assert.That(actualClubOwnerId, Is.EqualTo(expectedClubOwnerId));
                Assert.That(actualLogoUrl, Is.EqualTo(expectedLogoUrl));
                Assert.That(actualPhoneNumber, Is.EqualTo(expectedPhoneNumber));
            });
        }

        [Test]
        public async Task EditAsync_ChecksIfClubUpdatedSuccessfully()
        {
            int clubId = 1;

            var currentClubId = club1.Id;
            var currentClubOwnerId = club1.ClubOwnerId;
            var currentClubName = club1.Name;
            var currentHasParking = club1.HasParking;
            var currentHasShower = club1.HasShower;
            var currentHasShop = club1.HasShop;
            var currentDescription = club1.Description;
            var currentNumberOfCoaches = club1.NumberOfCoaches;
            var currentWorkingTimeStart = club1.WorkingTimeStart;
            var currentWorkingTimeEnd = club1.WorkingTimeEnd;
            var currentAdress = club1.Address;
            var currentCityId = club1.CityId;
            var currentEmail = club1.Email;
            var currentLogoUrl = club1.LogoUrl;
            var currentPhoneNumber = club1.PhoneNumber;

            var editModel = new ClubFormModel()
            {
                Id = clubId,
                Name = "updated name",
                Description = "updated description",
                Address = "updated address",
                CityId = 2,
                HasParking = false,
                Email = "updated@mail.com",
                HasShop = true,
                HasShower = false,
                NumberOfCoaches = 2,
                PhoneNumber = "000000000",
                WorkingTimeStart = 7,
                WorkingTimeEnd = 22,
                LogoUrl = "updatedLogo"
            };

            await service.EditAsync(editModel);

            var updatedClub = await dbContext.Clubs.Where(c => c.Id == clubId).FirstAsync();

            var actualId = updatedClub.Id;
            var actualClubOwnerId = updatedClub.ClubOwnerId;
            var actualName = updatedClub.Name;
            var actualHasParking = updatedClub.HasParking;
            var actualHasShower = updatedClub.HasShower;
            var actualHasShop = updatedClub.HasShop;
            var actualDescription = updatedClub.Description;
            var actualNumberOfCoaches = updatedClub.NumberOfCoaches;
            var actualWorkingTimeStart = updatedClub.WorkingTimeStart;
            var actualWorkingTimeEnd = updatedClub.WorkingTimeEnd;
            var actualAdress = updatedClub.Address;
            var actualCityId = updatedClub.CityId;
            var actualEmail = updatedClub.Email;
            var actualLogoUrl = updatedClub.LogoUrl;
            var actualPhoneNumber = updatedClub.PhoneNumber;
            Assert.Multiple(() =>
            {
                Assert.That(actualId, Is.EqualTo(currentClubId));
                Assert.That(actualClubOwnerId, Is.EqualTo(currentClubOwnerId));

                //Updated Data
                Assert.That(actualName, Is.Not.EqualTo(currentClubName));
                Assert.That(actualHasParking, Is.Not.EqualTo(currentHasParking));
                Assert.That(actualHasShower, Is.Not.EqualTo(currentHasShower));
                Assert.That(actualHasShop, Is.Not.EqualTo(currentHasShop));
                Assert.That(actualDescription, Is.Not.EqualTo(currentDescription));
                Assert.That(actualNumberOfCoaches, Is.Not.EqualTo(currentNumberOfCoaches));
                Assert.That(actualWorkingTimeStart, Is.Not.EqualTo(currentWorkingTimeStart));
                Assert.That(actualWorkingTimeEnd, Is.Not.EqualTo(currentWorkingTimeEnd));
                Assert.That(actualAdress, Is.Not.EqualTo(currentAdress));
                Assert.That(actualCityId, Is.Not.EqualTo(currentCityId));
                Assert.That(actualEmail, Is.Not.EqualTo(currentEmail));
                Assert.That(actualLogoUrl, Is.Not.EqualTo(currentLogoUrl));
                Assert.That(actualPhoneNumber, Is.Not.EqualTo(currentPhoneNumber));
            });

            Assert.Multiple(() =>
            {
                Assert.That(actualHasShower, Is.EqualTo(editModel.HasShower));
                Assert.That(actualHasShop, Is.EqualTo(editModel.HasShop));
                Assert.That(actualDescription, Is.EqualTo(editModel.Description));
                Assert.That(actualNumberOfCoaches, Is.EqualTo(editModel.NumberOfCoaches));
                Assert.That(actualWorkingTimeStart, Is.EqualTo(editModel.WorkingTimeStart));
                Assert.That(actualWorkingTimeEnd, Is.EqualTo(editModel.WorkingTimeEnd));
                Assert.That(actualAdress, Is.EqualTo(editModel.Address));
                Assert.That(actualCityId, Is.EqualTo(editModel.CityId));
                Assert.That(actualEmail, Is.EqualTo(editModel.Email));
                Assert.That(actualLogoUrl, Is.EqualTo(editModel.LogoUrl));
                Assert.That(actualPhoneNumber, Is.EqualTo(editModel.PhoneNumber));
            });
        }

        [Test]
        public async Task GetClubSortingServiceModelAsync_ReturnsClubSortingModel()
        {
            var model = new AllClubsSortingModel
            {
                Country = country1.Name,
                City = city1.Name,
                SearchTerm = "club",
                ClubSorting = ClubSorting.RatingDescending,
                ClubsPerPage = 10,
                CurrentPage = 1
            };

            var sortedModel = await service.GetClubSortingServiceModelAsync(model);

            Assert.That(sortedModel, Is.Not.Null);
            Assert.That(sortedModel.Clubs, Is.Not.Null);
            Assert.That(sortedModel.Clubs.Count(), Is.GreaterThanOrEqualTo(0));

            switch (model.ClubSorting)
            {
                case ClubSorting.RatingDescending:
                    Assert.That(sortedModel.Clubs.Select(c => c.Rating).OrderByDescending(r => r).SequenceEqual(sortedModel.Clubs.Select(c => c.Rating)), Is.True);
                    break;
            }
        }

        [Test]
        public async Task GetClubSortingServiceModelAsync_SortsByPriceAscending()
        {
            var model = new AllClubsSortingModel
            {
                ClubSorting = ClubSorting.PriceAscending,
                ClubsPerPage = 10,
                CurrentPage = 1
            };

            var sortedModel = await service.GetClubSortingServiceModelAsync(model);

            Assert.That(sortedModel, Is.Not.Null);
            Assert.That(sortedModel.Clubs, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(sortedModel.Clubs.Count(), Is.GreaterThanOrEqualTo(0));
                Assert.That(sortedModel.Clubs.Select(c => c.Price).OrderBy(p => p).SequenceEqual(sortedModel.Clubs.Select(c => c.Price)), Is.True);
            });
        }

        [Test]
        public async Task GetClubSortingServiceModelAsync_SortsByPriceDescending()
        {
            var model = new AllClubsSortingModel
            {
                ClubSorting = ClubSorting.PriceDescending,
                ClubsPerPage = 10,
                CurrentPage = 1
            };

            var sortedModel = await service.GetClubSortingServiceModelAsync(model);

            Assert.That(sortedModel, Is.Not.Null);
            Assert.That(sortedModel.Clubs, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(sortedModel.Clubs.Count(), Is.GreaterThanOrEqualTo(0));
                Assert.That(sortedModel.Clubs.Select(c => c.Price).OrderByDescending(p => p).SequenceEqual(sortedModel.Clubs.Select(c => c.Price)), Is.True);
            });
        }

        [Test]
        public async Task GetClubSortingServiceModelAsync_SortsByNumberOfCourtsAscending()
        {
            var model = new AllClubsSortingModel
            {
                ClubSorting = ClubSorting.NumberOfCourtsAscending,
                ClubsPerPage = 10,
                CurrentPage = 1
            };

            var sortedModel = await service.GetClubSortingServiceModelAsync(model);

            Assert.That(sortedModel, Is.Not.Null);
            Assert.That(sortedModel.Clubs, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(sortedModel.Clubs.Count(), Is.GreaterThanOrEqualTo(0));
                Assert.That(sortedModel.Clubs.Select(c => c.NumberofCourts).OrderBy(n => n).SequenceEqual(sortedModel.Clubs.Select(c => c.NumberofCourts)), Is.True);
            });
        }

        [Test]
        public async Task GetClubSortingServiceModelAsync_SortsByNumberOfCourtsDescending()
        {
            var model = new AllClubsSortingModel
            {
                ClubSorting = ClubSorting.NumberOfCourtsDescending,
                ClubsPerPage = 10,
                CurrentPage = 1
            };

            var sortedModel = await service.GetClubSortingServiceModelAsync(model);

            Assert.That(sortedModel, Is.Not.Null);
            Assert.That(sortedModel.Clubs, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(sortedModel.Clubs.Count(), Is.GreaterThanOrEqualTo(0));
                Assert.That(sortedModel.Clubs.Select(c => c.NumberofCourts).OrderByDescending(n => n).SequenceEqual(sortedModel.Clubs.Select(c => c.NumberofCourts)), Is.True);
            });
        }
    }
}

