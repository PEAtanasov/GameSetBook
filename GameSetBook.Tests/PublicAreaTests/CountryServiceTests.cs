using GameSetBook.Core.Contracts;
using GameSetBook.Core.Services;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Data;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Tests.PublicAreaTests
{
    [TestFixture]
    public class CountryServiceTests
    {
        private ApplicationDbContext dbContext;

        private IRepository repository;
        private ICountryService countryService;

        IEnumerable<Country> countries;

        private Country Bulgaria;
        private Country Romania;
        private Country Greece;

        [SetUp]
        public async Task Setup()
        {
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
            Greece = new Country()
            {
                Id = 3,
                Name = "Greece"
            };

            countries = new List<Country>()
            {
                Bulgaria,Romania,Greece
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GameSetBookTestInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ApplicationDbContext(options);

            await dbContext.AddRangeAsync(countries);
            await dbContext.SaveChangesAsync();

            var huinq = await dbContext.Countries.AsNoTracking().ToListAsync();
            var myrsha = await dbContext.Countries.FirstOrDefaultAsync(C=>C.Id == 1);

            repository = new Repository(dbContext);
            countryService = new CountryService(repository);
        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public async Task GetAllCountriesAsync_ReturnsCorrectResult()
        {
            var expectedResult = this.countries.Count();
            var expectedResult1 = 4;

            var countries = await countryService.GetAllCountriesAsync();
            var result = countries.Count();

            Assert.That(result, Is.EqualTo(expectedResult));
            Assert.That(result, Is.Not.EqualTo(expectedResult1));
        }

        [Test]
        public async Task GetAllCountiesAsync_ReturnsCorrectData()
        {
            var expectedResult1 = this.countries.ToList()[0].Name;
            var expectedResult2 = this.countries.ToList()[1].Name;
            var expectedResult3 = this.countries.ToList()[2].Name;

            var countries = await countryService.GetAllCountriesAsync();

            var result1 = countries.ToList()[0].Name;
            var result2 = countries.ToList()[1].Name;
            var result3 = countries.ToList()[2].Name;

            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.EqualTo(expectedResult1));
                Assert.That(result2, Is.EqualTo(expectedResult2));
                Assert.That(result3, Is.EqualTo(expectedResult3));
            });
        }

    }
}
