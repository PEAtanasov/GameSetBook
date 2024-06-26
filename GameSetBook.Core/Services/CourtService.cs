﻿using GameSetBook.Common.Enums.EnumExtensions;
using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Booking;
using GameSetBook.Core.Models.Court;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;

using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Core.Services
{
    public class CourtService : ICourtService
    {
        public readonly IRepository repository;

        public CourtService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateInitialAsync(CourtCreateFormModel[] model)
        {
            var courts = new List<Court>();

            foreach (var c in model)
            {
                Court court = new Court()
                {
                    Name = c.Name,
                    ClubId = c.ClubId,
                    IsLighted = c.IsLighted,
                    IsIndoor = c.IsIndoor,
                    PricePerHour = c.PricePerHour,
                    Surface = c.Surface,
                };

                courts.Add(court);
            }

            await repository.AddRangeAsync(courts);

            await repository.SaveChangesAsync();
        }

        public async Task AddCourtAsync(CourtCreateFormModel model)
        {
            var court = new Court()
            {
                Name = model.Name,
                ClubId = model.ClubId,
                IsLighted = model.IsLighted,
                IsIndoor = model.IsIndoor,
                PricePerHour = model.PricePerHour,
                Surface = model.Surface,
                IsActive = true
            };

            var club = await repository
                .GetAll<Club>()
                .FirstAsync(c=>c.Id==model.ClubId);

            club.NumberOfCourts += 1;

            await repository.AddAsync(court);

            await repository.SaveChangesAsync();
        }

        public async Task<CourtEditFormModel> GetCourtEditFormModelAsync(int courtId)
        {
            var court = await repository.GetAllReadOnly<Court>()
                .Include(c => c.Club)
                .FirstAsync(c => c.Id == courtId);

            var model = new CourtEditFormModel()
            {
                Id = court.Id,
                Name = court.Name,
                ClubId = court.ClubId,
                IsIndoor = court.IsIndoor,
                IsLighted = court.IsLighted,
                PricePerHour = court.PricePerHour,
                Surface = court.Surface,
                IsActive = court.IsActive,
                ClubOwnerId = court.Club.ClubOwnerId
            };

            return model;
        }

        public async Task<IEnumerable<CourtDetailsViewModel>> GetAllCourtsDetailsAsync(int clubId)
        {
            return await repository.GetAllReadOnly<Court>()
                .Where(c => c.ClubId == clubId)
                .Select(c => new CourtDetailsViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsActive = c.IsActive,
                    IsIndoor = c.IsIndoor,
                    IsLighted = c.IsLighted,
                    Price = c.PricePerHour,
                    Surface = c.Surface.GetDisplayName()
                })
                .ToListAsync();
        }

        public async Task EditAsync(CourtEditFormModel model)
        {
            var courtToEdit = await repository.GetAll<Court>()
                .Where(c => c.Id == model.Id)
                .Include(c => c.Club)
                .FirstAsync();

            courtToEdit.Name = model.Name;
            courtToEdit.PricePerHour = model.PricePerHour;
            courtToEdit.Surface = model.Surface;
            courtToEdit.IsLighted = model.IsLighted;
            courtToEdit.IsIndoor = model.IsIndoor;
            courtToEdit.IsActive = model.IsActive;

            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CourtScheduleViewModel>> GetAllCourtsScheduleAsync(int clubId, DateTime currentDate)
        {
            var club = await repository.GetAllReadOnly<Club>().FirstAsync(c => c.Id == clubId);

            int workingTimeStart = club.WorkingTimeStart;
            int workingTimeEnd = club.WorkingTimeEnd;

            var courts = await repository.GetAllReadOnly<Court>()
                .Where(c => c.ClubId == clubId && c.IsActive == true)
                .Select(c => new CourtScheduleViewModel()
                {
                    Id = c.Id,
                    ClubId = c.ClubId,
                    IsIndoor = c.IsIndoor,
                    IsLighted = c.IsLighted,
                    Name = c.Name,
                    Price = c.PricePerHour,
                    Surface = c.Surface.GetDisplayName(),
                    Bookings = c.Bookings.Where(b => b.BookingDate.Date == currentDate.Date).Select(b => new BookingScheduleViewModel()
                    {
                        Id = b.Id,
                        CourtId = b.CourtId,
                        Hour = b.Hour,
                        IsAvailable = b.IsAvailable,
                        BookingDate = b.BookingDate
                    }).ToList(),
                })
                .ToListAsync();

            for (int i = 0; i < courts.Count; i++)
            {
                List<BookingScheduleViewModel> bookings = GetAvailableBookingSlots(workingTimeStart, workingTimeEnd, currentDate, courts[i].Id);
                foreach (var booking in courts[i].Bookings)
                {
                    for (int n = 0; n < bookings.Count; n++)
                    {
                        if (bookings[n].Hour == booking.Hour)
                        {
                            bookings[n] = booking;
                        }
                    }
                }
                courts[i].Bookings = bookings;
            }

            return courts;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.GetAllReadOnly<Court>().AnyAsync(c => c.Id == id);
        }

        public async Task<decimal> GetPriceAsync(int id)
        {
            var court = await repository.GetAllReadOnly<Court>().FirstAsync(c => c.Id == id);

            return court.PricePerHour;
        }

        public async Task<bool> IsCourtInClubOfTheOwnerAsync(int courtId, string UserId)
        {
            return await repository.GetAllReadOnly<Court>()
                .Where(c => c.Club.ClubOwnerId == UserId)
                .AnyAsync(c => c.Id == courtId);
        }

        public async Task ChangeStatusAsync(int id)
        {
            var court = await repository.GetAll<Court>().FirstAsync(c=>c.Id==id);

            var currentStatus = court.IsActive;

            if (currentStatus == true)
            {
                court.IsActive = false;
            }
            else
            {
                court.IsActive = true;
            }

            await repository.SaveChangesAsync();
        }

        private List<BookingScheduleViewModel> GetAvailableBookingSlots(int start, int end, DateTime date, int courtId)
        {
            List<BookingScheduleViewModel> bookings = new List<BookingScheduleViewModel>();

            BookingScheduleViewModel booking;

            for (int i = start; i < end; i++)
            {
                booking = new BookingScheduleViewModel()
                {
                    Hour = i,
                    BookingDate = date,
                    CourtId = courtId,
                };
                bookings.Add(booking);
            }

            return bookings;
        }
    }
}
