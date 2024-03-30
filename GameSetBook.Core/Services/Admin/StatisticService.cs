using GameSetBook.Common.Enums;
using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Core.Models.Admin.Statistics;
using GameSetBook.Infrastructure.Common;
using GameSetBook.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Core.Services.Admin
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repository;

        public StatisticService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ClubStatisticsViewModel> GetClubsStatistics()
        {
            var clubs = await repository.GetAllWithDeletedReadOnly<Club>().Include(c => c.ClubReviews).ToListAsync();

            var model = new ClubStatisticsViewModel()
            {
                NumberOfClubsRegistered = clubs.Count(),
                NumberOfActiveClubs = clubs.Where(c => c.IsDeleted == false).Count(),
                NumberOfClubsForApproval = clubs.Where(c => c.IsAproovedByAdmin == false).Count(),
                NumberOfNotActiveClubs = clubs.Where(c => c.IsDeleted == true).Count(),
                NumberOfClubsWithLowRating = clubs.Where(c => c.Rating > 0 && c.Rating<6.00).Count(),
            };

            return model;
        }

        public BookingStatisticsViewModel GetBookingStatistics(DateTime date)
        {
            var bookings = repository.GetAllWithDeletedReadOnly<Booking>();

            var model = new BookingStatisticsViewModel()
            {
                NumberOfTotalBookings = bookings.Count(),
                NumberOfCanceledBookings = bookings.Where(b => b.IsDeleted == true).Count(),
                NumberOfBookingsBookedByClubOwners = bookings.Where(b => b.IsBookedByOwnerOrAdmin == true).Count(),
                NumberOfBookinsBookedByUsers = bookings.Where(b => b.IsBookedByOwnerOrAdmin == false).Count(),
                NumberOfBookingsBookedToday = bookings.Where(b => b.BookedOn.Date == date.Date).Count(),
            };

            return model;
        }

        public CourtStatisticsViewModel GetCourtStatistics()
        {
            var courts = repository.GetAllReadOnly<Court>();

            var model = new CourtStatisticsViewModel()
            {
                TotalCourts = courts.Count(),
                TotalNotActiveCourts = courts.Where(c => c.IsActive == false).Count(),
                TotalIndoorCourts = courts.Where(c => c.IsIndoor == true).Count(),
                TotalOutDoorCourts = courts.Where(c => c.IsIndoor == false).Count(),
                TotalLightedCourts = courts.Where(c => c.IsLighted == true).Count(),
                TotalNotLighedCourts = courts.Where(c => c.IsLighted == false).Count(),
                TotalArtificialGrassCourts = courts.Where(c => c.Surface == Surface.ArtificialGrass).Count(),
                TotalHardCourts = courts.Where(c => c.Surface == Surface.Hard).Count(),
                TotalClayCourts = courts.Where(c => c.Surface == Surface.Clay).Count(),
                TotalCarpetCourts = courts.Where(c => c.Surface == Surface.Carpet).Count(),
                TotalGrassCourts = courts.Where(c => c.Surface == Surface.Grass).Count(),
            };

            return model;
        }
    }
}
