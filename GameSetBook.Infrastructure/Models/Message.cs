//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;

//using GameSetBook.Infrastructure.Models.Contracts;
//using static GameSetBook.Common.ValidationConstatns.MessageConstants;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace GameSetBook.Infrastructure.Models
//{
//    /// <summary>
//    /// Message entity class
//    /// </summary>
//    [Comment("Message entity class")]
//    public class Message
//    {
//        /// <summary>
//        /// Message identifier
//        /// </summary>
//        [Key]
//        [Comment("Message identifier")]
//        public int Id { get; set; }

//        /// <summary>
//        /// Message title
//        /// </summary>
//        [Required]
//        [MaxLength(TitleMaxLength)]
//        [Comment("Message title")]
//        public string Title { get; set; } = string.Empty;

//        /// <summary>
//        /// Message content
//        /// </summary>
//        [Required]
//        [MaxLength(ContentMaxLength)]
//        [Comment("Message content")]
//        public string Content { get; set; } = string.Empty;

//        /// <summary>
//        /// Sender player profile identifier
//        /// </summary>
//        [Required]
//        [ForeignKey(nameof(SenderProfile))]
//        [Comment("Sender player profile identifier")]
//        public int SenderProfileId { get; set; }

//        public GameSetMatchUpPlayerProfile SenderProfile { get; set; } = null!;

//        /// <summary>
//        /// Sender player profile identifier
//        /// </summary>
//        [Required]
//        [Comment("Receiver player profile identifier")]
//        public int ReceiverProfileId { get; set; }

//        public GameSetMatchUpPlayerProfile ReceiverProfile { get; set; } = null!;

//        /// <summary>
//        /// Date and time the message was sent
//        /// </summary>
//        [Required]
//        [Comment("Date and time the message was sent")]
//        public DateTime SentOn { get; set; }

//        /// <summary>
//        /// Is the the message read
//        /// </summary>
//        [Required]
//        [Comment("Is the the message read")]
//        public bool Read { get; set; }
//    }
//}
