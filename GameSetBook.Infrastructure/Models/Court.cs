﻿using GameSetBook.Infrastructure.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameSetBook.Common.ValidationConstatns.CourtConstants;

namespace GameSetBook.Infrastructure.Models
{
    /// <summary>
    /// Court entity
    /// </summary>
    [Comment("Court entity")]
    public class Court
    {
        public Court()
        {
            Bookings= new List<Booking>();
        }
        /// <summary>
        /// Court identifier
        /// </summary>
        [Key]
        [Comment("Court identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Court name
        /// </summary>
        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Court name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Court surface
        /// </summary>
        [Required]
        [Comment("Court name")]
        public Surface Surface { get; set; }

        /// <summary>
        /// Is the court lighted
        /// </summary>
        [Required]
        [Comment("Is the court lighted")]
        public bool IsLighted {  get; set; }

        /// <summary>
        /// Is the court active
        /// </summary>
        [Required]
        [Comment("Is the court enable")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Club identifier
        /// </summary>
        [Required]
        [Comment("Club identifier")]
        [ForeignKey(nameof(Club))]
        public string ClubId { get; set; } = string.Empty;

        public Club Club { get; set; } = null!;

        public ICollection<Booking> Bookings { get; set; }
    }
}