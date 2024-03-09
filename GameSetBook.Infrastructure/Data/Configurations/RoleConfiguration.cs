using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static GameSetBook.Common.UserConstants;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(RoleSeed());
            
        }

        private IList<IdentityRole> RoleSeed()
        {
            var roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = "18906160-6956-4ecc-9b7c-fa5d0a4d0f82",
                    Name = AdminRole,
                    NormalizedName = AdminRole.ToUpper()
                },

                new IdentityRole()
                {
                    Id = "757178e3-b3c9-4414-8dd6-a72196f2b6d5",
                    Name = ClubOwnerRole,
                    NormalizedName = ClubOwnerRole.ToUpper()
                },

                new IdentityRole()
                {
                    Id = "cd40263e-6425-4dad-ada2-60e5813e5eb2",
                    Name = GSMUUserRole,
                    NormalizedName = GSMUUserRole.ToUpper()
                }           
            };
            return roles;
        }

    }
}
