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

        IEnumerable<Country> countries;

        private Country country1;
        private Country country2;
        private Country country3;

        private City city1;
        private City city2;
        private City city3;

        private Club club1;
        private Club club2;

        [SetUp]
        public async Task Setup()
        {
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

            countries = new List<Country>()
            {
                country1,country2,country3
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GameSetBookTestInMemoryDb" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ApplicationDbContext(options);

            await dbContext.AddRangeAsync(countries);
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
        public  async Task ExistByNameAsync_CheckIfCountryExistReturnsTrueIfSoAndFalseIfNot()
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
    }
}
