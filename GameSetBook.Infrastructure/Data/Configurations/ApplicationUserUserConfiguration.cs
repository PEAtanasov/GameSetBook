using GameSetBook.Infrastructure.Models.Identity;
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
    internal class ApplicationUserUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(UserSeed());
        }

        private IList<ApplicationUser> UserSeed()
        {
            var users = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            ApplicationUser user;

            user = new ApplicationUser()
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

            user = new ApplicationUser()
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

            user = user = new ApplicationUser()
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
