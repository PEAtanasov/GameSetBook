using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Enums;
using GameSetBook.Core.Models.Admin.Booking;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

using static GameSetBook.Common.ValidationConstatns.DateTimeFormats;

namespace GameSetBook.Core.Services.Admin
{
    public class BookingServiceAdmin : IBookingServiceAdmin
    {
        private readonly IRepository repository;

        public BookingServiceAdmin(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AllBookingsAdminSortingModel> GetBookingSortingServiceModelAsync(AllBookingsAdminSortingModel queryModel)
        {
            var bookingToSort = repository.GetAllWithDeletedReadOnly<Booking>();

            if (queryModel.ClubId != null)
            {
                bookingToSort = bookingToSort.Where(b => b.Court.ClubId == queryModel.ClubId);
            }

            if (queryModel.ClubId == null)
            {
                if (!string.IsNullOrWhiteSpace(queryModel.SearchTerm))
                {
                    bookingToSort = bookingToSort.Where(c => c.Court.Club.Name.ToLower().Contains(queryModel.SearchTerm.ToLower())
                                                            || c.ClientName.ToLower().Contains(queryModel.SearchTerm.ToLower())
                                                            || c.PhoneNumber.ToLower().Contains(queryModel.SearchTerm.ToLower())
                                                            || c.Client.NormalizedEmail.Contains(queryModel.SearchTerm.ToUpper()));
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(queryModel.SearchTerm))
                {
                    bookingToSort = bookingToSort.Where(c => c.ClientName.ToLower().Contains(queryModel.SearchTerm.ToLower())
                                                            || c.PhoneNumber.ToLower().Contains(queryModel.SearchTerm.ToLower())
                                                            || c.Client.NormalizedEmail.Contains(queryModel.SearchTerm.ToUpper()));
                }
            }



            if (queryModel.BookingDateFrom != null)
            {
                DateTime bookingDateFrom = DateTime.ParseExact(queryModel.BookingDateFrom, DateOnlyFormat, CultureInfo.InvariantCulture);
                bookingToSort = bookingToSort.Where(b => b.BookingDate.Date >= bookingDateFrom);
                queryModel.BookingDateFrom = bookingDateFrom.ToString(DateOnlyFormat, CultureInfo.InvariantCulture);
            }

            if (queryModel.BookingDateTo != null)
            {
                DateTime bookingDateTo = DateTime.ParseExact(queryModel.BookingDateTo, DateOnlyFormat, CultureInfo.InvariantCulture);
                bookingToSort = bookingToSort.Where(b => b.BookingDate.Date <= bookingDateTo);
                queryModel.BookingDateTo = bookingDateTo.ToString(DateOnlyFormat, CultureInfo.InvariantCulture);

            }

            if (queryModel.BookedOnDateFrom != null)
            {
                DateTime bookedOnDateFrom = DateTime.ParseExact(queryModel.BookedOnDateFrom, DateOnlyFormat, CultureInfo.InvariantCulture);
                bookingToSort = bookingToSort.Where(b => b.BookedOn.Date >= bookedOnDateFrom);
                queryModel.BookedOnDateFrom = bookedOnDateFrom.ToString(DateOnlyFormat, CultureInfo.InvariantCulture);
            }

            if (queryModel.BookedOnDateTo != null)
            {
                DateTime bookedOnDateTo = DateTime.ParseExact(queryModel.BookedOnDateTo, DateOnlyFormat, CultureInfo.InvariantCulture);
                bookingToSort = bookingToSort.Where(b => b.BookedOn.Date <= bookedOnDateTo);
                queryModel.BookedOnDateTo = bookedOnDateTo.ToString(DateOnlyFormat, CultureInfo.InvariantCulture);
            }

            bookingToSort = queryModel.StatusSorting switch
            {
                BookingStatusSorting.Active => bookingToSort.Where(b => b.IsDeleted == false),
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
                BookingSorting.BookedOnAscending => bookingToSort.OrderBy(b => b.BookedOn).ThenByDescending(b => b.ClientId),
                BookingSorting.BookedOnDescending => bookingToSort.OrderByDescending(b => b.BookedOn).ThenByDescending(b => b.ClientId),
                _ => bookingToSort.OrderBy(b => b.ClientName).ThenByDescending(b => b.Id),
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

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.GetAllWithDeletedReadOnly<Booking>()
                .AnyAsync(b => b.Id == id);
        }

        //TODO Implement HardDelete booking method.

        public async Task CancelAsync(int id)
        {
            var booking = await repository.GetAllWithDeleted<Booking>()
                .Where(b => b.Id == id)
                .FirstAsync();

            repository.Delete(booking);

            await repository.SaveChangesAsync();
        }

        public async Task<bool> BookingSpotAlreadyBookedAsync(DateTime date, int hour, int courtId)
        {
            return await repository.GetAllReadOnly<Booking>()
               .Where(b => b.CourtId == courtId)
               .AnyAsync(b => b.BookingDate.Date == date.Date && b.Hour == hour && b.IsAvailable == false);
        }

        public async Task CreateAsync(BookingCreateAdminFormModel model)
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
                IsBookedByOwnerOrAdmin = model.IsBookedByOwnerOrAdmin,
            };

            await repository.AddAsync(booking);
            await repository.SaveChangesAsync();
        }

        public async Task<BookingEditAdminFormModel> GetEditModelAsync(int id)
        {
            var model = await repository.GetAllWithDeletedReadOnly<Booking>()
                .Where(b => b.Id == id)
                .Select(b => new BookingEditAdminFormModel()
                {
                    Id = b.Id,
                    BookingDate = b.BookingDate,
                    ClientName = b.ClientName,
                    ClubId = b.Court.Club.Id,
                    Hour = b.Hour,
                    PhoneNumber = b.PhoneNumber,
                    Price = b.Price,
                    IsDeleted = b.IsDeleted ? "Yes" : "No"
                })
                .FirstAsync();

            return model;
        }

        public async Task EditAsync(BookingEditAdminFormModel model)
        {
            var booking = await repository.GetAllWithDeleted<Booking>()
                .Where(b => b.Id == model.Id)
                .FirstAsync();

            booking.PhoneNumber = model.PhoneNumber;
            booking.ClientName = model.ClientName;

            await repository.SaveChangesAsync();
        }
    }
}
