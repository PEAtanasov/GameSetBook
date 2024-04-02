namespace GameSetBook.Core.Models.Booking
{
    public class BookingInfoServiceViewModel
    {
        public int Id { get; set; }

        public int Hour { get; set; }

        public DateTime Date { get; set; }

        public DateTime BookdedOn { get; set; }

        public decimal Price { get; set; }

        public string ClubName { get; set; } = string.Empty;

        public string CourtName {  get; set; } = string.Empty;

        public int? ReviewId { get; set; } = int.MaxValue;
    }
}
