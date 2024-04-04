namespace GameSetBook.Core.Models.Admin.Booking
{
    public class BookingAdminServiceViewModel
    {
        public int Id { get; set; }

        public string ClientName { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Hour { get; set; }

        public DateTime BookingDate { get; set; } 

        public DateTime BookedOn { get; set; } 

        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsBookedByOwnerOrAdmin { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string ClientEmail { get; set; } = string.Empty;

        public string ClubName { get; set; } = string.Empty;

        public string CourtName {  get; set; } = string.Empty;

        public int? ReviewId { get; set; }
    }
}
