//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;

//using GameSetBook.Infrastructure.Models.Contracts;
//using GameSetBook.Common.Enums;

//namespace GameSetBook.Infrastructure.Models
//{
//    /// <summary>
//    /// Tournament entity
//    /// </summary>
//    [Comment("Tournament entity class")]
//    public class Tournament : IDeletable
//    {
//        public Tournament()
//        {
//            this.TournamentGSMUPlayerProfiles = new List<TournamentGSMUPlayerProfile>();
//        }
//        /// <summary>
//        /// Tournament identifier
//        /// </summary>
//        [Key]
//        [Comment("Tournament identifier")]
//        public int Id { get; set; }

//        /// <summary>
//        /// Tournament name
//        /// </summary>
//        [Required]
//        [Comment("Tournament name")]
//        public string Name { get; set; } = string.Empty;

//        /// <summary>
//        /// Tournament description
//        /// </summary>
//        [Required]
//        [Comment("Tournament description")]
//        public string Description { get; set; } = string.Empty;

//        /// <summary>
//        /// Tournament players level range start from (including)
//        /// </summary>
//        [Required]
//        [Comment("Tournament players level range start from (including)")]
//        public PlayerLevel PlayerLevelRangeFrom { get; set; }

//        /// <summary>
//        /// Tournament players level range end to (including)
//        /// </summary>
//        [Required]
//        [Comment("Tournament players level range end to (including)")]
//        public PlayerLevel PlayerLevelRangeTo { get; set; }

//        /// <summary>
//        /// Tournament start date and time
//        /// </summary>
//        [Required]
//        [Comment("Tournament start date and time")]
//        public DateTime Start { get; set; }

//        /// <summary>
//        /// Tournament end date and time
//        /// </summary>
//        [Required]
//        [Comment("Tournament end date and time")]
//        public DateTime End { get; set; }

//        /// <summary>
//        /// Number of allowed players to join the tournament
//        /// </summary>
//        [Required]
//        [Comment("Number of allowed players to join the tournament")]
//        public int NumberOfPlayersAllowed { get; set; }

//        /// <summary>
//        /// Is the record deleted
//        /// </summary>
//        [Required]
//        [Comment("IsDeleted the record deleted")]
//        public bool IsDeleted { get; set; }

//        /// <summary>
//        /// Deleted on date
//        /// </summary>
//        [Comment("Deleted on date")]
//        public DateTime? DeletedOn { get; set; }

//        /// <summary>
//        /// Current tournament's club identifier
//        /// </summary>
//        [Required]
//        [Comment("Current tournament's club identifier")]
//        public int ClubId { get; set; }

//        public virtual Club Club { get; set; } = null!;

//        public virtual ICollection<TournamentGSMUPlayerProfile> TournamentGSMUPlayerProfiles { get; set; }
//    }
//}
