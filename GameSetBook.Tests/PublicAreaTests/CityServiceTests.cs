using GameSetBook.Core.Contracts;
using GameSetBook.Core.Services;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Data;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Tests.PublicAreaTests
{
    [TestFixture]
    public class CityServiceTests
    {
        private ApplicationDbContext dbContext;
        IEnumerable<City> cities;
        IEnumerable<Country> countries;

        private City Sofia;
        private City Varna;
        private City Kavarna;
        private City Bucharest;
        private City Constanta;

        private Country Bulgaria;
        private Country Romania;

        private IRepository repository;
        private ICityService cityService;

        [SetUp]
        public async Task Setup()
        {
            //Counties
            Bulgaria = new Country()
            {
                Id = 1,
                Name = "Bulgaria"
            };
            Romania = new Country()
            {
                Id = 2,
                Name = "Romania"
            };

            //Cities
            Sofia = new City()
            {
                Id = 1,
                Name = "Sofia",
                CountryId = 1
            };
            Varna = new City()
            {
                Id = 2,
                Name = "Varna",
                CountryId = 1
            };
            Kavarna = new City()
            {
                Id = 3,
                Name = "Kavarna",
                CountryId = 1
            };
            Bucharest = new City()
            {
                Id = 4,
                Name = "Bucharest",
                CountryId = 2
            };
            Constanta = new City()
            {
                Id = 5,
                Name = "Constanta",
                CountryId = 2
            };

            //Collections
            countries = new List<Country>()
            {
                Bulgaria,Romania
            };

            cities = new List<City>()
            {
                Sofia,Varna,Kavarna,Bucharest,Constanta
            };

            //Database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GameSetBookTestInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new ApplicationDbContext(options);
            //dbContext.Database.EnsureCreated();

            await dbContext.AddRangeAsync(countries);
            await dbContext.AddRangeAsync(cities);
            //await dbContext.SaveChangesAsync();

            var number = await dbContext.SaveChangesAsync();

            var countcities = dbContext.Cities.Count();
            var countcountriwes = dbContext.Countries.Count();


            //repository
            repository = new Repository(dbContext);

            //Service
            cityService = new CityService(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task GetAllCitivesAsync_ShouldReturnAllCities()
        {
            var expectedResult = this.cities.Count();
            var expectedResult1 = 4;

            var cities = await cityService.GetAllCitiesAsync();
            var result = cities.Count();

            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(result, Is.Not.EqualTo(expectedResult1));
        }

        [Test]
        public async Task GetAllCitivesAsync_ReturnsCorrectData()
        {
            var expectedName1 = this.cities.ToList()[0].Name;
            var expectedName2 = this.cities.ToList()[1].Name;
            var expectedName3 = this.cities.ToList()[2].Name;
            var expectedName4 = this.cities.ToList()[3].Name;
            var expectedName5 = this.cities.ToList()[4].Name;

            var cities = await cityService.GetAllCitiesAsync();

            var resultName1 = cities.ToList()[0].Name;
            var resultName2 = cities.ToList()[1].Name;
            var resultName3 = cities.ToList()[2].Name;
            var resultName4 = cities.ToList()[3].Name;
            var resultName5 = cities.ToList()[4].Name;

            Assert.Multiple(() =>
            {
                Assert.That(resultName1, Is.EqualTo(expectedName1));
                Assert.That(resultName2, Is.EqualTo(expectedName2));
                Assert.That(resultName3, Is.EqualTo(expectedName3));
                Assert.That(resultName4, Is.EqualTo(expectedName4));
                Assert.That(resultName5, Is.EqualTo(expectedName5));
            });
        }

        [Test]
        public async Task GetAllCitivesAsync_ReturnsCorrectCountryName()
        {
            var expectedResult1 = this.Bulgaria.Name;
            var expectedResult2 = this.Romania.Name;

            var cities = await cityService.GetAllCitiesAsync();

            var result1 = cities.ToList()[0].CountryName;
            var result2 = cities.ToList()[4].CountryName;

            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EqualTo(expectedResult1));
                Assert.That(result2, Is.EqualTo(expectedResult2));
            });
        }
    }
}
