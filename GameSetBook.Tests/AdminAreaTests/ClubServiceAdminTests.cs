using GameSetBook.Common.Enums.EnumExtensions;
using GameSetBook.Core.Contracts;
using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Enums;
using GameSetBook.Core.Models.Admin.Club;
using GameSetBook.Core.Services;
using GameSetBook.Core.Services.Admin;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Data;
using GameSetBook.Infrastructure.Models;
using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Tests.AdminAreaTests
{
    [TestFixture]
    public class ClubServiceAdminTests
    {
        private ApplicationDbContext dbContext;

        private IRepository repository;
        private IClubServiceAdmin service;

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
                Id="pendingClubOwner2"
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
            service = new ClubServiceAdmin(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task ExistAsync_ReturnsTrueForExistingClub()
        {
            int existingClubId = 1;

            bool result = await service.ExistAsync(existingClubId);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistAsync_ReturnsFalseForNonExistingClub()
        {
            int nonExistingClubId = -1;

            bool result = await service.ExistAsync(nonExistingClubId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task ExistByNameAsync_ReturnsTrueForExistingClub()
        {
            string existingClubName = "Club1";

            bool result = await service.ExistByNameAsync(existingClubName);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ExistByNameAsync_ReturnsFalseForNonExistingClub()
        {
            string nonExistingClubName = "Non Existing Club";

            bool result = await service.ExistByNameAsync(nonExistingClubName);

            Assert.IsFalse(result);
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
        public async Task IsClubApproovedAsync_ShouldReturnTrueIfClubisApprovedOrFalseIfNot()
        {
            var approvedClubId = 1;
            var notApprovedClubId = 7;

            var result1 = await service.IsClubApprovedAsync(approvedClubId);
            var result2 = await service.IsClubApprovedAsync(notApprovedClubId);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task IsDeletedAsync_ReturnsTrueForDeletedClub()
        {
            int existingDeletedClubId = deletedClub.Id; 

            bool result = await service.IsDeletedAsync(existingDeletedClubId);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsDeletedAsync_ReturnsFalseForExistingClub()
        {
            int existingNotDeletedClubId = club1.Id;

            bool result = await service.IsDeletedAsync(existingNotDeletedClubId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task ApproveAsync_ReturnsClubOwnerIdIfClubIsApproved()
        {
            int clubIdToApprove = pendingClub1.Id; 
            var originalOwner = pendingClub1.ClubOwnerId;

            string newOwner = await service.ApproveAsync(clubIdToApprove);

            Assert.That(newOwner, Is.EqualTo(originalOwner));
        }

        [Test]
        public async Task ApproveAsync_ActivatesCourtsAndSetsApprovalFlag()
        {
            int clubIdToApprove = pendingClub1.Id;

            await service.ApproveAsync(clubIdToApprove);
            var approvedClub = await dbContext.Clubs.FirstAsync(c => c.Id == clubIdToApprove);

            Assert.That(approvedClub.IsAproovedByAdmin, Is.True);
            Assert.That(approvedClub.Courts.All(c => c.IsActive), Is.True); // Check all courts are active
        }

        [Test]
        public async Task GetClubNameAsync_ReturnsClubNameForExistingClub()
        {
            int existingClubId = club1.Id; 
            string expectedName = club1.Name;

            string clubName = await service.GetClubNameAsync(existingClubId);

            Assert.That(clubName, Is.EqualTo(expectedName));
        }

        [Test]
        public async Task GetClubIdByNameAsync_ReturnsClubIdForExistingName()
        {
            string existingClubName = club1.Name;
            int expectedClubId = club1.Id;

            int clubId = await service.GetClubIdByNameAsync(existingClubName);

            Assert.That(clubId, Is.EqualTo(expectedClubId));
        }

        [Test]
        public async Task GetClubMenuAsync_ReturnsClubMenuForExistingClub()
        {
            int existingClubId = club1.Id;

            var clubMenu = await service.GetClubMenuAsync(existingClubId);

            Assert.That(clubMenu, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(clubMenu.Id, Is.EqualTo(club1.Id));
                Assert.That(clubMenu.Name, Is.EqualTo(club1.Name));
                Assert.That(clubMenu.IsApproved, Is.EqualTo(club1.IsAproovedByAdmin));
                Assert.That(clubMenu.IsDeleted, Is.EqualTo(club1.IsDeleted));
            });
        }

        [Test]
        public void GetClubMenuAsync_ThrowsExceptionForNonExistingClub()
        {
            int nonExistingClubId = -1;

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await service.GetClubMenuAsync(nonExistingClubId);
            });
        }

        [Test]
        public async Task DeleteAsync_DeletesClubAndDeactivatesCourtsForExistingClub()
        {
            int existingActiveClubId = club1.Id;

            await service.DeleteAsync(existingActiveClubId);
            var deletedClub = dbContext.Clubs.FirstOrDefault(c => c.Id == existingActiveClubId);
            var deletedCourts = dbContext.Courts.Where(c => c.ClubId == existingActiveClubId).ToList();

            Assert.That(deletedClub, Is.Null);
            Assert.That(deletedCourts.All(c => !c.IsActive), Is.True); 
        }

        [Test]
        public async Task GetClubForEditAsync_ReturnsClubEditFormModelForExistingClub()
        {
            int existingClubId = club1.Id;

            var clubEditFormModel = await service.GetClubForEditAsync(existingClubId);

            Assert.That(clubEditFormModel, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(clubEditFormModel.Id, Is.EqualTo(club1.Id));
                Assert.That(clubEditFormModel.Address, Is.EqualTo(club1.Address));
                Assert.That(clubEditFormModel.CityId, Is.EqualTo(club1.CityId));
                Assert.That(clubEditFormModel.ClubOwnerName, Is.EqualTo(club1.ClubOwner.UserName));
                Assert.That(clubEditFormModel.Description, Is.EqualTo(club1.Description));
                Assert.That(clubEditFormModel.Name, Is.EqualTo(club1.Name));
                Assert.That(clubEditFormModel.Email, Is.EqualTo(club1.Email));
                Assert.That(clubEditFormModel.PhoneNumber, Is.EqualTo(club1.PhoneNumber));
                Assert.That(clubEditFormModel.HasParking, Is.EqualTo(club1.HasParking));
                Assert.That(clubEditFormModel.HasShop, Is.EqualTo(club1.HasShop));
                Assert.That(clubEditFormModel.HasShower, Is.EqualTo(club1.HasShower));
                Assert.That(clubEditFormModel.LogoUrl, Is.EqualTo(club1.LogoUrl));
                Assert.That(clubEditFormModel.WorkingTimeEnd, Is.EqualTo(club1.WorkingTimeEnd));
                Assert.That(clubEditFormModel.WorkingTimeStart, Is.EqualTo(club1.WorkingTimeStart));
                Assert.That(clubEditFormModel.NumberOfCoaches, Is.EqualTo(club1.NumberOfCoaches));
                Assert.That(clubEditFormModel.NumberOfCourts, Is.EqualTo(club1.NumberOfCourts));
                Assert.That(clubEditFormModel.NumberOfActiveCourts, Is.EqualTo(club1.Courts.Count(ct => ct.IsActive)));
                Assert.That(clubEditFormModel.IsAproovedByAdmin, Is.EqualTo(club1.IsAproovedByAdmin));
                Assert.That(clubEditFormModel.IsDeleted, Is.EqualTo(club1.IsDeleted));
                Assert.That(clubEditFormModel.DeletedOn, Is.EqualTo(club1.DeletedOn));
                Assert.That(clubEditFormModel.RegisteredOn, Is.EqualTo(club1.RegisteredOn));
                Assert.That(clubEditFormModel.Rating, Is.EqualTo(club1.Rating));
            });
        }

        [Test]
        public async Task EditAsync_UpdatesClubDetailsForExistingClub()
        {
            int existingClubId = club1.Id;

            var editedModel = new ClubEditFormModel
            {
                Id = existingClubId,
                Address = "New Address",
                CityId = 2,
                PhoneNumber = "1234567890",
                NumberOfCoaches = 5,
                Email = "newemail@example.com",
                Description = "Updated Description",
                Name = "Updated Name",
                LogoUrl = "newlogoUrl",
                WorkingTimeStart = 9,
                WorkingTimeEnd = 16,
                HasParking = true,
                HasShop = false,
                HasShower = true
            };

            await service.EditAsync(editedModel);

            var updatedClub = dbContext.Clubs.FirstOrDefault(c => c.Id == existingClubId);

            Assert.That(updatedClub, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(updatedClub.Address, Is.EqualTo(editedModel.Address));
                Assert.That(updatedClub.CityId, Is.EqualTo(editedModel.CityId));
                Assert.That(updatedClub.PhoneNumber, Is.EqualTo(editedModel.PhoneNumber));
                Assert.That(updatedClub.NumberOfCoaches, Is.EqualTo(editedModel.NumberOfCoaches));
                Assert.That(updatedClub.Email, Is.EqualTo(editedModel.Email));
                Assert.That(updatedClub.Description, Is.EqualTo(editedModel.Description));
                Assert.That(updatedClub.Name, Is.EqualTo(editedModel.Name));
                Assert.That(updatedClub.LogoUrl, Is.EqualTo(editedModel.LogoUrl));
                Assert.That(updatedClub.WorkingTimeStart, Is.EqualTo(editedModel.WorkingTimeStart));
                Assert.That(updatedClub.WorkingTimeEnd, Is.EqualTo(editedModel.WorkingTimeEnd));
                Assert.That(updatedClub.HasParking, Is.EqualTo(editedModel.HasParking));
                Assert.That(updatedClub.HasShop, Is.EqualTo(editedModel.HasShop));
                Assert.That(updatedClub.HasShower, Is.EqualTo(editedModel.HasShower));
            });
        }

        [Test]
        public async Task GetClubDetailsAsync_ReturnsClubDetailsForExistingClub()
        {
            int existingClubId = club1.Id; 

            var clubDetails = await service.GetClubDetailsAsync(existingClubId);

            Assert.That(clubDetails, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(clubDetails.Id, Is.EqualTo(club1.Id));
                Assert.That(clubDetails.Name, Is.EqualTo(club1.Name));
                Assert.That(clubDetails.Description, Is.EqualTo(club1.Description));
                Assert.That(clubDetails.Email, Is.EqualTo(club1.Email));
                Assert.That(clubDetails.HasParking, Is.EqualTo(club1.HasParking));
                Assert.That(clubDetails.HasShop, Is.EqualTo(club1.HasShop));
                Assert.That(clubDetails.HasShower, Is.EqualTo(club1.HasShower));
                Assert.That(clubDetails.ClubOwner, Is.EqualTo(club1.ClubOwner.UserName));
                Assert.That(clubDetails.Address, Is.EqualTo(club1.Address));
                Assert.That(clubDetails.City, Is.EqualTo(club1.City.Name));
                Assert.That(clubDetails.WorkingTimeStart, Is.EqualTo(club1.WorkingTimeStart));
                Assert.That(clubDetails.WorkingTimeEnd, Is.EqualTo(club1.WorkingTimeEnd));
                Assert.That(clubDetails.IsClubOwnerActive, Is.EqualTo(!string.IsNullOrWhiteSpace(club1.ClubOwner.UserName)));
                Assert.That(clubDetails.LogoUrl, Is.EqualTo(club1.LogoUrl));
                Assert.That(clubDetails.PhoneNumber, Is.EqualTo(club1.PhoneNumber));
                Assert.That(clubDetails.NumberOfCoaches, Is.EqualTo(club1.NumberOfCoaches));
                Assert.That(clubDetails.NumberOfCourts, Is.EqualTo(club1.NumberOfCourts));
                Assert.That(clubDetails.RegisteredOn, Is.EqualTo(club1.RegisteredOn));
                Assert.That(clubDetails.ClubOwnerId, Is.EqualTo(club1.ClubOwnerId));
                Assert.That(clubDetails.IsAproovedByAdmin, Is.EqualTo(club1.IsAproovedByAdmin));
            });

            // Check Courts
            Assert.That(clubDetails.Courts, Is.Not.Null);
            Assert.That(clubDetails.Courts.Count(), Is.EqualTo(club1.Courts.Count));
            foreach (var court in club1.Courts)
            {
                var correspondingCourt = clubDetails.Courts.FirstOrDefault(c => c.Id == court.Id);
                Assert.That(correspondingCourt, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(correspondingCourt.Id, Is.EqualTo(court.Id));
                    Assert.That(correspondingCourt.ClubId, Is.EqualTo(court.ClubId));
                    Assert.That(correspondingCourt.IsActive, Is.EqualTo(court.IsActive));
                    Assert.That(correspondingCourt.IsIndoor, Is.EqualTo(court.IsIndoor));
                    Assert.That(correspondingCourt.IsLighted, Is.EqualTo(court.IsLighted));
                    Assert.That(correspondingCourt.Name, Is.EqualTo(court.Name));
                    Assert.That(correspondingCourt.PricePerHour, Is.EqualTo(court.PricePerHour));
                    Assert.That(correspondingCourt.Surface, Is.EqualTo(court.Surface.GetDisplayName()));
                });
            }
        }

        [Test]
        public async Task GetPendingClubDetailsAsync_ReturnsPendingClubDetailsForExistingClub()
        {
            int pendingClubId = pendingClub1.Id; 

            var pendingClubDetails = await service.GetPendingClubDetailsAsync(pendingClubId);

            Assert.That(pendingClubDetails, Is.Not.Null);
            Assert.That(pendingClubDetails.IsAproovedByAdmin, Is.False);
            Assert.Multiple(() =>
            {
                Assert.That(pendingClubDetails.Id, Is.EqualTo(pendingClub1.Id));
                Assert.That(pendingClubDetails.Name, Is.EqualTo(pendingClub1.Name));
                Assert.That(pendingClubDetails.Description, Is.EqualTo(pendingClub1.Description));
                Assert.That(pendingClubDetails.Email, Is.EqualTo(pendingClub1.Email));
                Assert.That(pendingClubDetails.HasParking, Is.EqualTo(pendingClub1.HasParking));
                Assert.That(pendingClubDetails.HasShop, Is.EqualTo(pendingClub1.HasShop));
                Assert.That(pendingClubDetails.HasShower, Is.EqualTo(pendingClub1.HasShower));
                Assert.That(pendingClubDetails.ClubOwner, Is.EqualTo(pendingClub1.ClubOwner.UserName));
                Assert.That(pendingClubDetails.Address, Is.EqualTo(pendingClub1.Address));
                Assert.That(pendingClubDetails.City, Is.EqualTo(pendingClub1.City.Name));
                Assert.That(pendingClubDetails.WorkingTimeStart, Is.EqualTo(pendingClub1.WorkingTimeStart));
                Assert.That(pendingClubDetails.WorkingTimeEnd, Is.EqualTo(pendingClub1.WorkingTimeEnd));
                Assert.That(pendingClubDetails.IsClubOwnerActive, Is.EqualTo(!string.IsNullOrWhiteSpace(pendingClub1.ClubOwner.UserName)));
                Assert.That(pendingClubDetails.LogoUrl, Is.EqualTo(pendingClub1.LogoUrl));
                Assert.That(pendingClubDetails.PhoneNumber, Is.EqualTo(pendingClub1.PhoneNumber));
                Assert.That(pendingClubDetails.NumberOfCoaches, Is.EqualTo(pendingClub1.NumberOfCoaches));
                Assert.That(pendingClubDetails.NumberOfCourts, Is.EqualTo(pendingClub1.NumberOfCourts));
                Assert.That(pendingClubDetails.RegisteredOn, Is.EqualTo(pendingClub1.RegisteredOn));
                Assert.That(pendingClubDetails.ClubOwnerId, Is.EqualTo(pendingClub1.ClubOwnerId));
            });

            // Check Courts
            Assert.That(pendingClubDetails.Courts, Is.Not.Null);
            var countCourts = pendingClubDetails.Courts.Count();
            Assert.That(pendingClubDetails.Courts.Count(), Is.EqualTo(pendingClub1.Courts.Count));
            foreach (var court in pendingClub1.Courts)
            {
                var correspondingCourt = pendingClubDetails.Courts.FirstOrDefault(c => c.Id == court.Id);
                Assert.That(correspondingCourt, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(correspondingCourt.Id, Is.EqualTo(court.Id));
                    Assert.That(correspondingCourt.ClubId, Is.EqualTo(court.ClubId));
                    Assert.That(correspondingCourt.IsActive, Is.EqualTo(court.IsActive));
                    Assert.That(correspondingCourt.IsIndoor, Is.EqualTo(court.IsIndoor));
                    Assert.That(correspondingCourt.IsLighted, Is.EqualTo(court.IsLighted));
                    Assert.That(correspondingCourt.Name, Is.EqualTo(court.Name));
                    Assert.That(correspondingCourt.PricePerHour, Is.EqualTo(court.PricePerHour));
                    Assert.That(correspondingCourt.Surface, Is.EqualTo(court.Surface.GetDisplayName()));
                });
            }
        }

        [Test]
        public async Task AllPendingClubsAsync_ReturnsAllPendingClubs()
        {
            var expectedPendingClubs = new List<PendingClubViewModel>
            {
                new PendingClubViewModel
                {
                    Id = pendingClub1.Id,
                    Name = pendingClub1.Name,
                    NumberOfCourts = pendingClub1.Courts.Count,
                    RegisteredOn = pendingClub1.RegisteredOn,
                    City = pendingClub1.City.Name,
                    ClubOwner = pendingClub1.ClubOwner.UserName,
                    ClubOwnerStatus = !string.IsNullOrWhiteSpace(pendingClub2.ClubOwner.UserName)
                },

                new PendingClubViewModel
                {
                    Id = pendingClub2.Id,
                    Name = pendingClub2.Name,
                    NumberOfCourts = pendingClub2.Courts.Count,
                    RegisteredOn = pendingClub2.RegisteredOn,
                    City = pendingClub2.City.Name,
                    ClubOwner = pendingClub2.ClubOwner.UserName,
                    ClubOwnerStatus = !string.IsNullOrWhiteSpace(pendingClub2.ClubOwner.UserName)
                },

                new PendingClubViewModel
                {
                    Id = clubWithNoCouts.Id,
                    Name = clubWithNoCouts.Name,
                    NumberOfCourts = clubWithNoCouts.Courts.Count,
                    RegisteredOn = clubWithNoCouts.RegisteredOn,
                    City = clubWithNoCouts.City.Name,
                    ClubOwner = clubWithNoCouts.ClubOwner.UserName,
                    ClubOwnerStatus = !string.IsNullOrWhiteSpace(clubWithNoCouts.ClubOwner.UserName)
                }
            };

            var pendingClubs = await service.AllPendingClubsAsync();

            Assert.That(pendingClubs, Is.Not.Null);
            Assert.That(pendingClubs.Count(), Is.EqualTo(expectedPendingClubs.Count));

            foreach (var expectedClub in expectedPendingClubs)
            {
                var actualClub = pendingClubs.FirstOrDefault(c => c.Id == expectedClub.Id);
                Assert.That(actualClub, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(actualClub.Name, Is.EqualTo(expectedClub.Name));
                    Assert.That(actualClub.NumberOfCourts, Is.EqualTo(expectedClub.NumberOfCourts));
                    Assert.That(actualClub.RegisteredOn, Is.EqualTo(expectedClub.RegisteredOn));
                    Assert.That(actualClub.City, Is.EqualTo(expectedClub.City));
                    Assert.That(actualClub.ClubOwner, Is.EqualTo(expectedClub.ClubOwner));
                    Assert.That(actualClub.ClubOwnerStatus, Is.EqualTo(expectedClub.ClubOwnerStatus));
                });
            }
        }

        [Test]
        public async Task CreateAsync_AddsNewClub()
        {
            var model = new ClubAdminCreateFormModel
            {
                Name = "New Club Adding",
                Description = "New Club Description",
                Address = "123 New Street",
                CityId = 1,
                ClubOwnerId = "userId",
                HasParking = true,
                Email = "newclub@example.com",
                HasShop = true,
                HasShower = true,
                NumberOfCoaches = 3,
                NumberOfCourts = 5,
                PhoneNumber = "1234567890",
                WorkingTimeStart = 8,
                WorkingTimeEnd = 22,
                LogoUrl = "some_logo_image"
            };

            await service.CreateAsync(model);

            var createdClub = await dbContext.Clubs.FirstOrDefaultAsync(c => c.Name == model.Name);

            Assert.That(createdClub, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(createdClub.IsAproovedByAdmin, Is.False);
                Assert.That(createdClub.Name, Is.EqualTo(model.Name));
                Assert.That(createdClub.Description, Is.EqualTo(model.Description));
                Assert.That(createdClub.Address, Is.EqualTo(model.Address));
                Assert.That(createdClub.CityId, Is.EqualTo(model.CityId));
                Assert.That(createdClub.ClubOwnerId, Is.EqualTo(model.ClubOwnerId));
                Assert.That(createdClub.HasParking, Is.EqualTo(model.HasParking));
                Assert.That(createdClub.Email, Is.EqualTo(model.Email));
                Assert.That(createdClub.HasShop, Is.EqualTo(model.HasShop));
                Assert.That(createdClub.HasShower, Is.EqualTo(model.HasShower));
                Assert.That(createdClub.NumberOfCoaches, Is.EqualTo(model.NumberOfCoaches));
                Assert.That(createdClub.NumberOfCourts, Is.EqualTo(model.NumberOfCourts));
                Assert.That(createdClub.PhoneNumber, Is.EqualTo(model.PhoneNumber));
                Assert.That(createdClub.WorkingTimeStart, Is.EqualTo(model.WorkingTimeStart));
                Assert.That(createdClub.WorkingTimeEnd, Is.EqualTo(model.WorkingTimeEnd));
                Assert.That(createdClub.LogoUrl, Is.EqualTo(model.LogoUrl));
                Assert.That(createdClub.RegisteredOn.Date, Is.EqualTo(DateTime.Today));
            });
        }

        [Test]
        public async Task GetClubScheduleModelAsync_ReturnsClubScheduleModel()
        {
            int clubId = club1.Id;
            DateTime testDate = DateTime.Now;

            var clubSchedule = await service.GetClubScheduleModelAsync(clubId, testDate);

            Assert.That(clubSchedule, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(clubSchedule.Id, Is.EqualTo(club1.Id));
                Assert.That(clubSchedule.Name, Is.EqualTo(club1.Name));
                Assert.That(clubSchedule.Date, Is.EqualTo(testDate.Date));
                Assert.That(clubSchedule.WorkingHourEnd, Is.EqualTo(club1.WorkingTimeEnd));
                Assert.That(clubSchedule.WorkingHourStart, Is.EqualTo(club1.WorkingTimeStart));
            });
        }

        [Test]
        public async Task GetHardDeleteModelAsync_ReturnsClubHardDeleteModel()
        {
            int clubId = club1.Id;

            var hardDeleteModel = await service.GetHardDeleteModelAsync(clubId);

            Assert.That(hardDeleteModel, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(hardDeleteModel.Id, Is.EqualTo(club1.Id));
                Assert.That(hardDeleteModel.ClubOwnerEmail, Is.EqualTo(club1.ClubOwner.Email));
                Assert.That(hardDeleteModel.ClubOwnerId, Is.EqualTo(club1.ClubOwnerId));
                Assert.That(hardDeleteModel.LogoUrl, Is.EqualTo(club1.LogoUrl));
                Assert.That(hardDeleteModel.Name, Is.EqualTo(club1.Name));
                Assert.That(hardDeleteModel.TotalCourtsCount, Is.EqualTo(club1.Courts.Count()));
                Assert.That(hardDeleteModel.TotalReviewsCount, Is.EqualTo(club1.Reviews.Count()));
                Assert.That(hardDeleteModel.TotalBookingsCount, Is.EqualTo(club1.Courts.SelectMany(ct => ct.Bookings).Count()));
            });
        }

        [Test]
        public async Task HardDeleteAsync_RemovesClubAndAllRelatedEntities()
        {
            int clubId = club1.Id; 

            await service.HardDeleteAsync(clubId);

            var deletedClub = await dbContext.Clubs.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == clubId);
            Assert.That(deletedClub, Is.Null);

            var deletedReviews = await dbContext.Reviews.IgnoreQueryFilters().Where(r => r.ClubId == clubId).ToListAsync();
            Assert.That(deletedReviews, Is.Empty);

            var deletedBookings = await dbContext.Bookings.IgnoreQueryFilters()
                .Where(b => b.Court.ClubId == clubId)
                .ToListAsync();
            Assert.That(deletedBookings, Is.Empty);

            var deletedCourts = await dbContext.Courts.IgnoreQueryFilters().Where(ct => ct.ClubId == clubId).ToListAsync();
            Assert.That(deletedCourts, Is.Empty);
        }

        [Test]
        public async Task GetClubSortingModel_ReturnsClubSortingModel()
        {
            var model = new AllClubsAdminSortingModel
            {
                Country = country1.Name, 
                City = city1.Name, 
                SearchTerm = "club", 
                ClubSorting = ClubSorting.RatingDescending,
                ClubStatusSorting = ClubStatusSorting.OnlyNotDeleted,
                ClubsPerPage = 10,
                CurrentPage = 1
            };

            var sortedModel = await service.GetClubSortingModel(model);

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
        public async Task GetClubSortingModel_SortsByPriceAscending()
        {
            var model = new AllClubsAdminSortingModel
            {
                ClubSorting = ClubSorting.PriceAscending,
                ClubsPerPage = 10,
                CurrentPage = 1
            };

            var sortedModel = await service.GetClubSortingModel(model);

            Assert.That(sortedModel, Is.Not.Null);
            Assert.That(sortedModel.Clubs, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(sortedModel.Clubs.Count(), Is.GreaterThanOrEqualTo(0));
                Assert.That(sortedModel.Clubs.Select(c => c.Price).OrderBy(p => p).SequenceEqual(sortedModel.Clubs.Select(c => c.Price)), Is.True);
            });
        }

        [Test]
        public async Task GetClubSortingModel_SortsByPriceDescending()
        {
            var model = new AllClubsAdminSortingModel
            {
                ClubSorting = ClubSorting.PriceDescending,
                ClubsPerPage = 10,
                CurrentPage = 1
            };

            var sortedModel = await service.GetClubSortingModel(model);

            Assert.That(sortedModel, Is.Not.Null);
            Assert.That(sortedModel.Clubs, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(sortedModel.Clubs.Count(), Is.GreaterThanOrEqualTo(0));
                Assert.That(sortedModel.Clubs.Select(c => c.Price).OrderByDescending(p => p).SequenceEqual(sortedModel.Clubs.Select(c => c.Price)), Is.True);
            });
        }

        [Test]
        public async Task GetClubSortingModel_SortsByNumberOfCourtsAscending()
        {
            var model = new AllClubsAdminSortingModel
            {
                ClubSorting = ClubSorting.NumberOfCourtsAscending,
                ClubsPerPage = 10,
                CurrentPage = 1
            };

            var sortedModel = await service.GetClubSortingModel(model);

            Assert.That(sortedModel, Is.Not.Null);
            Assert.That(sortedModel.Clubs, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(sortedModel.Clubs.Count(), Is.GreaterThanOrEqualTo(0));
                Assert.That(sortedModel.Clubs.Select(c => c.NumberofCourts).OrderBy(n => n).SequenceEqual(sortedModel.Clubs.Select(c => c.NumberofCourts)), Is.True);
            });
        }

        [Test]
        public async Task GetClubSortingModel_SortsByNumberOfCourtsDescending()
        {
            var model = new AllClubsAdminSortingModel
            {
                ClubSorting = ClubSorting.NumberOfCourtsDescending,
                ClubsPerPage = 10,
                CurrentPage = 1
            };

            var sortedModel = await service.GetClubSortingModel(model);

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
