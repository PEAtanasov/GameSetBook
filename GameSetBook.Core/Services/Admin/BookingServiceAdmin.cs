using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Enums;
using GameSetBook.Core.Models.Admin.Booking;
using GameSetBook.Core.Models.Booking;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GameSetBook.Core.Services.Admin
{
    public class BookingServiceAdmin : IBookingServiceAdmin
    {
        private readonly IRepository repository;

        public BookingServiceAdmin(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<BookingAdminServiceViewModel>> GetAllBookingsAsync()
        {
            var bookings = await repository.GetAllWithDeletedReadOnly<Booking>()
                .Select(b => new BookingAdminServiceViewModel()
                {
                    Id = b.Id,
                    ClientEmail = b.Client.Email,
                    ClientName = b.ClientName,
                    ClubName = b.Court.Club.Name,
                    BookedOn = b.BookedOn,
                    BookingDate = b.BookingDate,
                    CourtName = b.Court.Name,
                    IsDeleted = b.IsDeleted,
                    DeletedOn = b.DeletedOn,
                    Hour = b.Hour,
                    IsBookedByOwnerOrAdmin = b.IsBookedByOwnerOrAdmin,
                    PhoneNumber = b.PhoneNumber,
                    Price = b.Price,
                    ReviewId = b.Review != null ? b.Review.Id : null
                })
                .ToListAsync();

            return bookings;
        }

        public async Task<AllBookingsAdminSortingModel> GetBookingSortingServiceModelAsync(AllBookingsAdminSortingModel queryModel)
        {
            var bookingToSort = repository.GetAllWithDeletedReadOnly<Booking>();

            if (queryModel.ClubId!=null)
            {
                bookingToSort = bookingToSort.Where(b => b.Court.ClubId == queryModel.ClubId);
            }
               
            if (!string.IsNullOrEmpty(queryModel.SearchTerm))
            {
                bookingToSort = bookingToSort.Where(c => c.Court.Club.Name.ToLower().Contains(queryModel.SearchTerm.ToLower())
                                                        || c.ClientName.ToLower().Contains(queryModel.SearchTerm.ToLower())
                                                        || c.PhoneNumber.ToLower().Contains(queryModel.SearchTerm.ToLower())
                                                        || c.Client.NormalizedEmail.Contains(queryModel.SearchTerm.ToUpper()));
            }

            if (queryModel.BookingDateFrom != null)
            {
                bookingToSort = bookingToSort.Where(b => b.BookingDate.Date >= queryModel.BookingDateFrom.Value.Date);
            }

            if (queryModel.BookingDateTo != null)
            {
                bookingToSort = bookingToSort.Where(b => b.BookingDate.Date <= queryModel.BookingDateTo.Value.Date);
            }

            if (queryModel.BookedOnDateFrom != null)
            {
                bookingToSort = bookingToSort.Where(b => b.BookedOn.Date >= queryModel.BookedOnDateFrom.Value.Date);
            }

            if (queryModel.BookedOnDateTo != null)
            {
                bookingToSort = bookingToSort.Where(b => b.BookedOn.Date <= queryModel.BookedOnDateTo.Value.Date);
            }

            bookingToSort = queryModel.StatusSorting switch
            {
                //BookingStatusSorting.All => bookingToSort.OrderByDescending(c => c.Id),
                BookingStatusSorting.Active => bookingToSort.Where(b=>b.IsDeleted==false),
                BookingStatusSorting.Canceled => bookingToSort.Where(b => b.IsDeleted == true),
                _ => bookingToSort.OrderBy(b => b.ClientName).ThenByDescending(b => b.Id),
            };

            bookingToSort = queryModel.BookingSorting switch
            {
                BookingSorting.None => bookingToSort.OrderByDescending(b => b.BookedOn).ThenByDescending(b => b.ClientId),
                BookingSorting.PriceAscending => bookingToSort.OrderBy(b => b.Price).ThenByDescending(b => b.ClientId),
                BookingSorting.PriceDescending => bookingToSort.OrderByDescending(b => b.Price).ThenByDescending(b => b.ClientId),
                BookingSorting.BookingDateAscending => bookingToSort.OrderBy(c => c.BookingDate).ThenByDescending(b => b.ClientId),
                BookingSorting.BookingDateDescending => bookingToSort.OrderByDescending(c => c.BookingDate).ThenByDescending(b => b.ClientId),
                BookingSorting.HourAscending => bookingToSort.OrderBy(b => b.Hour).ThenByDescending(b => b.ClientId),
                BookingSorting.HourDescending => bookingToSort.OrderByDescending(b => b.Hour).ThenByDescending(b => b.ClientId),
                BookingSorting.BookedOnAscending => bookingToSort.OrderBy(b=>b.BookedOn).ThenByDescending(b => b.ClientId),
                BookingSorting.BookedOnDescending => bookingToSort.OrderByDescending(b => b.BookedOn).ThenByDescending(b => b.ClientId),
                _ => bookingToSort.OrderBy(b=>b.ClientName).ThenByDescending(b => b.Id),
            };

            int totalBookings = await bookingToSort.CountAsync();
            var maxPage = Math.Ceiling((double)totalBookings / queryModel.BookingsPerPage);

            int currentPage = queryModel.CurrentPage;

            if (currentPage > maxPage)
            {
                currentPage = (int)maxPage;
            }
            if (currentPage <= 0)
            {
                currentPage = 1;
            }

            var bookings = await bookingToSort
                .Skip((currentPage - 1) * queryModel.BookingsPerPage)
                .Take(queryModel.BookingsPerPage)
                .Select(b => new BookingAdminServiceViewModel()
                {
                    Id = b.Id,
                    ClientEmail = b.Client.Email,
                    ClientName = b.ClientName,
                    ClubName = b.Court.Club.Name,
                    BookedOn = b.BookedOn,
                    BookingDate = b.BookingDate,
                    CourtName = b.Court.Name,
                    IsDeleted = b.IsDeleted,
                    DeletedOn = b.DeletedOn,
                    Hour = b.Hour,
                    IsBookedByOwnerOrAdmin = b.IsBookedByOwnerOrAdmin,
                    PhoneNumber = b.PhoneNumber,
                    Price = b.Price,
                    ReviewId = b.Review != null ? b.Review.Id : null
                })
                .ToListAsync();

            queryModel.Bookings = bookings;
            queryModel.TotalBookingsCount = totalBookings;

            return queryModel;
        }

    }
}
