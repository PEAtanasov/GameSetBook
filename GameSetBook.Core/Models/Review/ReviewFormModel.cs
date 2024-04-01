using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static GameSetBook.Common.ErrorMessageConstants;
using static GameSetBook.Common.ValidationConstatns.ReviewConstants;

namespace GameSetBook.Core.Models.Review
{
    public class ReviewFormModel
    {
        /// <summary>
        /// Review title
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Comment("Review title")]
        [StringLength(ReviewtTitleMaxLength,MinimumLength = ReviewtTitleMinLength,ErrorMessage = StringLengthMessage)]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Review description
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Comment("Review description")]
        [StringLength(ReviewDescriptionMaxLength,MinimumLength = ReviewDescriptionMinLength, ErrorMessage = StringLengthMessage)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Review rating
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        [Range(ReviewMinRate, ReviewtMaxRate)]
        [Comment("Review rating")]
        public int Rate { get; set; }

        /// <summary>
        /// Current review's club identifier
        /// </summary>
        [Comment("Current review's club identifier")]
        public int ClubId { get; set; }

        /// <summary>
        /// Current review's reviewer identifier
        /// </summary>
        [Comment("Current review's reviewer identifier")]
        public string ReviewerId { get; set; } = string.Empty;

        /// <summary>
        /// Current review's booking identifier
        /// </summary>
        [Comment("Current review's booking identifier")]
        public int BookingId { get; set; }
    }
}
