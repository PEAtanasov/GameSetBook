﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using GameSetBook.Infrastructure.Models.Contracts;

using static GameSetBook.Common.ValidationConstatns.BookingConstants;

namespace GameSetBook.Infrastructure.Models
{
    /// <summary>
    /// Booking entity
    /// </summary>
    [Comment("Booking entity")]
    public class Booking : IDeletable
    {
        public Booking()
        {
            Id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Booking identifier
        /// </summary>
        [Key]
        [Comment("Booking identifier")]
        public string Id { get; set; }

        /// <summary>
        /// Booking price
        /// </summary>
        [Required]
        [Comment("Booking price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// is the the booking available
        /// </summary>
        [Required]
        [Comment("is the the booking available")]
        public bool IsAvailable { get; set; } = true;

        /// <summary>
        /// is the booking deleted/canceled
        /// </summary>
        [Comment("is the booking canceled")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Deleted on date and time
        /// </summary>
        [Comment("Deleted on date and time")]
        public DateTime? DeletedOn { get; set; }

        /// <summary>
        /// Date and time booking is created
        /// </summary>
        [Required]
        [Comment("Date and time booking is created")]
        public DateTime BookedOn { get; set; }

        /// <summary>
        /// Hour of the booking
        /// </summary>
        [Required]
        [Comment("Hour of the booking")]
        public int Hour { get; set; }

        /// <summary>
        /// Date of the booking
        /// </summary>
        [Required]
        [Comment("Date of the booking")]
        public DateTime BookingDate { get; set; }

        /// <summary>
        /// Client's name
        /// </summary>
        [Required]
        [Comment("Client's name")]
        [MaxLength(ClientNameMaxLength)]
        public string ClientName { get; set; } = string.Empty;

        /// <summary>
        /// Client's phone number
        /// </summary>
        [Required]
        [MaxLength(ClientNameMaxLength)]
        [Phone]
        [Comment("Client's phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Client identifier
        /// </summary>
        [Required]
        [Comment("Client identifier")]
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; } = string.Empty;

        public virtual IdentityUser Client { get; set; } = null!;

        /// <summary>
        /// Court identifier
        /// </summary>
        [Required]
        [Comment("Court identifier")]
        [ForeignKey(nameof(Court))]
        public int CourtId { get; set; }

        public virtual Court Court { get; set; } = null!;
    }
}