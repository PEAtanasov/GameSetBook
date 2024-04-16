using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.Intrinsics.X86;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(UserSeed());
        }

        private static IList<ApplicationUser> UserSeed()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            ApplicationUser admin = new ApplicationUser()
            {
                Id = "65a12477-a9c9-48f1-a844-0ec223e1bca5",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                PhoneNumber = "0000000000",
                FirstName = "Petar",
                LastName = "Atanasov",
            };

            admin.PasswordHash = hasher.HashPassword(admin, "admin1");

            ApplicationUser clubOwner = new ApplicationUser()
            {
                Id = "82cd50ca-b023-42e5-8344-227d5c45877c",
                UserName = "clubowner@mail.com",
                NormalizedUserName = "CLUBOWNER@MAIL.COM",
                Email = "clubowner@mail.com",
                NormalizedEmail = "CLUBOWNER@MAIL.COM",
                PhoneNumber = "1111111111",
                FirstName = "Atanas",
                LastName = "Atanasov",
            };

            clubOwner.PasswordHash = hasher.HashPassword(clubOwner, "aaaaaa1");

            ApplicationUser user = user = new ApplicationUser()
            {
                Id = "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                UserName = "user@mail.com",
                NormalizedUserName = "USER@MAIL.COM",
                Email = "user@mail.com",
                NormalizedEmail = "USER@MAIL.COM",
                PhoneNumber = "2222222222",
                FirstName = "Encho",
                LastName = "Georgiev",
            };

            user.PasswordHash = hasher.HashPassword(user, "aaaaaa1");

            //////

            var user1 = new ApplicationUser()
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

            user1.PasswordHash = hasher.HashPassword(user1, "aaaaaa1");

            var user2 = new ApplicationUser()
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

            user2.PasswordHash = hasher.HashPassword(user2, "aaaaaa1");

            var user3 = new ApplicationUser()
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

            user3.PasswordHash =  hasher.HashPassword(user3, "aaaaaa1");

            var user4 = new ApplicationUser()
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

            user4.PasswordHash = hasher.HashPassword(user4, "aaaaaa1");

            var user5 = new ApplicationUser()
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

            user5.PasswordHash = hasher.HashPassword(user5, "aaaaaa1");

            var user6 = new ApplicationUser()
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

            user6.PasswordHash = hasher.HashPassword(user6, "aaaaaa1");

            var user7 = new ApplicationUser()
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

            user7.PasswordHash = hasher.HashPassword(user7, "aaaaaa1");

            var user8 = new ApplicationUser()
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

            user8.PasswordHash = hasher.HashPassword(user8, "aaaaaa1");

            var user9 = new ApplicationUser()
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

            user9.PasswordHash = hasher.HashPassword(user9, "aaaaaa1");

            var user10 = new ApplicationUser()
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

            user10.PasswordHash = hasher.HashPassword(user10, "aaaaaa1");

            var tennisClubSfOwner = new ApplicationUser()
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

            tennisClubSfOwner.PasswordHash = hasher.HashPassword(tennisClubSfOwner, "aaaaaa1");

            var forehandTcSfOwner = new ApplicationUser()
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

            forehandTcSfOwner.PasswordHash = hasher.HashPassword(forehandTcSfOwner, "aaaaaa1");

            var sixZeroClubSfOwner = new ApplicationUser()
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

            sixZeroClubSfOwner.PasswordHash = hasher.HashPassword(sixZeroClubSfOwner, "aaaaaa1");

            var matchPointTcVnOwner = new ApplicationUser()
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

            matchPointTcVnOwner.PasswordHash = hasher.HashPassword(matchPointTcVnOwner, "aaaaaa1");

            var AceTcVnOwner = new ApplicationUser()
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

            AceTcVnOwner.PasswordHash = hasher.HashPassword(AceTcVnOwner, "aaaaaa1");

            var blackSeaRamaTcKvnOwner = new ApplicationUser()
            {
                Id = "5813a55d-7cc0-4441-b5ed-27207a753a6d",
                UserName = "owner6@example.com",
                NormalizedUserName = "owner6@example.com".ToUpper(),
                Email = "owner6@example.com",
                NormalizedEmail = "owner6@example.com".ToUpper(),
                FirstName = "Petar",
                LastName = "Atanasov",
                PhoneNumber = "5555555"
            };

            blackSeaRamaTcKvnOwner.PasswordHash = hasher.HashPassword(blackSeaRamaTcKvnOwner, "aaaaaa1");

            var numberOneTcBcOwner = new ApplicationUser()
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

            numberOneTcBcOwner.PasswordHash = hasher.HashPassword(numberOneTcBcOwner, "aaaaaa1");

            var simonaHalepTcBcOwner = new ApplicationUser()
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

            simonaHalepTcBcOwner.PasswordHash = hasher.HashPassword(simonaHalepTcBcOwner, "aaaaaa1");

            var winnerTcCnOwner = new ApplicationUser()
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

            winnerTcCnOwner.PasswordHash = hasher.HashPassword(winnerTcCnOwner, "aaaaaa1");

            var tennisGodTcGrOwner = new ApplicationUser()
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

            tennisGodTcGrOwner.PasswordHash = hasher.HashPassword(tennisGodTcGrOwner, "aaaaaa1");

            var notApprovedClubOwner = new ApplicationUser()
            {
                Id = "b49cdbae-fe47-4f91-82b2-746025d31476",
                UserName = "notapproved@example.com",
                NormalizedUserName = "notapproved@example.com".ToUpper(),
                Email = "notapproved@example.com",
                NormalizedEmail = "notapproved@example.com".ToUpper(),
                FirstName = "not Approved owner",
                LastName = "not Approved owner",
                PhoneNumber = "99999991"
            };

            notApprovedClubOwner.PasswordHash = hasher.HashPassword(notApprovedClubOwner, "aaaaaa1");

            var users = new List<ApplicationUser>()
            {
                admin,clubOwner,user,user1, user2, user3, user4, user5, user6, user7, user8, user9, user10,
                tennisClubSfOwner,forehandTcSfOwner,sixZeroClubSfOwner,
                matchPointTcVnOwner,AceTcVnOwner,blackSeaRamaTcKvnOwner,
                numberOneTcBcOwner,simonaHalepTcBcOwner,winnerTcCnOwner,
                tennisGodTcGrOwner,notApprovedClubOwner,
            };

            return users;
        }
    }
}
