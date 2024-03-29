﻿using System.ComponentModel.DataAnnotations;

using static GameSetBook.Common.ErrorMessageConstants;
using static GameSetBook.Common.ValidationConstatns.BookingConstants;

namespace GameSetBook.Core.Models.Booking
{
    public class BookingCreateFormModel
    {
        public int Hour { get; set; }
        public int CourtId { get; set; }
        public DateTime BookingDate { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ClientNameMaxLength, MinimumLength = ClientNameMinLength, ErrorMessage = StringLengthMessage)]
        [Display(Name = "Name")]
        public string ClientName { get; set; } = string.Empty;

        public decimal Price {  get; set; }

        /// <summary>
        /// Client's phone number
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ClientPhoneMaxLength, MinimumLength = ClientPhoneMinLength, ErrorMessage = StringLengthMessage)]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Client identifier
        /// </summary>
        public string ClientId { get; set; } = string.Empty;

        public bool IsBookedByOwnerOrAdmin { get; set; }
    }
}
