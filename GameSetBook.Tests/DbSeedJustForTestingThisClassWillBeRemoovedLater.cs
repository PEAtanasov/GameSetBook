using GameSetBook.Infrastructure.Data;
using GameSetBook.Infrastructure.Models;
using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Tests
{
    [TestFixture]
    public class DbSeedJustForTestingThisClassWillBeRemoovedLater
    {
        private ApplicationDbContext dbContext;

        private IEnumerable<ApplicationUser> users;
        private IEnumerable<Country> countries;
        private IEnumerable<City> cities;
        private IEnumerable<Club> clubs;
        private IEnumerable<Court> courts;
        private IEnumerable<Booking> bookings;
        private IEnumerable<Review> reviews;


        //U S E R S
        //ADMINS
        private ApplicationUser admin;

        //CLUBOWNERS
        //sofia clubs
        private ApplicationUser tennisClubSfOwner;
        private ApplicationUser forehandTcSfOwner;
        private ApplicationUser sixZeroClubSfOwner;
        //varna clubs
        private ApplicationUser matchPointTcVnOwner;
        private ApplicationUser AceTcVnOwner;
        //Kavarna
        private ApplicationUser blackSeaRamaTcKvnOwner;
        //Bucharest
        private ApplicationUser numberOneTcBcOwner;
        private ApplicationUser simonaHalepTcBcOwner;
        //Constanta
        private ApplicationUser winnerTcCnOwner;
        //Athens
        private ApplicationUser tennisGodTcGrOwner;

        //REGULAR USERS
        private ApplicationUser user1;
        private ApplicationUser user2;
        private ApplicationUser user3;
        private ApplicationUser user4;
        private ApplicationUser user5;
        private ApplicationUser user6;
        private ApplicationUser user7;
        private ApplicationUser user8;
        private ApplicationUser user9;
        private ApplicationUser user10;


        //C O U N T R I E S
        private Country bulgaria;
        private Country romania;
        private Country greece;


        //C I T T I E S
        //Bulgaria
        private City sofia;
        private City varna;
        private City kavarna;

        //Romania
        private City bucharest;
        private City constanta;

        //Greece
        private City athens;



        //C L U B S
        //Sofia-bulgaria
        private Club tennisClubSf;
        private Club forehandTcSf;
        private Club sixZeroClubSf;

        //Varna - bulgaria
        private Club matchPointTcVn;
        private Club AceTcVn;

        //Kavarna - bulgaria
        private Club blackSeaRamaTcKvn;

        //Bucharest - Romania
        private Club numberOneTcBc;
        private Club simonaHalepTcBc;

        //Constanta - Romania
        private Club winnerTcCn;

        //Athens - Greece
        private Club tennisGodTcGr;




        //C O U R T S
        //tennisClubSf -sofia - bulgaria
        private Court tennisClubSfCourtNo1;
        private Court tennisClubSfCourtNo2;
        private Court tennisClubSfCourtNo3;
        private Court tennisClubSfCourtNo4;

        //forehandTcSf - sofia - bulgaria
        private Court forehandTcSfCourtNo1;
        private Court forehandTcSfCourtNo2;
        private Court forehandTcSfCourtNo3;

        //sixZeroClubSf - sofia - bulgaria
        private Court sixZeroClubSfCourtNo1;
        private Court sixZeroClubSfCourtNo2;

        //matchPointTcVn - varna - bulgaria
        private Court matchPointTcVnCourtNo1;
        private Court matchPointTcVnCourtNo2;
        private Court matchPointTcVnCourtNo3;

        //AceTcVn-varna - varna - bulgaria
        private Court AceTcVnCourtNo1;
        private Court AceTcVnCourtNo2;

        //blackSeaRamaTcKvn - kavarna - bulgaria
        private Court blackSeaRamaTcKvnCourtNo1;
        private Court blackSeaRamaTcKvnCourtNo2;

        //numberOneTcBc - Bucharest - romania
        private Court numberOneTcBcCourtNo1;
        private Court numberOneTcBcCourtNo2;
        private Court numberOneTcBcCourtNo3;

        //simonaHalepTcBc - Bucharest - romania
        private Court simonaHalepTcBcCourtNo1;
        private Court simonaHalepTcBcCourtNo2;

        //winnerTcCn - Constanta - Romania
        private Court winnerTcCnCourtNo1;
        private Court winnerTcCnCourtNo2;

        //tennisGodTcGr - Athens - Greece
        private Court tennisGodTcGrCourtNo1;
        private Court tennisGodTcGrCourtNo2;


        [SetUp]
        public async Task Setup()
        {

            //Regular Users SetUp
            user1 = new ApplicationUser()
            {
                Id = "f011047b-9d4a-4cb6-8125-56fcd52a572e",
                UserName = "user1@example.com",
                NormalizedUserName = "user1@example.com".ToUpper(),
                Email = "user1@example.com",
                NormalizedEmail = "user1@example.com".ToUpper(),
                FirstName = "Petar",
                LastName = "Petrov",
                PhoneNumber = "111111"               
            };

            user2 = new ApplicationUser()
            {
                Id = "be5f9238-069b-441f-b920-3464ab6ffc21",
                UserName = "user2@example.com",
                NormalizedUserName = "user2@example.com".ToUpper(),
                Email = "user2@example.com",
                NormalizedEmail = "user2@example.com".ToUpper(),
                FirstName = "Georgi",
                LastName = "Georgiev",
                PhoneNumber = "222222"
            };
            user3 = new ApplicationUser()
            {
                Id = "09ff5c8e-811b-404d-bf52-545f1100b31b",
                UserName = "user3@example.com",
                NormalizedUserName = "user3@example.com".ToUpper(),
                Email = "user3@example.com",
                NormalizedEmail = "user3@example.com".ToUpper(),
                FirstName = "Atanas",
                LastName = "Atanasov",
                PhoneNumber = "333333"
            };
            user4 = new ApplicationUser()
            {
                Id = "33104877-4d79-4194-b09a-9e75f1790ceb",
                UserName = "user4@example.com",
                NormalizedUserName = "user4@example.com".ToUpper(),
                Email = "user4@example.com",
                NormalizedEmail = "user4@example.com".ToUpper(),
                FirstName = "Natalia",
                LastName = "Atanasova",
                PhoneNumber = "444444"
            };
            user5 = new ApplicationUser()
            {
                Id = "a3070a05-d72b-4f5d-b4da-ee8ca88cd6c4",
                UserName = "user5@example.com",
                NormalizedUserName = "user5@example.com".ToUpper(),
                Email = "user5@example.com",
                NormalizedEmail = "user5@example.com".ToUpper(),
                FirstName = "Gergana",
                LastName = "Ivanova",
                PhoneNumber = "555555"
            };
            user6 = new ApplicationUser()
            {
                Id = "537897c6-0554-4ed4-9331-be3c7d8607af",
                UserName = "user6@example.com",
                NormalizedUserName = "user6@example.com".ToUpper(),
                Email = "user6@example.com",
                NormalizedEmail = "user6@example.com".ToUpper(),
                FirstName = "Plamen",
                LastName = "Plamenov",
                PhoneNumber = "666666"
            };
            user7 = new ApplicationUser()
            {
                Id = "6449c49f-46d1-40ed-9ec1-da665101ec50",
                UserName = "user7@example.com",
                NormalizedUserName = "user7@example.com".ToUpper(),
                Email = "user7@example.com",
                NormalizedEmail = "user7@example.com".ToUpper(),
                FirstName = "Nikolay",
                LastName = "Velinov",
                PhoneNumber = "777777"
            };
            user8 = new ApplicationUser()
            {
                Id = "c0bb387b-bfb2-48f0-895a-56394ae5c8c2",
                UserName = "user8@example.com",
                NormalizedUserName = "user8@example.com".ToUpper(),
                Email = "user8@example.com",
                NormalizedEmail = "user8@example.com".ToUpper(),
                FirstName = "Veselin",
                LastName = "Hristov",
                PhoneNumber = "888888"
            };
            user9 = new ApplicationUser()
            {
                Id = "4377278c-69e2-4269-b1c3-7e688ef5dcd4",
                UserName = "user9@example.com",
                NormalizedUserName = "user9@example.com".ToUpper(),
                Email = "user9@example.com",
                NormalizedEmail = "user9@example.com".ToUpper(),
                FirstName = "Martin",
                LastName = "Hristov",
                PhoneNumber = "999999"
            };
            user10 = new ApplicationUser()
            {
                Id = "e4193a92-3a49-41eb-8920-280bbec55eeb",
                UserName = "user10@example.com",
                NormalizedUserName = "user10@example.com".ToUpper(),
                Email = "user10@example.com",
                NormalizedEmail = "user10@example.com".ToUpper(),
                FirstName = "Dara",
                LastName = "Atanasova",
                PhoneNumber = "000000"
            };

            //CluOwners SetUp
            tennisClubSfOwner = new ApplicationUser()
            {
                Id = "53f6a3e4-df3b-4810-8ba0-83b9a57a379e",
                UserName = "owner1@example.com",
                NormalizedUserName = "owner1@example.com".ToUpper(),
                Email = "owner1@example.com",
                NormalizedEmail = "owner1@example.com".ToUpper(),
                FirstName = "owner1",
                LastName = "owner1",
                PhoneNumber = "0000000"
            };
            forehandTcSfOwner = new ApplicationUser()
            {
                Id = "3a9b86c8-1c51-4990-aafa-6c527abef86e",
                UserName = "owner2@example.com",
                NormalizedUserName = "owner2@example.com".ToUpper(),
                Email = "owner2@example.com",
                NormalizedEmail = "owner2@example.com".ToUpper(),
                FirstName = "owner2",
                LastName = "owner2",
                PhoneNumber = "1111111"
            };
            sixZeroClubSfOwner = new ApplicationUser()
            {
                Id = "78d95aa6-e1b2-499e-8b93-6dabcfdbc409",
                UserName = "owner3@example.com",
                NormalizedUserName = "owner3@example.com".ToUpper(),
                Email = "owner3@example.com",
                NormalizedEmail = "owner3@example.com".ToUpper(),
                FirstName = "owner3",
                LastName = "owner3",
                PhoneNumber = "2222222"
            };
            matchPointTcVnOwner = new ApplicationUser()
            {
                Id = "af0e6295-932f-4d03-b243-874cd538aa4b",
                UserName = "owner4@example.com",
                NormalizedUserName = "owner4@example.com".ToUpper(),
                Email = "owner4@example.com",
                NormalizedEmail = "owner4@example.com".ToUpper(),
                FirstName = "owner4",
                LastName = "owner4",
                PhoneNumber = "3333333"
            };
            AceTcVnOwner = new ApplicationUser()
            {
                Id = "4be73c85-8e2c-4553-8b17-5352c2a9d11f",
                UserName = "owner5@example.com",
                NormalizedUserName = "owner5@example.com".ToUpper(),
                Email = "owner5@example.com",
                NormalizedEmail = "owner5@example.com".ToUpper(),
                FirstName = "owner5",
                LastName = "owner5",
                PhoneNumber = "4444444"
            };
            blackSeaRamaTcKvnOwner = new ApplicationUser()
            {
                Id = "5813a55d-7cc0-4441-b5ed-27207a753a6d",
                UserName = "owner6@example.com",
                NormalizedUserName = "owner6@example.com".ToUpper(),
                Email = "owner6@example.com",
                NormalizedEmail = "owner6@example.com".ToUpper(),
                FirstName = "owner6",
                LastName = "owner6",
                PhoneNumber = "5555555"
            };
            numberOneTcBcOwner = new ApplicationUser()
            {
                Id = "1c3c37d5-2189-4d71-96b5-27c0da3abde7",
                UserName = "owner7@example.com",
                NormalizedUserName = "owner7@example.com".ToUpper(),
                Email = "owner7@example.com",
                NormalizedEmail = "owner7@example.com".ToUpper(),
                FirstName = "owner7",
                LastName = "owner7",
                PhoneNumber = "6666666"
            };
            simonaHalepTcBcOwner = new ApplicationUser()
            {
                Id = "0e0103e9-2f94-49de-8012-eba340f8e4cf",
                UserName = "owner8@example.com",
                NormalizedUserName = "owner8@example.com".ToUpper(),
                Email = "owner8@example.com",
                NormalizedEmail = "owner8@example.com".ToUpper(),
                FirstName = "owner8",
                LastName = "owner8",
                PhoneNumber = "7777777"
            };
            winnerTcCnOwner = new ApplicationUser()
            {
                Id = "d7fc7550-ed8f-4a86-acde-65c54168e949",
                UserName = "owner9@example.com",
                NormalizedUserName = "owner9@example.com".ToUpper(),
                Email = "owner9@example.com",
                NormalizedEmail = "owner9@example.com".ToUpper(),
                FirstName = "owner9",
                LastName = "owner9",
                PhoneNumber = "8888888"
            };
            tennisGodTcGrOwner = new ApplicationUser()
            {
                Id = "df044ba7-d51f-491d-8663-9ee9ddc57fb0",
                UserName = "owner10@example.com",
                NormalizedUserName = "owner10@example.com".ToUpper(),
                Email = "owner10@example.com",
                NormalizedEmail = "owner10@example.com".ToUpper(),
                FirstName = "owner10",
                LastName = "owner10",
                PhoneNumber = "9999999"
            };

            //Countries SetUp
            bulgaria = new Country()
            {
                Id = 1,
                Name = "Bulgaria",
            };
            romania = new Country()
            {
                Id = 2,
                Name = "Romania",
            };
            greece = new Country()
            {
                Id = 3,
                Name = "Greece",
            };

            //Cities setup
            //Bulgaria
            sofia = new City()
            {
                Id = 1,
                Name = "Sofia",
                CountryId = 1
            };
            varna = new City()
            {
                Id = 2,
                Name = "Varna",
                CountryId = 1
            };
            kavarna = new City()
            {
                Id = 3,
                Name = "Kavarna",
                CountryId = 1
            };
            //Romania
            bucharest = new City()
            {
                Id= 4,
                Name = "Bucharest",
                CountryId = 2
            };
            constanta = new City()
            {
                Id = 5,
                Name = "Constanta",
                CountryId = 2
            };
            //Greece
            athens = new City()
            {
                Id = 6,
                Name = "Athens",
                CountryId = 3
            };


            users = new List<ApplicationUser>()
            {
                user1, user2, user3, user4, user5, user6, user7, user8, user9, user10, 
                tennisClubSfOwner,forehandTcSfOwner,sixZeroClubSfOwner,
                matchPointTcVnOwner,AceTcVnOwner,blackSeaRamaTcKvnOwner,
                numberOneTcBcOwner,simonaHalepTcBcOwner,winnerTcCnOwner,tennisGodTcGrOwner
            };

            countries = new List<Country>()
            {
                bulgaria,romania,greece
            };

            cities = new List<City>()
            {
                sofia,varna,kavarna,bucharest,constanta,athens
            };

            clubs = new List<Club>()
            {
                tennisClubSf,forehandTcSf,sixZeroClubSf,matchPointTcVn,AceTcVn,blackSeaRamaTcKvn,numberOneTcBc,simonaHalepTcBc,winnerTcCn,tennisGodTcGr
            };

            courts = new List<Court>()
            {
                tennisClubSfCourtNo1,tennisClubSfCourtNo2,tennisClubSfCourtNo3,tennisClubSfCourtNo4,forehandTcSfCourtNo1,forehandTcSfCourtNo2,forehandTcSfCourtNo3,
                sixZeroClubSfCourtNo1,sixZeroClubSfCourtNo2,matchPointTcVnCourtNo1,matchPointTcVnCourtNo2,matchPointTcVnCourtNo3,AceTcVnCourtNo1,AceTcVnCourtNo2,
                blackSeaRamaTcKvnCourtNo1,blackSeaRamaTcKvnCourtNo2,numberOneTcBcCourtNo1,numberOneTcBcCourtNo2,numberOneTcBcCourtNo3,simonaHalepTcBcCourtNo1,
                simonaHalepTcBcCourtNo2,winnerTcCnCourtNo1,winnerTcCnCourtNo2,tennisGodTcGrCourtNo1,tennisGodTcGrCourtNo2
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "GameSetBookTestInMemoryDb" + Guid.NewGuid().ToString())
                    .Options;

            dbContext = new ApplicationDbContext(options);

            await dbContext.AddRangeAsync(users);
            await dbContext.AddRangeAsync(countries);
            await dbContext.AddRangeAsync(cities);
            //await dbContext.AddRangeAsync(clubs);
            //await dbContext.AddRangeAsync(courts);
            //await dbContext.AddRangeAsync(bookings);
            //await dbContext.AddRangeAsync(reviews);
            var count = await dbContext.SaveChangesAsync();

            var usersCount = await dbContext.Users.ToListAsync();
            var countriesCount = await dbContext.Countries.ToListAsync();
            var citiesCount = await dbContext.Cities.ToListAsync();


        }

        [TearDown]
        public async Task Teardown()
        {
            await this.dbContext.Database.EnsureDeletedAsync();
            await this.dbContext.DisposeAsync();
        }

        [Test]
        public void DemoTest()
        {
            Assert.That(2, Is.EqualTo(1));
            Assert.That(3, Is.EqualTo(5));
        }
    }
}
