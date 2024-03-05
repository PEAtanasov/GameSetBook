using Microsoft.AspNetCore.Identity;
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
    public class ClubReview
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
        [MaxLength(ReviewtDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Review rating
        /// </summary>
        [Required]
        [Range(ReviewMinRate, ReviewtMaxRate)]
        [Comment("Review rating")]
        public int Rate { get; set; }

        /// <summary>
        /// Current review's club identifier
        /// </summary>
        [Required]
        [ForeignKey(nameof(Club))]
        [Comment("Current review's club identifier")]
        public string ClubId { get; set; } = string.Empty;

        public virtual Club Club { get; set; } = null!;

        /// <summary>
        /// Current review's reviewer identifier
        /// </summary>
        [Required]
        [ForeignKey(nameof(Reviewer))]
        [Comment("Current review's reviewer identifier")]
        public string ReviewerId { get; set; } = string.Empty;

        public virtual IdentityUser Reviewer { get; set; } = null!;
    }
}
