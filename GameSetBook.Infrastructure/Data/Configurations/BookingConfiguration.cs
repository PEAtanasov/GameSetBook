using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;
using static GameSetBook.Common.ValidationConstatns.DateTimeFormats;
using System.Globalization;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder
                .HasOne(b=>b.Court)
                .WithMany(c=>c.Bookings)
                .HasForeignKey(b=>b.CourtId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(c => !c.IsDeleted);

            builder.HasData(BookingSeed());
        }
        
        private IList<Booking> BookingSeed()
        {
            var datetime = DateTime.Now.ToString("dd-MM-yyy HH:mm");
            var bookings = new List<Booking>()
            {
                new Booking()
                {
                    Id = 1,
                    ClientId = "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                    ClientName = "Petar Atanasov",
                    CourtId = 1,
                    Hour = 17,
                    IsAvailable=false,
                    PhoneNumber = "+359000111",
                    Price= 20.00m,
                    IsDeleted=false,
                    BookedOn= new DateTime(2024, 3, 9, 10 ,0,0),
                    BookingDate =  new DateTime(2024, 3, 14, 17 ,9,0)
                }     
            };

            return bookings;
        }
    }
}
