using GameSetBook.Core.Models.Admin.Booking;
using GameSetBook.Core.Models.Booking;

namespace GameSetBook.Core.Models.Admin.Court
{
    public class CourtScheduleAdminViewModel
    {
        public CourtScheduleAdminViewModel()
        {
            Bookings = new List<BookingScheduleAdminServiceModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surface { get; set; } = string.Empty;
        public bool IsLighted { get; set; }
        public bool IsIndoor { get; set; }
        public decimal Price { get; set; }
        public int ClubId { get; set; }
        public IEnumerable<BookingScheduleAdminServiceModel> Bookings { get; set; }
    }
}
