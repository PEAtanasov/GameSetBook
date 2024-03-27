using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSetBook.Core.Models.Court
{
    public class CourtDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Surface { get; set; } = string.Empty;
        public bool IsLighted { get; set; }
        public bool IsIndoor { get; set;}
        public bool IsActive { get; set;}
    }
}
