﻿using Microsoft.EntityFrameworkCore;

using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Booking;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using GameSetBook.Core.Enums;
using GameSetBook.Core.Models.Club;

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
            if (date.Date < DateTime.Now.Date || (date.Date == DateTime.Now.Date && hour <= date.Hour))
            {
                return false;
            }

            var club = await repository.GetAllReadOnly<Court>()
                .Where(b => b.Id == courtId)
                .Select(b => b.Club).FirstAsync();

            if (hour < club.WorkingTimeStart || hour >= club.WorkingTimeEnd)
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
                IsBookedByOwnerOrAdmin = model.IsBookedByOwnerOrAdmin,
            };

            var club = await repository.GetAllReadOnly<Club>().FirstAsync(c => c.Courts.Any(ct => ct.Id == model.CourtId));

            await repository.AddAsync(booking);
            await repository.SaveChangesAsync();

            return club.Id;
        }

        public async Task<BookingEditFormModel> GetBookingToEditAsync(int id)
        {
            return await repository.GetAllReadOnly<Booking>()
                .Where(b => b.Id == id)
                .Select(b => new BookingEditFormModel()
                {
                    Id = b.Id,
                    ClientName = b.ClientName,
                    PhoneNumber = b.PhoneNumber,
                    Price = b.Price,
                    BookingDate = b.BookingDate,
                    Hour = b.Hour,
                    CourtId = b.CourtId,
                })
                .FirstAsync();
        }

        public async Task EditAsync(BookingEditFormModel model)
        {
            var booking = await repository.GetAll<Booking>()
                .FirstAsync(b => b.Id == model.Id);

            booking.ClientName = model.ClientName;
            booking.PhoneNumber = model.PhoneNumber;

            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var booking = await repository.GetAll<Booking>()
                .FirstAsync(b => b.Id == id);

            booking.IsDeleted = true;
            booking.DeletedOn = DateTime.Now;

            await repository.SaveChangesAsync();
        }

        public async Task<bool> BookingExistAsync(DateTime date, int hour, int courtId)
        {
            return await repository.GetAllReadOnly<Booking>()
               .Where(b => b.CourtId == courtId)
               .AnyAsync(b => b.BookingDate.Date == date.Date && b.Hour == hour && b.IsAvailable == false);
        }

        public async Task<bool> BookingExistById(int id)
        {
            return await repository.GetAllReadOnly<Booking>()
               .AnyAsync(b => b.Id == id);
        }

        public async Task<bool> IsOwnerAllowedToEdit(int id, string ownerId)
        {
            return await repository.GetAllReadOnly<Booking>()
                .Where(c => c.Court.Club.ClubOwnerId == ownerId)
                .AnyAsync(b => b.Id == id);
        }

        public async Task<AllBookingsSortingModel> GetBookingSortingServiceModelAsync(AllBookingsSortingModel queryModel, string userId)
        {
            var bookingToSort = repository.GetAllReadOnly<Booking>()
                .Where(b => b.ClientId == userId && b.IsBookedByOwnerOrAdmin == false);

            if (!string.IsNullOrEmpty(queryModel.SearchTerm))
            {
                bookingToSort = bookingToSort.Where(c => c.Court.Club.Name.ToLower().Contains(queryModel.SearchTerm.ToLower())
                                                        || c.Court.Name.ToLower().Contains(queryModel.SearchTerm.ToLower()));
            }

            if (queryModel.BookingDateFrom != null)
            {
                bookingToSort = bookingToSort.Where(b => b.BookingDate.Date >= queryModel.BookingDateFrom.Value.Date);
            }

            if (queryModel.BookingDateTo != null)
            {
                bookingToSort = bookingToSort.Where(b => b.BookingDate.Date <= queryModel.BookingDateTo.Value.Date);
            }

            bookingToSort = queryModel.BookingSorting switch
            {
                BookingSorting.None => bookingToSort.OrderByDescending(b => b.BookedOn).ThenByDescending(b => b.Id),
                BookingSorting.PriceAscending => bookingToSort.OrderBy(b => b.Price).ThenBy(b=>b.Id),
                BookingSorting.PriceDescending => bookingToSort.OrderByDescending(b => b.Price).ThenByDescending(b => b.Id),
                BookingSorting.BookingDateAscending => bookingToSort.OrderBy(c => c.BookingDate).ThenBy(b => b.Id),
                BookingSorting.BookingDateDescending => bookingToSort.OrderByDescending(c => c.BookingDate).ThenByDescending(b => b.Id),
                BookingSorting.HourAscending => bookingToSort.OrderBy(b => b.Hour).ThenBy(b => b.Id),
                BookingSorting.HourDescending => bookingToSort.OrderByDescending(b => b.Hour).ThenByDescending(b => b.Id),
                _ => bookingToSort.OrderByDescending(c => c.Id)
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
                .Select(c => new BookingInfoServiceViewModel()
                {
                    Id = c.Id,
                    ClubName = c.Court.Club.Name,
                    CourtName = c.Court.Name,
                    Date = c.BookingDate,
                    Hour = c.Hour,
                    Price = c.Price,
                    BookdedOn = c.BookedOn
                })
                .ToListAsync();

            queryModel.Bookings = bookings;
            queryModel.TotalBookingCount = totalBookings;

            return queryModel;

        }
    }
}
