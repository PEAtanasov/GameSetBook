namespace GameSetBook.Core.Models.Review
{
    public class ReviewViewModel
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public int Rating { get; set; }

        public string CreatedOn { get; set; } = string.Empty;
    }
}
