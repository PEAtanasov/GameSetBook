using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Services.Admin;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Data;
using GameSetBook.Infrastructure.Models.Identity;
using GameSetBook.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using GameSetBook.Core.Services;
using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Admin.Country;
using GameSetBook.Core.Models.Admin.City;

namespace GameSetBook.Tests.AdminAreaTests
{
    [TestFixture]
    public class CityServiceAdminTests
    {
        private ApplicationDbContext dbContext;

        private IRepository repository;
        private ICityServiceAdmin service;
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
        private ApplicationUser owner3;

        private Country country1;
        private Country country2;

        private City city1;
        private City city2;
        private City city3;
        private City city4;

        private Club club1;
        private Club club2;
        private Club club3;

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
            owner3 = new ApplicationUser() { Id = "owner3" };

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
                Name = "Varna",
                CountryId = 1

            };
            city3 = new City()
            {
                Id = 3,
                Name = "Kavarna",
                CountryId = 1
            };
            city4 = new City()
            {
                Id = 4,
                Name = "Bucharest",
                CountryId = 2
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
            club3 = new Club()
            {
                Id = 3,
                Name = "Club3",
                ClubOwnerId = "owner3",
                CityId = 4
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
                user1,owner1,owner2,owner3
            };

            countries = new List<Country>()
            {
                country1,country2
            };

            cities = new List<City>()
            {
                city1,city2, city3,city4
            };

            clubs = new List<Club>()
            {
                club1, club2, club3
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
            Mock.Of<IUserStore<ApplicationUser>>(), null!, null!, null!, null!, null!, null!, null!, null!);

            repository = new Repository(dbContext);
            service = new CityServiceAdmin(repository, mockUserManager.Object);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task ExistById_ShuoldReturnTrueIfCityExistOrFalseIfNot()
        {
            var existingCityId = city1.Id;
            var nonExistingCityId = -1;

            var result1 = await service.ExistById(existingCityId);
            var result2 = await service.ExistById(nonExistingCityId);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task GetAllCitivesAsync_ShouldReturnAllCities()
        {
            var expectedResult = this.cities.Count();
            var wrongCount = 5;

            var cities = await service.GetAllCitiesAsync();
            var result = cities.Count();

            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(result, Is.Not.EqualTo(wrongCount));
        }

        [Test]
        public async Task GetAllCitivesAsync_ReturnsCorrectData()
        {
            var expectedName1 = this.cities.ToList()[0].Name;
            var expectedName2 = this.cities.ToList()[1].Name;
            var expectedName3 = this.cities.ToList()[2].Name;
            var expectedName4 = this.cities.ToList()[3].Name;

            var cities = await service.GetAllCitiesAsync();

            var resultName1 = cities.ToList()[0].Name;
            var resultName2 = cities.ToList()[1].Name;
            var resultName3 = cities.ToList()[2].Name;
            var resultName4 = cities.ToList()[3].Name;

            Assert.Multiple(() =>
            {
                Assert.That(resultName1, Is.EqualTo(expectedName1));
                Assert.That(resultName2, Is.EqualTo(expectedName2));
                Assert.That(resultName3, Is.EqualTo(expectedName3));
                Assert.That(resultName4, Is.EqualTo(expectedName4));
            });
        }

        [Test]
        public async Task ExistByNameAsync_CheckIfCityExistReturnsTrueIfSoAndFalseIfNot()
        {
            var countryId = country1.Id;
            var existingCityName = city1.Name;
            var nonExistingCityName = "Not existing";

            var result1 = await service.ExistByNameAsync(existingCityName, countryId);
            var result2 = await service.ExistByNameAsync(nonExistingCityName, countryId);

            Assert.That(result1, Is.True);
            Assert.That(result2, Is.False);
        }

        [Test]
        public async Task AddAsync_ValidModel_CallsRepositoryAddAsyncAndSaveChangesAsync()
        {
            var citiesCountBeforeAdding = await dbContext.Cities.CountAsync();
            var model = new CityAddAdminFormModel { Name = "Test city", CountryId= country1.Id };

            await service.AddAsync(model);

            var addedCity = await dbContext.Cities.FirstOrDefaultAsync(c => c.Name == model.Name);
            var citiesCountAfterAdding = await dbContext.Cities.CountAsync();

            Assert.That(addedCity, Is.Not.Null);
            Assert.That(addedCity.Name, Is.EqualTo(model.Name));
            Assert.That(citiesCountAfterAdding, Is.GreaterThan(citiesCountBeforeAdding));
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveCity()
        {
            var validCityId = city2.Id;

            var citiesCountBefore = await dbContext.Cities.CountAsync();

            await service.DeleteAsync(validCityId);

            var citiesCountAfter = await dbContext.Cities.CountAsync();

            Assert.That(citiesCountAfter, Is.LessThan(citiesCountBefore));
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveAllClubsRelatedToTheCity()
        {
            var validCityId = city1.Id;

            var clubsCountBefore = await dbContext.Clubs.CountAsync();

            await service.DeleteAsync(validCityId);

            var clubsCountAfter = await dbContext.Clubs.CountAsync();

            Assert.That(clubsCountAfter, Is.LessThan(clubsCountBefore));

            if (clubsCountBefore==0)
            {
                Assert.That(clubsCountAfter, Is.EqualTo(clubsCountBefore));
            }
            else
            {
                Assert.That(clubsCountAfter, Is.LessThan(clubsCountBefore));
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveAllCourtsRelatedToTheCity()
        {
            var validCityId = city1.Id;

            var courtsCountBefore = await dbContext.Courts.CountAsync();

            await service.DeleteAsync(validCityId);

            var courtsCountAfter = await dbContext.Courts.CountAsync();

            Assert.That(courtsCountAfter, Is.LessThan(courtsCountBefore));

            if (courtsCountBefore==0)
            {
                Assert.That(courtsCountAfter, Is.EqualTo(courtsCountBefore));
            }
            else
            {
                Assert.That(courtsCountAfter, Is.LessThan(courtsCountBefore));
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveAllBookingsRelatedToTheCity()
        {
            var validCityId = city1.Id;

            var bookingsCountBefore = await dbContext.Bookings.CountAsync();

            await service.DeleteAsync(validCityId);

            var bookingsCountAfter = await dbContext.Bookings.CountAsync();

            if (bookingsCountBefore==0)
            {
                Assert.That(bookingsCountAfter, Is.EqualTo(bookingsCountBefore));
            }
            else
            {
                Assert.That(bookingsCountAfter, Is.LessThan(bookingsCountBefore));
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldRemoveAllReviewsRelatedToTheCity()
        {
            var validCityId = city1.Id;

            var reviewsCountBefore = await dbContext.Reviews.CountAsync();

            await service.DeleteAsync(validCityId);

            var reviewsCountAfter = await dbContext.Reviews.CountAsync();

            if (reviewsCountBefore==0)
            {
                Assert.That(reviewsCountAfter, Is.EqualTo(reviewsCountBefore));
            }
            else
            {
                Assert.That(reviewsCountAfter, Is.LessThan(reviewsCountBefore));
            }
        }

        [Test]
        public async Task GetCityDetailsAsync_ShouldReturnModelWithCorrectData()
        {
            var validCityId = city1.Id;

            var expectedCityId = city1.Id;
            var expectedCityName = city1.Name;
            var expectedResultClubsCount = await dbContext.Clubs.Where(c => c.CityId == validCityId).CountAsync();
            var expectedCountryId = city1.CountryId;

            var result = await service.GetCityDetailsAsync(validCityId);

            var actualResultCityId = result.Id;
            var actualResultCityName = result.Name;
            var actualResultClubsCount = result.Clubs.Count();
            var actualResultCoutryId = result.Country.Id;
           

            Assert.That(actualResultClubsCount,Is.EqualTo(expectedResultClubsCount));
            Assert.That(actualResultCoutryId, Is.EqualTo(expectedCountryId));
            Assert.That(expectedCityId, Is.EqualTo(actualResultCityId));
            Assert.That(expectedCityName, Is.EqualTo(actualResultCityName));
        }
    }
}
