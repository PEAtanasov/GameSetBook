using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static GameSetBook.Common.ValidationConstatns.ReviewConstants;
using static GameSetBook.Common.ErrorMessageConstants;

namespace GameSetBook.Core.Models.Admin.Review
{
    public class ReviewReviseAdminFormModel
    {
        /// <summary>
        /// Review identifier
        /// </summary>
        [Required(ErrorMessage = RequiredMessage)]
        public int Id { get; set; }

        /// <summary>
        /// Review title
        /// </summary>
        [Required]
        [StringLength(ReviewtTitleMaxLength, MinimumLength =ReviewtTitleMinLength, ErrorMessage = StringLengthMessage)]
        [Display(Name ="Title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Review description
        /// </summary>
        [Required]
        [StringLength(ReviewDescriptionMaxLength, MinimumLength = ReviewDescriptionMinLength, ErrorMessage = StringLengthMessage)]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Review rating
        /// </summary>
        [Required]
        [Range(ReviewMinRate, ReviewtMaxRate, ErrorMessage = RangeMessage)]
        public int Rating {  get; set; }

        /// <summary>
        /// Current review's club identifier
        /// </summary>
        public int? ClubId { get; set; }

        /// <summary>
        /// Current review's club name
        /// </summary>
        public string ClubName { get; set; } =string.Empty;

        /// <summary>
        /// Reviewer email
        /// </summary>
        public string ReviewerEmail { get; set; } = string.Empty;

        /// <summary>
        /// Date review has been created
        /// </summary>
        public string DateAddedOn { get; set; } = string.Empty;
    }
}
