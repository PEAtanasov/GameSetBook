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

        /// <summary>
        /// Country where the city is located
        /// </summary>
        public virtual Country Country { get; set; } = null!;

        /// <summary>
        /// All clubs in the current city
        /// </summary>
        public virtual ICollection<Club> Clubs { get; set;}

    }
}