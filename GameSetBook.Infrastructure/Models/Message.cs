using GameSetBook.Infrastructure.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static GameSetBook.Common.ValidationConstatns.MessageConstants;

namespace GameSetBook.Infrastructure.Models
{
    /// <summary>
    /// Message entity class
    /// </summary>
    [Comment("Message entity class")]
    public class Message : IDeletable
    {
        /// <summary>
        /// Message identifier
        /// </summary>
        [Key]
        [Comment("Message identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Message title
        /// </summary>
        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Message title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Message content
        /// </summary>
        [Required]
        [MaxLength(ContentMaxLength)]
        [Comment("Message content")]
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Sender player profile identifier
        /// </summary>
        [Required]
        [Comment("Sender player profile identifier")]
        public string SenderProfileId { get; set; } = string.Empty;

        public GameSetMatchUpPlayerProfile SenderProfile { get; set; } = null!;

        /// <summary>
        /// Sender player profile identifier
        /// </summary>
        [Required]
        [Comment("Receiver player profile identifier")]
        public string ReceiverProfileId { get; set; } = string.Empty;
        public GameSetMatchUpPlayerProfile ReceiverProfile { get; set; } = null!;

        /// <summary>
        /// Date and time the message was sent
        /// </summary>
        [Required]
        [Comment("Date and time the message was sent")]
        public DateTime SentOn { get; set; }

        /// <summary>
        /// Is the record deleted
        /// </summary>
        [Required]
        [Comment("IsDeleted the record deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Deleted on date
        /// </summary>
        [Comment("Deleted on date")]
        public DateTime? DeletedOn { get; set; }

    }
}
