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
                Id = "7675dcd4-f0de-4e90-98fc-31b8ee54768f",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM"

            };
            user.PasswordHash =
                 hasher.HashPassword(user, "Admin123");
            users.Add(user);

            user = new IdentityUser()
            {
                Id = "7bbb2a6d-2243-4945-85a4-c365240a303b",
                Email = "clubowner@mail.com",
                NormalizedEmail = "CLUBOWNER@GMAIL.COM"

            };
            user.PasswordHash =
                 hasher.HashPassword(user, "Admin123");
            users.Add(user);

            user = user = new IdentityUser()
            {
                Id = "0a7178d0-e1d9-4249-8d4e-a393fe17c813",
                Email = "user@mail.com",
                NormalizedEmail = "USER@GMAIL.COM"
            };
            user.PasswordHash =
                 hasher.HashPassword(user, "User123");
            users.Add(user);
            
            return users;
        }
    }
}
