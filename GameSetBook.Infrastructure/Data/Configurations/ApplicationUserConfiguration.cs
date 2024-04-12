using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(UserSeed());
        }

        private IList<ApplicationUser> UserSeed()
        {
            var users = new List<ApplicationUser>();
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
            admin.PasswordHash =
                 hasher.HashPassword(admin, "aaaaaa1");
            users.Add(admin);

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
            clubOwner.PasswordHash =
                 hasher.HashPassword(clubOwner, "aaaaaa1");
            users.Add(clubOwner);

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
            user.PasswordHash =
                 hasher.HashPassword(user, "aaaaaa1");
            users.Add(user);

            return users;
        }
    }
}
