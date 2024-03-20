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

        private IList<IdentityUserRole<string>> UserRolesSeed()
        {
            var userRoles = new List<IdentityUserRole<string>>()
            {
                //admin user
                new IdentityUserRole<string>()
                {
                    UserId="65a12477-a9c9-48f1-a844-0ec223e1bca5",
                    RoleId ="18906160-6956-4ecc-9b7c-fa5d0a4d0f82"
                },

                //club owner
                new IdentityUserRole<string>()
                {
                    UserId="82cd50ca-b023-42e5-8344-227d5c45877c",
                    RoleId ="757178e3-b3c9-4414-8dd6-a72196f2b6d5"
                },
            };

            return userRoles;
        }
    }
}
