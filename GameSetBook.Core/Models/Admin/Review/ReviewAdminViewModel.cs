using Microsoft.EntityFrameworkCore;

namespace GameSetBook.Core.Models.Admin.Review
{
    public class ReviewAdminViewModel
    {
        /// <summary>
        /// Review identifier
        /// </summary>
        [Comment("Review identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Review title
        /// </summary>
        [Comment("Review title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Review description
        /// </summary>
        [Comment("Review description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Review rating
        /// </summary>
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
        [Comment("Reviewer name")]
        public string ReviewerName { get; set; } = string.Empty;

        /// <summary>
        /// Current review's reviewer identifier
        /// </summary>
        [Comment("Reviewer email")]
        public string ReviewerEmail { get; set; } = string.Empty;
    }
}
