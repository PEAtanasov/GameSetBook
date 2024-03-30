using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Infrastructure.Common;

namespace GameSetBook.Core.Services.Admin
{
    public class BookingServiceAdmin : IBookingServiceAdmin
    {
        private readonly IRepository repository;

        public BookingServiceAdmin(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
