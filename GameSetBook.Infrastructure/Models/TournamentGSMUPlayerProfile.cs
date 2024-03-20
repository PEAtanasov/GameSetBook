//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace GameSetBook.Infrastructure.Models
//{
//    /// <summary>
//    /// Mapping class that maps GSMUPlayerProfile to tournament
//    /// </summary>
//    public class TournamentGSMUPlayerProfile
//    {
//        /// <summary>
//        /// Current player profile identifier
//        /// </summary>
//        [Required]
//        [Comment("Current player profile identifier")]
//        [ForeignKey(nameof(PlayerProile))]
//        public int PlayerProfileId { get; set; }

//        public virtual GameSetMatchUpPlayerProfile PlayerProile { get; set; } = null!;

//        /// <summary>
//        /// Current tournament identifier
//        /// </summary>
//        [Required]
//        [Comment("Current tournament identifier")]
//        [ForeignKey(nameof(Tournament))]
//        public int TournamentId { get; set; }

//        public virtual Tournament Tournament { get; set; } = null!;
//    }
//}