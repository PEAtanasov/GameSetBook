using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using GameSetBook.Infrastructure.Models.Contracts;
using GameSetBook.Infrastructure.Models.Identity;
using static GameSetBook.Common.ImageSource;
using static GameSetBook.Common.ValidationConstatns.ClubConstants;

namespace GameSetBook.Infrastructure.Models
{
    /// <summary>
    /// Club entity
    /// </summary>
    [Comment("Club entity")]
    [Index(nameof(Name), IsUnique = true)]
    public class Club : IDeletable
    {
        public Club()
        {

            Courts = new List<Court>();
            Reviews = new List<Review>();
        }
        /// <summary>
        /// Club identifier
        /// </summary>
        [Key]
        [Comment("Club identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Club name
        /// </summary>
        [Required]
        [Comment("Club name")]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Club description
        /// </summary>
        [Required]
        [Comment("Club description")]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Club working time start
        /// </summary>
        [Required]
        [Comment("Club working time start")]
        public int WorkingTimeStart { get; set; }

        /// <summary>
        /// Club working time start
        /// </summary>
        [Required]
        [Comment("Club working time end")]
        public int WorkingTimeEnd { get; set; }

        /// <summary>
        /// Address of the club
        /// </summary>
        [Required]
        [Comment("Address of the club")]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Club's city identifier
        /// </summary>
        [Required]
        [Comment("Club's city identifier")]
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }

        /// <summary>
        /// City where the club is located
        /// </summary>
        public virtual City City { get; set; } = null!;

        /// <summary>
        /// Club's city
        /// </summary> 
        [Comment("Number of coaches in the club")]
        public int? NumberOfCoaches { get; set; }

        /// <summary>
        /// Numbber of courts in the club
        /// </summary>
        [Required]
        [Comment("Numbber of courts in the club")]
        public int NumberOfCourts { get; set; }

        /// <summary>
        /// Is car parking for clients available
        /// </summary>
        [Required]
        [Comment("Is car parking for clients available")]
        public bool HasParking { get; set; }

        /// <summary>
        /// Is shower for clients available
        /// </summary>
        [Required]
        [Comment("Is shower for clients available")]
        public bool HasShower { get; set; }

        /// <summary>
        /// Is tennis shop available
        /// </summary>
        [Required]
        [Comment("Is tennis shop available")]
        public bool HasShop { get; set; }

        /// <summary>
        /// Club's logo Url
        /// </summary>
        [Required]
        [Comment("Club's logo Url")]
        [MaxLength(ClubLogoUrlMaxLength)]
        public string LogoUrl { get; set; } = DefaultClubLogoUrl;

        /// <summary>
        /// Club's email
        /// </summary>
        [Required]
        [Comment("Club's email")]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Club's phone number
        /// </summary>
        [Required]
        [Comment("Club's phone number")]
        [MaxLength(PhoneMaxLength)]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Is the record deleted
        /// </summary>
        [Required]
        [Comment("IsDeleted the record deleted")]
        public bool IsDeleted { get ; set ; }

        /// <summary>
        /// Deleted on date
        /// </summary>
        [Comment("Deleted on date")]
        public DateTime? DeletedOn { get ; set ; }

        /// <summary>
        /// Date and time the club has been created
        /// </summary>
        [Required]
        [Comment("Date and time the club has been created")]
        public DateTime RegisteredOn { get; set; }

        /// <summary>
        /// Is the club aprooved from app admin
        /// </summary>
        [Required]
        [Comment("Is the club aprooved from app admin")]
        public bool IsAproovedByAdmin { get; set; }

        /// <summary>
        /// Club rating given from its clients
        /// </summary>
        [NotMapped]
        public double Rating
        {
            get
            {
                if (Reviews == null || !Reviews.Any())
                {
                    return 0;
                }

                return Math.Round(Reviews.Average(x => x.Rate), 1);
            }
        }

        /// <summary>
        /// Club owner's identifier
        /// </summary>
        [Required]
        [ForeignKey(nameof(ClubOwner))]
        [Comment("Club owner's identifier")]
        public string ClubOwnerId { get; set; } = string.Empty;

        /// <summary>
        /// Club owner
        /// </summary>
        public virtual ApplicationUser ClubOwner { get; set; } = null!;

        /// <summary>
        /// All courts of the club
        /// </summary>
        public virtual ICollection<Court> Courts { get; set; }

        /// <summary>
        /// All client reviews for the club
        /// </summary>
        public virtual ICollection<Review> Reviews { get; set; }
       
    }
}
