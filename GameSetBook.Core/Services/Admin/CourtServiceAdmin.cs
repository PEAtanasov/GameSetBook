using GameSetBook.Common.Enums.EnumExtensions;
using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Booking;
using GameSetBook.Core.Models.Admin.Court;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Core.Services.Admin
{
    public class CourtServiceAdmin : ICourtServiceAdmin
    {
        private readonly IRepository repository;

        public CourtServiceAdmin(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CourtAdminEditFormModel> GetEditModelAsync(int id)
        {
            var court = await repository.GetAllReadOnly<Court>()
                .Where(c => c.Id == id)
                .Select(c => new CourtAdminEditFormModel()
                {
                    Id = c.Id,
                    ClubId = c.ClubId,
                    ClubName = c.Club.Name,
                    Name = c.Name,
                    IsActive = c.IsActive,
                    IsIndoor = c.IsIndoor,
                    IsLighted = c.IsLighted,
                    PricePerHour = c.PricePerHour,
                    Surface = c.Surface
                })
                .FirstAsync();

            return court;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.GetAllReadOnly<Court>()
                .AnyAsync(c => c.Id == id);
        }

        public async Task EditAsync(CourtAdminEditFormModel model)
        {
            var court = await repository.GetAll<Court>()
                .FirstAsync(c => c.Id == model.Id);

            court.Name = model.Name;
            court.PricePerHour = model.PricePerHour;
            court.Surface = model.Surface;
            court.IsLighted = model.IsLighted;
            court.IsIndoor = model.IsIndoor;
            court.IsActive = model.IsActive;

            await repository.SaveChangesAsync();
        }

        public async Task AddAsync(CourtAdminCreateFormModel model)
        {
            var court = new Court()
            {
                Name = model.Name,
                PricePerHour = model.PricePerHour,
                Surface = model.Surface,
                IsLighted = model.IsLighted,
                ClubId = model.ClubId,
                IsIndoor = model.IsIndoor,
            };

            var club = await repository
               .GetAllWithDeleted<Club>()
               .FirstAsync(c => c.Id == model.ClubId);

            if (club.IsAproovedByAdmin==true && club.IsDeleted==false)
            {
                court.IsActive = true;
            }

            club.NumberOfCourts += 1;

            await repository.AddAsync(court);

            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var court=await repository.GetAll<Court>()
                .Where(c=>c.Id==id)
                .Include(c=>c.Club)
                .Include(c=>c.Bookings)
                .IgnoreQueryFilters()
                .FirstAsync();

            var review = await repository.GetAll<Review>()
                .Where(r=>r.Booking.CourtId==id)
                .ToListAsync();

            repository.RemoveRange(review);
            repository.RemoveRange(court.Bookings);
            repository.HardDelete(court);
            court.Club.NumberOfCourts -= 1;

            await repository.SaveChangesAsync();
        }

        public async Task<CourtAdminViewModel> GetViewModelForDeleteAsync(int id)
        {
            var court = await repository.GetAllReadOnly<Court>()
                .Where(c => c.Id == id)
                .Select(c => new CourtAdminViewModel()
                {
                    Id = c.Id,
                    ClubId = c.ClubId,
                    IsActive = c.IsActive,
                    IsIndoor = c.IsIndoor,
                    IsLighted = c.IsLighted,
                    Name = c.Name,
                    PricePerHour = c.PricePerHour,
                    Surface = c.Surface.GetDisplayName()
                })
                .FirstAsync();

            return court;
        }

        public async Task CreateInitialAsync(CourtAdminCreateFormModel[] model)
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

        public async Task<IEnumerable<CourtScheduleAdminViewModel>> GetCourtsScheduleAsync (int clubId, DateTime date, int workingHourStart, int workingHourEnd)
        {
            var courts = await repository.GetAllReadOnly<Court>()
                .Where(c => c.ClubId == clubId && c.IsActive == true)
                .Select(c => new CourtScheduleAdminViewModel()
                {
                    Id = c.Id,
                    ClubId = c.ClubId,
                    IsIndoor = c.IsIndoor,
                    IsLighted = c.IsLighted,
                    Name = c.Name,
                    Price = c.PricePerHour,
                    Surface = c.Surface.GetDisplayName(),
                    Bookings = c.Bookings.Where(b => b.BookingDate.Date == date.Date).Select(b => new BookingScheduleAdminServiceModel()
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
                List<BookingScheduleAdminServiceModel> bookings = GetAvailableBookings(workingHourStart, workingHourEnd, date, courts[i].Id);
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

        private List<BookingScheduleAdminServiceModel> GetAvailableBookings(int start, int end, DateTime date, int courtId)
        {
            List<BookingScheduleAdminServiceModel> bookings = new List<BookingScheduleAdminServiceModel>();

            BookingScheduleAdminServiceModel booking;

            for (int i = start; i < end; i++)
            {
                booking = new BookingScheduleAdminServiceModel()
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
