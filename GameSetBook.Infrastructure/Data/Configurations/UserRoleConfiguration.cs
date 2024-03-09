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
                    UserId="7675dcd4-f0de-4e90-98fc-31b8ee54768f",
                    RoleId ="18906160-6956-4ecc-9b7c-fa5d0a4d0f82"
                },

                //club owner
                new IdentityUserRole<string>()
                {
                    UserId="7bbb2a6d-2243-4945-85a4-c365240a303b8",
                    RoleId ="757178e3-b3c9-4414-8dd6-a72196f2b6d5"
                },

                //SMPUuser
                new IdentityUserRole<string>()
                {
                    UserId="0a7178d0-e1d9-4249-8d4e-a393fe17c813",
                    RoleId ="cd40263e-6425-4dad-ada2-60e5813e5eb2"
                }
            };

            return userRoles;
        }
    }
}
