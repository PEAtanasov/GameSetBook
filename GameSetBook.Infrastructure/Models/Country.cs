using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static GameSetBook.Common.ValidationConstatns.CountryConstants;

namespace GameSetBook.Infrastructure.Models
{
    /// <summary>
    /// Country entity
    /// </summary>
    [Comment("Country entity")]
    public class Country
    {
        public Country()
        {
            Cities = new List<City>();
        }

        /// <summary>
        /// Country identifier
        /// </summary>
        [Key]
        [Comment("Country identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Country name")]
        public string Name { get; set; } = string.Empty;

        public ICollection<City> Cities { get; set;}
    }
}