using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.HasData(UserSeed());
        }

        private IList<IdentityUser> UserSeed()
        {
            var users = new List<IdentityUser>();
            var hasher = new PasswordHasher<IdentityUser>();

            IdentityUser user;

            user = new IdentityUser()
            {
                Id = "65a12477-a9c9-48f1-a844-0ec223e1bca5",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM"

            };
            user.PasswordHash =
                 hasher.HashPassword(user, "aaaaaa1");
            users.Add(user);

            user = new IdentityUser()
            {
                Id = "82cd50ca-b023-42e5-8344-227d5c45877c",
                UserName = "clubowner@mail.com",
                NormalizedUserName = "CLUBOWNER@GMAIL.COM",
                Email = "clubowner@mail.com",
                NormalizedEmail = "CLUBOWNER@GMAIL.COM"

            };
            user.PasswordHash =
                 hasher.HashPassword(user, "aaaaaa1");
            users.Add(user);

            user = user = new IdentityUser()
            {
                Id = "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                UserName = "user@mail.com",
                NormalizedUserName = "USER@GMAIL.COM",
                Email = "user@mail.com",
                NormalizedEmail = "USER@GMAIL.COM"
            };
            user.PasswordHash =
                 hasher.HashPassword(user, "aaaaaa1");
            users.Add(user);
            
            return users;
        }
    }
}
