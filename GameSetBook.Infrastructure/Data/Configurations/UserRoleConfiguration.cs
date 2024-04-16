using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(UserRolesSeed());
        }

        private static IList<IdentityUserRole<string>> UserRolesSeed()
        {
            var userRoles = new List<IdentityUserRole<string>>()
            {
                //admin user
                new IdentityUserRole<string>()
                {
                    UserId="65a12477-a9c9-48f1-a844-0ec223e1bca5",
                    RoleId ="18906160-6956-4ecc-9b7c-fa5d0a4d0f82"
                },
               

                //club owners
                new IdentityUserRole<string>()
                {
                    UserId="82cd50ca-b023-42e5-8344-227d5c45877c",
                    RoleId ="757178e3-b3c9-4414-8dd6-a72196f2b6d5"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "53f6a3e4-df3b-4810-8ba0-83b9a57a379e",
                    RoleId = "757178e3-b3c9-4414-8dd6-a72196f2b6d5"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "3a9b86c8-1c51-4990-aafa-6c527abef86e",
                    RoleId = "757178e3-b3c9-4414-8dd6-a72196f2b6d5"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "78d95aa6-e1b2-499e-8b93-6dabcfdbc409",
                    RoleId = "757178e3-b3c9-4414-8dd6-a72196f2b6d5"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "af0e6295-932f-4d03-b243-874cd538aa4b",
                    RoleId = "757178e3-b3c9-4414-8dd6-a72196f2b6d5"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "4be73c85-8e2c-4553-8b17-5352c2a9d11f",
                    RoleId = "757178e3-b3c9-4414-8dd6-a72196f2b6d5"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "5813a55d-7cc0-4441-b5ed-27207a753a6d",
                    RoleId = "757178e3-b3c9-4414-8dd6-a72196f2b6d5"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "1c3c37d5-2189-4d71-96b5-27c0da3abde7",
                    RoleId = "757178e3-b3c9-4414-8dd6-a72196f2b6d5"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "0e0103e9-2f94-49de-8012-eba340f8e4cf",
                    RoleId = "757178e3-b3c9-4414-8dd6-a72196f2b6d5"
                },
                new IdentityUserRole<string>()
                {
                     UserId = "d7fc7550-ed8f-4a86-acde-65c54168e949",
                     RoleId = "757178e3-b3c9-4414-8dd6-a72196f2b6d5"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "df044ba7-d51f-491d-8663-9ee9ddc57fb0",
                    RoleId = "757178e3-b3c9-4414-8dd6-a72196f2b6d5"
                },

            };

            return userRoles;
        }
    }
}
