using Microsoft.EntityFrameworkCore;

using GameSetBook.Core.Contracts;
using GameSetBook.Core.Models.Court;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using static GameSetBook.Common.ErrorMessageConstants;
using GameSetBook.Common.Enums.EnumExtensions;
using GameSetBook.Core.Models.Booking;

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
            int clubId = model[0].ClubId;

            var club = await repository.GetByIdAsync<Club>(clubId) ?? throw new ArgumentException(ClubDoesNotExist);

            if (await ClubHasCourts(clubId))
            {
                throw new ArgumentException(ClubHasExistingCourts);
            }

            Court court;

            foreach (var c in model)
            {
                court = new Court()
                {
                    Name = c.Name,
                    ClubId = clubId,
                    IsLighted = c.IsLighted,
                    IsIndoor = c.IsIndoor,
                    PricePerHour = c.PricePerHour,
                    Surface = c.Surface,
                };

                club.Courts.Add(court);
            }

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ClubHasCourts(int clubId)
        {
            return await repository.GetAllReadOnly<Court>()
                .Where(c => c.ClubId == clubId)
                .AnyAsync();
        }

        public async Task<CourtEditFormModel> GetCourtEditFormModelAsync(int courtId)
        {
            var court = await repository.GetAllReadOnly<Court>()
                .Include(c => c.Club)
                .FirstOrDefaultAsync(c => c.Id == courtId)
                ?? throw new ArgumentException("The court does not exist");

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

        public async Task Edit(CourtEditFormModel model)
        {
            var courtToEdit = await repository.GetAll<Court>()
                .Where(c => c.Id == model.Id)
                .Include(c => c.Club)
                .FirstOrDefaultAsync();

            if (courtToEdit == null)
            {
                throw new ArgumentException("The court does not exist");
            }

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
           // DateTime currentDate = date ?? DateTime.Now;

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
                        CourtId = b.CourtId,
                        Hour = b.Hour,
                        IsAvailable = b.IsAvailable,
                        BookingDate = b.BookingDate
                    }).ToList(),
                })
                .ToListAsync();

            for (int i = 0; i < courts.Count; i++)
            {
                List<BookingScheduleViewModel> bookings = GetAvailableBookings(workingTimeStart, workingTimeEnd, currentDate, courts[i].Id);
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

        public async Task<bool> CourtExist(int id)
        {
            return await repository.GetAllReadOnly<Court>().AnyAsync(c => c.Id == id);
        }

        public async Task<decimal> GetPrice(int id)
        {
            var court = await repository.GetAllReadOnly<Court>().FirstAsync(c => c.Id == id);

            return court.PricePerHour;
        }

        private List<BookingScheduleViewModel> GetAvailableBookings(int start, int end, DateTime date, int courtId)
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
