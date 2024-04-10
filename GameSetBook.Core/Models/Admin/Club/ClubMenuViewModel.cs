namespace GameSetBook.Core.Models.Admin.Club
{
    public class ClubMenuViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public bool IsApproved { get; set; }

        public bool IsDeleted {  get; set; }
    }
}
