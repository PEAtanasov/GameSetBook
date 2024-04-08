namespace GameSetBook.Core.Models.Review
{
    public class ReviewsWithClubIdServiceModel
    {
        public IEnumerable<ReviewViewModel> Reviews { get; set; } = new List<ReviewViewModel>();
    }
}
