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

        //private IList<Booking> BookingSeed()
        //{
        //    var datetime = DateTime.Now.ToString("dd-MM-yyy HH:mm");
        //    var bookings = new List<Booking>()
        //    {
        //        new Booking()
        //        {
        //            Id = 1,
        //            ClientId = "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
        //            ClientName = "Encho georgiev",
        //            CourtId = 1,
        //            Hour = 17,
        //            IsAvailable=false,
        //            PhoneNumber = "2222222222",
        //            Price= 20.00m,
        //            IsDeleted=false,
        //            BookedOn= new DateTime(2024, 3, 9, 10 ,0,0),
        //            BookingDate =  new DateTime(2024, 3, 14, 17 ,9,0)
        //        }     
        //    };

        //    return bookings;
        //}

        private static IList<Booking> BookingSeed()
        {

            var booking1 = new Booking()
            {
                Id = 1,
                ClientName = "Petar Petrov",
                CourtId = 1,
                Price = 30,
                Hour = 10,
                BookingDate = DateTime.Parse("04-20-2023 10:00"),
                BookedOn = DateTime.Parse("01-04-2023 10:00"),
                ClientId = "f011047b-9d4a-4cb6-8125-56fcd52a572e",
                IsAvailable = false,
                PhoneNumber = "111111",
                IsBookedByOwnerOrAdmin = false,
            };

            var booking2 = new Booking()
            {
                Id = 2,
                ClientName = "Petar Petrov",
                CourtId = 1,
                Price = 30,
                Hour = 11,
                BookingDate = DateTime.Parse("04-20-2023 10:00"),
                BookedOn = DateTime.Parse("01-04-2023 10:00"),
                ClientId = "f011047b-9d4a-4cb6-8125-56fcd52a572e",
                IsAvailable = false,
                PhoneNumber = "111111",
                IsBookedByOwnerOrAdmin = false,
            };

            var booking3 = new Booking()
            {
                Id = 3,
                ClientName = "Georgi Georgiev",
                CourtId = 2,
                Price = 35,
                Hour = 10,
                BookingDate = DateTime.Parse("04-21-2023 10:00"),
                BookedOn = DateTime.Parse("01-04-2023 10:00"),
                ClientId = "be5f9238-069b-441f-b920-3464ab6ffc21",
                IsAvailable = false,
                PhoneNumber = "222222",
                IsBookedByOwnerOrAdmin = false,
            };

            var booking4 = new Booking()
            {
                Id = 4,
                ClientName = "Georgi Georgiev",
                CourtId = 2,
                Price = 35,
                Hour = 11,
                BookingDate = DateTime.Parse("04-21-2023 10:00"),
                BookedOn = DateTime.Parse("01-04-2023 10:00"),
                ClientId = "be5f9238-069b-441f-b920-3464ab6ffc21",
                IsAvailable = false,
                PhoneNumber = "222222",
                IsBookedByOwnerOrAdmin = false,
            };

            var booking5 = new Booking()
            {
                Id = 5,
                ClientName = "Atanas Atanasov",
                CourtId = 3,
                Price = 35,
                Hour = 10,
                BookingDate = DateTime.Parse("04-20-2023 10:00"),
                BookedOn = DateTime.Parse("01-04-2023 10:00"),
                ClientId = "09ff5c8e-811b-404d-bf52-545f1100b31b",
                IsAvailable = false,
                PhoneNumber = "333333",
                IsBookedByOwnerOrAdmin = false,
            };

            var booking6 = new Booking()
            {
                Id = 6,
                ClientName = "Atanas Atanasov",
                CourtId = 3,
                Price = 35,
                Hour = 11,
                BookingDate = DateTime.Parse("04-21-2023 10:00"),
                BookedOn = DateTime.Parse("01-04-2023 10:00"),
                ClientId = "09ff5c8e-811b-404d-bf52-545f1100b31b",
                IsAvailable = false,
                PhoneNumber = "333333",
                IsBookedByOwnerOrAdmin = false,
            };

            var booking7 = new Booking()
            {
                Id = 7,
                ClientName = "Atanas Atanasov",
                CourtId = 4,
                Price = 45,
                Hour = 10,
                BookingDate = DateTime.Parse("04-20-2023 10:00"),
                BookedOn = DateTime.Parse("01-04-2023 10:00"),
                ClientId = "09ff5c8e-811b-404d-bf52-545f1100b31b",
                IsAvailable = false,
                PhoneNumber = "333333",
                IsBookedByOwnerOrAdmin = false,
            };
            var booking8 = new Booking()
            {
                Id = 8,
                ClientName = "Atanas Atanasov",
                CourtId = 4,
                Price = 45,
                Hour = 11,
                BookingDate = DateTime.Parse("04-21-2023 10:00"),
                BookedOn = DateTime.Parse("01-04-2023 10:00"),
                ClientId = "09ff5c8e-811b-404d-bf52-545f1100b31b",
                IsAvailable = false,
                PhoneNumber = "333333",
                IsBookedByOwnerOrAdmin = false,
            };

            var booking9 = new Booking()
            {
                Id = 9,
                ClientName = "Natalia Atanasova",
                CourtId = 5,
                Price = 30,
                Hour = 10,
                BookingDate = DateTime.Parse("04-20-2023 10:00"),
                BookedOn = DateTime.Parse("01-04-2023 10:00"),
                ClientId = "33104877-4d79-4194-b09a-9e75f1790ceb",
                IsAvailable = false,
                PhoneNumber = "333333",
                IsBookedByOwnerOrAdmin = false,
            };
            var booking10 = new Booking()
            {
                Id = 10,
                ClientName = "Natalia Atanasova",
                CourtId = 5,
                Price = 30,
                Hour = 11,
                BookingDate = DateTime.Parse("04-21-2023 10:00"),
                BookedOn = DateTime.Parse("01-04-2023 10:00"),
                ClientId = "33104877-4d79-4194-b09a-9e75f1790ceb",
                IsAvailable = false,
                PhoneNumber = "333333",
                IsBookedByOwnerOrAdmin = false,
            };

            var deleted1 = new Booking()
            {
                Id = 11,
                ClientName = "Petar Petrov",
                CourtId = 1,
                Price = 30,
                Hour = 10,
                BookingDate = DateTime.Parse("04-21-2023 10:00"),
                BookedOn = DateTime.Parse("01-04-2023 10:00"),
                ClientId = "f011047b-9d4a-4cb6-8125-56fcd52a572e",
                IsAvailable = true,
                PhoneNumber = "111111",
                IsBookedByOwnerOrAdmin = false,
                IsDeleted = true,
                DeletedOn = DateTime.Parse("04-18-2023 10:00"),
            };

            var deleted2 = new Booking()
            {
                Id = 12,
                ClientName = "Petar Petrov",
                CourtId = 1,
                Price = 30,
                Hour = 11,
                BookingDate = DateTime.Parse("04-20-2023 10:00"),
                BookedOn = DateTime.Parse("01-04-2023 10:00"),
                ClientId = "f011047b-9d4a-4cb6-8125-56fcd52a572e",
                IsAvailable = true,
                PhoneNumber = "111111",
                IsBookedByOwnerOrAdmin = false,
                IsDeleted = true,
                DeletedOn = DateTime.Parse("04-18-2023 10:00"),
            };

            var booking13 = new Booking()
            {
                Id = 13,
                ClientName = "Petar Petrov",
                CourtId = 1,
                Price = 30,
                Hour = 13,
                BookingDate = DateTime.Parse("04-20-2023 10:00"),
                BookedOn = DateTime.Parse("01-04-2023 10:00"),
                ClientId = "f011047b-9d4a-4cb6-8125-56fcd52a572e",
                IsAvailable = false,
                PhoneNumber = "111111",
                IsBookedByOwnerOrAdmin = false,
            };

            var booking14 = new Booking()
            {
                Id = 14,
                ClientName = "Petar Petrov",
                CourtId = 1,
                Price = 30,
                Hour = 14,
                BookingDate = DateTime.Parse("04-20-2023 10:00"),
                BookedOn = DateTime.Parse("01-04-2023 10:00"),
                ClientId = "f011047b-9d4a-4cb6-8125-56fcd52a572e",
                IsAvailable = false,
                PhoneNumber = "111111",
                IsBookedByOwnerOrAdmin = false,
            };

            var bookings = new List<Booking>()
            {
                booking1, booking2 , booking3 , booking4 , booking5 , booking6 , booking7 , booking8, booking9 , booking10, deleted1, deleted2, booking13,booking14
            };

            return bookings;
        }
    }
}
