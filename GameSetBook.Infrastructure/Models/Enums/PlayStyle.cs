using System.ComponentModel.DataAnnotations;

namespace GameSetBook.Infrastructure.Models.Enums
{
    public enum PlayStyle
    {
        [Display(Name = "No style")]
        None = 0,

        [Display(Name = "Baseline Player")]
        Baseliner = 1,

        [Display(Name = "All-Court Player")]
        AllCourtPlayer = 2,

        [Display(Name = "Serve-and-Volley Player")]
        ServeAndVolleyPlayer = 3,

        [Display(Name = "Counterpuncher")]
        Counterpuncher = 4,

        [Display(Name = "Power Player")]
        PowerPlayer = 5,

        [Display(Name = "Tactical Player")]
        TacticalPlayer = 6
    }
}

