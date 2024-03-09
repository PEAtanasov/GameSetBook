using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasQueryFilter(c => !c.IsDeleted);
            builder.HasData(BookingSeed());
        }
        
        private IList<Booking> BookingSeed()
        {
            var bookings = new List<Booking>()
            {
                new Booking()
                {
                    Id = 1,
                    ClientId = "0a7178d0-e1d9-4249-8d4e-a393fe17c813",
                    ClientName = "Petar Atanasov",
                    CourtId = 1,
                    Hour = 17,
                    IsAvailable=false,
                    PhoneNumber = "+359000111",
                    Price= 20.00m,
                    IsDeleted=false,
                    BookedOn= DateTime.Parse("09-03-2024 13:09"),
                    BookingDate = DateTime.Parse("14-03-2024 13:09")                  
                }
            };

            return bookings;
        }
    }
}
