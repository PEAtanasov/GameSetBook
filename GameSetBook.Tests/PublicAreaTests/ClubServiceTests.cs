using GameSetBook.Core.Contracts;
using GameSetBook.Core.Services;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Data;
using GameSetBook.Infrastructure.Models.Identity;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

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

            cities = new List<City>()
            {
                    city1, city2, city3,city4
            };

            users = new List<ApplicationUser>()
            {
                    user1,user2,user3,clubOwner1,clubOwner2,clubOwner3,clubOwner4,clubOwner5,clubOwner6,clubOwner7,clubOwner8,clubOwnerDeletedClub
            };

            clubs = new List<Club>() { club1, club2, club3, club4, club5, club6, club7, club8, deletedClub };

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

            var result1 = await service.ExsitAnotherCluWhitNameAsync(existingClubId1, existingClubName2);
            var result2 = await service.ExsitAnotherCluWhitNameAsync(existingClubId2, existingClubName1);
            var result3 = await service.ExsitAnotherCluWhitNameAsync(notExistingClubId, notExistingClubName);
            var result4 = await service.ExsitAnotherCluWhitNameAsync(existingClubId1, existingClubName1);


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
    }
}

