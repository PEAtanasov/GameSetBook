using System.ComponentModel.DataAnnotations;

using static GameSetBook.Common.ErrorMessageConstants;
using static GameSetBook.Common.ValidationConstatns.BookingConstants;
using static GameSetBook.Common.ValidationConstatns.CourtConstants;

namespace GameSetBook.Core.Models.Booking
{
    public class BookingEditFormModel
    {
        /// <summary>
        /// Booking identitfier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Client's name
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ClientNameMaxLength, MinimumLength = ClientNameMinLength, ErrorMessage = StringLengthMessage)]
        [Display(Name = "Name")]
        public string ClientName { get; set; } = string.Empty;

        /// <summary>
        /// Price of the booking
        /// </summary>
        [Display(Name = "Price")]
        [Range(MinPricePerHour, MaxPricePerHour)]
        public decimal? Price { get; set; }

        /// <summary>
        /// Client's phone number
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ClientPhoneMaxLength, MinimumLength = ClientPhoneMinLength, ErrorMessage = StringLengthMessage)]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Booking's hour
        /// </summary>
        public int Hour { get; set; }

        /// <summary>
        /// Booking's date
        /// </summary>
        public DateTime BookingDate { get; set; }

        /// <summary>
        /// Booking's court identifier
        /// </summary>
        public int CourtId { get; set; }
    }
}
