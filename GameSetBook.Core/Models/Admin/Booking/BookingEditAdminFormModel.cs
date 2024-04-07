using System.ComponentModel.DataAnnotations;
using static GameSetBook.Common.ErrorMessageConstants;
using static GameSetBook.Common.ValidationConstatns.BookingConstants;

namespace GameSetBook.Core.Models.Admin.Booking
{
    public class BookingEditAdminFormModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Hour { get; set; }


        public int ClubId { get; set; }

        public DateTime BookingDate { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ClientNameMaxLength, MinimumLength = ClientNameMinLength, ErrorMessage = StringLengthMessage)]
        [Display(Name = "Name")]
        public string ClientName { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Client's phone number
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ClientPhoneMaxLength, MinimumLength = ClientPhoneMinLength, ErrorMessage = StringLengthMessage)]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        public string IsDeleted { get; set; } = string.Empty;
    }
}
