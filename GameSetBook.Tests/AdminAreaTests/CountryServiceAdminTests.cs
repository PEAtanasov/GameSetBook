using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Country;
using GameSetBook.Core.Services;
using GameSetBook.Core.Services.Admin;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Data;
using GameSetBook.Infrastructure.Models;
using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace GameSetBook.Tests.AdminAreaTests
{
    public class CountryServiceAdminTests
    {
        private ApplicationDbContext dbContext;

        private IRepository repository;
        private ICountryServiceAdmin service;
        private Mock<UserManager<ApplicationUser>> mockUserManager;

        IEnumerable<ApplicationUser> users;
        IEnumerable<Country> countries;
        IEnumerable<City> cities;
        IEnumerable<Club> clubs;
        IEnumerable<Court> courts;
        IEnumerable<Booking> bookings;
        IEnumerable<Review> reviews;

        private ApplicationUser user1;
        private ApplicationUser owner1;
        private ApplicationUser owner2;

        private Country country1;
        private Country country2;
        private Country country3;

        private City city1;
        private City city2;
        private City city3;

        private Club club1;
        private Club club2;

        private Court court1;
        private Court court2;
        private Court court3;

        private Booking booking1;
        private Booking booking2;
        private Booking booking3;

        private Review review1;
        private Review review2;

        [SetUp]
        public async Task Setup()
        {
            user1 = new ApplicationUser() { Id = "user1" };
            owner1 = new ApplicationUser() { Id = "owner1" };
            owner2 = new ApplicationUser() { Id = "owner2" };

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
            country3 = new Country()
            {
                Id = 3,
                Name = "Greece"
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
                Name = "Varna",
                CountryId = 1

            };
            city3 = new City()
            {
                Id = 3,
                Name = "Kavarna",
                CountryId = 1
            };

            club1 = new Club()
            {
                Id = 1,
                Name = "Club1",
                ClubOwnerId = "owner1",
                CityId = 1
            };
            club2 = new Club()
            {
                Id = 2,
                Name = "Club2",
                ClubOwnerId = "owner2",
                CityId = 1
            };

            court1 = new Court()
            {
                Id = 1,
                ClubId = 1,
            };

            court2 = new Court()
            {
                Id = 2,
                ClubId = 1,
            };

            court3 = new Court()
            {
                Id = 3,
                ClubId = 1,
            };

            booking1 = new Booking()
            {
                Id = 1,
                ClientId = "user1",
                CourtId = 1,
                Hour = 11
            };
            booking2 = new Booking()
            {
                Id = 2,
                ClientId = "user1",
                CourtId = 1,
                Hour = 12
            };
            booking3 = new Booking()
            {
                Id = 3,
                ClientId = "user1",
                CourtId = 1,
                Hour = 13
            };

            review1 = new Review()
            {
                Id = 1,
                ClubId = 1,
                BookingId = 1,
                ReviewerId = "user1",
                Rate = 10
            };
            review2 = new Review()
            {
                Id = 2,
                ClubId = 1,
                BookingId = 2,
                ReviewerId = "user1",
                Rate = 9
            };

            users = new List<ApplicationUser>()
            {
                user1,owner1,owner2
            };

            countries = new List<Country>()
            {
                country1,country2,country3
            };

            cities = new List<City>()
            {
                city1,city2, city3
            };

            clubs = new List<Club>()
            {
                club1, club2,
            };

            courts = new List<Court>()
            {
                court1,court2,court3
            };

            bookings = new List<Booking>()
            {
                booking1,booking2,booking3
            };

            reviews = new List<Review>()
            {
                review1,review2
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GameSetBookTestInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ApplicationDbContext(options);

            await dbContext.AddRangeAsync(users);
            await dbContext.AddRangeAsync(countries);
            await dbContext.AddRangeAsync(cities);
            await dbContext.AddRangeAsync(clubs);
            await dbContext.AddRangeAsync(courts);
            await dbContext.AddRangeAsync(bookings);
            await dbContext.AddRangeAsync(reviews);
            await dbContext.SaveChangesAsync();

            mockUserManager = new Mock<UserManager<ApplicationUser>>(
            Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

            repository = new Repository(dbContext);
            service = new CountryServiceAdmin(repository, mockUserManager.Object);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task ExistByNameAsync_CheckIfCountryExistReturnsTrueIfSoAndFalseIfNot()
        {
            var existingCountryName = country1.Name;
            var nonExistingCountryName = "Not existing";

            var result1 = await service.ExistByNameAsync(existingCountryName);
            var result2 = await service.ExistByNameAsync(nonExistingCountryName);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task ExistAsync_CheckIfCountryExistReturnsTrueIfSoAndFalseIfNot()
        {
            var existingCountryId = country1.Id;
            var nonExistingCountryId = -1;

            var result1 = await service.ExistAsync(existingCountryId);
            var result2 = await service.ExistAsync(nonExistingCountryId);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task AddAsync_ValidModel_CallsRepositoryAddAsyncAndSaveChangesAsync()
        {
            var countiesCountBeforeAdding = await dbContext.Countries.CountAsync();
            var model = new CountryAddAdminFormModel { Name = "Test Country" };

            await service.AddAsync(model);

            var addedCountry = await dbContext.Countries.FirstOrDefaultAsync(c => c.Name == model.Name);
            var countriesCountAfterAdding = await dbContext.Countries.CountAsync();

            Assert.That(addedCountry, Is.Not.Null);
            Assert.That(addedCountry.Name, Is.EqualTo(model.Name));
            Assert.That(countriesCountAfterAdding, Is.GreaterThan(countiesCountBeforeAdding));
        }

        [Test]
        public async Task GetAllCountiesAsync_ReturnsCorrectData()
        {
            var expectedResult1 = this.countries.ToList()[0].Name;
            var expectedResult2 = this.countries.ToList()[1].Name;
            var expectedResult3 = this.countries.ToList()[2].Name;

            var countries = await service.GetAllCountriesAsync();

            var result1 = countries.ToList()[0].Name;
            var result2 = countries.ToList()[1].Name;
            var result3 = countries.ToList()[2].Name;

            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EqualTo(expectedResult1));
                Assert.That(result2, Is.EqualTo(expectedResult2));
                Assert.That(result3, Is.EqualTo(expectedResult3));
                Assert.That(countries.Count(), Is.EqualTo(this.countries.Count()));
            });
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveCountry()
        {
            var countryId = club2.Id;

            var countriesCountBefore = await dbContext.Countries.CountAsync();

            await service.DeleteAsync(countryId);

            var countriesCountAfter = await dbContext.Countries.CountAsync();

            Assert.That(countriesCountAfter, Is.LessThan(countriesCountBefore));
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveAllCitiesRelatedToTheCountry()
        {
            var countryId = club1.Id;

            var citiesCountBefore = await dbContext.Cities.CountAsync();

            await service.DeleteAsync(countryId);

            var citiesCountAfter = await dbContext.Cities.CountAsync();

            Assert.That(citiesCountAfter, Is.LessThan(citiesCountBefore));
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveAllClubsRelatedToTheCountry()
        {
            var countryId = club1.Id;

            var clubCountBefore = await dbContext.Clubs.CountAsync();

            await service.DeleteAsync(countryId);

            var clubCountAfter = await dbContext.Clubs.CountAsync();

            Assert.That(clubCountAfter, Is.LessThan(clubCountBefore));
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveAllCourtsRelatedToTheCountry()
        {
            var countryId = club1.Id;

            var courtCountBefore = await dbContext.Courts.CountAsync();

            await service.DeleteAsync(countryId);

            var courtCountAfter = await dbContext.Courts.CountAsync();

            Assert.That(courtCountAfter, Is.LessThan(courtCountBefore));
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveAllBookingsRelatedToTheCountry()
        {
            var countryId = club1.Id;

            var bookingCountBefore = await dbContext.Bookings.CountAsync();

            await service.DeleteAsync(countryId);

            var bookingCountAfter = await dbContext.Bookings.CountAsync();

            Assert.That(bookingCountAfter, Is.LessThan(bookingCountBefore));
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveAllReviewsRelatedToTheCountry()
        {
            var countryId = club1.Id;

            var reviewCountBefore = await dbContext.Reviews.CountAsync();

            await service.DeleteAsync(countryId);

            var reviewCountAfter = await dbContext.Reviews.CountAsync();

            Assert.That(reviewCountAfter, Is.LessThan(reviewCountBefore));
        }

        [Test]
        public async Task GetCountryDetailAsync_CheckIfReturnsCorrectData()
        {
            var countryId = club1.Id;

            var expectedResultCitiesCount= await dbContext.Cities.Where(c => c.CountryId == countryId).CountAsync();
            var expectedResultClubsCount = await dbContext.Clubs.Where(c => c.City.CountryId == countryId).CountAsync();

            var result = await service.GetCountryDetailAsync(countryId);

            var numberOfCitiesInTheCountryActualResult = result.Cities.Count();
            var numberOfClubsInTheCountryActualResult = result.Clubs.Count();

            Assert.That(numberOfCitiesInTheCountryActualResult, Is.EqualTo(expectedResultCitiesCount));
            Assert.That(numberOfClubsInTheCountryActualResult, Is.EqualTo(expectedResultClubsCount));
        }
    }
}
