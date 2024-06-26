﻿using GameSetBook.Infrastructure.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static GameSetBook.Common.ValidationConstatns.ReviewConstants;

namespace GameSetBook.Infrastructure.Models
{
    /// <summary>
    /// Club's review entity
    /// </summary>
    [Comment("Club's review entity")]
    public class Review
    {
        /// <summary>
        /// Review identifier
        /// </summary>
        [Key]
        [Comment("Review identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Review title
        /// </summary>
        [Required]
        [Comment("Review title")]
        [MaxLength(ReviewtTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Review description
        /// </summary>
        [Required]
        [Comment("Review description")]
        [MaxLength(ReviewDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Review rating
        /// </summary>
        [Required]
        [Range(ReviewMinRate, ReviewtMaxRate)]
        [Comment("Review rating")]
        public int Rate { get; set; }

        /// <summary>
        /// Date the reviews was added
        /// </summary>
        [Required]
        [Comment("Date the reviews was added")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Current review's club identifier
        /// </summary>
        [Required]
        [ForeignKey(nameof(Club))]
        [Comment("Current review's club identifier")]
        public int ClubId { get; set; }

        /// <summary>
        /// Review's club
        /// </summary>
        public virtual Club Club { get; set; } = null!;

        /// <summary>
        /// Current review's reviewer identifier
        /// </summary>
        [Required]
        [ForeignKey(nameof(Reviewer))]
        [Comment("Current review's reviewer identifier")]
        public string ReviewerId { get; set; } = string.Empty;

        /// <summary>
        /// User who create the review
        /// </summary>
        public virtual ApplicationUser Reviewer { get; set; } = null!;

        /// <summary>
        /// Current review's booking identifier
        /// </summary>
        [Required]
        [ForeignKey(nameof(Booking))]
        [Comment("Current review's booking identifier")]
        public int BookingId { get; set; }

        /// <summary>
        /// Review's booking
        /// </summary>
        public Booking Booking { get; set; } = null!;
    }
}
