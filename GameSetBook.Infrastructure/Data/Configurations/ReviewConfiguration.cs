using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .HasOne(c=>c.Club)
                .WithMany(c=>c.Reviews)
                .HasForeignKey(c=>c.ClubId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(c => c.Booking)
                .WithOne(c => c.Review)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(cr => !cr.Club.IsDeleted);

            builder.HasData(ReviewSeed());
        }

        private static IList<Review> ReviewSeed()
        {
            var review1 = new Review()
            {
                Id = 1,
                BookingId = 1,
                ClubId = 1,
                CreatedOn = DateTime.Parse("04-18-2023 10:00"),
                ReviewerId = "f011047b-9d4a-4cb6-8125-56fcd52a572e",
                Title = "Super",
                Description = "The best cluib ever",
                Rate = 10,
            };

            var review2 = new Review()
            {
                Id = 2,
                BookingId = 2,
                ClubId = 1,
                CreatedOn = DateTime.Parse("04-17-2023 10:00"),
                ReviewerId = "f011047b-9d4a-4cb6-8125-56fcd52a572e",
                Title = "Well Done",
                Description = "The best cluib ever",
                Rate = 9,
            };
            var review3 = new Review()
            {
                Id = 3,
                BookingId = 13,
                ClubId = 1,
                CreatedOn = DateTime.Parse("04-18-2023 10:00"),
                ReviewerId = "f011047b-9d4a-4cb6-8125-56fcd52a572e",
                Title = "Super",
                Description = "The best cluib ever",
                Rate = 9,
            };

            var review4 = new Review()
            {
                Id = 4,
                BookingId = 14,
                ClubId = 1,
                CreatedOn = DateTime.Parse("04-17-2023 10:00"),
                ReviewerId = "f011047b-9d4a-4cb6-8125-56fcd52a572e",
                Title = "Well Done",
                Description = "The best cluib ever",
                Rate = 7,
            };

            var review5 = new Review()
            {
                Id = 5,
                BookingId = 9,
                ClubId = 2,
                CreatedOn = DateTime.Parse("04-17-2023 10:00"),
                ReviewerId = "33104877-4d79-4194-b09a-9e75f1790ceb",
                Title = "Ok!,but there is more to ask",
                Description = "It was ok, they can improove, hopefully!",
                Rate = 6,
            };

            var review6 = new Review()
            {
                Id = 6,
                BookingId = 10,
                ClubId = 2,
                CreatedOn = DateTime.Parse("04-18-2023 10:00"),
                ReviewerId = "33104877-4d79-4194-b09a-9e75f1790ceb",
                Title = "meh...!",
                Description = "not good, try to avoid if you can",
                Rate = 3,
            };

            var reviews = new List<Review>()
            {
                review1,review2, review3,review4,review5 , review6
            };

            return reviews;
        }
    }
}
