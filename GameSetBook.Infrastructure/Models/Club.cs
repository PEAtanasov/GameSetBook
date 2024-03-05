using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static GameSetBook.Common.ValidationConstatns.ClubConstants;

namespace GameSetBook.Infrastructure.Models
{
    /// <summary>
    /// Club entity
    /// </summary>
    [Comment("Club entity")]
    public class Club
    {
        public Club()
        {
            Id= Guid.NewGuid().ToString();
            Courts = new List<Court>();
            ClubReviews = new List<ClubReview>();
        }
        /// <summary>
        /// Club identifier
        /// </summary>
        [Key]
        [Comment("Club identifier")]
        public string Id { get; set; }

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
        public string Description { get; set; } = Common.ImageSource.DefaultClubLogoUrl;

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

        public virtual City City { get; set; } = null!;

        /// <summary>
        /// Club's country identifier
        /// </summary>
        [Required]
        [Comment("Club's country identifier")]
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;

        /// <summary>
        /// Number of coaches in the club
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
        public string LogoUrl { get; set; } = string.Empty;

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
        /// Is the club active
        /// </summary>
        [Required]
        [Comment("Is the club active")]
        public bool IsActive { get; set; }

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
                double averageRate = ClubReviews.Average(x => x.Rate);
                return Math.Round(averageRate, 1);
            }
        }

        /// <summary>
        /// Club owner's identifier
        /// </summary>
        [Required]
        [ForeignKey(nameof(ClubOwner))]
        public string ClubOwnerId { get; set; } = string.Empty;

        public virtual IdentityUser ClubOwner { get; set; } = null!;

        public virtual ICollection<Court> Courts { get; set; }

        public virtual ICollection<ClubReview> ClubReviews { get; set; }
    }
}
