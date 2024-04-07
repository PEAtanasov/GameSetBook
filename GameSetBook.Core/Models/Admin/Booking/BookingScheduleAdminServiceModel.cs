namespace GameSetBook.Core.Models.Admin.Booking
{
    public class BookingScheduleAdminServiceModel
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int Hour { get; set; }
        public int CourtId { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
