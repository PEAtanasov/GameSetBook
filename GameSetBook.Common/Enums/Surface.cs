using System.ComponentModel.DataAnnotations;

namespace GameSetBook.Common.Enums
{
    public enum Surface
    {
        [Display(Name = "Grass")]
        Grass = 0,

        [Display(Name = "Artificial Grass")]
        ArtificialGrass = 1,

        [Display(Name = "Hard")]
        Hard = 2,

        [Display(Name = "Clay")]
        Clay = 3,

        [Display(Name = "Carpet")]
        Carpet = 4
    }
}
