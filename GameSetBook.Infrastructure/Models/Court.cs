using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static GameSetBook.Common.ValidationConstatns.CourtConstants;
using GameSetBook.Common.Enums;

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
        [Comment("Court surface")]
        public Surface Surface { get; set; }

        /// <summary>
        /// Is the court lighted
        /// </summary>
        [Required]
        [Comment("Is the court lighted")]
        public bool IsLighted {  get; set; }

        /// <summary>
        /// Price for renting court per one hour
        /// </summary>
        [Required]
        [Comment("Price for renting court per one hour")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerHour { get; set; }

        /// <summary>
        /// Is the court indoor
        /// </summary>
        [Required]
        [Comment("Is the court indoor")]
        public bool IsIndoor { get; set; }

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
        public int ClubId { get; set; }

        public virtual Club Club { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}