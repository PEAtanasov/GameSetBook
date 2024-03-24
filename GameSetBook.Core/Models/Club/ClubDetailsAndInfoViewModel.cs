using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSetBook.Core.Models.Club
{
    public class ClubDetailsAndInfoViewModel
    {
        public int ClubId { get; set; }

        public ClubInfoViewModel Info { get; set; } = null!;

        public ClubDetailsViewModel Details { get; set; } = null!;

    }
}
