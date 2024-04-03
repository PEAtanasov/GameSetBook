//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;

//namespace GameSetBook.Infrastructure.Models
//{
//    /// <summary>
//    /// Article entity class
//    /// </summary>
//    [Comment("Article entity class")]
//    public class Article
//    {
//        /// <summary>
//        /// Article identifier
//        /// </summary>
//        [Key]
//        [Comment("Article identifier")]
//        public int Id { get; set; }

//        /// <summary>
//        /// Artcile title
//        /// </summary>
//        [Required]
//        [Comment("Article title")]
//        public string Title { get; set; } = string.Empty;

//        /// <summary>
//        /// Article description
//        /// </summary>
//        [Required]
//        [Comment("Article description")]
//        public string Description { get; set; } = string.Empty;

//        /// <summary>
//        /// Article image url path
//        /// </summary>
//        [Required]
//        [Comment("Article image url path")]
//        public string ImageUrl { get; set; } = string.Empty;

//        /// <summary>
//        /// Date and time article is published
//        /// </summary>
//        [Required]
//        [Comment("Date and time article is published")]
//        public DateTime PublishedOn { get; set; }
//    }
//}
