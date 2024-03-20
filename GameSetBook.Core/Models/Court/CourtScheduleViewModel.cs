using GameSetBook.Core.Models.Booking;

namespace GameSetBook.Core.Models.Court
{
    public class CourtScheduleViewModel
    {
        public CourtScheduleViewModel()
        {
            Bookings = new List<BookingScheduleViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surface {  get; set; } = string.Empty;
        public bool IsLighted { get; set; }
        public bool IsIndoor { get; set; }
        public decimal Price { get; set; }
        public int ClubId { get; set; }
        public IEnumerable<BookingScheduleViewModel> Bookings { get; set; }
    }
}