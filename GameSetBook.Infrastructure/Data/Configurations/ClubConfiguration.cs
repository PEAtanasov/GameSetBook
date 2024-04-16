using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class ClubConfiguration : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.HasQueryFilter(c => !c.IsDeleted);
            builder.HasData(ClubSeed());
        }

        //private IList<Club> ClubSeed()
        //{
        //    var clubs = new List<Club>()
        //    {
        //        new Club()
        //        {
        //            Id = 1,
        //            Name = "First Club",
        //            Description = "First Club Description",
        //            CityId=1,
        //            ClubOwnerId = "82cd50ca-b023-42e5-8344-227d5c45877c",
        //            Email = "firstClub@mail.com",
        //            PhoneNumber = "+359123456",
        //            HasParking = true,
        //            HasShop = true,
        //            HasShower = true,
        //            NumberOfCoaches =2,
        //            NumberOfCourts =2,
        //            WorkingTimeStart = 8,
        //            WorkingTimeEnd = 20,
        //            IsAproovedByAdmin = true,
        //            RegisteredOn = DateTime.Parse("09-03-2024 10:00"),
        //            Address = "First Club Address"
        //        }
        //    };

        //    return clubs;
        //}

        private static IList<Club> ClubSeed()
        {
            var tennisClubSf = new Club()
            {
                Id = 1,
                Name = "TC Sofia",
                ClubOwnerId = "53f6a3e4-df3b-4810-8ba0-83b9a57a379e",
                CityId = 1,
                Address = "Address 0",
                Email = "club1@example.com",
                PhoneNumber = "00000001",
                LogoUrl = "LOGO",
                NumberOfCourts = 4,
                NumberOfCoaches = 2,
                WorkingTimeStart = 8,
                WorkingTimeEnd = 21,
                RegisteredOn = DateTime.Parse("01-03-2024 10:00"),
                IsAproovedByAdmin = true,
                HasParking = true,
                HasShop = true,
                HasShower = true,
                IsDeleted = false,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.",
            };

            var forehandTcSf = new Club()
            {
                Id = 2,
                Name = "Forehand TC",
                ClubOwnerId = "3a9b86c8-1c51-4990-aafa-6c527abef86e",
                CityId = 1,
                Address = "Address 1",
                Email = "club2@example.com",
                PhoneNumber = "+35988800002",
                LogoUrl = "LOGO2",
                NumberOfCourts = 3,
                NumberOfCoaches = 2,
                WorkingTimeStart = 7,
                WorkingTimeEnd = 20,
                RegisteredOn = DateTime.Parse("02-03-2024 10:00"),
                IsAproovedByAdmin = true,
                HasParking = true,
                HasShop = false,
                HasShower = true,
                IsDeleted = false,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.",
            };

            var sixZeroClubSf = new Club()
            {
                Id = 3,
                Name = "6-0 Sofia",
                ClubOwnerId = "78d95aa6-e1b2-499e-8b93-6dabcfdbc409",
                CityId = 1,
                Address = "Address 2",
                Email = "club2@example.com",
                PhoneNumber = "+35988800003",
                LogoUrl = "LOGO3",
                NumberOfCourts = 2,
                NumberOfCoaches = 1,
                WorkingTimeStart = 7,
                WorkingTimeEnd = 23,
                RegisteredOn = DateTime.Parse("03-03-2024 10:00"),
                IsAproovedByAdmin = true,
                HasParking = true,
                HasShop = false,
                HasShower = true,
                IsDeleted = false,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.",
            };

            //Varna
            var matchPointTcVn = new Club()
            {
                Id = 4,
                Name = "Match Point",
                ClubOwnerId = "af0e6295-932f-4d03-b243-874cd538aa4b",
                CityId = 2,
                Address = "Address 3",
                Email = "club3@example.com",
                PhoneNumber = "+35988800004",
                LogoUrl = "LOGO4",
                NumberOfCourts = 3,
                NumberOfCoaches = 2,
                WorkingTimeStart = 7,
                WorkingTimeEnd = 20,
                RegisteredOn = DateTime.Parse("04-03-2024 10:00"),
                IsAproovedByAdmin = true,
                HasParking = true,
                HasShop = true,
                HasShower = false,
                IsDeleted = false,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.",
            };

            var AceTcVn = new Club()
            {
                Id = 5,
                Name = "TC Ace Varna",
                ClubOwnerId = "4be73c85-8e2c-4553-8b17-5352c2a9d11f",
                CityId = 2,
                Address = "Address 4",
                Email = "club4@example.com",
                PhoneNumber = "+35988800005",
                LogoUrl = "LOGO5",
                NumberOfCourts = 2,
                NumberOfCoaches = 2,
                WorkingTimeStart = 8,
                WorkingTimeEnd = 22,
                RegisteredOn = DateTime.Parse("01-03-2024 10:00"),
                IsAproovedByAdmin = true,
                HasParking = false,
                HasShop = true,
                HasShower = true,
                IsDeleted = false,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.",
            };

            //Kavarna
            var blackSeaRamaTcKvn = new Club()
            {
                Id = 6,
                Name = "BlackSeaRama TC",
                ClubOwnerId = "5813a55d-7cc0-4441-b5ed-27207a753a6d",
                CityId = 3,
                Address = "Address 5",
                Email = "club5@example.com",
                PhoneNumber = "+35988800006",
                LogoUrl = "LOGO6",
                NumberOfCourts = 2,
                NumberOfCoaches = 2,
                WorkingTimeStart = 7,
                WorkingTimeEnd = 21,
                RegisteredOn = DateTime.Parse("05-01-2011 10:00"),
                IsAproovedByAdmin = true,
                HasParking = true,
                HasShop = true,
                HasShower = true,
                IsDeleted = false,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.",
            };

            //Bucharest - Romania
            var numberOneTcBc = new Club()
            {
                Id = 7,
                Name = "Number One",
                ClubOwnerId = "1c3c37d5-2189-4d71-96b5-27c0da3abde7",
                CityId = 4,
                Address = "Address 6",
                Email = "club6@example.com",
                PhoneNumber = "+35988800007",
                LogoUrl = "LOGO7",
                NumberOfCourts = 3,
                NumberOfCoaches = 3,
                WorkingTimeStart = 7,
                WorkingTimeEnd = 23,
                RegisteredOn = DateTime.Parse("12-04-2023 10:00"),
                IsAproovedByAdmin = true,
                HasParking = true,
                HasShop = true,
                HasShower = true,
                IsDeleted = false,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.",
            };
            var simonaHalepTcBc = new Club()
            {
                Id = 8,
                Name = "TC Simona Halep",
                ClubOwnerId = "0e0103e9-2f94-49de-8012-eba340f8e4cf",
                CityId = 4,
                Address = "Address 7",
                Email = "club7@example.com",
                PhoneNumber = "+35988800008",
                LogoUrl = "LOGO8",
                NumberOfCourts = 2,
                NumberOfCoaches = 2,
                WorkingTimeStart = 8,
                WorkingTimeEnd = 22,
                RegisteredOn = DateTime.Parse("03-04-2023 10:00"),
                IsAproovedByAdmin = true,
                HasParking = true,
                HasShop = true,
                HasShower = true,
                IsDeleted = false,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.",
            };
            var winnerTcCn = new Club()
            {
                Id = 9,
                Name = "Winner TC",
                ClubOwnerId = "d7fc7550-ed8f-4a86-acde-65c54168e949",
                CityId = 5,
                Address = "Address 8",
                Email = "club8@example.com",
                PhoneNumber = "+35988800009",
                LogoUrl = "LOGO9",
                NumberOfCourts = 2,
                NumberOfCoaches = 1,
                WorkingTimeStart = 7,
                WorkingTimeEnd = 20,
                RegisteredOn = DateTime.Parse("04-04-2023 10:00"),
                IsAproovedByAdmin = true,
                HasParking = true,
                HasShop = true,
                HasShower = false,
                IsDeleted = false,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.",
            };
            //Athens - greece
            var tennisGodTcGr = new Club()
            {
                Id = 10,
                Name = "Zeus TC",
                ClubOwnerId = "df044ba7-d51f-491d-8663-9ee9ddc57fb0",
                CityId = 6,
                Address = "Address 10",
                Email = "club10@example.com",
                PhoneNumber = "+35988800010",
                LogoUrl = "LOGO10",
                NumberOfCourts = 2,
                NumberOfCoaches = 2,
                WorkingTimeStart = 8,
                WorkingTimeEnd = 21,
                RegisteredOn = DateTime.Parse("01-04-2023 10:00"),
                IsAproovedByAdmin = true,
                HasParking = true,
                HasShop = true,
                HasShower = true,
                IsDeleted = false,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.",
            };

            var notApprovedClubSf = new Club()
            {
                Id = 11,
                Name = "Top Tennis",
                ClubOwnerId = "b49cdbae-fe47-4f91-82b2-746025d31476",
                CityId = 1,
                Address = "Address 101",
                Email = "club11@example.com",
                PhoneNumber = "+35988800011",
                LogoUrl = "LOGO11",
                NumberOfCourts = 2,
                NumberOfCoaches = 2,
                WorkingTimeStart = 8,
                WorkingTimeEnd = 21,
                RegisteredOn = DateTime.Parse("12-12-2023 10:00"),
                IsAproovedByAdmin = false,
                HasParking = true,
                HasShop = true,
                HasShower = true,
                IsDeleted = false,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.",
            };

            var clubs = new List<Club>()
            {
                tennisClubSf,forehandTcSf,sixZeroClubSf,matchPointTcVn,AceTcVn,
                blackSeaRamaTcKvn,numberOneTcBc,simonaHalepTcBc,winnerTcCn,tennisGodTcGr,notApprovedClubSf
            };

            return clubs;
        }
    }
}
