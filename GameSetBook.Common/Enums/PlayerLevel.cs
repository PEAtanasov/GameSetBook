using System.ComponentModel.DataAnnotations;

namespace GameSetBook.Common.Enums
{
    public enum PlayerLevel
    {
        [Display(Name = "Newbie")]
        Newbie = 0,

        [Display(Name = "Beginer")]
        Beginer = 1,

        [Display(Name = "Intermediate")]
        Intermediate = 2,

        [Display(Name = "Advanced")]
        Advanced = 3,

        [Display(Name = "Proffesional")]
        Pro = 4,

        [Display(Name = "Like a boss")]
        LikeABoss = 5
    }
}
