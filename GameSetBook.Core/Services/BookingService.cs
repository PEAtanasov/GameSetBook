using Microsoft.EntityFrameworkCore;

using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Booking;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Core.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository repository;

        public BookingService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> AreDateAndHourValidAsync(DateTime date, int hour, int courtId)
        {
            var bookingAlreadyExist = await repository.GetAllReadOnly<Booking>()
                .Where(b => b.CourtId == courtId)
                .AnyAsync(b => b.BookingDate.Date == date.Date && b.Hour == hour);

            var club = await repository.GetAllReadOnly<Booking>()
                .Where(b => b.CourtId == courtId)
                .Select(b => b.Court.Club).FirstAsync();

            if (hour < club.WorkingTimeStart || hour >= club.WorkingTimeEnd)
            {
                return false;
            }

            if (bookingAlreadyExist)
            {
                return false;
            }

            if (date.Date < DateTime.Now.Date || (date.Date == DateTime.Now.Date && hour <= date.Hour))
            {
                return false;
            }

            return true;
        }

        public async Task<int> AddBookingAsync(BookingCreateFormModel model)
        {
            var booking = new Booking()
            {

                CourtId = model.CourtId,
                BookingDate = model.BookingDate,
                BookedOn = DateTime.Now,
                ClientId = model.ClientId,
                ClientName = model.ClientName,
                Hour = model.Hour,
                IsAvailable = false,
                PhoneNumber = model.PhoneNumber,
                Price = model.Price,
            };

            var club = await repository.GetAllReadOnly<Club>().FirstAsync(c => c.Courts.Any(ct => ct.Id == model.CourtId));

            await repository.AddAsync(booking);
            await repository.SaveChangesAsync();

            return club.Id;
        }

        //public async GetAllBookings(string id)

    }
}
