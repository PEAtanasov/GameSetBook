﻿using GameSetBook.Common.Enums.EnumExtensions;
using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Court;
using GameSetBook.Core.Services.Admin;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Data;
using GameSetBook.Infrastructure.Models;
using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Tests.AdminAreaTests
{
    public class CourtServiceAdminTests
    {
        private ApplicationDbContext dbContext;

        private IRepository repository;
        private ICourtServiceAdmin service;

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
                BookingDate = DateTime.Now,
            };

            booking4 = new Booking()
            {
                Id = 4,
                CourtId = 1,
                ClientId = "newUserId",
                Hour = 11,
                BookingDate = DateTime.Now,
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
                    user1,user2,user3,clubOwner1,clubOwner2,clubOwner3,clubOwner4,clubOwner5,clubOwner6,clubOwnerPendingClub1,clubOwner8,clubOwnerDeletedClub,clubOwnerWiCourts,clubOwnerPendingClub1,clubOwnerPendingClub2
            };

            clubs = new List<Club>() { club1, club2, club3, club4, club5, club6, pendingClub1, club8, deletedClub, clubWithNoCouts, pendingClub2 };

            courts = new List<Court>() { court1, court2, court3, notActiveCourt4, court5, court6, court7, court8, court9, court10, court11, court12, court13, court14 };

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
            service = new CourtServiceAdmin(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task EditAsync_UpdatesCourtProperties()
        {
            var model = new CourtAdminEditFormModel
            {
                Id = court1.Id,
                Name = "Updated Court Name",
                PricePerHour = 99,
                Surface = Common.Enums.Surface.Grass,
                IsLighted = false,
                IsIndoor = false,
                IsActive = false
            };

            await service.EditAsync(model);

            var updatedCourt = await dbContext.Courts.FindAsync(court1.Id);
            Assert.That(updatedCourt, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(updatedCourt.Name, Is.EqualTo(model.Name));
                Assert.That(updatedCourt.PricePerHour, Is.EqualTo(model.PricePerHour));
                Assert.That(updatedCourt.Surface, Is.EqualTo(model.Surface));
                Assert.That(updatedCourt.IsLighted, Is.EqualTo(model.IsLighted));
                Assert.That(updatedCourt.IsIndoor, Is.EqualTo(model.IsIndoor));
                Assert.That(updatedCourt.IsActive, Is.EqualTo(model.IsActive));
            });
        }

        [Test]
        public async Task ExistAsync_ShouldReturnTrueIfCourtExist()
        {
            int existingId = court1.Id;

            bool exists = await service.ExistAsync(existingId);

            Assert.That(exists, Is.True);
        }

        [Test]
        public async Task ExistAsync_ShouldReturnFalseIfCourtDoesNotExist()
        {
            int nonExistingId = -1;

            bool exists = await service.ExistAsync(nonExistingId);

            Assert.That(exists, Is.False);
        }


        [Test]
        public async Task AddAsync_WithValidData_AddsNewCourtAndUpdatesClub()
        {
            var model = new CourtAdminCreateFormModel
            {
                Name = "New Court",
                PricePerHour = 50,
                Surface = Common.Enums.Surface.Hard,
                IsLighted = true,
                ClubId = club1.Id,
                IsIndoor = true,
            };

            await service.AddAsync(model);

            var addedCourt = await dbContext.Courts.FindAsync(15);
            Assert.That(addedCourt, Is.Not.Null);
            Assert.That(addedCourt.Name, Is.EqualTo("New Court"));
            Assert.That(addedCourt.PricePerHour, Is.EqualTo(50));
            Assert.That(addedCourt.Surface, Is.EqualTo(Common.Enums.Surface.Hard));
            Assert.That(addedCourt.IsLighted, Is.True);
            Assert.That(addedCourt.IsActive, Is.True);

            var updatedClub = await dbContext.Clubs.FirstAsync(c=>c.Id==club1.Id);
            Assert.That(updatedClub.NumberOfCourts, Is.EqualTo(2));
        }

        [Test]
        public async Task AddAsync_ClubNotApproved_CourtNotAddedAndClubNotUpdated()
        {
            var initialClubNumberOfCourts = pendingClub1.NumberOfCourts;
            var model = new CourtAdminCreateFormModel
            {
                Name = "New Court",
                PricePerHour = 50,
                Surface = Common.Enums.Surface.Hard,
                IsLighted = true,
                ClubId = pendingClub1.Id,
                IsIndoor = true,
            };

            await service.AddAsync(model);

            var addedCourt = await dbContext.Courts.FindAsync(15);
            Assert.That(addedCourt, Is.Not.Null);
            Assert.That(addedCourt.IsActive, Is.False);

            var updatedClub = await dbContext.Clubs.FirstAsync(c => c.Id == pendingClub1.Id);
            Assert.That(updatedClub.NumberOfCourts, Is.EqualTo(initialClubNumberOfCourts + 1));
        }

        [Test]
        public async Task AddAsync_ClubDeleted_CourtNotAddedAndClubNotUpdated()
        {
            var initialClubCourtCount = deletedClub.NumberOfCourts;
            var model = new CourtAdminCreateFormModel
            {
                Name = "New Court",
                PricePerHour = 50,
                Surface = Common.Enums.Surface.Hard,
                IsLighted = true,
                ClubId = deletedClub.Id,
                IsIndoor = true,
            };

            await service.AddAsync(model);

            var addedCourt = await dbContext.Courts.FindAsync(15);
            Assert.That(addedCourt, Is.Not.Null);
            Assert.That(addedCourt.IsActive, Is.False);

            var updatedClub = await dbContext.Clubs.IgnoreQueryFilters().FirstAsync(c => c.Id == deletedClub.Id);
            Assert.That(updatedClub.NumberOfCourts, Is.EqualTo(initialClubCourtCount + 1));
        }

        [Test]
        public async Task CreateInitialAsync_WithValidData_AddsCourtsToClub()
        {
            var model = new CourtAdminCreateFormModel[]
            {
            new CourtAdminCreateFormModel
            {
                Name = "Court A",
                ClubId = clubWithNoCouts.Id,
                IsLighted = true,
                IsIndoor = true,
                PricePerHour = 30,
                Surface = Common.Enums.Surface.Clay
            },
            new CourtAdminCreateFormModel
            {
                Name = "Court B",
                ClubId = clubWithNoCouts.Id,
                IsLighted = true,
                IsIndoor = false,
                PricePerHour = 25,
                Surface = Common.Enums.Surface.Hard
            }
            };

            await service.CreateInitialAsync(model);

            var club = await dbContext.Clubs.FirstAsync(c=>c.Id==clubWithNoCouts.Id);

            Assert.That(club.Courts, Has.Count.EqualTo(2));
        }

        [Test]
        public async Task GetEditModelAsync_ReturnsCorrectModel()
        {
            int courtId = court1.Id;

            var result = await service.GetEditModelAsync(courtId);

            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(courtId));
                Assert.That(result.ClubId, Is.EqualTo(court1.ClubId));
                Assert.That(result.ClubName, Is.EqualTo(court1.Club.Name));
                Assert.That(result.Name, Is.EqualTo(court1.Name));
                Assert.That(result.IsActive, Is.EqualTo(court1.IsActive));
                Assert.That(result.IsIndoor, Is.EqualTo(court1.IsIndoor));
                Assert.That(result.IsLighted, Is.EqualTo(court1.IsLighted));
                Assert.That(result.PricePerHour, Is.EqualTo(court1.PricePerHour));
                Assert.That(result.Surface, Is.EqualTo(court1.Surface));
            });
        }

        [Test]
        public async Task GetCourtScheduleAsync_ReturnsCorrectSchedule()
        {
            int clubId = court1.ClubId;
            DateTime date = DateTime.Now.Date;
            int workingHourStart = 8;
            int workingHourEnd = 18; 

            var result = await service.GetCourtsScheduleAsync(clubId, date, workingHourStart, workingHourEnd);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<IEnumerable<CourtScheduleAdminViewModel>>());
            Assert.That(result.Any(), Is.True);

            var courtSchedule = result.First(c=>c.Id==court1.Id);
            Assert.That(courtSchedule, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(courtSchedule.Id, Is.EqualTo(court1.Id));
                Assert.That(courtSchedule.ClubId, Is.EqualTo(court1.ClubId));
                Assert.That(courtSchedule.Name, Is.EqualTo(court1.Name));
                Assert.That(courtSchedule.IsIndoor, Is.EqualTo(court1.IsIndoor));
                Assert.That(courtSchedule.IsLighted, Is.EqualTo(court1.IsLighted));
                Assert.That(courtSchedule.Price, Is.EqualTo(court1.PricePerHour));
                Assert.That(courtSchedule.Surface, Is.EqualTo(court1.Surface.GetDisplayName()));
            });

            var dateBookings = court1.Bookings.Where(b => b.BookingDate.Date == date.Date);
            Assert.That(courtSchedule.Bookings.Where(b => b.IsAvailable == false).Count(), Is.EqualTo(dateBookings.Count()));
        }

        [Test]
        public async Task DeleteAsync_DeletesCourtAndAssociatedEntities()
        {
            int courtIdToDelete = court1.Id;
            int expectedNumberOfCourts = court1.Club.NumberOfCourts - 1;

            await service.DeleteAsync(courtIdToDelete);

            var deletedCourt = await repository.GetAll<Court>()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(c => c.Id == courtIdToDelete);

            Assert.That(deletedCourt, Is.Null);

            var deletedBookings = await repository.GetAll<Booking>()
                .Where(b => b.CourtId == courtIdToDelete)
                .ToListAsync();

            Assert.That(deletedBookings, Is.Empty);

            var deletedReviews = await repository.GetAll<Review>()
                .Where(r => r.Booking.CourtId == courtIdToDelete)
                .ToListAsync();

            Assert.That(deletedReviews, Is.Empty);

            var updatedClub = await repository.GetAll<Club>()
                .FirstOrDefaultAsync(c => c.Id == court1.ClubId);

            Assert.That(updatedClub, Is.Not.Null);
            Assert.That(updatedClub.NumberOfCourts, Is.EqualTo(expectedNumberOfCourts));
        }

        [Test]
        public async Task GetViewModelForDeleteAsync_ReturnsViewModelWithCorrectData()
        {
            int courtIdToGet = court1.Id;

            var viewModel = await service.GetViewModelForDeleteAsync(courtIdToGet);

            Assert.That(viewModel, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(viewModel.Id, Is.EqualTo(court1.Id));
                Assert.That(viewModel.ClubId, Is.EqualTo(court1.ClubId)); 
                Assert.That(viewModel.IsActive, Is.EqualTo(court1.IsActive)); 
                Assert.That(viewModel.IsIndoor, Is.EqualTo(court1.IsIndoor)); 
                Assert.That(viewModel.IsLighted, Is.EqualTo(court1.IsLighted)); 
                Assert.That(viewModel.Name, Is.EqualTo(court1.Name)); 
                Assert.That(viewModel.PricePerHour, Is.EqualTo(court1.PricePerHour));
                Assert.That(viewModel.Surface, Is.EqualTo(court1.Surface.GetDisplayName()));
            });
        }
    }
}
