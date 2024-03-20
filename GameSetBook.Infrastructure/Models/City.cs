using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static GameSetBook.Common.ValidationConstatns.CityConstants;

namespace GameSetBook.Infrastructure.Models
{
    /// <summary>
    /// City entity
    /// </summary>
    [Comment("City entity")]
    public class City
    {
        public City()
        {
            Clubs = new List<Club>();
            //Profiles = new List<GameSetMatchUpPlayerProfile>();
        }

        /// <summary>
        /// City identifier
        /// </summary>
        [Key]
        [Comment("City identifier")]
        public int Id { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("City name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Country identifier
        /// </summary>
        [Required]
        [Comment("Country identifier")]
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;

        public virtual ICollection<Club> Clubs { get; set;}
        //public virtual ICollection<GameSetMatchUpPlayerProfile> Profiles { get; set; }
    }
}