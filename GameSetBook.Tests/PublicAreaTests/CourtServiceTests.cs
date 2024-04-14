using GameSetBook.Common.Enums;
using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Court;
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
                NumberOfCourts = 3,
                WorkingTimeEnd = 21,
                WorkingTimeStart = 8,
                RegisteredOn = DateTime.Now.AddDays(-30),
                HasShop = false,
            };

            club3 = new Club()
            {
                Id = 3,
                CityId = 1,
                ClubOwnerId = "newOwner3Id",
                IsAproovedByAdmin = true,
                NumberOfCourts = 3,
                WorkingTimeEnd = 21,
                WorkingTimeStart = 8,
                RegisteredOn = DateTime.Now.AddDays(-30),
                HasShop = true,
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

            clubs = new List<Club>() { club1, club2, club3 };

            courts = new List<Court>() { court1, court2, court3, notActiveCourt4, court5, court6, court7 };

            bookings = new List<Booking>()
            {
                booking1,booking2,booking3,booking4, booking5, booking6, booking7, booking8, booking9, booking10, bookingDeleted1,booking12,booking13,booking14,booking15, booking16, booking17, booking18,bookingDeleted2, booking20
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
        public async Task ExistAsync_ShouldReturnTrueIfCourtExistAndFalseIfDoesNotExist()
        {
            var existingCourtId = 1;
            var existingCourtId2 = 3;

            var nonExistingCourtId = -1;
            var nonExistingCourtId2 = int.MaxValue;

            var result1 = await service.ExistAsync(existingCourtId);
            var result2 = await service.ExistAsync(existingCourtId2);
            var result3 = await service.ExistAsync(nonExistingCourtId);
            var result4 = await service.ExistAsync(nonExistingCourtId2);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
            Assert.That(result3, Is.False);
            Assert.That(result4, Is.False);
        }

        [Test]
        public async Task GetPriceAsync_ShoudReturnCourtPricePerHour()
        {
            var expectedResul1 = court1.PricePerHour;
            var actualPriceCourt1 = 30M;

            var expectedResult2 = court2.PricePerHour;
            var actualPriceCourt2 = 20M;

            var result1 = await service.GetPriceAsync(court1.Id);
            var result2 = await service.GetPriceAsync(court2.Id);

            Assert.That(result1, Is.EqualTo(expectedResul1));
            Assert.That(result1, Is.EqualTo(actualPriceCourt1));
            Assert.That(result2, Is.EqualTo(expectedResult2));
            Assert.That(result2, Is.EqualTo(actualPriceCourt2));
        }

        [Test]
        public async Task IsCourtInClubOfTheOwnerAsync_ShouldReturnTrueIfTheCourtIsIntheClubOwnersClubOrFalseIfNot()
        {
            var ownerId = "clubOwnerId";
            var courtInTheClubId = 1;
            var courtNotInTheClubId = 5;

            var result1 = await service.IsCourtInClubOfTheOwnerAsync(courtInTheClubId, ownerId);
            var result2 = await service.IsCourtInClubOfTheOwnerAsync(courtNotInTheClubId, ownerId);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task ChangeStatusAsync_ShouldChangeIsActive()
        {
            var statusBeforeChange = court1.IsActive;

            await service.ChangeStatusAsync(court1.Id);

            var result = court1.IsActive;

            Assert.That(result, Is.Not.EqualTo(statusBeforeChange));
        }

        [Test]
        public async Task ChangeStatusAsync_ShouldChangeIsActiveFromFalseToTrue()
        {
            var courtIdNotActiveStatus = notActiveCourt4.Id;

            await service.ChangeStatusAsync(courtIdNotActiveStatus);

            var result = notActiveCourt4.IsActive;

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task ChangeStatusAsync_ShouldChangeIsActiveFromTrueToFlase()
        {
            var courtIdActiveStatus = court1.Id;

            await service.ChangeStatusAsync(courtIdActiveStatus);

            var result = court1.IsActive;

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task AddCourtAsync_CheckIfCourtIsAddedSuccesfully()
        {
            int totalCourtsBeforeAdding = await dbContext.Courts.CountAsync();

            var model = new CourtCreateFormModel()
            {
                ClubId = club1.Id,
                IsIndoor = true,
                IsLighted = true,
                Name = "Test",
                PricePerHour = 30,
                Surface = Common.Enums.Surface.ArtificialGrass
            };

            await service.AddCourtAsync(model);

            int totalCourtsAfterAdding = await dbContext.Courts.CountAsync();

            Assert.That(totalCourtsAfterAdding, Is.GreaterThan(totalCourtsBeforeAdding));
        }

        [Test]
        public async Task AddCourtAsync_CheckIfNumberOfCourtsIsIncreasedAfterAddingNewCourt()
        {
            int totalCourtsBeforeAdding = club1.NumberOfCourts;
            int courtCountBefore = club1.Courts.Count();

            var model = new CourtCreateFormModel()
            {
                ClubId = club1.Id,
                IsIndoor = true,
                IsLighted = true,
                Name = "Test",
                PricePerHour = 30,
                Surface = Common.Enums.Surface.ArtificialGrass
            };

            await service.AddCourtAsync(model);

            int totalCourtsAfterAdding = club1.NumberOfCourts;
            int courtCountAfter = club1.Courts.Count();

            Assert.That(totalCourtsAfterAdding, Is.GreaterThan(totalCourtsBeforeAdding));
            Assert.That(totalCourtsAfterAdding, Is.EqualTo(totalCourtsBeforeAdding + 1));
            Assert.That(courtCountAfter, Is.GreaterThan(courtCountBefore));
            Assert.That(courtCountAfter, Is.EqualTo(courtCountBefore + 1));
        }

        [Test]
        public async Task GetCourtEditFormModelAsync_CheckIfReturnsModelWithCorrectDataAndNotNull()
        {
            var courtId = court1.Id;

            var result = await service.GetCourtEditFormModelAsync(courtId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(courtId));
            Assert.That(result.Name, Is.EqualTo(court1.Name));
            Assert.That(result.IsActive, Is.EqualTo(court1.IsActive));
            Assert.That(result.IsLighted, Is.EqualTo(court1.IsLighted));
            Assert.That(result.IsIndoor, Is.EqualTo(court1.IsIndoor));
            Assert.That(result.ClubId, Is.EqualTo(court1.ClubId));
        }

        [Test]
        public async Task EdidAsync_CheckIfTheDataIsUpdatedSuccesfully()
        {
            var courtId = court1.Id;
            var nameBefore = "No1";
            var isLightedBefore = true;
            var isIndoorBefore = true;
            var isActiveBefore = true;
            var priceBefore = 30;
            var surfaceBefore = Surface.Carpet;

            var model = new CourtEditFormModel()
            {
                Id = courtId,
                Name = "test-update" + Guid.NewGuid().ToString(),
                IsActive = false,
                IsIndoor = false,
                IsLighted = false,
                PricePerHour = 99,
                Surface = Surface.Hard,
            };

            await service.EditAsync(model);

            var courtIdAfter = court1.Id;
            var nameAfter = court1.Name;
            var isLightedAfter = court1.IsLighted;
            var isIndoorAfter = court1.IsIndoor;
            var isActiveAfter = court1.IsActive;
            var priceAfter = court1.PricePerHour;
            var surfaceAfter = court1.Surface;

            Assert.That(courtId, Is.EqualTo(courtIdAfter));
            Assert.That(nameBefore, Is.Not.EqualTo(nameAfter));
            Assert.That(isLightedBefore, Is.Not.EqualTo(isLightedAfter));
            Assert.That(isIndoorBefore, Is.Not.EqualTo(isIndoorAfter));
            Assert.That(isActiveBefore, Is.Not.EqualTo(isActiveAfter));
            Assert.That(priceBefore, Is.Not.EqualTo(priceAfter));
            Assert.That(surfaceBefore, Is.Not.EqualTo(surfaceAfter));

            Assert.That(courtIdAfter, Is.EqualTo(model.Id));
            Assert.That(nameAfter, Is.EqualTo(model.Name));
            Assert.That(isLightedAfter, Is.EqualTo(model.IsLighted));
            Assert.That(isIndoorAfter, Is.EqualTo(model.IsIndoor));
            Assert.That(isActiveAfter, Is.EqualTo(model.IsActive));
            Assert.That(priceAfter, Is.EqualTo(model.PricePerHour));
            Assert.That(surfaceAfter, Is.EqualTo(model.Surface));

            Assert.False(isLightedAfter);
            Assert.False(isIndoorAfter);
            Assert.False(isActiveAfter);
        }

        [Test]
        public async Task CreateInitialAsync_CheckIfAddesCourtsToTheClubWhenRegistered()
        {
            var owner = new ApplicationUser()
            {
                Id = "testOwnerAddingCourtsToClub",

            };

            var club = new Club()
            {
                Id = 100,
                ClubOwnerId = owner.Id,
                NumberOfCourts= 2,
            };

            await dbContext.AddAsync(owner);
            await dbContext.AddAsync(club);
            await dbContext.SaveChangesAsync();

            var clubCourtsCountBeforeAdding = club.Courts.Count;

            var model = new CourtCreateFormModel[2];
          
            for (int i = 0; i < club.NumberOfCourts; i++)
            {
                model[i] = new CourtCreateFormModel() { ClubId = club.Id };
            }

            await service.CreateInitialAsync(model);

            var clubCourtsCountAfterAdding = club.Courts.Count;

            Assert.That(clubCourtsCountAfterAdding, Is.GreaterThan(clubCourtsCountBeforeAdding));
            Assert.That(clubCourtsCountAfterAdding, Is.EqualTo(club.NumberOfCourts));
        }

        [Test]
        public async Task GetAllCourtsDetailsAsync_ShouldReturnCollectionOfCourtDetailsModel()
        {
            var club2Id = club2.Id;
            var club3Id = club3.Id;

            var club2CourtsCount = club2.Courts.Count;
            var club3CourtsCount = club3.Courts.Count;

            var result1 = await service.GetAllCourtsDetailsAsync(club2Id);
            var result2 = await service.GetAllCourtsDetailsAsync(club3Id);

            Assert.That(club2CourtsCount, Is.EqualTo(result1.Count()));
            Assert.That(club3CourtsCount, Is.EqualTo(result2.Count()));
        }

        [Test]
        public async Task GetAllCourtsScheduleAsync_CheckIfReturnsCorrectData()
        {
            var clubId = club1.Id;
            var dateToCheck = DateTime.Now.AddDays(1);

            var result1 = await service.GetAllCourtsScheduleAsync(clubId, dateToCheck);

            var numberOfActiveCourts1 = 1;
            var numberOfBookings1 = 4;
            var numberOfReturnedCourtsFromResult1 = result1.Count();
            var numberOfBookedSlotsToCheckFromResult1 = 0;

            foreach (var court in result1)
            {
                foreach (var booking in court.Bookings)
                {
                    if (booking.IsAvailable==false)
                    {
                        numberOfBookedSlotsToCheckFromResult1 += 1;
                    }
                }
            }

            var clubId2 = club2.Id;
            var dateToCheck2 = DateTime.Now.AddDays(10);

            var result2 = await service.GetAllCourtsScheduleAsync(clubId2, dateToCheck2);

            var numberOfActiveCourts2 = 2;
            var numberOfBookings2 = 0;
            var numberOfReturnedCourtsFromResult2 = result2.Count();
            var numberOfBookedSlotsToCheckFromResult2 = 0;

            foreach (var court in result2)
            {
                foreach (var booking in court.Bookings)
                {
                    if (booking.IsAvailable == false)
                    {
                        numberOfBookedSlotsToCheckFromResult2 += 1;
                    }
                }
            }

            Assert.That(numberOfReturnedCourtsFromResult1, Is.EqualTo(numberOfActiveCourts1));
            Assert.That(numberOfBookedSlotsToCheckFromResult1, Is.EqualTo(numberOfBookings1));
            Assert.That(numberOfReturnedCourtsFromResult2, Is.EqualTo(numberOfActiveCourts2));
            Assert.That(numberOfBookedSlotsToCheckFromResult2, Is.EqualTo(numberOfBookings2));
        }
    }
}
